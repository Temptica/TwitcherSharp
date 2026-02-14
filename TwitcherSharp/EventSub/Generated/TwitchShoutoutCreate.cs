using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchShoutoutCreate : Resource, ITwitcherSharpEventSub<TwitchShoutoutCreate>
{

	/// <summary> 
	/// An ID that identifies the broadcaster that sent the Shoutout.
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
	/// An ID that identifies the broadcaster that received the Shoutout.
	/// </summary>
	public string ToBroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster’s login name.
	/// </summary>
	public string ToBroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The broadcaster’s display name.
	/// </summary>
	public string ToBroadcasterUserName { get; set; }

	/// <summary> 
	/// An ID that identifies the moderator that sent the Shoutout. If the broadcaster sent the Shoutout, this ID is the same as the ID in broadcaster_user_id.
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
	/// The number of users that were watching the broadcaster’s stream at the time of the Shoutout.
	/// </summary>
	public int ViewerCount { get; set; }

	/// <summary> 
	/// The UTC timestamp (in RFC3339 format) of when the moderator sent the Shoutout.
	/// </summary>
	public string StartedAt { get; set; }

	/// <summary> 
	/// The UTC timestamp (in RFC3339 format) of when the broadcaster may send a Shoutout to a different broadcaster.
	/// </summary>
	public string CooldownEndsAt { get; set; }

	/// <summary> 
	/// The UTC timestamp (in RFC3339 format) of when the broadcaster may send another Shoutout to the broadcaster in to_broadcaster_user_id.
	/// </summary>
	public string TargetCooldownEndsAt { get; set; }

	public static TwitchShoutoutCreate FromData(Dictionary data)
	{
	    return new TwitchShoutoutCreate
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			ToBroadcasterUserId = data["to_broadcaster_user_id"].AsString(),
			ToBroadcasterUserLogin = data["to_broadcaster_user_login"].AsString(),
			ToBroadcasterUserName = data["to_broadcaster_user_name"].AsString(),
			ModeratorUserId = data["moderator_user_id"].AsString(),
			ModeratorUserLogin = data["moderator_user_login"].AsString(),
			ModeratorUserName = data["moderator_user_name"].AsString(),
			ViewerCount = data["viewer_count"].AsInt32(),
			StartedAt = data["started_at"].AsString(),
			CooldownEndsAt = data["cooldown_ends_at"].AsString(),
			TargetCooldownEndsAt = data["target_cooldown_ends_at"].AsString(),
		};
	}

}
