namespace ClassGenerator.GenObjects.EventSub;

public class TwitchEventSubDefinitionInfo
{
    public string EnumName { get; set; }
    public string Value { get; set; }
    public string Version { get; set; }
    public List<string> Conditions { get; set; } = [];
    public List<string> Scopes { get; set; } = [];
    public string DocumentationLink { get; set; }
    public string ScriptName { get; set; }

    /// <summary>
    /// True for a legacy alias definition (same subscription type, pointing at the pre-override,
    /// mechanically-derived script name) kept around so code already depending on it still compiles.
    /// See <see cref="EventSubScriptNameResolver"/>.
    /// </summary>
    public bool IsObsolete { get; set; }

    public TwitchEventSubDefinitionInfo Clone() => (TwitchEventSubDefinitionInfo)MemberwiseClone();
}
