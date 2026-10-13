namespace ClassGenerator.Generator;

/// <summary>
/// The code that reads a property from a twitcher object: the ReadAs… helper of InteropExtension for the common
/// types (<c>ReadAsString("id")</c>), else Read with a conversion (<c>Read("id", static v => v.As&lt;T&gt;())</c>).
/// </summary>
public static class ReadCall
{
    private static readonly HashSet<string> Helpers =
        ["AsString()", "AsBool()", "AsInt32()", "AsInt64()", "AsDouble()", "AsStringArray()"];

    /// <param name="propertyName">The twitcher property to read</param>
    /// <param name="asType">The Variant conversion, like <c>AsString()</c></param>
    public static string For(string propertyName, string asType)
    {
        return Helpers.Contains(asType)
            ? $"ReadAs{asType[2..^2]}(\"{propertyName}\")"
            : $"Read(\"{propertyName}\", static v => v.{asType})";
    }
}
