using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSubscribe;

public partial class TwitchChannelSubscribeCondition : Resource, ITwitcherSharpCondition<TwitchChannelSubscribeCondition>
{
    public string Name => nameof(TwitchChannelSubscribeCondition);

    /// <summary> 
    /// The broadcaster user ID for the channel you want to get subscribe notifications for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSubscribeCondition object.
    /// </summary> 
    public static TwitchChannelSubscribeCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelSubscribeCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_subscribe.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }
}
