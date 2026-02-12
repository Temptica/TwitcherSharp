using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelUnbanEvent : Resource, ITwitcherSharpEventSub<TwitchChannelUnbanEvent>
{

	/// <summary> 
	/// The user id for the user who was unbanned on the specified channel.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user login for the user who was unbanned on the specified channel.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user display name for the user who was unbanned on the specified channel.
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
	/// The user ID of the issuer of the unban.
	/// </summary>
	public string ModeratorUserId { get; set; }

	/// <summary> 
	/// The user login of the issuer of the unban.
	/// </summary>
	public string ModeratorUserLogin { get; set; }

	/// <summary> 
	/// The user name of the issuer of the unban.
	/// </summary>
	public string ModeratorUserName { get; set; }

	public static TwitchChannelUnbanEvent FromData(Dictionary data)
	{
	    return new TwitchChannelUnbanEvent
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
		};
	}

}
