using System.Text;
using ClassGenerator.GenObjects.EventSub;

namespace ClassGenerator.Generator.EventSub;

/// <summary>
/// Generates the C# TwitchEventSubDefinitionType enum and TwitchEventSubDefinition static definitions
/// from the parsed subscription types list.
/// </summary>
public class TwitchEventSubDefinitionGenerator
{
    public void Generate(string eventSubDir, List<TwitchEventSubDefinitionInfo> definitions)
    {
        File.WriteAllText(Path.Combine(eventSubDir, "TwitchEventSubDefinitionType.cs"), GenerateTypeEnum(definitions));
        File.WriteAllText(Path.Combine(eventSubDir, "TwitchEventSubDefinition.cs"), GenerateDefinition(definitions));
    }

    private static string GenerateTypeEnum(List<TwitchEventSubDefinitionInfo> definitions)
    {
        var sb = new StringBuilder();
        sb.AppendLine("namespace TwitcherSharp.EventSub;");
        sb.AppendLine();
        sb.AppendLine("public enum TwitchEventSubDefinitionType");
        sb.AppendLine("{");
        for (var i = 0; i < definitions.Count; i++)
        {
            sb.Append("    ").Append(definitions[i].EnumName);
            sb.AppendLine(i < definitions.Count - 1 ? "," : "");
        }

        sb.AppendLine("}");
        return sb.ToString();
    }

    private static string GenerateDefinition(List<TwitchEventSubDefinitionInfo> definitions)
    {
        var sb = new StringBuilder();
        sb.AppendLine("using Godot;");
        sb.AppendLine("using TwitcherSharp.Interfaces;");
        sb.AppendLine();
        sb.AppendLine("namespace TwitcherSharp.EventSub;");
        sb.AppendLine();
        sb.AppendLine(
            "public partial class TwitchEventSubDefinition() : RefCounted, ITwitcherSharp<TwitchEventSubDefinition>");
        sb.AppendLine("{");
        sb.AppendLine("    private GodotObject _data;");
        sb.AppendLine();
        sb.AppendLine("    public TwitchEventSubDefinitionType Type { get; set; }");
        sb.AppendLine("    public StringName Value { get; set; }");
        sb.AppendLine("    public StringName Version { get; set; }");
        sb.AppendLine("    public List<StringName> Conditions { get; set; }");
        sb.AppendLine("    public List<StringName> Scopes { get; set; }");
        sb.AppendLine("    public string DocumentationLink { get; set; }");
        sb.AppendLine("    public string GetReadableName() => $\"{Value} (v{Version})\";");
        sb.AppendLine("    public GDScript Script { get; set; }");
        sb.AppendLine();
        sb.AppendLine("    public static TwitchEventSubDefinition FromObject(GodotObject data)");
        sb.AppendLine("    {");
        sb.AppendLine("        if (data == null) return null;");
        sb.AppendLine("        var definition = new TwitchEventSubDefinition();");
        sb.AppendLine("        definition._data = data;");
        sb.AppendLine("        definition.Type = (TwitchEventSubDefinitionType)data.Get(\"type\").AsInt32();");
        sb.AppendLine("        definition.Value = data.Get(\"value\").AsStringName();");
        sb.AppendLine("        definition.Version = data.Get(\"version\").AsStringName();");
        sb.AppendLine("        definition.Conditions = data.Get(\"conditions\").AsSystemArrayOfStringName().ToList();");
        sb.AppendLine("        definition.Scopes = data.Get(\"scopes\").AsSystemArrayOfStringName().ToList();");
        sb.AppendLine("        definition.DocumentationLink = data.Get(\"documentation_link\").AsString();");
        sb.AppendLine("        return definition;");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    public GodotObject ToGodotObject()");
        sb.AppendLine("    {");
        sb.AppendLine("        var script = GD.Load<GDScript>(\"res://addons/twitcher/eventsub/twitch_eventsub_definition.gd\");");
        sb.AppendLine();
        sb.AppendLine("        var conditions = new Godot.Collections.Array<StringName>(Conditions ?? []);");
        sb.AppendLine("        var scopes = new Godot.Collections.Array<StringName>(Scopes ?? []);");
        sb.AppendLine(
            "        var data = script.New((int)Type, Value, Version, conditions, scopes, DocumentationLink, Script)");
        sb.AppendLine("            .AsGodotObject();");
        sb.AppendLine("        return data;");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    private const string basePath = \"res://addons/twitcher/generated_eventsub/twitch_es_\";");
        sb.AppendLine();
        sb.AppendLine(
            "    public TwitchEventSubDefinition(TwitchEventSubDefinitionType type, string value, string version,");
        sb.AppendLine(
            "        List<StringName> conditions, List<StringName> scopes, string documentationLink, string name) : this()");
        sb.AppendLine("    {");
        sb.AppendLine("        Type = type;");
        sb.AppendLine("        Value = value;");
        sb.AppendLine("        Version = version;");
        sb.AppendLine("        Conditions = conditions;");
        sb.AppendLine("        Scopes = scopes;");
        sb.AppendLine("        DocumentationLink = documentationLink;");
        sb.AppendLine("        Script = GD.Load<GDScript>($\"{basePath}{name}.gd\");");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    #region Static Definitions");
        sb.AppendLine();

        foreach (var definition in definitions)
        {
            sb.AppendLine(FormatDefinitionField(definition));
            sb.AppendLine();
        }

        sb.AppendLine("    #endregion");
        sb.AppendLine();
        sb.AppendLine("    public static readonly List<TwitchEventSubDefinition> All =");
        sb.AppendLine("    [");
        sb.Append("        ");
        sb.AppendLine(WrapList(definitions.Select(d => d.EnumName), 8));
        sb.AppendLine("    ];");
        sb.AppendLine("}");
        return sb.ToString();
    }

    private static string FormatDefinitionField(TwitchEventSubDefinitionInfo definition)
    {
        var conditions = FormatStringArray(definition.Conditions);
        var scopes = FormatStringArray(definition.Scopes);
        var sb = new StringBuilder();
        sb.AppendLine($"    public static readonly TwitchEventSubDefinition {definition.EnumName} = new(");
        sb.AppendLine(
            $"        TwitchEventSubDefinitionType.{definition.EnumName}, \"{definition.Value}\", \"{definition.Version}\",");
        sb.AppendLine($"        {conditions}, {scopes},");
        sb.AppendLine($"        \"{definition.DocumentationLink}\",");
        sb.Append($"        \"{definition.ScriptName}\");");
        return sb.ToString();
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
                sb.AppendLine(",");
                sb.Append(new string(' ', indent)).Append(value);
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
