using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub.Generated;

public partial class TwitchChannelPredictionEndEvent : Resource, ITwitcherSharpEventSub<TwitchChannelPredictionEndEvent>
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
	/// ID of the winning outcome.
	/// </summary>
	public string WinningOutcomeId { get; set; }

	/// <summary> 
	/// An array of outcomes for the Channel Points Prediction. Includes top_predictors.
	/// </summary>
	public TwitchOutcomes[] Outcomes { get; set; }

	/// <summary> 
	/// The status of the Channel Points Prediction. Valid values are resolved and canceled.
	/// </summary>
	public string Status { get; set; }

	/// <summary> 
	/// The time the Channel Points Prediction started.
	/// </summary>
	public string StartedAt { get; set; }

	/// <summary> 
	/// The time the Channel Points Prediction ended.
	/// </summary>
	public string EndedAt { get; set; }

	public static TwitchChannelPredictionEndEvent FromData(Dictionary data)
	{
	    return new TwitchChannelPredictionEndEvent
	    {
			Id = data["id"].AsString(),
			BroadcasterUserId = data["broadcaster_user_id"].AsString(),
			BroadcasterUserLogin = data["broadcaster_user_login"].AsString(),
			BroadcasterUserName = data["broadcaster_user_name"].AsString(),
			Title = data["title"].AsString(),
			WinningOutcomeId = data["winning_outcome_id"].AsString(),
			Outcomes = data["outcomes"].AsGodotArray().Select(x => TwitchOutcomes.FromData(x.AsGodotDictionary())).ToArray(),
			Status = data["status"].AsString(),
			StartedAt = data["started_at"].AsString(),
			EndedAt = data["ended_at"].AsString(),
		};
	}

}
