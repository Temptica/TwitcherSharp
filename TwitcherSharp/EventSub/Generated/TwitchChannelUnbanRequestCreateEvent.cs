using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelUnbanRequestCreateEvent : Resource, ITwitcherSharpEventSub<TwitchChannelUnbanRequestCreateEvent>
{

	/// <summary> 
	/// The ID of the unban request.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// The broadcaster’s user ID for the channel the unban request was created for.
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
	/// User ID of user that is requesting to be unbanned.
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
	/// Message sent in the unban request.
	/// </summary>
	public string Text { get; set; }

	/// <summary> 
	/// The UTC timestamp (in RFC3339 format) of when the unban request was created.
	/// </summary>
	public string CreatedAt { get; set; }

	public static TwitchChannelUnbanRequestCreateEvent FromData(Dictionary data)
	{
	    return new TwitchChannelUnbanRequestCreateEvent
	    {
			Id = data["id"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			UserId = data["user_id"].AsString(),
			UserLogin = data["user_login"].AsString(),
			UserName = data["user_name"].AsString(),
			Text = data["text"].AsString(),
			CreatedAt = data["created_at"].AsString(),
		};
	}

}
