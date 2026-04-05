using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPollBegin;

public partial class TwitchChannelPollBeginCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelPollBeginCondition>
{
    public string Name => nameof(TwitchChannelPollBeginCondition);

    /// <summary> 
    /// The broadcaster user ID of the channel for which “poll begin” notifications will be received.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPollBeginCondition object.
    /// </summary> 
    public static TwitchChannelPollBeginCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelPollBeginCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_poll_begin.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelPollBeginCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelPollBeginCondition
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
