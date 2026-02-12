using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelAdBreakBeginEvent : Resource, ITwitcherSharpEventSub<TwitchChannelAdBreakBeginEvent>
{

	/// <summary> 
	/// Length in seconds of the mid-roll ad break requested
	/// </summary>
	public int DurationSeconds { get; set; }

	/// <summary> 
	/// The UTC timestamp of when the ad break began, in RFC3339 format. Note that there is potential delay between this event, when the streamer requested the ad break, and when the viewers will see ads.
	/// </summary>
	public string StartedAt { get; set; }

	/// <summary> 
	/// Indicates if the ad was automatically scheduled via Ads Manager
	/// </summary>
	public bool IsAutomatic { get; set; }

	/// <summary> 
	/// The broadcaster’s user ID for the channel the ad was run on.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The broadcaster’s user login for the channel the ad was run on.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The broadcaster’s user display name for the channel the ad was run on.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// The ID of the user that requested the ad. For automatic ads, this will be the ID of the broadcaster.
	/// </summary>
	public string RequesterUserId { get; set; }

	/// <summary> 
	/// The login of the user that requested the ad.
	/// </summary>
	public string RequesterUserLogin { get; set; }

	/// <summary> 
	/// The display name of the user that requested the ad.
	/// </summary>
	public string RequesterUserName { get; set; }

	public static TwitchChannelAdBreakBeginEvent FromData(Dictionary data)
	{
	    return new TwitchChannelAdBreakBeginEvent
	    {
			DurationSeconds = data["duration_seconds"].AsInt32(),
			StartedAt = data["started_at"].AsString(),
			IsAutomatic = data["is_automatic"].AsBool(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			RequesterUserId = data["requester_user_id"].AsString(),
			RequesterUserLogin = data["requester_user_login"].AsString(),
			RequesterUserName = data["requester_user_name"].AsString(),
		};
	}

}
