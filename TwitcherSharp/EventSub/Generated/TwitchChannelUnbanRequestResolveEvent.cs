using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelUnbanRequestResolveEvent : Resource, ITwitcherSharpEventSub<TwitchChannelUnbanRequestResolveEvent>
{

	/// <summary> 
	/// The ID of the unban request.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// The broadcaster’s user ID for the channel the unban request was updated for.
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
	/// Optional. User ID of moderator who approved/denied the request.
	/// </summary>
	public string ModeratorId { get; set; }

	/// <summary> 
	/// Optional. The moderator’s login name
	/// </summary>
	public string ModeratorLogin { get; set; }

	/// <summary> 
	/// Optional. The moderator’s display name
	/// </summary>
	public string ModeratorName { get; set; }

	/// <summary> 
	/// User ID of user that requested to be unbanned.
	/// </summary>
	public string UserId { get; set; }

	/// <summary> 
	/// The user’s login name.
	/// </summary>
	public string UserLogin { get; set; }

	/// <summary> 
	/// The user’s display name.
	/// </summary>
	public string UserName { get; set; }

	/// <summary> 
	/// Optional. Resolution text supplied by the mod/broadcaster upon approval/denial of the request.
	/// </summary>
	public string ResolutionText { get; set; }

	/// <summary> 
	/// Dictates whether the unban request was approved or denied. Can be the following: approvedcanceleddenied
	/// </summary>
	public string Status { get; set; }

	public static TwitchChannelUnbanRequestResolveEvent FromData(Dictionary data)
	{
	    return new TwitchChannelUnbanRequestResolveEvent
	    {
			Id = data["id"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			ModeratorId = data["moderator_id"].AsString(),
			ModeratorLogin = data["moderator_login"].AsString(),
			ModeratorName = data["moderator_name"].AsString(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			ResolutionText = data["resolution_text"].AsString(),
			Status = data["status"].AsString(),
		};
	}

}
