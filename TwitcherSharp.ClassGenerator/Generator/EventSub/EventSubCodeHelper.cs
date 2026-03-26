using System.Text;
using ClassGenerator.Extensions;
using ClassGenerator.GenObjects.EventSub;

namespace ClassGenerator.Generator.EventSub;

public static class EventSubCodeHelper
{
    public static bool UseTwitcherEventSubV2 = true;

    public static string MainEventSub(TwitchEventSubGenComponent component, string nameSpace, bool isCondition = false)
    {
        var code = new StringBuilder();
        var hasSharedComponents = false;
        var componentsToCheck = component.SubComponents.Values.ToList();

        while (componentsToCheck.Count > 0)
        {
            var componentToCheck = componentsToCheck[0];
            componentsToCheck.RemoveAt(0);
            if (componentToCheck.IsShared)
            {
                hasSharedComponents = true;
                break;
            }

            componentsToCheck.AddRange(componentToCheck.SubComponents.Values);
        }

        code.AppendLine(EventSubCodeStrings.EventSubNameSpaces.Replace("{{NameSpace}}", nameSpace).Replace(
            "{{SharedNamespace}}", hasSharedComponents ? "using TwitcherSharp.EventSub.Generated.Shared;" : ""));
        code.AppendLine();

        code.AppendLine(GenerateComponent(component, isCondition: isCondition));

        code.AppendLine("}");

        return code.ToString();
    }

    private static string GenerateComponent(TwitchEventSubGenComponent component, int level = 0, string type = null,
        bool isCondition = false)
    {
        var code = new StringBuilder();

        var header = isCondition ? EventSubCodeStrings.ConditionSubHeader : EventSubCodeStrings.EventSubHeader;
        code.AppendLine(header.Replace("{{ClassName}}", component.ClassName));

        code.AppendLine("{");
        if (isCondition)
        {
            code.AppendIndentedLine($"public string Name => nameof({component.ClassName});", level + 1);
            code.AppendLine();
        }

        var fields = component.Fields.Values.ToList();

        foreach (var field in fields)
        {
            code.AppendIndentedLine(EventSubCodeStrings.FieldDescription.Replace("{{Description}}", field.Description),
                1);

            var fieldType = field.Type;
            if (field.IsArray && !fieldType.Contains("[]")) fieldType += "[]";
            code.AppendIndentedLine($"public {fieldType} {field.Name} {{ get; set; }}", 1);
            if (field != fields[^1]) code.AppendLine();
        }


        if (UseTwitcherEventSubV2)
        {
            //FROM OBJECT
            code.AppendLine();
            code.AppendLine(EventSubCodeStrings.ComponentFromBody.Replace("{{className}}", component.ClassName));

            foreach (var typedArrayField in fields.Where(f => f.IsArray && f.IsTyped))
            {
                code.AppendIndentedLine(
                    $"var {typedArrayField.Name.ToCamelCase()}Array = data.Get(\"{typedArrayField.Name.ToSnakeCase()}\").AsGodotArray<GodotObject>();",
                    2);
            }

            code.AppendIndentedLine($"return new {component.ClassName}", 2);
            code.AppendIndentedLine("{", 2);

            foreach (var field in fields)
            {
                string fieldData;
                if (field.IsArray && field.IsTyped)
                {
                    fieldData =
                        $"{field.Name} = {field.Name.ToCamelCase()}Array.Select({field.TypedComponent.ClassName}.FromObject).ToArray(),";
                }
                else fieldData = $"{field.Name} = data.Get(\"{field.Name.ToSnakeCase()}\").{field.GetAsType()},";

                code.AppendIndentedLine(fieldData, 3);
            }

            code.AppendIndentedLine("};", 2);
            code.AppendIndentedLine("}", 1);
            code.Append(Environment.NewLine);

            //TO OBJECT
            code.AppendIndentedLine("public GodotObject ToGodotObject()", 1);
            code.AppendIndentedLine("{", 1);

            type ??= component.ClassName.Remove("Event").Remove("Condition");

            var path =
                $"res://addons/twitcher/generated_eventsub/{type.Remove("V2").ToSnakeCase().Replace("twitch", "twitch_es")}.gd";

            if (component.ClassName.Contains("Image"))
            {
                path = $"res://addons/twitcher/generated_eventsub/{type.ToSnakeCase().Replace("twitch", "twitch_es").Replace("image", "twitch_image")}.gd";
            }
            
            code.AppendIndentedLine($"var script = GD.Load<GDScript>(\"{path}\");", 2);

            string typeToUse;

            if (component.ClassName.EndsWith("Event")) typeToUse = "Event";
            else if(component.ClassName.EndsWith("EventV2")) typeToUse = "EventV2";
            else if(component.ClassName.EndsWith("Condition")) typeToUse = "Condition";
            else if(component.ClassName.EndsWith("ConditionV2")) typeToUse = "ConditionV2";
            else
                typeToUse = component.IsShared
                    ? component.ClassName.Replace("Twitch", "TwitchES")
                    : component.ClassName.Remove(type).Remove("Twitch");

            var scriptName = $"{typeToUse.ToCamelCase().Remove("Twitch")}Class";
            if (component.IsShared)
            {
                code.AppendIndentedLine($"var request = script.New().AsGodotObject();", 2);
            }
            else
            {
                code.AppendIndentedLine($"var {scriptName} = script.Get(\"{typeToUse}\").As<GDScript>();", 2);
                code.AppendIndentedLine($"var request = {scriptName}.New().AsGodotObject();", 2);
            }

            foreach (var field in fields)
            {
                code.AppendIndentedLine(field.Type == "Object"
                        ? $"request.Set(\"{field.Name.ToSnakeCase()}\", {field.Name}.ToGodotObject());"
                        : $"request.Set(\"{field.Name.ToSnakeCase()}\", {field.Name});",
                    2);
            }

            code.AppendIndentedLine("return request;", 2);
        }

        code.AppendIndentedLine("}", 1);
        code.AppendLine();

        if (isCondition)
        {
            //FROM DICTIONARY
            code.AppendIndentedLine(EventSubCodeStrings.FromDictionary.Replace("{{ClassName}}", component.ClassName),
                1);

            foreach (var field in component.Fields.Values)
            {
                var fieldCode = field switch
                {
                    //3 cases -> Normal/Array, TypedArray, Typed
                    { IsTyped: false } => $"""{field.Name} = data["{field.Name.ToSnakeCase()}"].{field.GetAsType()},""",
                    { IsArray: false } =>
                        $"""{field.Name} = {field.Type}.FromData(data["{field.Name.ToSnakeCase()}"].AsGodotDictionary()),""",
                    _ =>
                        $"""{field.Name} = data["{field.Name.ToSnakeCase()}"].AsGodotArray().Select(x => {field.TypedComponent.ClassName}.FromData(x.AsGodotDictionary())).ToArray(),"""
                };

                code.AppendIndentedLine(fieldCode, 3);
            }

            code.AppendIndentedLine("};", 2);
            code.AppendIndentedLine("}", 1);
            code.AppendLine();

            //TO DICTIONARY
            code.AppendIndentedLine(EventSubCodeStrings.ToDictionary, 1);

            foreach (var field in component.Fields.Values)
            {
                var fieldCode = $$"""{"{{field.Name.ToSnakeCase()}}", {{field.Name}}},""";

                code.AppendIndentedLine(fieldCode, 3);
            }

            code.AppendIndentedLine("};", 2);
            code.AppendIndentedLine("}", 1);
        }

        var nonSharedSubComponents = component.SubComponents
            .Where(s => !s.Value.IsShared)
            .Select(s => s.Value)
            .ToList();

        if (nonSharedSubComponents.Count != 0)
        {
            foreach (var subComponent in nonSharedSubComponents)
            {
                code.AppendLine();
                code.AppendIndentedLine(GenerateComponent(subComponent, level, type), level + 1);
                code.AppendIndentedLine("}", level + 1);
            }
        }

        return code.ToString().TrimEnd();
    }
}