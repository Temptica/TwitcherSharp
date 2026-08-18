using ClassGenerator.Extensions;

namespace ClassGenerator.GenObjects.Api;

public class TwitchGenField : IEquatable<TwitchGenField>
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

    /// <summary>
    /// The GDScript key for this field. <see cref="Name"/> special-cases a handful of raw Twitch schema
    /// keys (leading digits, dots) into valid C# identifiers by underscore-prefixing them — GDScript needed
    /// the exact same trick for the exact same reason, so <c>@export var _100x100</c> is the real property
    /// name on the addon side too, not <c>100x100</c>. Round-tripping <see cref="Name"/> through
    /// <see cref="StringExtension.ToSnakeCase"/> for these wrongly strips (and sometimes mangles) that
    /// leading underscore, so they're passed through verbatim instead.
    /// </summary>
    public string SnakeCaseKey => Name switch
    {
        "_1" or "_2" or "_3" or "_4" or "_1_5" or "_100x100" or "_24x24" or "_300x200" => Name,
        _ => Name.ToSnakeCase()
    };

    public string Description { get; set; }
    public string Type { get; set; }
    public bool IsRequired { get; set; }
    public bool IsNullableTyped => IsTyped || IsArray || Type == "string" || Type == "string[]";
    public bool IsArray { get; set; }
    public string CleanedType => CleanedArrayType + (IsArray ? "[]" : "");
    public string CleanedArrayType => Type.Split('/')[^1] + (TypedComponent?.HasGeneric == true ? "<T>" : "");
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
            _ when CleanedType.Contains("Dictionary<string,") =>
                $"AsGodotDictionary<string,{CleanedArrayType.Replace("Godot.Collections.Dictionary<string,", "").Replace(">", "")}>()",
            _ => $"As<{CleanedType}>()",
        };
    }

    public TwitchGenComponent TypedComponent { get; set; }

    public bool Equals(TwitchGenField other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Name == other.Name;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj is not TwitchGenField field) return false;
        return Name.Equals(field.Name) && Type.Equals(field.Type);
    }
}