using ClassGenerator.Extensions;

namespace ClassGenerator.GenObjects.EventSub;

public class TwitchEventSubGenField(string fieldName, string description, string type)
{
    public string Name { get; } = fieldName.ToPascalCase();
    public string Description { get; } = description;
    public string Type { get; set; } = SanitizeType(type, fieldName);
    public bool IsArray { get; set; }
    public bool IsTyped => Type.Contains("Twitch");
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
            _ => $"As<{Type}>()",
        };
    }

    private static string SanitizeType(string type, string name) =>
        type.ToLower() switch
        {
            "integer" => "int",
            "int (or null)" => "int", //WHY TWITCH??
            "[]string" => "string[]", // cmn....
            "number" => "double",
            "boolean" => "bool",
            "bool" => "bool",
            "object" when name == "Text" => "string",
            "object" when name == "Prefix" => "string",
            "string" => "string",
            "int" => "int",
            _ => type.ToPascalCase()
        };
}