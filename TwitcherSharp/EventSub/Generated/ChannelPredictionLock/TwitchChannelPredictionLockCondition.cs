using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPredictionLock;

public partial class TwitchChannelPredictionLockCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelPredictionLockCondition>
{
    public string Name => nameof(TwitchChannelPredictionLockCondition);

    /// <summary> 
    /// The broadcaster user ID of the channel for which “prediction lock” notifications will be received.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPredictionLockCondition object.
    /// </summary> 
    public static TwitchChannelPredictionLockCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelPredictionLockCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_prediction_lock.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelPredictionLockCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelPredictionLockCondition
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
