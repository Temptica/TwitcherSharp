using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub;
public partial class TwitchEventSubConfig() : RefCounted, ITwitcherSharp<TwitchEventSubConfig>
{
    private GodotObject _data;
    public TwitchEventSubDefinitionType Type { get; private set; }
    public ITwitcherSharpCondition Condition { get; set; }
    public TwitchEventSubDefinition Definition => TwitchEventSubDefinition.All.First(x => x.Type == Type);

    public string Id { get; set; }

    [Signal]
    public delegate void TypeChangedEventHandler(TwitchEventSubDefinitionType type);

    public TwitchEventSubConfig(TwitchEventSubDefinition definition, ITwitcherSharpCondition conditions) : this()
    {
        Type = definition.Type;
        Condition = conditions;
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
        var data = script.New().AsGodotObject();
        data.Set("type", (int)Type);
        data.Set("condition", Condition.ToDictionary());
        return data;
    }
}