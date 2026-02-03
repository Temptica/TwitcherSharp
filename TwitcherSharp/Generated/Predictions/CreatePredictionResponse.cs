using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Predictions;
 
/// <summary> 
///  
/// </summary>
public partial class CreatePredictionResponse : Resource, ITwitcherSharp<CreatePredictionResponse>
{
    private GodotObject _data;
	public Prediction[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreatePredictionResponse object.
    /// </summary> 
    public static CreatePredictionResponse FromObject(GodotObject data)
    {
        return new CreatePredictionResponse
        {

			Data = data.Get("data").As<Prediction[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_prediction_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
