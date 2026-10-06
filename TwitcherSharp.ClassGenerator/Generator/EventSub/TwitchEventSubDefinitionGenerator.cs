using System.Text;
using ClassGenerator.GenObjects.EventSub;

namespace ClassGenerator.Generator.EventSub;

public class TwitchEventSubDefinitionGenerator
{
    private const string TypeEnumTemplate = """
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
                                                using Godot;
                                                using TwitcherSharp.Extensions;
                                                using TwitcherSharp.Interfaces;

                                                namespace TwitcherSharp.EventSub;

                                                public partial class TwitchEventSubDefinition() : RefCounted, ITwitcherSharp<TwitchEventSubDefinition>
                                                {
                                                    private const string ScriptPath = "res://addons/twitcher/eventsub/twitch_eventsub_definition.gd";

                                                    public TwitchEventSubDefinitionType Type { get; set; }
                                                    public StringName Value { get; set; } = null!;
                                                    public StringName Version { get; set; } = null!;
                                                    public List<StringName> Conditions { get; set; } = null!;
                                                    public List<StringName> Scopes { get; set; } = null!;
                                                    public string DocumentationLink { get; set; } = null!;
                                                    public string GetReadableName() => $"{Value} (v{Version})";

                                                    /// <summary>
                                                    /// Only set for the static, generated definitions (via the parameterized constructor) - never populated
                                                    /// by <see cref="FromObject"/>, since a plain godot definition object carries no script reference.
                                                    /// </summary>
                                                    public GDScript? Script { get; set; }

                                                    public static TwitchEventSubDefinition? FromObject(GodotObject? data)
                                                    {
                                                        if (data == null) return null;
                                                        var value = data.Read("value", static v => v.AsStringName());
                                                        var version = data.Read("version", static v => v.AsStringName());
                                                        return new TwitchEventSubDefinition
                                                        {
                                                            // twitcher numbers its types in another order: the type follows from the event.
                                                            Type = FindType(value, version) ?? default,
                                                            Value = value,
                                                            Version = version,
                                                            Conditions = data.Read("conditions", static v => v.AsSystemArrayOfStringName().ToList()),
                                                            Scopes = data.Read("scopes", static v => v.AsSystemArrayOfStringName().ToList()),
                                                            DocumentationLink = data.Read("documentation_link", static v => v.AsString()),
                                                        };
                                                    }

                                                    /// <summary>
                                                    /// twitcher's own definition of this event (TwitchEventsubDefinition.ALL). Definitions are plain Objects
                                                    /// that nothing frees, so only a definition twitcher does not know is created, and the caller frees that.
                                                    /// </summary>
                                                    public GodotObject ToGodotObject()
                                                    {
                                                        if (FindTwitcherDefinition() is { } known) return known;

                                                        var conditions = new Godot.Collections.Array<StringName>(Conditions ?? []);
                                                        var scopes = new Godot.Collections.Array<StringName>(Scopes ?? []);
                                                        return InteropExtension.NewObject(ScriptPath, (int)Type, Value, Version, conditions, scopes,
                                                            DocumentationLink, Script!);
                                                    }

                                                    /// <summary>
                                                    /// twitcher's number for this event (TwitchEventsubDefinition.Type), which differs from <see cref="Type"/>;
                                                    /// -1 when twitcher does not know the event.
                                                    /// </summary>
                                                    public int TwitcherType => FindTwitcherDefinition()?.Read("type", static v => v.AsInt32()) ?? -1;

                                                    private GodotObject? FindTwitcherDefinition()
                                                    {
                                                        using var script = GD.Load<GDScript>(ScriptPath);
                                                        using var all = script.Get("ALL");
                                                        using var definitions = all.AsGodotDictionary();
                                                        foreach (var (key, definition) in definitions)
                                                        {
                                                            key.Dispose();
                                                            using (definition)
                                                            {
                                                                // Plain Objects: their wrappers hold no reference.
                                                                var known = definition.AsGodotObject();
                                                                if (known.Read("value", static v => v.AsStringName()) == Value
                                                                    && known.Read("version", static v => v.AsStringName()) == Version)
                                                                    return known;
                                                            }
                                                        }

                                                        return null;
                                                    }

                                                    /// <summary>
                                                    /// The type of an event by its value and version; twitcher's own numbers differ from TwitchEventSubDefinitionType.
                                                    /// </summary>
                                                    public static TwitchEventSubDefinitionType? FindType(StringName value, StringName version) =>
                                                        All.FirstOrDefault(definition => definition.Value == value && definition.Version == version)?.Type;

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
        var values = string.Join(",\n", definitions.Select(d => $"    {d.EnumName}"));
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
        return $"""
                    public static readonly TwitchEventSubDefinition {definition.EnumName} = new(
                        TwitchEventSubDefinitionType.{definition.EnumName}, "{definition.Value}", "{definition.Version}",
                        {conditions}, {scopes},
                        "{definition.DocumentationLink}",
                        "{definition.ScriptName}");
                """;
    }

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
