using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelPollProgressEvent : Resource, ITwitcherSharpEventSub<TwitchChannelPollProgressEvent>
{

	/// <summary> 
	/// ID of the poll.
	/// </summary>
	public string Id { get; set; }

	/// <summary> 
	/// The requested broadcaster ID.
	/// </summary>
	public string BroadcasterUserId { get; set; }

	/// <summary> 
	/// The requested broadcaster login.
	/// </summary>
	public string BroadcasterUserLogin { get; set; }

	/// <summary> 
	/// The requested broadcaster display name.
	/// </summary>
	public string BroadcasterUserName { get; set; }

	/// <summary> 
	/// Question displayed for the poll.
	/// </summary>
	public string Title { get; set; }

	/// <summary> 
	/// An array of choices for the poll. Includes vote counts.
	/// </summary>
	public choices Choices { get; set; }

	/// <summary> 
	/// Not supported.
	/// </summary>
	public bits_voting BitsVoting { get; set; }

	/// <summary> 
	/// The Channel Points voting settings for the poll.
	/// </summary>
	public channel_points_voting ChannelPointsVoting { get; set; }

	/// <summary> 
	/// The time the poll started.
	/// </summary>
	public string StartedAt { get; set; }

	/// <summary> 
	/// The time the poll will end.
	/// </summary>
	public string EndsAt { get; set; }

	public static TwitchChannelPollProgressEvent FromData(Dictionary data)
	{
	    return new TwitchChannelPollProgressEvent
	    {
			Id = data["id"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			Title = data["title"].AsString(),
			Choices = data["choices"].As<choices>(),
			BitsVoting = data["bits_voting"].As<bits_voting>(),
			ChannelPointsVoting = data["channel_points_voting"].As<channel_points_voting>(),
			StartedAt = data["started_at"].AsString(),
			EndsAt = data["ends_at"].AsString(),
		};
	}

}
