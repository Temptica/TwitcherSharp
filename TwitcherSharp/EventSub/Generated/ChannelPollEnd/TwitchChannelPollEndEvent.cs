using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelPollEnd;

public partial class TwitchChannelPollEndEvent : Resource, ITwitcherSharpEventSub<TwitchChannelPollEndEvent>
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
	/// The status of the poll. Valid values are completed, archived, and terminated.
	/// </summary>
	public string Status { get; set; }

	/// <summary> 
	/// The time the poll started.
	/// </summary>
	public string StartedAt { get; set; }

	/// <summary> 
	/// The time the poll ended.
	/// </summary>
	public string EndedAt { get; set; }


    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPollEndEvent object.
    /// </summary> 
    public static TwitchChannelPollEndEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
		var choicesArray = data.Get("choices").AsGodotArray<GodotObject>();
		return new TwitchChannelPollEndEvent
		{
			Id = data.Get("id").AsString(),
			BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
			BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
			BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
			Title = data.Get("title").AsString(),
			Choices = choicesArray.Select(TwitchChoices.FromObject).ToArray(),
			BitsVoting = data.Get("bits_voting").As<TwitchBitsVoting>(),
			ChannelPointsVoting = data.Get("channel_points_voting").As<TwitchChannelPointsVoting>(),
			Status = data.Get("status").AsString(),
			StartedAt = data.Get("started_at").AsString(),
			EndedAt = data.Get("ended_at").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_poll_end.gd");
		var eventClass = script.Get("Event").AsGodotObject();
		var request = eventClass.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("broadcaster_user_id", BroadcasterUserId);
		request.Set("broadcaster_user_login", BroadcasterUserLogin);
		request.Set("broadcaster_user_name", BroadcasterUserName);
		request.Set("title", Title);
		request.Set("choices", Choices);
		request.Set("bits_voting", BitsVoting);
		request.Set("channel_points_voting", ChannelPointsVoting);
		request.Set("status", Status);
		request.Set("started_at", StartedAt);
		request.Set("ended_at", EndedAt);
		return request;
	}

}
