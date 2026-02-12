using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelPredictionLockEvent : Resource, ITwitcherSharpEventSub<TwitchChannelPredictionLockEvent>
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
	/// An array of outcomes for the Channel Points Prediction. Includes top_predictors.
	/// </summary>
	public outcomes Outcomes { get; set; }

	/// <summary> 
	/// The time the Channel Points Prediction started.
	/// </summary>
	public string StartedAt { get; set; }

	/// <summary> 
	/// The time the Channel Points Prediction was locked.
	/// </summary>
	public string LockedAt { get; set; }

	public static TwitchChannelPredictionLockEvent FromData(Dictionary data)
	{
	    return new TwitchChannelPredictionLockEvent
	    {
			Id = data["id"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			Title = data["title"].AsString(),
			Outcomes = data["outcomes"].As<outcomes>(),
			StartedAt = data["started_at"].AsString(),
			LockedAt = data["locked_at"].AsString(),
		};
	}

}
