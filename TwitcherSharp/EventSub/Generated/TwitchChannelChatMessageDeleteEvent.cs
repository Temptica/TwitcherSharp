using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelChatMessageDeleteEvent : Resource, ITwitcherSharpEventSub<TwitchChannelChatMessageDeleteEvent>
{

	/// <summary> 
	/// The broadcaster user ID.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster display name.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The broadcaster login.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The ID of the user whose message was deleted.
	/// </summary>
	public string TargetUserId { get; set; }

	/// <summary> 
	/// The user name of the user whose message was deleted.
	/// </summary>
	public string TargetUserName { get; set; }

	/// <summary> 
	/// The user login of the user whose message was deleted.
	/// </summary>
	public string TargetUserLogin { get; set; }

	/// <summary> 
	/// A UUID that identifies the message that was removed.
	/// </summary>
	public string MessageId { get; set; }

	public static TwitchChannelChatMessageDeleteEvent FromData(Dictionary data)
	{
	    return new TwitchChannelChatMessageDeleteEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			TargetUserId = data["target_user_id"].AsString(),
			TargetUserName = data["target_user_name"].AsString(),
			TargetUserLogin = data["target_user_login"].AsString(),
			MessageId = data["message_id"].AsString(),
		};
	}

}
