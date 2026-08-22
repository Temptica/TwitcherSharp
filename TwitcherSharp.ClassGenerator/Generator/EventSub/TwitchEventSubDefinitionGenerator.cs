using System.Text;
using ClassGenerator.GenObjects.EventSub;

namespace ClassGenerator.Generator.EventSub;

public class TwitchEventSubDefinitionGenerator
{
    private const string TypeEnumTemplate = """
                                             using System;

                                             namespace TwitcherSharp.EventSub;

                                             public enum TwitchEventSubDefinitionType
                                             {
                                             {{Values}}
                                             }
                                             """;

    /// <summary>
    /// Param: {{Definitions}} {{AllList}}
    /// </summary>
    private const string DefinitionTemplate = """
                                                using System;
                                                using Godot;
                                                using TwitcherSharp.Interfaces;

                                                namespace TwitcherSharp.EventSub;

                                                public partial class TwitchEventSubDefinition() : RefCounted, ITwitcherSharp<TwitchEventSubDefinition>
                                                {
                                                    private GodotObject _data;

                                                    public TwitchEventSubDefinitionType Type { get; set; }
                                                    public StringName Value { get; set; }
                                                    public StringName Version { get; set; }
                                                    public List<StringName> Conditions { get; set; }
                                                    public List<StringName> Scopes { get; set; }
                                                    public string DocumentationLink { get; set; }
                                                    public string GetReadableName() => $"{Value} (v{Version})";
                                                    public GDScript Script { get; set; }

                                                    public static TwitchEventSubDefinition FromObject(GodotObject data)
                                                    {
                                                        if (data == null) return null;
                                                        var definition = new TwitchEventSubDefinition();
                                                        definition._data = data;
                                                        definition.Type = (TwitchEventSubDefinitionType)data.Get("type").AsInt32();
                                                        definition.Value = data.Get("value").AsStringName();
                                                        definition.Version = data.Get("version").AsStringName();
                                                        definition.Conditions = data.Get("conditions").AsSystemArrayOfStringName().ToList();
                                                        definition.Scopes = data.Get("scopes").AsSystemArrayOfStringName().ToList();
                                                        definition.DocumentationLink = data.Get("documentation_link").AsString();
                                                        return definition;
                                                    }

                                                    public GodotObject ToGodotObject()
                                                    {
                                                        var script = GD.Load<GDScript>("res://addons/twitcher/eventsub/twitch_eventsub_definition.gd");

                                                        var conditions = new Godot.Collections.Array<StringName>(Conditions ?? []);
                                                        var scopes = new Godot.Collections.Array<StringName>(Scopes ?? []);
                                                        var data = script.New((int)Type, Value, Version, conditions, scopes, DocumentationLink, Script)
                                                            .AsGodotObject();
                                                        return data;
                                                    }

                                                    private const string basePath = "res://addons/twitcher/generated_eventsub/twitch_es_";

                                                    public TwitchEventSubDefinition(TwitchEventSubDefinitionType type, string value, string version,
                                                        List<StringName> conditions, List<StringName> scopes, string documentationLink, string name) : this()
                                                    {
                                                        Type = type;
                                                        Value = value;
                                                        Version = version;
                                                        Conditions = conditions;
                                                        Scopes = scopes;
                                                        DocumentationLink = documentationLink;
                                                        Script = GD.Load<GDScript>($"{basePath}{name}.gd");
                                                    }

                                                    #region Static Definitions

                                                {{Definitions}}
                                                    #endregion

                                                    public static readonly List<TwitchEventSubDefinition> All =
                                                    [
                                                        {{AllList}}
                                                    ];
                                                }
                                                """;

    public static void Generate(string eventSubDir, List<TwitchEventSubDefinitionInfo> definitions)
    {
        File.WriteAllText(Path.Combine(eventSubDir, "TwitchEventSubDefinitionType.cs"), GenerateTypeEnum(definitions) + "\n");
        File.WriteAllText(Path.Combine(eventSubDir, "TwitchEventSubDefinition.cs"), GenerateDefinition(definitions) + "\n");
    }

    private static string GenerateTypeEnum(List<TwitchEventSubDefinitionInfo> definitions)
    {
        var values = string.Join(",\n", definitions.Select(d =>
            d.IsObsolete
                ? $"    [Obsolete(\"{ObsoleteMessage(d)}\")]\n    {d.EnumName}"
                : $"    {d.EnumName}"));
        return TypeEnumTemplate.Replace("{{Values}}", values);
    }

    private static string GenerateDefinition(List<TwitchEventSubDefinitionInfo> definitions)
    {
        var definitionFields = string.Join("\n\n", definitions.Select(FormatDefinitionField)) + "\n";
        var allList = WrapList(definitions.Select(d => d.EnumName), 8);
        return DefinitionTemplate
            .Replace("{{Definitions}}", definitionFields)
            .Replace("{{AllList}}", allList);
    }

    private static string FormatDefinitionField(TwitchEventSubDefinitionInfo definition)
    {
        var conditions = FormatStringArray(definition.Conditions);
        var scopes = FormatStringArray(definition.Scopes);
        var obsoleteAttribute = definition.IsObsolete ? $"    [Obsolete(\"{ObsoleteMessage(definition)}\")]\n" : "";
        return $"""
                {obsoleteAttribute}    public static readonly TwitchEventSubDefinition {definition.EnumName} = new(
                        TwitchEventSubDefinitionType.{definition.EnumName}, "{definition.Value}", "{definition.Version}",
                        {conditions}, {scopes},
                        "{definition.DocumentationLink}",
                        "{definition.ScriptName}");
                """;
    }

    // Legacy definitions are always named "{Primary}Legacy" - see EventSubScriptNameResolver.
    private static string ObsoleteMessage(TwitchEventSubDefinitionInfo definition) =>
        $"Kept for backwards compatibility - points at the pre-override script name '{definition.ScriptName}'. " +
        $"Use {definition.EnumName[..^"Legacy".Length]} instead.";

    private static string FormatStringArray(List<string> values) =>
        values.Count == 0 ? "[]" : $"[{string.Join(", ", values.Select(v => $"\"{v}\""))}]";

    private static string WrapList(IEnumerable<string> values, int indent)
    {
        const int maxWidth = 120;
        var sb = new StringBuilder();
        var lineLength = indent;
        var first = true;
        foreach (var value in values)
        {
            var token = (first ? "" : ", ") + value;
            if (!first && lineLength + token.Length > maxWidth)
            {
                sb.Append(",\n").Append(' ', indent).Append(value);
                lineLength = indent + value.Length;
            }
            else
            {
                sb.Append(token);
                lineLength += token.Length;
            }

            first = false;
        }

        return sb.ToString();
    }
}
