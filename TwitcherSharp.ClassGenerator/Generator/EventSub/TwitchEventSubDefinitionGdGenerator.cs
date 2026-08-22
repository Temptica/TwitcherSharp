using System.Text;
using ClassGenerator.Extensions;
using ClassGenerator.GenObjects.EventSub;

namespace ClassGenerator.Generator.EventSub;

/// <summary>
/// Generates the GDScript mirror of TwitchEventSubDefinition (twitch_eventsub_definition.gd) for the
/// Twitcher addon, from the same parsed subscription types list used for the C# side.
/// </summary>
public class TwitchEventSubDefinitionGdGenerator
{
    public void Generate(string filePath, List<TwitchEventSubDefinitionInfo> definitions)
    {
        File.WriteAllText(filePath, GenerateFile(definitions));
    }

    private static string GenerateFile(List<TwitchEventSubDefinitionInfo> definitions)
    {
        var sb = new StringBuilder();
        sb.AppendLine("@tool");
        sb.AppendLine("extends Object");
        sb.AppendLine();
        sb.AppendLine("class_name TwitchEventsubDefinition");
        sb.AppendLine();
        sb.AppendLine("## All supported subscriptions should be used in comination with get_all method as index.");
        sb.AppendLine("enum Type {");
        foreach (var definition in definitions)
        {
            sb.Append('\t').Append(ToScreamingSnakeCase(definition.EnumName)).AppendLine(",");
        }

        sb.AppendLine("}");
        sb.AppendLine();
        sb.AppendLine("## The type of itself");
        sb.AppendLine("var type: Type");
        sb.AppendLine("## Name within Twitch");
        sb.AppendLine("var value: StringName");
        sb.AppendLine("## Version defined in Twitch");
        sb.AppendLine("var version: StringName");
        sb.AppendLine("## Keys of the conditions it need for setup");
        sb.AppendLine("var conditions: Array[StringName]");
        sb.AppendLine("## Possible scopes it needs (on some of them its more then needed)");
        sb.AppendLine("var scopes: Array[StringName]");
        sb.AppendLine("## Link to the twitch documentation");
        sb.AppendLine("var documentation_link: String");
        sb.AppendLine("## The actual script that represents the return value");
        sb.AppendLine("var response_script: Script");
        sb.AppendLine();
        sb.AppendLine();
        sb.AppendLine(
            "func _init(typ: Type, val: StringName, ver: StringName, cond: Array[StringName], scps: Array[StringName], doc_link: String, resp_script: Script):");
        sb.AppendLine("\ttype = typ");
        sb.AppendLine("\tvalue = val");
        sb.AppendLine("\tversion = ver");
        sb.AppendLine("\tconditions = cond");
        sb.AppendLine("\tscopes = scps");
        sb.AppendLine("\tdocumentation_link = doc_link");
        sb.AppendLine("\tresponse_script = resp_script");
        sb.AppendLine();
        sb.AppendLine("## Get a human readable name of it");
        sb.AppendLine("func get_readable_name() -> String:");
        sb.AppendLine("\treturn \"%s (v%s)\" % [value, version]");
        sb.AppendLine();
        sb.AppendLine();

        foreach (var definition in definitions)
        {
            sb.AppendLine(FormatStaticVar(definition));
        }

        sb.AppendLine();
        sb.AppendLine("## Returns all supported subscriptions");
        sb.AppendLine(
            "static var ALL: Dictionary[TwitchEventsubDefinition.Type, TwitchEventsubDefinition] = {");
        foreach (var definition in definitions)
        {
            var name = ToScreamingSnakeCase(definition.EnumName);
            sb.Append('\t').Append("Type.").Append(name).Append(": ").Append(name).AppendLine(",");
        }

        sb.AppendLine("}");
        sb.AppendLine();
        sb.AppendLine("## Returns all supported subscriptions by name");
        sb.AppendLine("static var BY_NAME: Dictionary[StringName, TwitchEventsubDefinition] = {");
        foreach (var definition in definitions)
        {
            var name = ToScreamingSnakeCase(definition.EnumName);
            sb.Append('\t').Append(name).Append(".value: ").Append(name).AppendLine(",");
        }

        sb.AppendLine("}");

        return sb.ToString();
    }

    private static string FormatStaticVar(TwitchEventSubDefinitionInfo definition)
    {
        var name = ToScreamingSnakeCase(definition.EnumName);
        var conditions = FormatStringArray(definition.Conditions);
        var scopes = FormatStringArray(definition.Scopes);
        var scriptClassName = "TwitchES" + definition.ScriptName.ToPascalCase();
        return
            $"static var {name} := TwitchEventsubDefinition.new(Type.{name}, &\"{definition.Value}\", &\"{definition.Version}\", {conditions}, {scopes}, \"{definition.DocumentationLink}\", {scriptClassName})";
    }

    private static string FormatStringArray(List<string> values) =>
        values.Count == 0 ? "[]" : $"[{string.Join(",", values.Select(v => $"&\"{v}\""))}]";

    // Deliberately not StringExtension.ToSnakeCase: that helper splits a trailing version digit off its
    // letter (e.g. "V2" -> "V_2"), but Twitch/Twitcher naming keeps them glued ("CHANNEL_MODERATE_V2").
    private static string ToScreamingSnakeCase(string pascalCaseName)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < pascalCaseName.Length; i++)
        {
            var c = pascalCaseName[i];
            if (char.IsUpper(c) && i > 0 && !char.IsUpper(pascalCaseName[i - 1]))
            {
                sb.Append('_');
            }

            sb.Append(char.ToUpperInvariant(c));
        }

        return sb.ToString();
    }
}
