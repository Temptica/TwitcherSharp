using ClassGenerator.Extensions;

namespace ClassGenerator.GenObjects.EventSub;

public class TwitchEventSubGenField(string fieldName, string description, string type, bool required = false)
{
    public string Name { get; } = fieldName.ToPascalCase();
    public string Description { get; } = description;
    public string Type { get; set; } = SanitizeType(type, fieldName);
    public bool IsArray { get; set; }
    public bool IsTyped => Type.Contains("Twitch");
    public bool IsRequired { get; set; } = required;
    public TwitchEventSubGenComponent TypedComponent { get; set; }

    public string GetAsType()
    {
        return Type switch
        {
            "string" => "AsString()",
            "bool" => "AsBool()",
            "int" => "AsInt32()",
            "double" => "AsDouble()",
            "string[]" => "AsStringArray()",
            "int[]" => "AsInt32Array()",
            "double[]" => "AsFloat64Array()",
            "Dictionary" => "AsGodotDictionary()",
            _ => $"As<{Type}>()",
        };
    }

    private static string SanitizeType(string type, string name) =>
        type.ToLower() switch
        {
            "integer" => "int",
            "int (or null)" => "int", //WHY TWITCH??
            "int" => "int",
            "number" => "double",
            "boolean" => "bool",
            "bool" => "bool",
            "[]string" => "string[]", // cmn....
            "string[]" => "string[]",
            "string" => "string",
            "dictionary" => "Dictionary",
            "object" when name == "Text" => "string",
            "object" when name == "Prefix" => "string",
            _ => type.ToPascalCase()
        };
}