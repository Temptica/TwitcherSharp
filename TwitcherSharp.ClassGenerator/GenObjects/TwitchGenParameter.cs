namespace ClassGenerator.GenObjects;

public class TwitchGenParameter : IComparable<TwitchGenParameter>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Required { get; set; }
    public string Type { get; set; }
    public bool IsTime { get; set; }
    public bool IsArray { get; set; }

    public int CompareTo(TwitchGenParameter other)
    {
        if (Name == "broadcaster_id")
            return -1;
        if (other.Name == "broadcaster_id")
            return 1;
        return Required switch
        {
            true when !other.Required => 1,
            false when other.Required => -1,
            _ => string.CompareOrdinal(Name, other.Name)
        };
    }
    
    public string GetTypeString()
    {
        return IsArray ? $"{Type}[]" : Type;
    }

    public string GetTypeDefault()
    {
        if (IsArray) return "[]";
        return Type switch
        {
            "string" => "\"\"",
            "int" => "0",
            "double" => "0",
            "bool" => "false",
            _ => "null"
        };
    }
}