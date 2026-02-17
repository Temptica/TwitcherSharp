using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelPollProgress;

public partial class TwitchChannelPollProgressCondition : Resource, ITwitcherSharpEventSub<TwitchChannelPollProgressCondition>
{

	/// <summary> 
	/// The broadcaster user ID of the channel for which “poll progress” notifications will be received.
	/// </summary>
	public string BroadcasterUserId { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPollProgressCondition object.
    /// </summary> 
    public static TwitchChannelPollProgressCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelPollProgressCondition
		{
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_poll_progress.gd");
		var conditionClass = script.Get("Condition").AsGodotObject();
		var request = conditionClass.Call("new").AsGodotObject();
		request.Set("broadcaster_user_id", BroadcasterUserId);
		return request;
	}

}
