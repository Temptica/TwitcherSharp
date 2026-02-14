using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchShoutoutReceived : Resource, ITwitcherSharpEventSub<TwitchShoutoutReceived>
{

	/// <summary> 
	/// An ID that identifies the broadcaster that received the Shoutout.
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
	/// An ID that identifies the broadcaster that sent the Shoutout.
	/// </summary>
	public string FromBroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster’s login name.
	/// </summary>
	public string FromBroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The broadcaster’s display name.
	/// </summary>
	public string FromBroadcasterUserName { get; set; }

	/// <summary> 
	/// The number of users that were watching the from-broadcaster’s stream at the time of the Shoutout.
	/// </summary>
	public int ViewerCount { get; set; }

	/// <summary> 
	/// The UTC timestamp (in RFC3339 format) of when the moderator sent the Shoutout.
	/// </summary>
	public string StartedAt { get; set; }

	public static TwitchShoutoutReceived FromData(Dictionary data)
	{
	    return new TwitchShoutoutReceived
	    {
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			FromBroadcasterUserId = data["from_broadcaster_user_id"].AsString(),
			FromBroadcasterUserLogin = data["from_broadcaster_user_login"].AsString(),
			FromBroadcasterUserName = data["from_broadcaster_user_name"].AsString(),
			ViewerCount = data["viewer_count"].AsInt32(),
			StartedAt = data["started_at"].AsString(),
		};
	}

}
