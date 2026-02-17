namespace ClassGenerator.GenObjects.Api;

public class TwitchGenComponent(string name, string @ref, string description)
{
    public string ClassName
    {
        get;
        set => field = SanitizeName(value);
    } = SanitizeName(name);

    public string Ref { get; } = @ref;
    public string Description { get; } = description;
    private List<TwitchGenField> Fields { get; } = [];
    private List<TwitchGenComponent> ParentComponents { get; } = [];
    public List<TwitchGenComponent> SubComponents { get; } = [];
    public bool IsGlobal => ParentComponents.Count>1;

    private Dictionary<string, string> Meta { get; } = [];

    public void AddField(TwitchGenField field)
    {
        Fields.Add(field);
    }

    public IList<TwitchGenField> GetAllFields() => Fields;

    public string Tag { private get; set; }
    public bool IsBody => ClassName.EndsWith("Body");
    public bool IsOpt => ClassName.EndsWith("Opt");
    public bool IsResponse => ClassName.EndsWith("Response");

    public string GetTag()
    {
        if (!string.IsNullOrEmpty(Tag))
        {
            return Tag;
        }

        if (IsGlobal) return "Shared";
        else if (ParentComponents.Count == 0) return "";
        return ParentComponents[0].GetTag();
    }

    private static string SanitizeName(string name) => name.StartsWith("Twitch") ? name : $"Twitch{name}";

    public void AddComponent(TwitchGenComponent component)
    {
        SubComponents.Add(component);
        component.ParentComponents.Add(this);
    }

    public bool HasMeta(string key)
    {
        return Meta.ContainsKey(key);
    }
}