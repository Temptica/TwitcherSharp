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

        if (method.RequiredParameters.Count != 0)
        {
            methodString.AppendIndented(GetMethodParameterSummary(method.RequiredParameters), 1);
        }

        methodString.AppendIndentedLine($"/// <returns><see cref=\"{method.ResultType}\"/></returns>",
            method.RequiredParameters.Count != 0 ? 1 : 0);

        methodString
            .AppendIndentedLine($"public async Task<{method.ResultType}> {method.Name}({GetMethodParameter(method)})",
                1);

        methodString
            .AppendIndentedLine("{", 1);

        var methods = GetGodotMethodParameter(method);

        methodString.AppendIndentedLine(
            !string.IsNullOrEmpty(methods)
                ? $"return await _data.CallAsync<{method.ResultType}>(\"{method.Name.ToSnakeCase()}\", {methods}); "
                : $"return await _data.CallAsync<{method.ResultType}>(\"{method.Name.ToSnakeCase()}\"); ",
            2);

        methodString.AppendIndentedLine("}", 1);

        return methodString.ToString();
    }

    private static string GetMethodParameterSummary(List<TwitchGenParameter> methodRequiredParameters)
    {
        var code = new StringBuilder();

        foreach (var parameter in methodRequiredParameters)
        {
            code.AppendIndentedLine(
                $"/// <param name=\"{parameter.Name.ToCamelCase()}\">{parameter.Description}</param>", 0, "/// ");
        }

        return code.ToString();
    }

    private static string GetMethodParameter(TwitchGenMethod method)
    {
        var parmsList = new List<string>();

        if (method.ContainsBody)
        {
            parmsList.Add($"{method.BodyType} body");
        }

        parmsList.AddRange(method.RequiredParameters.Select(p => $"{p.Type} {p.Name.ToCamelCase()}"));

        if (method.ContainsOptional)
        {
            parmsList.Add($"{method.GetOptionalClassName()} opt = null");
        }

        return string.Join(", ", parmsList);
    }

    private static string GetGodotMethodParameter(TwitchGenMethod method)
    {
        var paramsList = new List<string>();
        if (method.ContainsBody) paramsList.Add("body.ToGodotObject()");
        if (method.ContainsOptional) paramsList.Add("opt?.ToGodotObject()");

        paramsList.AddRange(method.RequiredParameters.Select(p => p.Name.ToCamelCase()));

        return string.Join(", ", paramsList);
    }

    public static string GlobalComponentCode(TwitchGenComponent component, string type = "")
    {
        var code = new StringBuilder();

        var componentsToCheck = component.SubComponents.ToList();
        var interfacesToImplement = component.InterfacesToImplement.ToHashSet();

        while (componentsToCheck.Count > 0)
        {
            var componentToCheck = componentsToCheck[0];
            componentsToCheck.RemoveAt(0);
            foreach (var genInterface in componentToCheck.InterfacesToImplement)
            {
                interfacesToImplement.Add(genInterface);
            }
            componentsToCheck.AddRange(componentToCheck.SubComponents);
        }

        foreach (var interfaceToCheck in interfacesToImplement)
        {
            code.AppendLine($"using TwitcherSharp.Api.Generated.{interfaceToCheck.NameSpace};");
        }
        
        code.AppendLine(ApiCodeStrings.ComponentUsings
            .Replace("{{root}}", component.GetNameSpace()));
        code.AppendLine();

        code.AppendIndentedLine(ComponentCode(component, type));

        code.AppendLine("}");
        return code.ToString();
    }

    private static string ComponentCode(TwitchGenComponent component, string type = "")
    {
        var code = new StringBuilder();

        if (!string.IsNullOrWhiteSpace(component.Description))
        {
            code.AppendIndentedLine($"\n<summary> \n{component.Description} \n</summary>", 0, "/// ");
        }

        var interfacesToImplement = string.Join(", ", component.InterfacesToImplement.Select(i => i.InterfaceName));
        if(interfacesToImplement != "") interfacesToImplement = ", " + interfacesToImplement;
        
        code.AppendLine(ApiCodeStrings.ComponentHeader
            .Replace("{{description}}", CleanDescription(component.Description))
            .Replace("{{className}}", component.ClassName)
            .Replace("{{interfaces}}", interfacesToImplement));

        //PROPS
        var fields = component.GetAllFields();

        foreach (var field in fields)
        {
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

        foreach (var subComponent in component.SubComponents.Where(c => !c.IsGlobal))
        {
            code.AppendIndentedLine(ComponentCode(subComponent), 1);
            code.AppendIndentedLine("}", 1);
        }

        return code.ToString();
    }

    public static string InterfaceCode(TwitchGenInterface genInterface)
    {
        var code = new StringBuilder();
        if (genInterface.Fields.Any(f => f.IsTyped))
        {
            if (genInterface.NameSpace == "Interfaces")
            {
                code.AppendLine("using TwitcherSharp.Api.Generated.Shared;");
            }
            else
            {
                foreach (var nameSpace in genInterface.Fields.Where(f => f.IsTyped).Select(f => f.TypedComponent.GetNameSpace()).Distinct())
                {
                    code.AppendLine($"using TwitcherSharp.Api.Generated.{nameSpace};");
                }
            }
        }

        code.AppendIndentedLine(ApiCodeStrings.InterfaceBody.Replace("{{nameSpace}}", genInterface.NameSpace).Replace("{{interfaceName}}", genInterface.InterfaceName));
        foreach (var field in genInterface.Fields)
        {
            code.AppendIndentedLine($"public {field.CleanedType} {field.Name} {{ get; set; }}", 1);
        }

        code.AppendIndentedLine("}");
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