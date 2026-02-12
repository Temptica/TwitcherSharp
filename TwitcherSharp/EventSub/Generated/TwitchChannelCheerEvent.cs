using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelCheerEvent : Resource, ITwitcherSharpEventSub<TwitchChannelCheerEvent>
{

	/// <summary> 
	/// Whether the user cheered anonymously or not.
	/// </summary>
	public bool IsAnonymous { get; set; }

	/// <summary> 
	/// The user ID for the user who cheered on the specified channel. This is null if is_anonymous is true.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user login for the user who cheered on the specified channel. This is null if is_anonymous is true.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user display name for the user who cheered on the specified channel. This is null if is_anonymous is true.
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
	/// The message sent with the cheer.
	/// </summary>
	public string Message { get; set; }

	/// <summary> 
	/// The number of Bits cheered.
	/// </summary>
	public int Bits { get; set; }

	public static TwitchChannelCheerEvent FromData(Dictionary data)
	{
	    return new TwitchChannelCheerEvent
	    {
			IsAnonymous = data["is_anonymous"].AsBool(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			Message = data["message"].AsString(),
			Bits = data["bits"].AsInt32(),
		};
	}

}
