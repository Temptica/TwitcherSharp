namespace ClassGenerator.GenObjects;

public class TwitchGenComponent(string name, string @ref, string description)
{
    public string ClassName { get;
        set => field = SanitizeName(value);
    } = SanitizeName(name);
    public string Ref { get; set; } = @ref;
    public string Description { get; set; } = description;
    private List<TwitchGenField> Fields { get; set; } = [];
    private Dictionary<string, TwitchGenField> FieldsMap { get; set; } = [];
    private List<TwitchGenComponent> ParentComponent { get; set; } = [];
    
    private Dictionary<string, TwitchGenComponent> SubComponents { get; set; } = [];
    public bool IsRoot => !IsGlobal && ParentComponent.Count == 0;
    public bool HasPaging { get; set; }
    public bool IsGlobal { get; set; } = true;

    private Dictionary<string, string> Meta { get; set; } = [];

    public void AddField(TwitchGenField field)
    {
        Fields.Add(field);
        FieldsMap[field.Name] = field;
        if (field.Name == "Pagination") HasPaging = true;
    }

    public IList<TwitchGenField> GetAllFields() => Fields;

    public string Tag { private get; set; }
    
    public string GetTag()
    {
        if (!string.IsNullOrEmpty(Tag))
        {
            return Tag;
        }

        if(IsGlobal || ParentComponent.Count == 0) return "Generic";
        
        return ParentComponent[0].GetTag() ;
    }

    private static string SanitizeName(string name) => name switch
    {
        "Image" => "TwitchImage",
        "Panel" => "TwitchPanel",
        _ => name
    };

    public void AddComponent(TwitchGenComponent component)
    {
        SubComponents.Add(component.ClassName, component);
        component.ParentComponent.Add(this);
    }

    public List<TwitchGenComponent> GetAllSubComponents() => SubComponents.Values.ToList();

    public bool HasMeta(string key)
    {
        return Meta.ContainsKey(key);
    }

    public void AddMeta(string key, string data)
    {
        Meta[key] = data;
    }

    public string GetMeta(string key)
    {
        return Meta[key];
    }
}