using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPollEnd;

public partial class TwitchChannelPollEndCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelPollEndCondition>
{
    public string Name => nameof(TwitchChannelPollEndCondition);

    /// <summary> 
    /// The broadcaster user ID of the channel for which “poll end” notifications will be received.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPollEndCondition object.
    /// </summary> 
    public static TwitchChannelPollEndCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelPollEndCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_poll_end.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }
}
