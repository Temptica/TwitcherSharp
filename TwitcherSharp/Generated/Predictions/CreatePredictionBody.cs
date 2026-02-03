using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Predictions;
 
/// <summary> 
///  
/// </summary>
public partial class CreatePredictionBody : Resource, ITwitcherSharp<CreatePredictionBody>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public string Title { get; set; }
	public Outcomes[] Outcomes { get; set; }
	public int PredictionWindow { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreatePredictionBody object.
    /// </summary> 
    public static CreatePredictionBody FromObject(GodotObject data)
    {
        return new CreatePredictionBody
        {

			BroadcasterId = data.Get("broadcaster_id").AsString(),
			Title = data.Get("title").AsString(),
			Outcomes = data.Get("outcomes").As<Outcomes[]>(),
			PredictionWindow = data.Get("prediction_window").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_prediction_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("title", Title);
		request.Set("outcomes", Outcomes);
		request.Set("prediction_window", PredictionWindow);
		return request;
	}
}
