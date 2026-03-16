namespace ClassGenerator.GenObjects.Api;

public class TwitchGenInterface
{
    public string InterfaceName { get; init; }
    public string NameSpace { get; set; } = "Interfaces";
    public List<TwitchGenField> Fields { get; } = [];
    public List<TwitchGenComponent> SubComponents { get; } = [];
    public List<string> ComponentsToAdd { get; init; }
    public List<TwitchGenComponent> ComponentsToGenerate { get; } = [];
    
    public bool IsGlobal => NameSpace != "Interfaces";

    public TwitchGenInterface(string interfaceName, List<string> componentsToAdd)
    {
        if (!interfaceName.StartsWith('I')) interfaceName = "I" + interfaceName;
        InterfaceName = interfaceName;
        ComponentsToAdd = componentsToAdd;
    }

    public void AddFieldsRange(List<TwitchGenField> fields, List<TwitchGenComponent> subComponentsToGenerate)
    {
        Fields.AddRange(fields);
        foreach (var typedField in fields.Where(f => f.IsTyped))
        {
            typedField.TypedComponent.AddParentInterface(this);
            foreach (var subComponent in SubComponents) 
            {
                typedField.TypedComponent.AddParentComponent(subComponent);
            }
        }
        ComponentsToGenerate.AddRange(subComponentsToGenerate);
    }

    public void AddSubComponent(TwitchGenComponent component)
    {
        SubComponents.Add(component);
        component.ImplementInterface(this);
    }
}