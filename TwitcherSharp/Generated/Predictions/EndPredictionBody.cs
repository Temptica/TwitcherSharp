using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Predictions;
 
/// <summary> 
///  
/// </summary>
public partial class EndPredictionBody : Resource, ITwitcherSharp<EndPredictionBody>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public string Id { get; set; }
	public string Status { get; set; }
	public string WinningOutcomeId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a EndPredictionBody object.
    /// </summary> 
    public static EndPredictionBody FromObject(GodotObject data)
    {
        return new EndPredictionBody
        {

			BroadcasterId = data.Get("broadcaster_id").AsString(),
			Id = data.Get("id").AsString(),
			Status = data.Get("status").AsString(),
			WinningOutcomeId = data.Get("winning_outcome_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_end_prediction_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("id", Id);
		request.Set("status", Status);
		request.Set("winning_outcome_id", WinningOutcomeId);
		return request;
	}
}
