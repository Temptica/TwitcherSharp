using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelGuestStarSessionBeginEvent : Resource, ITwitcherSharpEventSub<TwitchChannelGuestStarSessionBeginEvent>
{

	/// <summary> 
	/// The broadcaster user ID.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster display name.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The broadcaster login.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// ID representing the unique session that was started.
	/// </summary>
	public string SessionId { get; set; }

	/// <summary> 
	/// RFC3339 timestamp indicating the time the session began.
	/// </summary>
	public string StartedAt { get; set; }

	public static TwitchChannelGuestStarSessionBeginEvent FromData(Dictionary data)
	{
	    return new TwitchChannelGuestStarSessionBeginEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			SessionId = data["session_id"].AsString(),
			StartedAt = data["started_at"].AsString(),
		};
	}

}
