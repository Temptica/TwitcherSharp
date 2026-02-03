using System.Text;
using ClassGenerator.Extensions;
using ClassGenerator.GenObjects;

namespace ClassGenerator.Generator;

public static class CodeHelper
{
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
            methodString.AppendIndentedLine($"/// <param name=\"body\">{method.BodyType}</param>", 1);
        if (method.ContainsOptional)
            methodString.AppendIndentedLine($"/// <param name=\"opt\">{method.GetOptionalClassName()}</param>", 1);
        // foreach (var methodRequiredParameter in method.RequiredParameters)
        // {
        //     methodString.AppendIndentedLine(
        //         $"/// <param name=\"{methodRequiredParameter.Name.ToCamelCase()}\"></param>", 1);
        // }
        //
        // foreach (var methodOptionalParameter in method.OptionalParameters)
        // {
        //     methodString.AppendIndentedLine(
        //         $"/// <param name=\"{methodOptionalParameter.Name.ToCamelCase()}\"></param>", 1);
        // }

        methodString
            .AppendIndentedLine($"public async Task<{method.ResultType}> {method.Name}({GetMethodParameter(method)})",
                1);

        methodString
            .AppendIndentedLine("{", 1);

        var methods = GetGodotMethodParameter(method, true);
        
        methodString.AppendIndentedLine(
            !string.IsNullOrEmpty(methods)
                ? $"return await _data.CallAsync<{method.ResultType}>(\"{method.ResultType.ToSnakeCase()}\", {methods}); "
                : $"return await _data.CallAsync<{method.ResultType}>(\"{method.ResultType.ToSnakeCase()}\"); ",
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

        // foreach (var parameter in method.RequiredParameters)
        // {
        //     parmsList.Add($"{parameter.GetTypeString()} {parameter.Name.ToCamelCase()}");
        // }
        //
        // foreach (var parameter in method.OptionalParameters)
        // {
        //     parmsList.Add($"{parameter.GetTypeString()} {parameter.Name.ToCamelCase()} = {parameter.GetTypeDefault()}");
        // }

        return string.Join(", ", parmsList);
    }

    private static string GetGodotMethodParameter(TwitchGenMethod method, bool toCamel = false)
    {
        var paramsList = new List<string>();
        if (method.ContainsBody) paramsList.Add("body");
        if (method.ContainsOptional) paramsList.Add("opt");
        // foreach (var parameter in method.RequiredParameters)
        //     paramsList.Add(toCamel ? parameter.Name.ToCamelCase() : parameter.Name);
        // foreach (var parameter in method.OptionalParameters)
        //     paramsList.Add(toCamel ? parameter.Name.ToCamelCase() : parameter.Name);
        return string.Join(", ", paramsList);
    }

    public static string ComponentCode(TwitchGenComponent component, string type = "")
    {
        var code = new StringBuilder();
        
        code.AppendLine(CodeStrings.ComponentHeader
            .Replace("{{root}}", component.GetTag())
            .Replace("{{description}}", CleanDescription(component.Description))
            .Replace("{{className}}", component.ClassName));

        //PROPS
        var fields = component.GetAllFields();
        
        foreach (var field in fields)
        {
            //public string TestObject { get; set; }
            code.AppendIndentedLine($"public {field.CleanedType} {field.Name} {{ get; set; }}", 1);
        }
        
        
        code.AppendLine(CodeStrings.ComponentFromBody.Replace("{{className}}", component.ClassName));
        code.Append(Environment.NewLine);

        //FROM OBJECT
        foreach (var field in fields)
        {
            code.AppendIndentedLine($"{field.Name} = data.Get(\"{field.Name.ToSnakeCase()}\").{field.GetAsType()},", 3);
        }

        code.AppendIndentedLine("};", 2);
        code.AppendIndentedLine("}", 1);
        code.Append(Environment.NewLine);

        //TO OBJECT
        code.AppendIndentedLine("public GodotObject ToGodotObject()", 1);
        code.AppendIndentedLine("{", 1);

        var path = $"res://addons/twitcher/generated/twitch_{component.ClassName.ToSnakeCase()}.gd";
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
}