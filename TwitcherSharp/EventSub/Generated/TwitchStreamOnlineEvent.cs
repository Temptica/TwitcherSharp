using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchStreamOnlineEvent : Resource, ITwitcherSharpEventSub<TwitchStreamOnlineEvent>
{

	/// <summary> 
	/// The id of the stream.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// The broadcaster’s user id.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster’s user login.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The broadcaster’s user display name.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The stream type. Valid values are: live, playlist, watch_party, premiere, rerun.
	/// </summary>
	public string Type { get; set; }

	/// <summary> 
	/// The timestamp at which the stream went online at.
	/// </summary>
	public string StartedAt { get; set; }

	public static TwitchStreamOnlineEvent FromData(Dictionary data)
	{
	    return new TwitchStreamOnlineEvent
	    {
			Id = data["id"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			Type = data["type"].AsString(),
			StartedAt = data["started_at"].AsString(),
		};
	}

}
