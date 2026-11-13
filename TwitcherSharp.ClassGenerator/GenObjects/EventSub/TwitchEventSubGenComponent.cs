using ClassGenerator.Extensions;

namespace ClassGenerator.GenObjects.EventSub;

public class TwitchEventSubGenComponent(string name)
{
    public string ClassName { get; set; } = SanitizeName(name);

    public string Description { get; set; }

    public string Id { get; set; }

    public TwitchEventSubGenComponent Parent { get; set; }

    public Dictionary<string, TwitchEventSubGenComponent> SubComponents { get; } = [];

    public Dictionary<string, TwitchEventSubGenField> Fields { get; } = [];

    public bool IsRoot => Parent == null;

    public bool IsShared { get; set; }
    public bool HasRequiredFields => Fields.Any(f => f.Value.IsRequired);

    public List<TwitchEventSubGenField> GetRequiredFields() => Fields
        .Where(f => f.Value.IsRequired)
        .Select(f => f.Value)
        .ToList();

    public void AddField(TwitchEventSubGenField field)
    {
        Fields[field.Name] = field;
        if (field.IsArray && field.IsTyped)
        {
            AddFieldSubComponent(field.TypedComponent);
        }
    }

    public void AddSubComponent(TwitchEventSubGenComponent component)
    {
        SubComponents[component.ClassName] = component;
        component.Parent = this;

        var field = new TwitchEventSubGenField(component.ClassName.Replace("Twitch", ""), component.Description,
            component.ClassName)
        {
            TypedComponent = component
        };

        Fields[field.Name] = field;
    }

    private void AddFieldSubComponent(TwitchEventSubGenComponent component)
    {
        SubComponents[component.ClassName] = component;
        component.Parent = this;
    }

    private static string SanitizeName(string name) =>
        name.StartsWith("Twitch") ? name : $"Twitch{name.ToPascalCase()}";
}