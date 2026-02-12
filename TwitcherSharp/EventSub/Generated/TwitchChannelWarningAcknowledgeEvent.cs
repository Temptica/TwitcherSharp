using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelWarningAcknowledgeEvent : Resource, ITwitcherSharpEventSub<TwitchChannelWarningAcknowledgeEvent>
{

	/// <summary> 
	/// The user ID of the broadcaster.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The login of the broadcaster.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The user name of the broadcaster.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The ID of the user that has acknowledged their warning.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user that has acknowledged their warning.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user name of the user that has acknowledged their warning.
	/// </summary>
	public string UserName { get; set; }

	public static TwitchChannelWarningAcknowledgeEvent FromData(Dictionary data)
	{
	    return new TwitchChannelWarningAcknowledgeEvent
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
