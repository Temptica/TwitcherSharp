using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelWarningSendEvent : Resource, ITwitcherSharpEventSub<TwitchChannelWarningSendEvent>
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
	/// The user ID of the moderator who sent the warning.
	/// </summary>
	public string ModeratorUserId { get; set; }

	/// <summary> 
	/// The login of the moderator.
	/// </summary>
	public string ModeratorUserLogin { get; set; }

	/// <summary> 
	/// The user name of the moderator.
	/// </summary>
	public string ModeratorUserName { get; set; }

	/// <summary> 
	/// The ID of the user being warned.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The login of the user being warned.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user name of the user being.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// Optional. The reason given for the warning.
	/// </summary>
	public string Reason { get; set; }

	/// <summary> 
	/// Optional. The chat rules cited for the warning.
	/// </summary>
	public string[] ChatRulesCited { get; set; }

	public static TwitchChannelWarningSendEvent FromData(Dictionary data)
	{
	    return new TwitchChannelWarningSendEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			ModeratorUserId = data["moderator_user_id"].AsString(),
			ModeratorUserLogin = data["moderator_user_login"].AsString(),
			ModeratorUserName = data["moderator_user_name"].AsString(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Reason = data["reason"].AsString(),
			ChatRulesCited = data["chat_rules_cited"].AsStringArray(),
		};
	}

}
