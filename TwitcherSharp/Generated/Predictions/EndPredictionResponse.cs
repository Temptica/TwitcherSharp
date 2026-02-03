using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Predictions;
 
/// <summary> 
///  
/// </summary>
public partial class EndPredictionResponse : Resource, ITwitcherSharp<EndPredictionResponse>
{
    private GodotObject _data;
	public Prediction[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a EndPredictionResponse object.
    /// </summary> 
    public static EndPredictionResponse FromObject(GodotObject data)
    {
        return new EndPredictionResponse
        {

			Data = data.Get("data").As<Prediction[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_end_prediction_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
