using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelChatClearEvent : Resource, ITwitcherSharpEventSub<TwitchChannelChatClearEvent>
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

	public static TwitchChannelChatClearEvent FromData(Dictionary data)
	{
	    return new TwitchChannelChatClearEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
		};
	}

}
