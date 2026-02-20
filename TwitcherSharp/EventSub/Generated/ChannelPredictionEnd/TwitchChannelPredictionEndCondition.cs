using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPredictionEnd;

public partial class TwitchChannelPredictionEndCondition : Resource, ITwitcherSharpCondition<TwitchChannelPredictionEndCondition>
{
    public string Name => nameof(TwitchChannelPredictionEndCondition);

    /// <summary> 
    /// The broadcaster user ID of the channel for which “prediction end” notifications will be received.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPredictionEndCondition object.
    /// </summary> 
    public static TwitchChannelPredictionEndCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelPredictionEndCondition
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_prediction_end.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        return request;
    }
}
