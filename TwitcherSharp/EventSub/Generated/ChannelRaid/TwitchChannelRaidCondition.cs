using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelRaid;

public partial class TwitchChannelRaidCondition : Resource, ITwitcherSharpEventSub<TwitchChannelRaidCondition>
{

	/// <summary> 
	/// The broadcaster user ID that created the channel raid you want to get notifications for. Use this parameter if you want to know when a specific broadcaster raids another broadcaster. The channel raid condition must include either from_broadcaster_user_id or to_broadcaster_user_id.
	/// </summary>
	public string FromBroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster user ID that received the channel raid you want to get notifications for. Use this parameter if you want to know when a specific broadcaster is raided by another broadcaster. The channel raid condition must include either from_broadcaster_user_id or to_broadcaster_user_id.
	/// </summary>
	public string ToBroadcasterUserId { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelRaidCondition object.
    /// </summary> 
    public static TwitchChannelRaidCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchChannelRaidCondition
		{
			FromBroadcasterUserId = data.Get("from_broadcaster_user_id").AsString(),
			ToBroadcasterUserId = data.Get("to_broadcaster_user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_raid.gd");
		var conditionClass = script.Get("Condition").AsGodotObject();
		var request = conditionClass.Call("new").AsGodotObject();
		request.Set("from_broadcaster_user_id", FromBroadcasterUserId);
		request.Set("to_broadcaster_user_id", ToBroadcasterUserId);
		return request;
	}

}
