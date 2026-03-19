using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPredictionProgress;

public partial class TwitchChannelPredictionProgressCondition : RefCounted, ITwitcherSharpCondition<TwitchChannelPredictionProgressCondition>
{
    public string Name => nameof(TwitchChannelPredictionProgressCondition);

    /// <summary> 
    /// The broadcaster user ID of the channel for which “prediction progress” notifications will be received.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPredictionProgressCondition object.
    /// </summary> 
    public static TwitchChannelPredictionProgressCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelPredictionProgressCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_prediction_progress.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }

    public static TwitchChannelPredictionProgressCondition FromDictionary(Dictionary data)
    {
        return new TwitchChannelPredictionProgressCondition
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
