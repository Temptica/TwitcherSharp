using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelBanEvent : Resource, ITwitcherSharpEventSub<TwitchChannelBanEvent>
{

	/// <summary> 
	/// The user ID for the user who was banned on the specified channel.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user login for the user who was banned on the specified channel.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user display name for the user who was banned on the specified channel.
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
	/// The user ID of the issuer of the ban.
	/// </summary>
	public string ModeratorUserId { get; set; }

	/// <summary> 
	/// The user login of the issuer of the ban.
	/// </summary>
	public string ModeratorUserLogin { get; set; }

	/// <summary> 
	/// The user name of the issuer of the ban.
	/// </summary>
	public string ModeratorUserName { get; set; }

	/// <summary> 
	/// The reason behind the ban.
	/// </summary>
	public string Reason { get; set; }

	/// <summary> 
	/// The UTC date and time (in RFC3339 format) of when the user was banned or put in a timeout.
	/// </summary>
	public string BannedAt { get; set; }

	/// <summary> 
	/// The UTC date and time (in RFC3339 format) of when the timeout ends. Is null if the user was banned instead of put in a timeout.
	/// </summary>
	public string EndsAt { get; set; }

	/// <summary> 
	/// Indicates whether the ban is permanent (true) or a timeout (false). If true, ends_at will be null.
	/// </summary>
	public bool IsPermanent { get; set; }

	public static TwitchChannelBanEvent FromData(Dictionary data)
	{
	    return new TwitchChannelBanEvent
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			ModeratorUserId = data["moderator_user_id"].AsString(),
			ModeratorUserLogin = data["moderator_user_login"].AsString(),
			ModeratorUserName = data["moderator_user_name"].AsString(),
			Reason = data["reason"].AsString(),
			BannedAt = data["banned_at"].AsString(),
			EndsAt = data["ends_at"].AsString(),
			IsPermanent = data["is_permanent"].AsBool(),
		};
	}

}
