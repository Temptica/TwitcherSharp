using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelSuspiciousUserUpdateEvent : Resource, ITwitcherSharpEventSub<TwitchChannelSuspiciousUserUpdateEvent>
{

	/// <summary> 
	/// The ID of the channel where the treatment for a suspicious user was updated.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The display name of the channel where the treatment for a suspicious user was updated.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The Login of the channel where the treatment for a suspicious user was updated.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The ID of the moderator that updated the treatment for a suspicious user.
	/// </summary>
	public string ModeratorUserId { get; set; }

	/// <summary> 
	/// The display name of the moderator that updated the treatment for a suspicious user.
	/// </summary>
	public string ModeratorUserName { get; set; }

	/// <summary> 
	/// The login of the moderator that updated the treatment for a suspicious user.
	/// </summary>
	public string ModeratorUserLogin { get; set; }

	/// <summary> 
	/// The ID of the suspicious user whose treatment was updated.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The display name of the suspicious user whose treatment was updated.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The login of the suspicious user whose treatment was updated.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The status set for the suspicious user. Can be the following: “none”, “active_monitoring”, or “restricted”.
	/// </summary>
	public string LowTrustStatus { get; set; }

	public static TwitchChannelSuspiciousUserUpdateEvent FromData(Dictionary data)
	{
	    return new TwitchChannelSuspiciousUserUpdateEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			ModeratorUserId = data["moderator_user_id"].AsString(),
			ModeratorUserName = data["moderator_user_name"].AsString(),
			ModeratorUserLogin = data["moderator_user_login"].AsString(),
			UserId = data["user_id"].AsString(),
			UserName = data["user_name"].AsString(),
			UserLogin = data["user_login"].AsString(),
			LowTrustStatus = data["low_trust_status"].AsString(),
		};
	}

}
