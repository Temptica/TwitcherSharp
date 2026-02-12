using System.Text;
using ClassGenerator.Extensions;
using ClassGenerator.GenObjects.Api;

namespace ClassGenerator.Generator.Api;

public static class ApiCodeHelper
{
    private static readonly string[] Suffixes = ["Response", "Body", "Opt"];

    public static string ApiMethod(TwitchGenMethod method)
    {
        var methodString = new StringBuilder();

        if (!string.IsNullOrEmpty(method.Summary))
        {
            methodString.AppendIndentedLine("/// <summary>", 1);
            methodString.AppendIndentedLine($"/// {CleanDescription(method.Summary)}", 1);
            methodString.AppendIndentedLine("/// </summary>", 1);
        }

        if (method.ContainsBody)
            methodString.AppendIndentedLine($"/// <param name=\"body\"><see cref=\"{method.BodyType}\"/></param>", 1);
        if (method.ContainsOptional)
            methodString.AppendIndentedLine(
                $"/// <param name=\"opt\"><see cref=\"{method.GetOptionalClassName()}\"/></param>", 1);

        methodString.AppendIndentedLine($"/// <returns><see cref=\"{method.ResultType}\"/></returns>", 1);

        methodString
            .AppendIndentedLine($"public async Task<{method.ResultType}> {method.Name}({GetMethodParameter(method)})",
                1);

        methodString
            .AppendIndentedLine("{", 1);

        var methods = GetGodotMethodParameter(method, true);

        methodString.AppendIndentedLine(
            !string.IsNullOrEmpty(methods)
                ? $"return await _data.CallAsync<{method.ResultType}>(\"{method.Name.ToSnakeCase()}\", {methods}); "
                : $"return await _data.CallAsync<{method.ResultType}>(\"{method.Name.ToSnakeCase()}\"); ",
            2);

        methodString.AppendIndentedLine("}", 1);

        return methodString.ToString();
    }

    private static string GetMethodParameter(TwitchGenMethod method)
    {
        var parmsList = new List<string>();

        if (method.ContainsBody)
        {
            parmsList.Add($"{method.BodyType} body");
        }

        if (method.ContainsOptional)
        {
            parmsList.Add($"{method.GetOptionalClassName()} opt");
        }

        return string.Join(", ", parmsList);
    }

    private static string GetGodotMethodParameter(TwitchGenMethod method, bool toCamel = false)
    {
        var paramsList = new List<string>();
        if (method.ContainsBody) paramsList.Add("body.ToGodotObject()");
        if (method.ContainsOptional) paramsList.Add("opt.ToGodotObject()");
        return string.Join(", ", paramsList);
    }

    public static string ComponentCode(TwitchGenComponent component, string type = "")
    {
        var code = new StringBuilder();

        code.AppendLine(ApiCodeStrings.ComponentHeader
            .Replace("{{root}}", component.GetTag())
            .Replace("{{description}}", CleanDescription(component.Description))
            .Replace("{{className}}", component.ClassName));

        //PROPS
        var fields = component.GetAllFields();

        foreach (var field in fields)
        {
            //public string TestObject { get; set; }
            code.AppendIndentedLine(
                $"public {field.CleanedType}{(field.IsRequired || field.IsNullableTyped ? "" : "?")} {field.Name} {{ get; set; }}",
                1);
        }

        //FROM OBJECT
        code.AppendLine();
        code.AppendLine(ApiCodeStrings.ComponentFromBody.Replace("{{className}}", component.ClassName));

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
                    $"{field.Name} = {field.Name.ToCamelCase()}Array.Select({field.CleanedArrayType}.FromObject).ToArray(),";
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

        var path = $"res://addons/twitcher/generated/{GetBaseName(component.ClassName).ToSnakeCase()}.gd";
        code.AppendIndentedLine($"var script = GD.Load<GDScript>(\"{path}\");", 2);

        var scriptName = "script";
        if (!string.IsNullOrEmpty(type))
        {
            code.AppendIndentedLine($"var {type.ToLower()}Class = script.Get(\"{type}\").AsGodotObject();", 2);
            scriptName = $"{type.ToLower()}Class";
        }

        code.AppendIndentedLine($"var request = {scriptName}.Call(\"new\").AsGodotObject();", 2);

        foreach (var field in fields)
        {
            if (!field.IsRequired)
            {
                // if({field.Name}.HasValue) request.Set("{field.Name.ToSnakeCase()}", {field.Name.Value}.ToGodotObject());
                if (field.IsNullableTyped)
                {
                    code.AppendIndentedLine($"if({field.Name} != null) " + (
                            field.Type == "Object"
                                ? $"request.Set(\"{field.Name.ToSnakeCase()}\", {field.Name}.ToGodotObject());"
                                : $"request.Set(\"{field.Name.ToSnakeCase()}\", {field.Name});"),
                        2);

                    continue;
                }

                code.AppendIndentedLine(
                    $"if({field.Name}.HasValue) " + (field.Type == "Object"
                        ? $"request.Set(\"{field.Name.ToSnakeCase()}\", {field.Name}.Value.ToGodotObject());"
                        : $"request.Set(\"{field.Name.ToSnakeCase()}\", {field.Name}.Value);"),
                    2);
                continue;
            }

            code.AppendIndentedLine(
                field.Type == "Object"
                    ? $"request.Set(\"{field.Name.ToSnakeCase()}\", {field.Name}.ToGodotObject());"
                    : $"request.Set(\"{field.Name.ToSnakeCase()}\", {field.Name});",
                2);
        }

        code.AppendIndentedLine("return request;", 2);
        code.AppendIndentedLine("}", 1);
        code.AppendLine("}");
        return code.ToString();
    }

    private static string CleanDescription(string description, int level = 0)
    {
        return description?.Replace("\n", "\n" + new string('\t', level) + "/// ").Trim();
    }

    private static string GetBaseName(string name)
    {
        return Suffixes.Aggregate(name,
            (current, suffix) => current.EndsWith(suffix) ? current.Replace(suffix, "") : current);
    }
}