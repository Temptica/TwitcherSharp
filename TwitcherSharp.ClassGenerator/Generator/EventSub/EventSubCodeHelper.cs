using System.Text;
using ClassGenerator.Extensions;
using ClassGenerator.GenObjects.EventSub;

namespace ClassGenerator.Generator.EventSub;

public static class EventSubCodeHelper
{
    /// <summary>
    /// What twitcher's generator needs to name the classes nested under one root component: whether the root is a V2
    /// event (its nested classes get a V2 suffix) and the names already given (a repeated name gets its parent's name
    /// as prefix, like Fragments_Emote).
    /// </summary>
    private sealed class TwitcherNaming(bool isV2)
    {
        public bool IsV2 { get; } = isV2;
        public HashSet<string> Used { get; } = [];
    }

    /// <summary>
    /// twitcher's property name for a field: the JSON key. The fields of a V2 event carry a V2 suffix here (AutomodV2)
    /// that the key does not have (automod).
    /// </summary>
    private static string GodotName(TwitchEventSubGenField field) =>
        (field.Name.EndsWith("V2") ? field.Name[..^2] : field.Name).ToSnakeCase();

    /// <summary>
    /// twitcher's name for a nested class, following its TwitchAPIParser (_get_component_name), TwitchGenComponent
    /// (Image/Panel renamed) and TwitchEventsubGenerator (V2 suffix).
    /// </summary>
    private static string TwitcherNestedName(TwitchEventSubGenComponent component, string type, TwitcherNaming naming,
        string parentName)
    {
        var name = component.ClassName.Remove(type).Remove("Twitch");
        if (!naming.Used.Add(name) && !string.IsNullOrEmpty(parentName))
        {
            name = parentName.Replace("V2", "") + "_" + name;
            naming.Used.Add(name);
        }

        name = name switch
        {
            "Image" => "TwitchImage",
            "Panel" => "TwitchPanel",
            _ => name,
        };
        return naming.IsV2 ? name.Replace("V2", "").Replace("v2", "") + "V2" : name;
    }

    private const bool UseTwitcherEventSubV2 = true;

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
        bool isCondition = false, TwitcherNaming naming = null, string parentName = null)
    {
        // The names twitcher's generator gives the classes nested under this root (see TwitcherNestedName).
        naming ??= new TwitcherNaming(component.ClassName.Contains("V2"));
        var twitcherName = level == 0 && parentName == null ? null : TwitcherNestedName(component, type, naming, parentName);
        var code = new StringBuilder();

        var header = isCondition ? EventSubCodeStrings.ConditionSubHeader : EventSubCodeStrings.EventSubHeader;
        if (isCondition)
            header = header.Replace("{{requiredFields}}",
                string.Join(", ", component.Fields
                    .Where(f => f.Value.IsRequired)
                    .Select(f => $"{f.Value.Type} {f.Key.ToCamelCase()}")));
        code.AppendLine(header.Replace("{{ClassName}}", component.ClassName));

        code.AppendLine("{");
        code.AppendIndentedLine("private Variant _data;\n", 1);

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

            if ((field.IsArray && field.TypedComponent != null) || field.IsTyped)
            {
                code.AppendIndentedLine(
                    $"public {fieldType}{(field.IsRequired ? "" : "?")} {field.Name} {{ get => field ??= _data.Get{(field.IsArray ? "Array" : "")}<{field.Type.Remove("[]")}>(\"{GodotName(field)}\"); set; }}{(field.IsRequired ? $"= {field.Name.ToCamelCase()};" : "")}",
                    1);
            }
            else if (field.IsRequired)
                code.AppendIndentedLine(
                    $"public {fieldType} {field.Name} {{ get; set; }} = {field.Name.ToCamelCase()};", 1);
            else code.AppendIndentedLine($"public {fieldType}{(field.IsValueType ? "" : "?")} {field.Name} {{ get; set; }}", 1);

            if (field != fields[^1]) code.AppendLine();
        }

        //Only disable this for twitcher V2.4.0 and below.
        //Although the plugin doesn't really support those versions, it's there if you need it, at your own 'risk'.
        if (UseTwitcherEventSubV2)
        {
            //FROM OBJECT
            code.AppendLine();
            code.AppendLine(EventSubCodeStrings.ComponentFromBody.Replace("{{className}}", component.ClassName));

            if (isCondition && component.HasRequiredFields)
            {
                var requiredFields = string.Join(", ",
                    component.GetRequiredFields().Select(field =>
                        $"""data.Read("{GodotName(field)}", static v => v.{field.GetAsType()})"""));

                var requiredCode = $"var instance = new {component.ClassName}({requiredFields})";
                if (component.Fields.All(f => f.Value.IsRequired)) requiredCode += ";";
                code.AppendIndentedLine(requiredCode, 2);
            }
            else code.AppendIndentedLine($"var instance = new {component.ClassName}", 2);

            var nonRequiredFields = fields.Where(f => !isCondition || !f.IsRequired).ToList();

            if (nonRequiredFields.Count > 0)
            {
                code.AppendIndentedLine("{", 2);

                foreach (var field in nonRequiredFields)
                {
                    if (!field.IsArray && !field.IsTyped)
                        code.AppendIndentedLine(
                            $"{field.Name} = data.Read(\"{GodotName(field)}\", static v => v.{field.GetAsType()}),", 3);
                }

                code.AppendIndentedLine("};", 2);
            }

            code.AppendIndentedLine("\ninstance._data = Variant.CreateFrom(data);\nreturn instance;", 2);

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
                path =
                    $"res://addons/twitcher/generated_eventsub/{type.ToSnakeCase().Replace("twitch", "twitch_es").Replace("image", "twitch_image")}.gd";
            }


            string typeToUse;

            // twitcher keeps a V2 event in the file of the first version, as V2Event / V2Condition.
            if (component.ClassName.EndsWith("V2Event")) typeToUse = "V2Event";
            else if (component.ClassName.EndsWith("V2Condition")) typeToUse = "V2Condition";
            else if (component.ClassName.EndsWith("Event")) typeToUse = "Event";
            else if (component.ClassName.EndsWith("EventV2")) typeToUse = "EventV2";
            else if (component.ClassName.EndsWith("Condition")) typeToUse = "Condition";
            else if (component.ClassName.EndsWith("ConditionV2")) typeToUse = "ConditionV2";
            else
                typeToUse = component.IsShared
                    ? component.ClassName.Replace("Twitch", "TwitchES")
                    : twitcherName ?? component.ClassName.Remove(type).Remove("Twitch");

            code.AppendIndentedLine(component.IsShared
                ? $"var request = InteropExtension.NewObject(\"{path}\");"
                : $"var request = InteropExtension.NewInner(\"{path}\", \"{typeToUse}\");", 2);

            foreach (var field in fields)
            {
                string fieldCode;

                if (field.IsArray && (field.IsTyped || field.Type == "Object"))
                {
                    fieldCode =
                        $"if({field.Name} != null) request.SetArray(\"{GodotName(field)}\", {field.Name});";
                }
                else if (field.IsArray)
                {
                    fieldCode =
                        $"if({field.Name} != null) request.SetValue(\"{GodotName(field)}\", new Godot.Collections.Array<{field.Type.Remove("[]")}>({field.Name}));";
                }
                else if (field.Type == "Object" || field.IsTyped)
                {
                    fieldCode = $"if({field.Name} != null) request.SetObject(\"{GodotName(field)}\", {field.Name});";
                }
                else if (field.IsValueType || field.IsRequired)
                    fieldCode = $"request.SetValue(\"{GodotName(field)}\", {field.Name});";
                else fieldCode = $"if({field.Name} != null) request.SetValue(\"{GodotName(field)}\", {field.Name});";

                code.AppendIndentedLine(fieldCode, 2);
            }

            code.AppendIndentedLine("return request;", 2);
        }

        code.AppendIndentedLine("}", 1);

        code.AppendLine();
        code.AppendIndentedLine("/// <summary> Releases the twitcher object this instance was mapped from. </summary>", 1);
        code.AppendIndentedLine("protected override void Dispose(bool disposing)", 1);
        code.AppendIndentedLine("{", 1);
        // Only when disposed explicitly: when finalized, the Variant is finalized on its own, and disposing it again
        // throws on the finalizer thread, which ends the process.
        code.AppendIndentedLine("if (disposing) _data.Dispose();", 2);
        code.AppendIndentedLine("base.Dispose(disposing);", 2);
        code.AppendIndentedLine("}", 1);
        code.AppendLine();

        if (isCondition)
        {
            //FROM DICTIONARY

            var fromDictionaryCode = EventSubCodeStrings.FromDictionary.Replace("{{ClassName}}", component.ClassName);
            if (component.HasRequiredFields)
            {
                var requiredFields = string.Join(", ",
                    component.GetRequiredFields().Select(f => $"""data["{f.Name.ToSnakeCase()}"].{f.GetAsType()}"""));
                fromDictionaryCode = fromDictionaryCode.Replace("{{RequiredProperties}}", $"({requiredFields})");

                // var requiredCode = $"return new {component.ClassName}({requiredFields})";
                // if (component.Fields.Count(f => !f.Value.IsRequired) == 0) requiredCode += ";";
                // code.AppendIndentedLine(requiredCode, 2);
            }
            else
            {
                fromDictionaryCode = fromDictionaryCode.Remove("{{RequiredProperties}}");
            }

            code.AppendIndentedLine(fromDictionaryCode, 1);


            foreach (var field in component.Fields.Values.Where(f => !f.IsRequired))
            {
                var fieldCode = field switch
                {
                    //3 cases -> Normal/Array, TypedArray, Typed
                    { IsTyped: false } => $"""{field.Name} = data["{GodotName(field)}"].{field.GetAsType()},""",
                    { IsArray: false } =>
                        $"""{field.Name} = {field.Type}.FromData(data["{GodotName(field)}"].AsGodotDictionary()),""",
                    _ =>
                        $"""{field.Name} = data["{GodotName(field)}"].AsGodotArray().Select(x => {field.TypedComponent.ClassName}.FromData(x.AsGodotDictionary())).ToArray(),"""
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
                // Nullable reference fields need the null-forgiving operator to satisfy the Variant conversion.
                var bang = field.IsValueType || field.IsRequired ? "" : "!";
                var fieldCode = $$"""{"{{GodotName(field)}}", {{field.Name}}{{bang}}},""";

                code.AppendIndentedLine(fieldCode, 3);
            }

            code.AppendIndentedLine("};", 2);
            code.AppendIndentedLine("}", 1);
        }

        var nonSharedSubComponents = component.SubComponents.Values
            .Where(s => !s.IsShared)
            .ToList();
        foreach (var subComponent in nonSharedSubComponents)
        {
            code.AppendLine();
            code.AppendIndentedLine(GenerateComponent(subComponent, level, type, naming: naming,
                parentName: twitcherName ?? ""), level + 1);
            code.AppendIndentedLine("}", level + 1);
        }

        return code.ToString().TrimEnd();
    }
}