using System.Text;
using ClassGenerator.Extensions;
using ClassGenerator.GenObjects.Api;
using ClassGenerator.GenObjects.EventSub;

namespace ClassGenerator.Generator.EventSub;

public static class EventSubCodeHelper
{
    public static string MainEventSub(TwitchEventSubGenComponent component)
    {
        var code = new StringBuilder();
        code.AppendLine(EventSubCodeStrings.EventSubNameSpaces);
        code.AppendLine();

        code.AppendLine(GenerateComponent(component));


        code.AppendLine("}");

        return code.ToString();
    }

    private static string GenerateComponent(TwitchEventSubGenComponent component, int level = 0)
    {
        var code = new StringBuilder();

        code.AppendLine(EventSubCodeStrings.EventSubHeader.Replace("{{ClassName}}", component.ClassName));
        code.AppendLine("{");
        code.AppendLine();

        foreach (var field in component.Fields)
        {
            code.AppendIndentedLine(EventSubCodeStrings.FieldDescription.Replace("{{Description}}", field.Description),
                1);
            code.AppendIndentedLine($"public {field.Type} {field.Name} {{ get; set; }}", 1);
            code.AppendLine();
        }

        code.AppendIndentedLine(EventSubCodeStrings.FromDictionary.Replace("{{ClassName}}", component.ClassName),
            1);

        foreach (var field in component.Fields)
        {
            var fieldCode = field switch
            {
                //3 cases -> Normal/Array, TypedArray, Typed
                { IsTyped: false } => $"""{field.Name} = data["{field.Name.ToSnakeCase()}"].{field.GetAsType()},""",
                { IsArray: false } =>
                    $"""{field.Name} = {field.Type}.FromData(data["{field.Name.ToSnakeCase()}"].AsGodotDictionary()),""",
                _ =>
                    $"""{field.Name} = data["{field.Name.ToSnakeCase()}"].AsGodotArray().Select(x => TwitchData.FromData(x.AsGodotDictionary())).ToArray(),"""
            };

            code.AppendIndentedLine(fieldCode, 3);
        }

        code.AppendIndentedLine("};", 2);
        code.AppendIndentedLine("}", 1);

        if (component.SubComponents.Count != 0)
        {
            code.AppendLine();
            foreach (var subComponent in component.SubComponents)
            {
                code.AppendIndentedLine(GenerateComponent(subComponent, level + 1), level );
                code.AppendIndentedLine("}");
            }
        }

        return code.ToString();
    }
}