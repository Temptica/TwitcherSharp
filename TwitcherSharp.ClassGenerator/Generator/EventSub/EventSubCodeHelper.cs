using System.Text;
using ClassGenerator.Extensions;
using ClassGenerator.GenObjects.EventSub;

namespace ClassGenerator.Generator.EventSub;

public static class EventSubCodeHelper
{
    public static bool UseTwitcherEventSubV2 = true;

    public static string MainEventSub(TwitchEventSubGenComponent component, string nameSpace)
    {
        var code = new StringBuilder();
        var hasSharedComponents = false;
        var componentsToCheck = component.SubComponents.Values.ToList();

        while (componentsToCheck.Count >0)
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
        
        code.AppendLine(EventSubCodeStrings.EventSubNameSpaces.Replace("{{NameSpace}}", nameSpace).Replace("{{SharedNamespace}}", hasSharedComponents ? "using TwitcherSharp.EventSub.Generated.Shared;" : ""));
        code.AppendLine();

        code.AppendLine(GenerateComponent(component));

        code.AppendLine("}");

        return code.ToString();
    }

    private static string GenerateComponent(TwitchEventSubGenComponent component, int level = 0, string type = null)
    {
        var code = new StringBuilder();

        code.AppendLine(EventSubCodeStrings.EventSubHeader.Replace("{{ClassName}}", component.ClassName));
        code.AppendLine("{");
        code.AppendLine();

        var fields = component.Fields.Values.ToList();

        foreach (var field in fields)
        {
            code.AppendIndentedLine(EventSubCodeStrings.FieldDescription.Replace("{{Description}}", field.Description),
                1);

            var fieldType = field.Type;
            if (field.IsArray && !fieldType.Contains("[]")) fieldType += "[]";
            code.AppendIndentedLine($"public {fieldType} {field.Name} {{ get; set; }}", 1);
            code.AppendLine();
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

            code.AppendIndentedLine($"var script = GD.Load<GDScript>(\"{path}\");", 2);

            var v2String = component.ClassName.Contains("V2") ? "V2" : "";
            string typeToUse;
            
            if (component.ClassName.EndsWith("Event")) typeToUse = "Event" + v2String;
            else typeToUse = (component.IsShared ? component.ClassName : component.ClassName.Remove(type).Remove("Twitch")) + v2String;
            
            var scriptName = $"{typeToUse.ToCamelCase().Remove("Twitch")}Class";
            code.AppendIndentedLine($"var {scriptName} = script.Get(\"{typeToUse}\").AsGodotObject();", 2);

            code.AppendIndentedLine($"var request = {scriptName}.Call(\"new\").AsGodotObject();", 2);

            foreach (var field in fields)
            {
                code.AppendIndentedLine(field.Type == "Object"
                        ? $"request.Set(\"{field.Name.ToSnakeCase()}\", {field.Name}.ToGodotObject());"
                        : $"request.Set(\"{field.Name.ToSnakeCase()}\", {field.Name});",
                    2);
            }

            code.AppendIndentedLine("return request;", 2);
        }
        else
        {
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
        }

        code.AppendIndentedLine("}", 1);

        var nonSharedSubComponents = component.SubComponents
            .Where(s => !s.Value.IsShared)
            .Select(s => s.Value)
            .ToList();

        if (nonSharedSubComponents.Count != 0)
        {
            
            foreach (var subComponent in nonSharedSubComponents)
            {
                code.AppendLine();
                code.AppendIndentedLine(GenerateComponent(subComponent, level, type), level+1);
                code.AppendIndentedLine("}", level+1);
            }
        }

        return code.ToString();
    }
}