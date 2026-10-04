using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub;

public partial class TwitchEventSubConfig() : RefCounted, ITwitcherSharp<TwitchEventSubConfig>
{
    private const string ScriptPath = "res://addons/twitcher/eventsub/twitch_eventsub_config.gd";

    private Variant _data;

    private TwitchEventSubDefinitionType _type;
    public TwitchEventSubDefinitionType Type
    {
        get => _type;
        set
        {
            if(_type == value) return;
            
            UpdateType(value);
        }
    }

    public List<ITwitcherSharpCondition> Condition { get; set; } = [];
    public TwitchEventSubDefinition Definition => TwitchEventSubDefinition.All.First(x => x.Type == Type);

    public string? Id { get; set; }

    [Signal]
    public delegate void TypeChangedEventHandler(TwitchEventSubDefinitionType type);

    public TwitchEventSubConfig(TwitchEventSubDefinition definition, IList<ITwitcherSharpCondition> conditions) : this()
    {
        Type = definition.Type;
        Condition = conditions.ToList();
        foreach (var condition in Condition.Select(x => x.Name))
        {
            if (definition.Conditions?.Contains(condition) != true)
            {
                GD.PushError($"Following conditions may be missing: {condition}");
            }
        }
    }

    private TwitchEventSubDefinitionType UpdateType(TwitchEventSubDefinitionType type)
    {
        if (type == Type) return Type;

        var definition = TwitchEventSubDefinition.All.First(x => x.Type == type);
        Condition = Condition.Where(x => definition.Conditions?.Contains(x.Name) == true).ToList();
        _type = type;
        EmitSignalTypeChanged(type);
        return Type;
    }

    public static TwitchEventSubConfig? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var config = new TwitchEventSubConfig { _data = Variant.CreateFrom(data) };
        // twitcher numbers its types in another order than TwitchEventSubDefinitionType: map through the definition.
        var definition = data.Read("definition", static v => v.With(TwitchEventSubDefinition.FromObject));
        if (definition is not null) config.Type = definition.Type;
        config.Id = data.Read("id", static v => v.AsString());
        return config;
    }

    /// <summary>
    /// The twitcher config this was mapped from (twitcher tells subscriptions apart by object), or a new one.
    /// The caller owns the returned wrapper.
    /// </summary>
    public GodotObject ToGodotObject()
    {
        if (!_data.IsNil) return _data.AsGodotObject();

        var data = InteropExtension.NewObject(ScriptPath);
        data.SetValue("type", Definition.TwitcherType);

        // twitcher keeps the conditions of all condition objects in one Dictionary.
        using var condition = new Godot.Collections.Dictionary();
        foreach (var part in Condition)
        {
            using var values = part.ToDictionary();
            foreach (var (key, value) in values)
            {
                using (key)
                using (value)
                {
                    condition[key] = value;
                }
            }
        }

        data.Set("condition", condition);
        if (Id != null) data.SetValue("id", Id);
        return data;
    }

    /// <summary> Releases the twitcher object this config was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        // Only when disposed explicitly: when finalized, the Variant is finalized on its own.
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}