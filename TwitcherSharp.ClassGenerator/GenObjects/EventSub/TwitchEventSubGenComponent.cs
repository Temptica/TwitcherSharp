using ClassGenerator.Extensions;

namespace ClassGenerator.GenObjects.EventSub;

public class TwitchEventSubGenComponent(string name)
{
    public string ClassName { get; set; } = SanitizeName(name);

    public string NameSpace { get; set; }

    public string Description { get; set; }

    public TwitchEventSubGenComponent Parent { get; set; }

    public Dictionary<string, TwitchEventSubGenComponent> SubComponents { get; } = [];

    public Dictionary<string, TwitchEventSubGenField> Fields { get; } = [];

    public bool IsShared { get; set; }
    public bool HasRequiredFields => Fields.Any(f => f.Value.IsRequired);

    public List<TwitchEventSubGenField> GetRequiredFields() => Fields
        .Where(f => f.Value.IsRequired)
        .Select(f => f.Value)
        .ToList();

    public void AddField(TwitchEventSubGenField field)
    {
        Fields[field.Name] = field;
        if (field.IsTyped) AttachSubComponent(field.TypedComponent);
    }

    public void ReplaceSubComponent(TwitchEventSubGenComponent existing, TwitchEventSubGenComponent replacement)
    {
        SubComponents.Remove(existing.ClassName);
        AttachSubComponent(replacement);

        foreach (var field in Fields.Values.Where(f => f.TypedComponent == existing))
        {
            field.TypedComponent = replacement;
        }
    }

    private void AttachSubComponent(TwitchEventSubGenComponent component)
    {
        SubComponents[component.ClassName] = component;
        if (!component.IsShared) component.Parent = this;
    }

    private static string SanitizeName(string name) =>
        name.StartsWith("Twitch") ? name : $"Twitch{name.ToPascalCase()}";
}
