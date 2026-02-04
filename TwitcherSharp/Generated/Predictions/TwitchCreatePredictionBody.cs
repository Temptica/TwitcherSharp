using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Predictions;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCreatePredictionBody : Resource, ITwitcherSharp<TwitchCreatePredictionBody>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public string Title { get; set; }
	public TwitchOutcomes[] Outcomes { get; set; }
	public int PredictionWindow { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchCreatePredictionBody object.
    /// </summary> 
    public static TwitchCreatePredictionBody FromObject(GodotObject data)
    {
		var outcomesArray = data.Get("outcomes").AsGodotArray<GodotObject>();
		return new TwitchCreatePredictionBody
		{
			BroadcasterId = data.Get("broadcaster_id").AsString(),
			Title = data.Get("title").AsString(),
			Outcomes = outcomesArray.Select(TwitchOutcomes.FromObject).ToArray(),
			PredictionWindow = data.Get("prediction_window").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_prediction.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("title", Title);
		request.Set("outcomes", Outcomes);
		request.Set("prediction_window", PredictionWindow);
		return request;
	}
}
