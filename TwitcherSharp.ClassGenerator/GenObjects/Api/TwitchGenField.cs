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

    public string Description { get; set; }
    public string Type { get; set; }
    public bool IsRequired { get; set; }
    public bool IsNullableTyped => IsTyped || IsArray || Type == "string" || Type == "string[]";
    public bool IsArray { get; set; }
    public string CleanedType => CleanedArrayType + (IsArray ? "[]" : "");
    public string CleanedArrayType => Type.Split('/')[^1] + (TypedComponent?.HasGeneric == true ? "<T>" : "");
    public bool IsTyped => TypedComponent != null;

    /// <summary>
    /// A scalar C# value type (non-array, non-class).
    /// </summary>
    public bool IsValueType => !IsArray && !IsTyped && Type is "int" or "bool" or "double" or "float" or "Variant";

    /// <summary>
    /// The nullability suffix to append to a property type under <c>&lt;Nullable&gt;enable</c>.
    /// Follows the Twitch API docs: fields the docs mark as required stay non-nullable, everything else is nullable.
    /// </summary>
    public string NullableSuffix => IsRequired ? "" : "?";

    /// <summary>
    /// Property initializer for required reference-type fields. These are always populated by FromObject, but that
    /// happens via an object initializer (after the parameterless constructor exits), which the compiler can't see -
    /// so it would otherwise flag the non-nullable property as possibly uninitialized (CS8618). `null!` tells the
    /// compiler to trust the factory method instead of forcing a real default (which would also break `field ??=`
    /// lazy-loading getters, since a non-null default like `[]` would short-circuit the `??=`).
    /// </summary>
    public string DefaultInitializer => IsRequired && !IsValueType ? " = null!;" : "";

    /// <summary>
    /// Null-forgiving operator for the lazy-load fetch (`_data?.Get&lt;T&gt;(...)`) of a required reference-type
    /// field: the fetch itself is nullable-typed (godot data COULD be absent), but the declared property type is
    /// non-nullable to match the Twitch docs, so the fetch needs to be asserted non-null to satisfy the getter's
    /// return type.
    /// </summary>
    public string RequiredBang => IsRequired && !IsValueType ? "!" : "";

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