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
}
