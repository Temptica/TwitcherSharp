using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelGuestStarSessionEndEvent : Resource, ITwitcherSharpEventSub<TwitchChannelGuestStarSessionEndEvent>
{

	/// <summary> 
	/// The non-host broadcaster user ID.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The non-host broadcaster display name.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The non-host broadcaster login.
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

	/// <summary> 
	/// RFC3339 timestamp indicating the time the session ended.
	/// </summary>
	public string EndedAt { get; set; }

	/// <summary> 
	/// User ID of the host channel.
	/// </summary>
	public string HostUserId { get; set; }

	/// <summary> 
	/// The host display name.
	/// </summary>
	public string HostUserName { get; set; }

	/// <summary> 
	/// The host login.
	/// </summary>
	public string HostUserLogin { get; set; }

	public static TwitchChannelGuestStarSessionEndEvent FromData(Dictionary data)
	{
	    return new TwitchChannelGuestStarSessionEndEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			SessionId = data["session_id"].AsString(),
			StartedAt = data["started_at"].AsString(),
			EndedAt = data["ended_at"].AsString(),
			HostUserId = data["host_user_id"].AsString(),
			HostUserName = data["host_user_name"].AsString(),
			HostUserLogin = data["host_user_login"].AsString(),
		};
	}

}
