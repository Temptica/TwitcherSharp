using System.Text;
using ClassGenerator.Extensions;
using ClassGenerator.GenObjects.Api;

namespace ClassGenerator.Generator.Api;

public static class ApiCodeHelper
{
    private static readonly string[] Suffixes = ["Response", "Body", "Opt"];

    #region API

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
            methodString.AppendIndentedLine(
                $"/// <param name=\"body\"><see cref=\"{method.BodyType.Replace("<T>", "&lt;T&gt;")}\"/></param>", 1);
        if (method.ContainsOptional)
            methodString.AppendIndentedLine(
                $"/// <param name=\"opt\"><see cref=\"{method.GetOptionalClassName()}\"/></param>", 1);

        if (method.RequiredParameters.Count != 0)
        {
            methodString.AppendIndentedLine(GetMethodParameterSummary(method.RequiredParameters).TrimEnd(), 1);
        }

        methodString.AppendIndentedLine(
            $"/// <returns><see cref=\"{method.ResultType.Replace("<T>", "&lt;T&gt;")}\"/></returns>", 1);

        methodString
            .AppendIndentedLine(
                $"public async Task<{method.ResultType}> {method.Name}{(method.HasGeneric ? $"<T>" : "")}({GetMethodParameter(method)}){(method.HasGeneric ? $" where T : RefCounted, {method.GenericType}" : "")}",
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
            var description = parameter.Description.Replace("\\_", "_");
            if (description.Contains("* ") && !description.Contains("**"))
            {
                var idx = description.IndexOf('*');
                description = description.Insert(idx, "<list type=\"bullet\">\n");

                while (description.Contains('*'))
                {
                    var starIdx = description.IndexOf('*');
                    description = description.Remove(starIdx, 1);
                    description = description.Insert(starIdx, "<item>");
                    var nextNewLine = description.IndexOf('\n', starIdx + 7);
                    if (nextNewLine == -1) nextNewLine = description.Length;
                    description = description.Insert(nextNewLine, "</item>");
                }

                var lastIdx = description.LastIndexOf("</item>", StringComparison.Ordinal);

                description = description.Insert(lastIdx + 7, "\n</list>");
            }

            code.AppendIndentedLine(
                $"/// <param name=\"{parameter.Name.ToCamelCase()}\">{description}</param>", 0, "/// ");
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

        paramsList.AddRange(method.RequiredParameters.Select(p => p.Type.Contains("[]")
            ? $"new Godot.Collections.Array<{p.Type.Remove("[]")}>({p.Name.ToCamelCase()})"
            : p.Name.ToCamelCase()));

        return string.Join(", ", paramsList);
    }

    #endregion

    #region Components

    public static string GlobalComponentCode(TwitchGenComponent component, string type = "")
    {
        var code = new StringBuilder();

        var componentsToCheck = component.SubComponents.ToList();
        var nameSpacesToUse = component.InterfacesToImplement
            .Select(i => i.NameSpace)
            .ToHashSet();

        while (componentsToCheck.Count > 0)
        {
            var componentToCheck = componentsToCheck[0];
            componentsToCheck.RemoveAt(0);
            foreach (var genInterface in componentToCheck.InterfacesToImplement)
            {
                nameSpacesToUse.Add(genInterface.NameSpace);
            }

            if (componentToCheck.GetNameSpace() != component.GetNameSpace())
            {
                nameSpacesToUse.Add(componentToCheck.GetNameSpace());
            }

            componentsToCheck.AddRange(componentToCheck.SubComponents);
        }

        foreach (var nameSpace in nameSpacesToUse)
        {
            code.AppendLine($"using TwitcherSharp.Api.Generated.{nameSpace};");
        }


        code.AppendLine(ApiCodeStrings.ComponentUsings
            .Replace("{{root}}", component.GetNameSpace()));
        code.AppendLine();


        var componentCode = ComponentCode(component, out var usings, type);

        foreach (var @using in usings.Distinct())
        {
            code.Insert(0, $"using {@using};\n");
        }

        code.AppendIndentedLine(componentCode);

        code.AppendLine("}");
        return code.ToString();
    }

    private static string ComponentCode(TwitchGenComponent component, out List<string> usings, string type = "")
    {
        usings = [];
        var code = new StringBuilder();

        if (!string.IsNullOrWhiteSpace(component.Description))
        {
            code.AppendIndentedLine($"\n<summary> \n{component.Description} \n</summary>", 0, "/// ");
        }

        var interfacesToImplement = string.Join(", ", component.InterfacesToImplement.Select(i => i.InterfaceName));
        if (interfacesToImplement != "") interfacesToImplement = ", " + interfacesToImplement;

        if (component.HasGeneric)
        {
            code.AppendLine(ApiCodeStrings.GenericComponentHeader
                .Replace("{{className}}", component.ClassName)
                .Replace("{{interfaces}}", interfacesToImplement)
                .Replace("{{type}}", $"RefCounted, {component.GenericType}"));
        }
        else
        {
            code.AppendLine(ApiCodeStrings.ComponentHeader
                .Replace("{{className}}", component.ClassName)
                .Replace("{{interfaces}}", interfacesToImplement));
        }

        //PROPS
        var fields = component.GetAllFields();

        foreach (var field in fields)
        {
            if (field.TypedComponent?.InterfacesToImplement.Count > 0)
            {
                foreach (var genInterface in field.TypedComponent.InterfacesToImplement)
                {
                    usings.Add("TwitcherSharp.Api.Generated." + genInterface.NameSpace);
                }
            }

            if (field.TypedComponent?.InterfacesToImplement.Count > 0 && type == "")
            {
                //Only if all subfields match, use interface type
                var @interface = field.TypedComponent?.InterfacesToImplement[0].InterfaceName;
                // get => field ??= _data?.GetArray<TwitchResponseData>("data");
                code.AppendIndentedLine(
                    $"public {@interface}{(field.IsRequired || field.IsNullableTyped ? "" : "?")}{(field.IsArray ? "[]" : "")} {field.Name} {{ get => field ??= _data?.{(field.IsArray ? $"GetArray<{field.Type}>" : $"Get<{field.Type}>")}(\"{field.SnakeCaseKey}\"); set; }}",
                    1);
                continue;
            }

            if (component.HasGeneric && component.GenericField.Equals(field))
            {
                var fieldType = field.TypedComponent?.HasGeneric == true
                    ? field.CleanedType
                    : component.GenericType;

                if (field.Equals(component.GenericField))
                {
                    code.AppendIndentedLine(
                        $"public {fieldType}{(field.IsRequired || field.IsNullableTyped ? "" : "?")} {field.Name} {{ get => field ??= {(field.IsArray ? $"_data?.GetArray<{fieldType.Remove("[]")}>(\"data\")" : "T.FromDictionary(_data?.Get(\"{field.SnakeCaseKey}\").AsGodotDictionary())")}; set; }}",
                        1);
                    continue;
                }

                code.AppendIndentedLine(
                    $"public {fieldType}{(field.IsRequired || field.IsNullableTyped ? "" : "?")} {field.Name} {{ get => field ??= _data?.{(field.IsArray ? $"GetArray<{fieldType}>" : $"Get<{fieldType}>")}(\"{field.SnakeCaseKey}\"); set; }}",
                    1);

                continue;
            }

            if (field.IsTyped)
            {
                code.AppendIndentedLine(
                    $"public {field.CleanedType}{(field.IsRequired || field.IsNullableTyped ? "" : "?")} {field.Name} {{ get => field ??= _data?.{(field.IsArray ? $"GetArray<{field.Type}>" : $"Get<{field.Type}>")}(\"{field.SnakeCaseKey}\"); set; }}",
                    1);
                continue;
            }

            code.AppendIndentedLine(
                $"public {field.CleanedType}{(field.IsRequired || field.IsNullableTyped ? "" : "?")} {field.Name} {{ get; set; }}",
                1);
        }

        //FROM OBJECT
        code.AppendLine();
        code.AppendIndentedLine(
            (component.HasGeneric
                ? ApiCodeStrings.GenericComponentFromBody
                : ApiCodeStrings.ComponentFromBody)
            .Replace("{{className}}", component.ClassName), 1);

        var nonTypedFields = fields.Where(f => !f.IsTyped && !f.Equals(component.GenericField)).ToList();

        code.AppendIndentedLine(
            $"var instance = new {component.ClassName}{(component.HasGeneric ? "<T>" : "")}{(nonTypedFields.Count == 0 ? "();" : "")}",
            2);

        if (nonTypedFields.Count > 0)
        {
            code.AppendIndentedLine("{", 2);

            foreach (var field in nonTypedFields)
            {
                code.AppendIndentedLine($"{field.Name} = data.Get(\"{field.SnakeCaseKey}\").{field.GetAsType()},",
                    3);
            }

            code.AppendIndentedLine("};", 2);
        }
        
        code.AppendIndentedLine("\ninstance._data = data;\nreturn instance;", 2);

        code.AppendIndentedLine("}", 1);
        code.Append(Environment.NewLine);

        //TO OBJECT
        code.AppendIndentedLine("public GodotObject ToGodotObject()", 1);
        code.AppendIndentedLine("{", 1);
        var path = $"res://addons/twitcher/generated/{GetBaseName(component.ClassName).ToSnakeCase()}.gd";

        if (component.ParentCount > 0 && !component.IsGlobal)
            path =
                $"res://addons/twitcher/generated/{GetBaseName(component.GetGlobalRootParent().ClassName).ToSnakeCase()}.gd";

        code.AppendIndentedLine($"var script = GD.Load<GDScript>(\"{path}\");", 2);


        var scriptName = "script";
        if (!string.IsNullOrEmpty(type))
        {
            code.AppendIndentedLine($"var {type.ToCamelCase()}Class = script.Get(\"{type}\").AsGodotObject();", 2);
            scriptName = $"{type.ToCamelCase()}Class";
        }
        else if (component.ParentCount > 0 && !component.IsGlobal)
        {
            var className = component.GetGlobalRootParent().ClassName.Contains("Response")
                ? component.ClassName.Remove("Twitch")
                : component.ClassName.Remove("TwitchResponse").Remove("Twitch");
            code.AppendIndentedLine(
                $"var {component.ClassName.ToCamelCase()}Class = script.Get(\"{className}\").AsGodotObject();",
                2);
            scriptName = $"{component.ClassName.ToCamelCase()}Class";
        }

        code.AppendIndentedLine($"var request = {scriptName}.Call(\"new\").AsGodotObject();", 2);
        foreach (var field in fields)
        {
            if (field.IsArray && field.IsTyped)
            {
                code.AppendIndentedLine(
                    $"if({field.Name} != null) request.SetArray(\"{field.SnakeCaseKey}\", {field.Name});",
                    2);
                continue;
            }

            if (field.IsArray)
            {
                code.AppendIndentedLine(
                    $"if({field.Name} != null) request.Set(\"{field.SnakeCaseKey}\", new Godot.Collections.Array<{field.CleanedArrayType}>({field.Name}));",
                    2);
                continue;
            }

            if (component.HasGeneric && field.Equals(component.GenericField))
            {
                code.AppendIndentedLine(
                    $"if({field.Name} != null) request.Set(\"{field.SnakeCaseKey}\", new Godot.Collections.Dictionary<string,Variant>({field.Name}.ToDictionary()));",
                    2);
                continue;
            }

            if (!field.IsRequired)
            {
                if (field.IsNullableTyped)
                {
                    if (field.CleanedType.Contains("[]"))
                    {
                        code.AppendIndentedLine(
                            $"if({field.Name} != null) request.Set(\"{field.SnakeCaseKey}\", new Godot.Collections.Array<{field.CleanedArrayType.Remove("[]")}>({field.Name}));",
                            2);
                        continue;
                    }

                    code.AppendIndentedLine($"if({field.Name} != null) " + (
                            field.Type == "Object"
                                ? $"request.Set(\"{field.SnakeCaseKey}\", {field.Name}?.ToGodotObject());"
                                : $"request.Set(\"{field.SnakeCaseKey}\", {field.Name});"),
                        2);

                    continue;
                }

                code.AppendIndentedLine(
                    $"if({field.Name}.HasValue) " + (field.Type == "Object"
                        ? $"request.Set(\"{field.SnakeCaseKey}\", {field.Name}.Value.ToGodotObject());"
                        : $"request.Set(\"{field.SnakeCaseKey}\", {field.Name}.Value);"),
                    2);
                continue;
            }

            code.AppendIndentedLine(
                field.IsTyped
                    ? $"request.Set(\"{field.SnakeCaseKey}\", {field.Name}?.ToGodotObject());"
                    : $"request.Set(\"{field.SnakeCaseKey}\", {field.Name});",
                2);
        }

        code.AppendIndentedLine("return request;", 2);
        code.AppendIndentedLine("}", 1);

        if (component.HasPagination)
        {
            usings.Add("TwitcherSharp.Extensions");
            code.AppendIndented(ApiCodeStrings.NextPageCode.Replace("{{response}}", component.ClassName +
                (component.HasGeneric ? "<T>" : "")), 1);
            code.AppendLine();
            code.AppendIndentedLine(
                ComponentCode(component.SubComponents.Single(c => c.IsPagination), out var subUsings,
                    "ResponsePagination"),
                1);
            usings.AddRange(subUsings);
            code.AppendIndentedLine("}", 1);
        }

        foreach (var subComponent in component.SubComponents.Where(c => !c.IsGlobal && !c.IsPagination))
        {
            code.AppendIndentedLine(ComponentCode(subComponent, out var subUsings), 1);
            usings.AddRange(subUsings);
            code.AppendIndentedLine("}", 1);
        }

        foreach (var twitchGenInterface in component.InterfacesToImplement)
        {
            foreach (var subComponent in twitchGenInterface.Fields.Where(f => f.IsTyped).Select(f => f.TypedComponent))
            {
                if (component.SubComponents.Any(c => c.Equals(subComponent))) continue;

                code.AppendIndentedLine(ComponentCode(subComponent, out var subUsings), 1);
                usings.AddRange(subUsings);


                code.AppendIndentedLine("}", 1);
            }
        }

        return code.ToString();
    }

    public static string InterfaceCode(TwitchGenInterface genInterface)
    {
        var code = new StringBuilder();
        if (genInterface.Fields.Any(f => f.IsTyped))
        {
            var nameSpaces = new HashSet<string> { genInterface.NameSpace };
            foreach (var typedComponent in genInterface.Fields.Where(f => f.IsTyped)
                         .Select(f => f.TypedComponent).Distinct())
            {
                if (typedComponent.InterfacesToImplement.Count > 0)
                {
                    foreach (var @interface in typedComponent.InterfacesToImplement.Select(i => i.NameSpace))
                    {
                        nameSpaces.Add(@interface);
                    }

                    continue;
                }

                nameSpaces.Add(typedComponent.GetNameSpace());
            }

            foreach (var nameSpace in nameSpaces.Where(n => !n.Equals(genInterface.NameSpace)))
            {
                code.AppendLine($"using TwitcherSharp.Api.Generated.{nameSpace};");
            }
        }

        code.AppendIndentedLine(ApiCodeStrings.InterfaceBody.Replace("{{nameSpace}}", genInterface.NameSpace)
            .Replace("{{interfaceName}}", genInterface.InterfaceName));

        foreach (var field in genInterface.Fields)
        {
            if (field.TypedComponent?.ParentInterfaces.Count > 0)
            {
                var @interface = field.TypedComponent?.InterfacesToImplement[0].InterfaceName;
                code.AppendIndentedLine(
                    $"public {@interface}{(field.IsRequired || field.IsNullableTyped ? "" : "?")} {field.Name} {{ get; set; }}",
                    1);
                continue;
            }

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

    #endregion
}