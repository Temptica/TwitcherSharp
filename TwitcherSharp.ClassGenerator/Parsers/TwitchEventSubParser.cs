using System.Text.RegularExpressions;
using ClassGenerator.Extensions;
using ClassGenerator.Generator.EventSub;
using ClassGenerator.GenObjects.EventSub;
using ClassGenerator.Markdown;
using ClassGenerator.Parsers.EventSub;
using static ClassGenerator.Parsers.EventSub.EventSubConventions;

namespace ClassGenerator.Parsers;

/// <summary>
/// Turns the subscription types of the Markdown EventSub reference into the components the EventSub generator writes:
/// one event (and condition) per twitcher script and version, plus the objects twitcher keeps in scripts of their own.
/// </summary>
public partial class TwitchEventSubParser
{
    public List<TwitchEventSubGenComponent> Components { get; } = [];
    public List<TwitchEventSubGenComponent> SubComponents { get; } = [];
    public List<TwitchEventSubGenComponent> ConditionComponents { get; } = [];
    public List<TwitchEventSubDefinitionInfo> Definitions { get; } = [];

    public void Parse(IReadOnlyList<EventSubSubscriptionType> types)
    {
        foreach (var (name, (type, path)) in SharedObjectSources) AddSharedObject(name, Find(types, type, path));

        foreach (var group in types.GroupBy(ScriptName))
        {
            var versions = group.Select(t => t.Version).Distinct().OrderBy(VersionOrder).ToList();
            var conditions = new List<TwitchEventSubGenComponent>();
            for (var i = 0; i < versions.Count; i++)
            {
                var versionTypes = group.Where(t => t.Version == versions[i]).ToList();
                AddEvent(group.Key, versionTypes, i > 0);
                AddCondition(group.Key, versionTypes, i > 0, conditions);
            }
        }

        EventSubCorrections.Apply([..Components, ..SubComponents]);
        AddDefinitions(types);

        Console.WriteLine($"{Components.Count} eventsub components parsed");
    }

    private static string ScriptName(EventSubSubscriptionType type) => EventSubScriptNameResolver.ScriptName(type.Type);

    private static int VersionOrder(string version) => int.TryParse(version, out var order) ? order : 0;

    private static List<DocField> Find(IReadOnlyList<EventSubSubscriptionType> types, string type, string path)
    {
        var fields = types.First(t => t.Type == type).Event;
        foreach (var name in path.Split('.'))
        {
            var field = fields.FirstOrDefault(f => f.Name == name)
                        ?? throw new InvalidOperationException($"No {path} in the {type} event");
            fields = field.Children;
        }

        return fields;
    }

    private void AddSharedObject(string name, List<DocField> fields)
    {
        var component = new TwitchEventSubGenComponent(name) { IsShared = true };
        AddFields(component, fields, false);
        SubComponents.Add(component);
    }

    private void AddEvent(string scriptName, List<EventSubSubscriptionType> versionTypes, bool isLaterVersion)
    {
        var fields = versionTypes.SelectMany(t => t.Event).DistinctBy(f => f.Name).ToList();
        if (SharedEvents.Contains(scriptName))
        {
            var shared = new TwitchEventSubGenComponent(scriptName) { IsShared = true };
            AddFields(shared, fields, false);
            SubComponents.Add(shared);
            return;
        }

        var className = "Twitch" + ClassName(scriptName) +
                        (isLaterVersion ? LaterVersionEventSuffixes.GetValueOrDefault(scriptName, "EventV2") : "Event");
        var component = new TwitchEventSubGenComponent(className) { Description = Text(versionTypes[0].Description) };
        AddFields(component, fields, false);
        Components.Add(component);
    }

    private void AddCondition(string scriptName, List<EventSubSubscriptionType> versionTypes, bool isLaterVersion,
        List<TwitchEventSubGenComponent> conditions)
    {
        var fields = versionTypes[0].Condition;
        if (fields.Count == 0 || SharedEvents.Contains(scriptName)) return;
        if (isLaterVersion && !OwnLaterVersionConditions.Contains(scriptName) &&
            conditions.Any(c => HasSameFields(c, fields)))
            return;

        var className = "Twitch" + ClassName(scriptName) + (isLaterVersion ? "V2" : "") + "Condition";
        var component = new TwitchEventSubGenComponent(className) { Description = Text(versionTypes[0].Description) };
        AddFields(component, fields, true);
        conditions.Add(component);
        ConditionComponents.Add(component);
    }

    /// <summary>
    /// A description on one line, as the doc comments take it.
    /// </summary>
    private static string Text(string description) => WhiteSpace().Replace(description, " ").Trim();

    [GeneratedRegex(@"\s+")]
    private static partial Regex WhiteSpace();

    private static string ClassName(string scriptName) =>
        ClassNameOverrides.GetValueOrDefault(scriptName) ?? scriptName.ToPascalCase();

    private static bool HasSameFields(TwitchEventSubGenComponent component, List<DocField> fields) =>
        component.Fields.Values.Select(f => f.RawName).SequenceEqual(fields.Select(f => f.Name));

    private void AddFields(TwitchEventSubGenComponent parent, IEnumerable<DocField> fields, bool isCondition)
    {
        foreach (var field in fields) AddField(parent, field, isCondition);
    }

    private void AddField(TwitchEventSubGenComponent parent, DocField field, bool isCondition)
    {
        var required = isCondition && field.IsRequired;
        if (field.Name.StartsWith(SharedChatPrefix) && AddSharedChatField(parent, field)) return;

        if (field.Children.Count == 0)
        {
            parent.AddField(new TwitchEventSubGenField(field.Name, Text(field.Description), ScalarType(field), required)
            {
                IsArray = field.IsArray,
            });
            return;
        }

        var sharedName = SharedObjectAliases.GetValueOrDefault(field.Name) ?? field.Name;
        var shared = SubComponents.FirstOrDefault(c => c.ClassName == "Twitch" + sharedName.ToPascalCase());
        var component = shared != null && IsSharedShape(shared, field)
            ? shared
            : NestedComponent(parent, field, shared);

        if (field.IsArray)
        {
            parent.AddField(new TwitchEventSubGenField(field.Name, Text(field.Description), component.ClassName + "[]")
            {
                IsArray = true,
                TypedComponent = component,
            });
        }
        else
        {
            parent.AddSubComponent(component);
        }
    }

    private TwitchEventSubGenComponent NestedComponent(TwitchEventSubGenComponent parent, DocField field,
        TwitchEventSubGenComponent shared)
    {
        var className = shared?.ClassName ??
                        "Twitch" + field.Name.ToPascalCase() + (parent.ClassName.EndsWith("V2") ? "V2" : "");
        var component = new TwitchEventSubGenComponent(className) { Description = Text(field.Description) };
        AddFields(component, field.Children, false);
        return component;
    }

    /// <summary>
    /// A field uses a shared object when it has no fields the object lacks.
    /// </summary>
    private static bool IsSharedShape(TwitchEventSubGenComponent shared, DocField field) =>
        field.Children.All(c => shared.Fields.Values.Any(f => f.RawName == c.Name || f.Name == c.Name.ToPascalCase()));

    /// <summary>
    /// shared_chat_ fields repeat the object of their sibling without the prefix, so they share its class.
    /// </summary>
    private static bool AddSharedChatField(TwitchEventSubGenComponent parent, DocField field)
    {
        var siblingName = field.Name[SharedChatPrefix.Length..].ToPascalCase();
        var sibling = parent.Fields.Values.FirstOrDefault(f =>
            f.TypedComponent != null && f.TypedComponent.ClassName.Remove("Twitch").Remove("V2") == siblingName);
        if (sibling == null) return false;

        parent.AddField(new TwitchEventSubGenField(field.Name, Text(field.Description), sibling.TypedComponent.ClassName)
        {
            IsArray = field.IsArray,
            TypedComponent = sibling.TypedComponent,
        });
        return true;
    }

    private static string ScalarType(DocField field) => field.Type switch
    {
        "Object" => "Dictionary",
        _ => field.Type,
    };

    private void AddDefinitions(IReadOnlyList<EventSubSubscriptionType> types)
    {
        foreach (var group in types.GroupBy(t => t.Type))
        {
            var lowest = group.Select(t => t.Version).OrderBy(VersionOrder).First();
            foreach (var type in group.OrderBy(t => VersionOrder(t.Version)))
            {
                Definitions.Add(new TwitchEventSubDefinitionInfo
                {
                    EnumName = ToEnumName(type.Type) + (type.Version == lowest ? "" : "V" + type.Version),
                    Value = type.Type,
                    Version = type.Version,
                    Conditions = type.Condition.Select(f => f.Name).ToList(),
                    Scopes = type.Scopes,
                    DocumentationLink = TwitcherDocumentationLink(type, type.Version == lowest),
                });
            }
        }

        Console.WriteLine($"{Definitions.Count} subscription type definitions parsed");
    }

    /// <summary>
    /// twitcher's definitions still link the subscription types page that the Markdown reference replaced.
    /// </summary>
    private static string TwitcherDocumentationLink(EventSubSubscriptionType type, bool isLowestVersion) =>
        "https://dev.twitch.tv/docs/eventsub/eventsub-subscription-types/#" + type.Type.Replace(".", "") +
        (isLowestVersion ? "" : "-v" + type.Version);

    private static string ToEnumName(string dottedValue) =>
        string.Concat(dottedValue.Split(['.', '_'], StringSplitOptions.RemoveEmptyEntries)
            .Select(w => char.ToUpperInvariant(w[0]) + w[1..]));
}
