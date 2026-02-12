using ClassGenerator.Extensions;

namespace ClassGenerator.GenObjects.EventSub;

public class TwitchEventSubGenComponent(string name)
{
    public string ClassName
    {
        get;
    } = SanitizeName(name);

    public string Description { get; set; }

    public TwitchEventSubGenComponent Parent { get; set; }

    public List<TwitchEventSubGenComponent> SubComponents { get; } = [];

    public List<TwitchEventSubGenField> Fields { get; } = [];

    public bool IsRoot => Parent == null;

    public void AddField(TwitchEventSubGenField field)
    {
        Fields.Add(field);
    }

    public void AddSubComponent(TwitchEventSubGenComponent component)
    {
        SubComponents.Add(component);
        component.Parent = this;

        var field = new TwitchEventSubGenField(component.ClassName.Replace("Twitch", ""), component.Description,
            component.ClassName)
        {
            TypedComponent = component
        };
        Fields.Add(field);
    }

    private static string SanitizeName(string name) => name.StartsWith("Twitch") ? name:$"Twitch{name.ToPascalCase()}";
}