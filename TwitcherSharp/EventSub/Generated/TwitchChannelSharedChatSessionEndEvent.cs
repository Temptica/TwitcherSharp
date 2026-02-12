using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelSharedChatSessionEndEvent : Resource, ITwitcherSharpEventSub<TwitchChannelSharedChatSessionEndEvent>
{

	/// <summary> 
	/// The unique identifier for the shared chat session.
	/// </summary>
	public string SessionId { get; set; }

	/// <summary> 
	/// The User ID of the channel in the subscription condition which is no longer active in the shared chat session.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The display name of the channel in the subscription condition which is no longer active in the shared chat session.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The user login of the channel in the subscription condition which is no longer active in the shared chat session.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The User ID of the host channel.
	/// </summary>
	public string HostBroadcasterUserId { get; set; }

	/// <summary> 
	/// The display name of the host channel.
	/// </summary>
	public string HostBroadcasterUserName { get; set; }

	/// <summary> 
	/// The user login of the host channel.
	/// </summary>
	public string HostBroadcasterUserLogin { get; set; }

	public static TwitchChannelSharedChatSessionEndEvent FromData(Dictionary data)
	{
	    return new TwitchChannelSharedChatSessionEndEvent
	    {
			SessionId = data["session_id"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			HostBroadcasterUserId = data["host_broadcaster_user_id"].AsString(),
			HostBroadcasterUserName = data["host_broadcaster_user_name"].AsString(),
			HostBroadcasterUserLogin = data["host_broadcaster_user_login"].AsString(),
		};
	}

}
