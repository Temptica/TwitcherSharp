using ClassGenerator.Extensions;

namespace ClassGenerator.GenObjects.Api;

public class TwitchGenField
{
    public string Name
    {
        get;
        init => field = value switch
        {
            "1" => "_1",
            "2" => "_2",
            "3" => "_3",
            "4" => "_4",
            "1.5" => "_1_5",
            "100x100" => "_100x100",
            "24x24" => "_24x24",
            "300x200" => "_300x200",
            _ => value.ToPascalCase()
        };
    }

    public string Description { get; set; }
    public string Type { get; set; }
    public bool IsRequired { get; set; }
    public bool IsNullableTyped => IsTyped || IsArray || Type == "string" || Type == "string[]";
    public bool IsArray { get; set; }
    public string CleanedType => Type.Split('/')[^1] + (IsArray ? "[]" : "");
    public string CleanedArrayType => Type.Split('/')[^1];
    public bool IsTyped => TypedComponent != null;
    public string GetAsType()
    {
        return CleanedType switch
        {
            "string" => "AsString()",
            "bool" => "AsBool()",
            "int" => "AsInt32()",
            "double" => "AsDouble()",
            "string[]" => "AsStringArray()",
            "int[]" => "AsInt32Array()",
            "double[]" => "AsFloat64Array()",
            _ => $"As<{CleanedType}>()",
        };
    }
    
    public TwitchGenComponent TypedComponent { get; set; }
}