using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelFollowEvent : Resource, ITwitcherSharpEventSub<TwitchChannelFollowEvent>
{

	/// <summary> 
	/// The user ID for the user now following the specified channel.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user login for the user now following the specified channel.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user display name for the user now following the specified channel.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The requested broadcaster ID.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The requested broadcaster login.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The requested broadcaster display name.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// RFC3339 timestamp of when the follow occurred.
	/// </summary>
	public string FollowedAt { get; set; }

	public static TwitchChannelFollowEvent FromData(Dictionary data)
	{
	    return new TwitchChannelFollowEvent
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			FollowedAt = data["followed_at"].AsString(),
		};
	}

}
