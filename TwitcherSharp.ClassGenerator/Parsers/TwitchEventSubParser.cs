using ClassGenerator.Extensions;
using ClassGenerator.Generator.EventSub;
using ClassGenerator.GenObjects.EventSub;
using ClassGenerator.Markdown;
using ClassGenerator.Parsers.EventSub;
using static ClassGenerator.Parsers.EventSub.EventSubConventions;

namespace ClassGenerator.Parsers;

/// <summary>
/// Builds the event, condition and shared components plus the subscription definitions from the parsed
/// Markdown subscription types. Types that share a Twitcher script (e.g. the three goal events) share one
/// namespace; every extra version of a type gets a <c>V{n}</c> event, and a condition only when its fields differ.
/// </summary>
public class TwitchEventSubParser
{
    public List<TwitchEventSubGenComponent> Components { get; } = [];
    public List<TwitchEventSubGenComponent> SubComponents { get; } = [];
    public List<TwitchEventSubGenComponent> ConditionComponents { get; } = [];
    public List<TwitchEventSubDefinitionInfo> Definitions { get; } = [];

    public void Parse(IReadOnlyList<EventSubSubscriptionType> types)
    {
        foreach (var group in types.GroupBy(t => NameSpaceOf(t.Type)))
        {
            AddNameSpace(group.Key, group.ToList());
        }

        foreach (var sharedObject in SharedObjects) ExtractSharedObject(sharedObject);

        AddDefinitions(types);

        Console.WriteLine($"{Components.Count} eventsub components parsed");
    }

    private static string NameSpaceOf(string type) =>
        NameSpaceOverrides.GetValueOrDefault(type) ?? EventSubScriptNameResolver.ScriptName(type).ToPascalCase();

    private void AddNameSpace(string nameSpace, List<EventSubSubscriptionType> types)
    {
        var conditions = new List<TwitchEventSubGenComponent>();
        var versions = types.OrderBy(t => t.VersionOrder).Select(t => t.Version).Distinct().ToList();

        for (var i = 0; i < versions.Count; i++)
        {
            var suffix = i == 0 ? string.Empty : "V" + versions[i];
            var versionTypes = types.Where(t => t.Version == versions[i]).ToList();

            Components.Add(BuildComponent($"Twitch{nameSpace}Event{suffix}", nameSpace, versionTypes[0].Description,
                MergeFields(versionTypes.Select(t => t.Event)), suffix, false));

            var conditionFields = versionTypes[0].Condition;
            if (conditionFields.Count == 0 || conditions.Any(c => HasSameFields(c, conditionFields))) continue;

            var condition = BuildComponent($"Twitch{nameSpace}{suffix}Condition", nameSpace, versionTypes[0].Description,
                conditionFields, suffix, true);
            conditions.Add(condition);
            ConditionComponents.Add(condition);
        }
    }

    private static List<DocField> MergeFields(IEnumerable<List<DocField>> fieldLists) =>
        fieldLists.SelectMany(f => f).DistinctBy(f => f.Name).ToList();

    private static bool HasSameFields(TwitchEventSubGenComponent component, List<DocField> fields) =>
        component.Fields.Values.Select(f => f.RawName).SequenceEqual(fields.Select(f => f.Name));

    private static TwitchEventSubGenComponent BuildComponent(string className, string nameSpace, string description,
        IEnumerable<DocField> fields, string suffix, bool isCondition)
    {
        var component = new TwitchEventSubGenComponent(className) { NameSpace = nameSpace, Description = description };
        foreach (var field in fields) component.AddField(BuildField(component, field, suffix, isCondition));
        return component;
    }

    private static TwitchEventSubGenField BuildField(TwitchEventSubGenComponent parent, DocField field, string suffix,
        bool isCondition)
    {
        var required = isCondition && field.IsRequired;
        var sibling = SharedChatSibling(parent, field.Name);

        if (field.Children.Count == 0 && sibling == null)
        {
            var type = field.Type == "Object[]" ? "Dictionary" : field.Type;
            return new TwitchEventSubGenField(field.Name, field.Description, type, required) { IsArray = field.IsArray };
        }

        var subComponent = sibling?.TypedComponent ?? BuildComponent(
            $"Twitch{field.Name.ToPascalCase()}{suffix}", parent.NameSpace, field.Description, field.Children, suffix, false);

        return new TwitchEventSubGenField(field.Name, field.Description, subComponent.ClassName, required)
        {
            IsArray = field.IsArray,
            TypedComponent = subComponent,
        };
    }

    private static TwitchEventSubGenField SharedChatSibling(TwitchEventSubGenComponent parent, string fieldName) =>
        fieldName.StartsWith(SharedChatPrefix)
            ? parent.Fields.Values.FirstOrDefault(f => f.IsTyped && f.RawName == fieldName[SharedChatPrefix.Length..])
            : null;

    private void ExtractSharedObject(string fieldName)
    {
        var className = "Twitch" + fieldName.ToPascalCase();
        var occurrences = Components.Concat(SubComponents)
            .SelectMany(Walk)
            .SelectMany(parent => parent.Fields.Values
                .Where(f => f.RawName == fieldName && f.TypedComponent?.ClassName == className && !f.TypedComponent.IsShared)
                .Select(f => (Parent: parent, Component: f.TypedComponent)))
            .ToList();

        if (occurrences.Count == 0) return;

        var signature = occurrences
            .GroupBy(o => Signature(o.Component))
            .OrderByDescending(g => g.Count())
            .First().Key;

        var shared = occurrences.First(o => Signature(o.Component) == signature).Component;
        shared.IsShared = true;
        shared.NameSpace = SharedNameSpace;
        shared.Parent = null;
        SubComponents.Add(shared);

        foreach (var (parent, component) in occurrences.Where(o => Signature(o.Component) == signature))
        {
            parent.ReplaceSubComponent(component, shared);
        }
    }

    private static IEnumerable<TwitchEventSubGenComponent> Walk(TwitchEventSubGenComponent component) =>
        component.SubComponents.Values.Where(c => !c.IsShared).SelectMany(Walk).Prepend(component);

    private static string Signature(TwitchEventSubGenComponent component) =>
        string.Join(";", component.Fields.Values.Select(f =>
            $"{f.RawName}:{f.Type}{(f.IsArray ? "[]" : "")}{(f.TypedComponent != null ? "{" + Signature(f.TypedComponent) + "}" : "")}"));

    private void AddDefinitions(IReadOnlyList<EventSubSubscriptionType> types)
    {
        foreach (var type in types.OrderBy(t => t.Type, StringComparer.Ordinal).ThenBy(t => t.VersionOrder))
        {
            var isLowestVersion = types.Where(t => t.Type == type.Type).Min(t => t.VersionOrder) == type.VersionOrder;

            Definitions.Add(new TwitchEventSubDefinitionInfo
            {
                EnumName = ToEnumName(type.Type) + (isLowestVersion ? string.Empty : "V" + type.Version),
                Value = type.Type,
                Version = type.Version,
                Conditions = type.Condition.Select(f => f.Name).ToList(),
                Scopes = type.Scopes,
                DocumentationLink = type.DocumentationUrl,
                ScriptName = EventSubScriptNameResolver.ScriptName(type.Type),
            });
        }

        Console.WriteLine($"{Definitions.Count} subscription type definitions parsed");
    }

    private static string ToEnumName(string type) =>
        string.Concat(type.Split(['.', '_'], StringSplitOptions.RemoveEmptyEntries)
            .Select(w => char.ToUpperInvariant(w[0]) + w[1..]));
}
