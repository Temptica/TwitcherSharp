using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelModeratorRemoveEvent : Resource, ITwitcherSharpEventSub<TwitchChannelModeratorRemoveEvent>
{

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
	/// The user ID of the removed moderator.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user login of the removed moderator.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The display name of the removed moderator.
	/// </summary>
	public string UserName { get; set; }

	public static TwitchChannelModeratorRemoveEvent FromData(Dictionary data)
	{
	    return new TwitchChannelModeratorRemoveEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
		};
	}

}
