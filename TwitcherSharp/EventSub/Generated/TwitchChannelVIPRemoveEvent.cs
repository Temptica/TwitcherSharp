using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelVIPRemoveEvent : Resource, ITwitcherSharpEventSub<TwitchChannelVIPRemoveEvent>
{

	/// <summary> 
	/// The ID of the user who was removed as a VIP.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user who was removed as a VIP.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The display name of the user who was removed as a VIP.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// The ID of the broadcaster.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The login of the broadcaster.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The display name of the broadcaster.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	public static TwitchChannelVIPRemoveEvent FromData(Dictionary data)
	{
	    return new TwitchChannelVIPRemoveEvent
	    {
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
		};
	}

}
