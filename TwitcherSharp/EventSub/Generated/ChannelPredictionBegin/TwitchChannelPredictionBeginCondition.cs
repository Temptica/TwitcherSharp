using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPredictionBegin;

public partial class TwitchChannelPredictionBeginCondition : Resource, ITwitcherSharpEventSub<TwitchChannelPredictionBeginCondition>
{

	/// <summary> 
	/// The broadcaster user ID of the channel for which “prediction begin” notifications will be received.
	/// </summary>
	public string BroadcasterUserId { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPredictionBeginCondition object.
    /// </summary> 
    public static TwitchChannelPredictionBeginCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelPredictionBeginCondition
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_prediction_begin.gd");
		var conditionClass = script.Get("Condition").AsGodotObject();
		var request = conditionClass.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		return request;
	}

}
