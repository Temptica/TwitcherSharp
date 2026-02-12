using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelRaidEvent : Resource, ITwitcherSharpEventSub<TwitchChannelRaidEvent>
{

	/// <summary> 
	/// The broadcaster ID that created the raid.
	/// </summary>
	public string FromBroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster login that created the raid.
	/// </summary>
	public string FromBroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The broadcaster display name that created the raid.
	/// </summary>
	public string FromBroadcasterUserName { get; set; }

	/// <summary> 
	/// The broadcaster ID that received the raid.
	/// </summary>
	public string ToBroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster login that received the raid.
	/// </summary>
	public string ToBroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The broadcaster display name that received the raid.
	/// </summary>
	public string ToBroadcasterUserName { get; set; }

	/// <summary> 
	/// The number of viewers in the raid.
	/// </summary>
	public int Viewers { get; set; }

	public static TwitchChannelRaidEvent FromData(Dictionary data)
	{
	    return new TwitchChannelRaidEvent
	    {
			FromBroadcasterUserId = data["from_broadcaster_user_id"].AsString(),
			FromBroadcasterUserLogin = data["from_broadcaster_user_login"].AsString(),
			FromBroadcasterUserName = data["from_broadcaster_user_name"].AsString(),
			ToBroadcasterUserId = data["to_broadcaster_user_id"].AsString(),
			ToBroadcasterUserLogin = data["to_broadcaster_user_login"].AsString(),
			ToBroadcasterUserName = data["to_broadcaster_user_name"].AsString(),
			Viewers = data["viewers"].AsInt32(),
		};
	}

}
