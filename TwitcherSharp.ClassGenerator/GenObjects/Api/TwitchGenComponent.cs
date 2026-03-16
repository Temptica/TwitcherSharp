namespace ClassGenerator.GenObjects.Api;

public class TwitchGenComponent(string name, string @ref, string description) : IEquatable<TwitchGenComponent>
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
    private List<TwitchGenInterface> ParentInterfaces { get; } = [];
    public List<TwitchGenComponent> SubComponents { get; } = [];
    public List<TwitchGenInterface> InterfacesToImplement { get; } = [];
    public bool IsGlobal => ParentComponents.Count > 1;

    public void AddField(TwitchGenField field)
    {
        Fields.Add(field);
    }

    public IList<TwitchGenField> GetAllFields() => Fields;

    public string NameSpace { private get; set; }
    public bool IsBody => ClassName.EndsWith("Body");
    public bool IsOpt => ClassName.EndsWith("Opt");
    public bool IsResponse => ClassName.EndsWith("Response");

    public string GetNameSpace()
    {
        if (!string.IsNullOrEmpty(NameSpace))
        {
            return NameSpace;
        }
        
        if (ParentComponents.Count == 0) return "";
        var parentTags = ParentComponents.Select(c => c.GetNameSpace()).ToHashSet();
        foreach (var parentInterface in ParentInterfaces.Select(pi=>pi.NameSpace)) parentTags.Add(parentInterface);
        return parentTags.Count == 1 ? ParentComponents[0].GetNameSpace() : "Shared";
    }

    private static string SanitizeName(string name) => name.StartsWith("Twitch") ? name : $"Twitch{name}";

    public void AddComponent(TwitchGenComponent component)
    {
        SubComponents.Add(component);
        component.ParentComponents.Add(this);
    }

    public void AddParentInterface(TwitchGenInterface twitchGenInterface)
    {
        ParentInterfaces.Add(twitchGenInterface);
    }

    public void AddParentComponent(TwitchGenComponent component)
    {
        ParentComponents.Add(component);
    }

    public TwitchGenComponent GetParentOrNull()
    {
        return ParentComponents.Count == 1 ? ParentComponents[0] : null;
    }

    public void ImplementInterface(TwitchGenInterface twitchGenInterface)
    {
        InterfacesToImplement.Add(twitchGenInterface);
    }
    
    public (List<TwitchGenField> fields, List<TwitchGenComponent> subComponentsToGenerate) IntersectAndRemove(List<TwitchGenComponent> others)
    {
        var intersection = Fields;
        var subComponentsToGenerate = new List<TwitchGenComponent>();
        foreach (var component in others)
        {
            intersection = intersection.Intersect(component.Fields).ToList();
        }
        
        foreach (var subComponent in intersection.Where(f => f.IsTyped).Select(f =>f.TypedComponent))
        {
            subComponentsToGenerate.Add(subComponent);
            subComponent.ParentComponents.Remove(this);
            if (others.Select(o => o.GetNameSpace()).Distinct().Count() == 1)
            {
                subComponent.NameSpace = others[0].GetNameSpace();
            }
            
            foreach (var otherSubComponent in others.SelectMany(c => c.SubComponents).Where(sc => sc.Equals(subComponent)).ToList())
            {
                foreach (var otherSubParentComponent in otherSubComponent.ParentComponents)
                {
                    otherSubParentComponent.SubComponents.Remove(otherSubComponent);
                }
            }
        }
        
        return (intersection, subComponentsToGenerate);
    }

    public bool Equals(TwitchGenComponent other)
    {
        if (other == null) return false;
        return ClassName == other.ClassName || Ref == other.Ref;
    }
    public override int GetHashCode()
    {
        return ClassName.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj is not TwitchGenComponent component) return false;
        return component.ClassName.Equals(ClassName) || component.Ref.Equals(Ref);
    }

    public bool HasParentInterface()
    {
        return ParentInterfaces.Count > 0;
    }
}