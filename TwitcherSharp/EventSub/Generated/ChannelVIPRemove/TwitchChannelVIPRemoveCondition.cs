using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelVIPRemove;

public partial class TwitchChannelVIPRemoveCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelVIPRemoveCondition>
{
    public string Name => nameof(TwitchChannelVIPRemoveCondition);

    /// <summary> 
    /// The User ID of the broadcaster (channel) Maximum: 1
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelVIPRemoveCondition object.
    /// </summary> 
    public static TwitchChannelVIPRemoveCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelVIPRemoveCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_vip_remove.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelVIPRemoveCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelVIPRemoveCondition
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
