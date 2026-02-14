using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelPollBeginEvent : Resource, ITwitcherSharpEventSub<TwitchChannelPollBeginEvent>
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
	/// An array of choices for the poll.
	/// </summary>
	public TwitchChoices[] Choices { get; set; }

	/// <summary> 
	/// NOTE: Bits voting is not supported.
	/// </summary>
	public TwitchBitsVoting BitsVoting { get; set; }

	/// <summary> 
	/// 
	/// </summary>
	public TwitchChannelPointsVoting ChannelPointsVoting { get; set; }

	/// <summary> 
	/// The time the poll started.
	/// </summary>
	public string StartedAt { get; set; }

	/// <summary> 
	/// The time the poll will end.
	/// </summary>
	public string EndsAt { get; set; }

	public static TwitchChannelPollBeginEvent FromData(Dictionary data)
	{
	    return new TwitchChannelPollBeginEvent
	    {
			Id = data["id"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			Title = data["title"].AsString(),
			Choices = data["choices"].AsGodotArray().Select(x => TwitchChoices.FromData(x.AsGodotDictionary())).ToArray(),
			BitsVoting = TwitchBitsVoting.FromData(data["bits_voting"].AsGodotDictionary()),
			ChannelPointsVoting = TwitchChannelPointsVoting.FromData(data["channel_points_voting"].AsGodotDictionary()),
			StartedAt = data["started_at"].AsString(),
			EndsAt = data["ends_at"].AsString(),
		};
	}

}
