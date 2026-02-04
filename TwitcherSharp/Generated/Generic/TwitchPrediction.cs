using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchPrediction : Resource, ITwitcherSharp<TwitchPrediction>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string BroadcasterId { get; set; }
	public string BroadcasterName { get; set; }
	public string BroadcasterLogin { get; set; }
	public string Title { get; set; }
	public string WinningOutcomeId { get; set; }
	public TwitchPredictionOutcome[] Outcomes { get; set; }
	public int PredictionWindow { get; set; }
	public string Status { get; set; }
	public string CreatedAt { get; set; }
	public string EndedAt { get; set; }
	public string LockedAt { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchPrediction object.
    /// </summary> 
    public static TwitchPrediction FromObject(GodotObject data)
    {
		var outcomesArray = data.Get("outcomes").AsGodotArray<GodotObject>();
		return new TwitchPrediction
		{
			Id = data.Get("id").AsString(),
			BroadcasterId = data.Get("broadcaster_id").AsString(),
			BroadcasterName = data.Get("broadcaster_name").AsString(),
			BroadcasterLogin = data.Get("broadcaster_login").AsString(),
			Title = data.Get("title").AsString(),
			WinningOutcomeId = data.Get("winning_outcome_id").AsString(),
			Outcomes = outcomesArray.Select(TwitchPredictionOutcome.FromObject).ToArray(),
			PredictionWindow = data.Get("prediction_window").AsInt32(),
			Status = data.Get("status").AsString(),
			CreatedAt = data.Get("created_at").AsString(),
			EndedAt = data.Get("ended_at").AsString(),
			LockedAt = data.Get("locked_at").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_prediction.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("broadcaster_name", BroadcasterName);
		request.Set("broadcaster_login", BroadcasterLogin);
		request.Set("title", Title);
		request.Set("winning_outcome_id", WinningOutcomeId);
		request.Set("outcomes", Outcomes);
		request.Set("prediction_window", PredictionWindow);
		request.Set("status", Status);
		request.Set("created_at", CreatedAt);
		request.Set("ended_at", EndedAt);
		request.Set("locked_at", LockedAt);
		return request;
	}
}
