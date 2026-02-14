using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchShieldMode : Resource, ITwitcherSharpEventSub<TwitchShieldMode>
{

	/// <summary> 
	/// An ID that identifies the broadcaster whose Shield Mode status was updated.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster’s login name.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The broadcaster’s display name.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// An ID that identifies the moderator that updated the Shield Mode’s status. If the broadcaster updated the status, this ID will be the same as broadcaster_user_id.
	/// </summary>
	public string ModeratorUserId { get; set; }

	/// <summary> 
	/// The moderator’s login name.
	/// </summary>
	public string ModeratorUserLogin { get; set; }

	/// <summary> 
	/// The moderator’s display name.
	/// </summary>
	public string ModeratorUserName { get; set; }

	/// <summary> 
	/// The UTC timestamp (in RFC3339 format) of when the moderator activated Shield Mode. The object includes this field only for channel.shield_mode.begin events.
	/// </summary>
	public string StartedAt { get; set; }

	/// <summary> 
	/// The UTC timestamp (in RFC3339 format) of when the moderator deactivated Shield Mode. The object includes this field only for channel.shield_mode.end events.
	/// </summary>
	public string EndedAt { get; set; }

	public static TwitchShieldMode FromData(Dictionary data)
	{
	    return new TwitchShieldMode
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			ModeratorUserId = data["moderator_user_id"].AsString(),
			ModeratorUserLogin = data["moderator_user_login"].AsString(),
			ModeratorUserName = data["moderator_user_name"].AsString(),
			StartedAt = data["started_at"].AsString(),
			EndedAt = data["ended_at"].AsString(),
		};
	}

}
