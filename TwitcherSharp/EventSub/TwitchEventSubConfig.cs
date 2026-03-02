using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub;

public partial class TwitchEventSubConfig() : Resource, ITwitcherSharp<TwitchEventSubConfig>
{
    private GodotObject _data;

    public TwitchEventSubDefinitionType Type
    {
        get;
        set => field = UpdateType(value);
    }

    public List<ITwitcherSharpCondition> Condition { get; set; } = [];
    public TwitchEventSubDefinition Definition => TwitchEventSubDefinition.All.First(x => x.Type == Type);

    public string Id { get; set; }

    [Signal]
    public delegate void TypeChangedEventHandler(TwitchEventSubDefinitionType type);

    public TwitchEventSubConfig(TwitchEventSubDefinition definition, IList<ITwitcherSharpCondition> conditions) : this()
    {
        Type = definition.Type;
        Condition = conditions.ToList();
        foreach (var condition in Condition.Select(x => x.Name))
        {
            if (!definition.Conditions.Contains(condition))
            {
                GD.PushError($"Following conditions may be missing: {condition}");
            }
        }
    }

    private TwitchEventSubDefinitionType UpdateType(TwitchEventSubDefinitionType type)
    {
        if (type == Type) return Type;

        var definition = TwitchEventSubDefinition.All.First(x => x.Type == type);
        Condition = Condition.Where(x => definition.Conditions.Contains(x.Name)).ToList();
        Type = type;
        EmitSignalTypeChanged(type);
        return Type;
    }

    public static TwitchEventSubConfig FromObject(GodotObject data)
    {
        if (data == null) return null;
        var config = new TwitchEventSubConfig();
        config._data = data;
        config.Type = (TwitchEventSubDefinitionType)data.Get("type").AsInt32();
        return config;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/eventsub/twitch_eventsub_config.gd");
        var data = script.Call("New").AsGodotObject();
        data.Set("type", (int)Type);
        data.Set("condition", Condition.Select(x => x.ToGodotObject()).ToArray());
        return data;
    }
}