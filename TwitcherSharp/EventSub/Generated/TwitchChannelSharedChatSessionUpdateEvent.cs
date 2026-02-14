using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelSharedChatSessionUpdateEvent : Resource, ITwitcherSharpEventSub<TwitchChannelSharedChatSessionUpdateEvent>
{

	/// <summary> 
	/// The unique identifier for the shared chat session.
	/// </summary>
	public string SessionId { get; set; }

	/// <summary> 
	/// The User ID of the channel in the subscription condition.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The display name of the channel in the subscription condition.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The user login of the channel in the subscription condition.
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

	/// <summary> 
	/// The list of participants in the session.
	/// </summary>
	public TwitchParticipants Participants { get; set; }

	public static TwitchChannelSharedChatSessionUpdateEvent FromData(Dictionary data)
	{
	    return new TwitchChannelSharedChatSessionUpdateEvent
	    {
			SessionId = data["session_id"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			HostBroadcasterUserId = data["host_broadcaster_user_id"].AsString(),
			HostBroadcasterUserName = data["host_broadcaster_user_name"].AsString(),
			HostBroadcasterUserLogin = data["host_broadcaster_user_login"].AsString(),
			Participants = TwitchParticipants.FromData(data["participants"].AsGodotDictionary()),
		};
	}

public partial class TwitchParticipants : Resource, ITwitcherSharpEventSub<TwitchParticipants>
{

	/// <summary> 
	/// The User ID of the participant channel.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The display name of the participant channel.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The user login of the participant channel.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	public static TwitchParticipants FromData(Dictionary data)
	{
	    return new TwitchParticipants
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
		};
	}

}

}
