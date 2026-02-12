using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchAutomodTermsUpdateEvent : Resource, ITwitcherSharpEventSub<TwitchAutomodTermsUpdateEvent>
{

	/// <summary> 
	/// The ID of the broadcaster specified in the request.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The login of the broadcaster specified in the request.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The user name of the broadcaster specified in the request.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The ID of the moderator who changed the channel settings.
	/// </summary>
	public string ModeratorUserId { get; set; }

	/// <summary> 
	/// The moderator’s login.
	/// </summary>
	public string ModeratorUserLogin { get; set; }

	/// <summary> 
	/// The moderator’s user name.
	/// </summary>
	public string ModeratorUserName { get; set; }

	/// <summary> 
	/// The status change applied to the terms. Possible options are: add_permittedremove_permittedadd_blockedremove_blocked
	/// </summary>
	public string Action { get; set; }

	/// <summary> 
	/// Indicates whether this term was added due to an Automod message approve/deny action.
	/// </summary>
	public bool FromAutomod { get; set; }

	public static TwitchAutomodTermsUpdateEvent FromData(Dictionary data)
	{
	    return new TwitchAutomodTermsUpdateEvent
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			ModeratorUserId = data["moderator_user_id"].AsString(),
			ModeratorUserLogin = data["moderator_user_login"].AsString(),
			ModeratorUserName = data["moderator_user_name"].AsString(),
			Action = data["action"].AsString(),
			FromAutomod = data["from_automod"].AsBool(),
		};
	}

}
