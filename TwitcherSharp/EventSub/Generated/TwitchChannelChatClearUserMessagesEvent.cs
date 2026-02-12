using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelChatClearUserMessagesEvent : Resource, ITwitcherSharpEventSub<TwitchChannelChatClearUserMessagesEvent>
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
	/// The ID of the user that was banned or put in a timeout. All of their messages are deleted.
	/// </summary>
	public string TargetUserId { get; set; }

	/// <summary> 
	/// The user name of the user that was banned or put in a timeout.
	/// </summary>
	public string TargetUserName { get; set; }

	/// <summary> 
	/// The user login of the user that was banned or put in a timeout.
	/// </summary>
	public string TargetUserLogin { get; set; }

	public static TwitchChannelChatClearUserMessagesEvent FromData(Dictionary data)
	{
	    return new TwitchChannelChatClearUserMessagesEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			TargetUserId = data["target_user_id"].AsString(),
			TargetUserName = data["target_user_name"].AsString(),
			TargetUserLogin = data["target_user_login"].AsString(),
		};
	}

}
