using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelVIPAdd;

public partial class TwitchChannelVIPAddCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelVIPAddCondition>
{
    public string Name => nameof(TwitchChannelVIPAddCondition);

    /// <summary> 
    /// The User ID of the broadcaster (channel) Maximum: 1
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelVIPAddCondition object.
    /// </summary> 
    public static TwitchChannelVIPAddCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelVIPAddCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_vip_add.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelVIPAddCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelVIPAddCondition
        {
            BroadcasterUserId = data["broadcaster_user_id"].AsString(),
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"broadcaster_user_id", BroadcasterUserId},
        };
    }
}
