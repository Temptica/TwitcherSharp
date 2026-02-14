using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelPredictionBeginEvent : Resource, ITwitcherSharpEventSub<TwitchChannelPredictionBeginEvent>
{

	/// <summary> 
	/// Channel Points Prediction ID.
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
	/// Title for the Channel Points Prediction.
	/// </summary>
	public string Title { get; set; }

	/// <summary> 
	/// An array of outcomes for the Channel Points Prediction.
	/// </summary>
	public TwitchOutcomes[] Outcomes { get; set; }

	/// <summary> 
	/// The time the Channel Points Prediction started.
	/// </summary>
	public string StartedAt { get; set; }

	/// <summary> 
	/// The time the Channel Points Prediction will automatically lock.
	/// </summary>
	public string LocksAt { get; set; }

	public static TwitchChannelPredictionBeginEvent FromData(Dictionary data)
	{
	    return new TwitchChannelPredictionBeginEvent
	    {
			Id = data["id"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			Title = data["title"].AsString(),
			Outcomes = data["outcomes"].AsGodotArray().Select(x => TwitchOutcomes.FromData(x.AsGodotDictionary())).ToArray(),
			StartedAt = data["started_at"].AsString(),
			LocksAt = data["locks_at"].AsString(),
		};
	}

}
