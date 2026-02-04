using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Predictions;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchEndPredictionResponse : Resource, ITwitcherSharp<TwitchEndPredictionResponse>
{
    private GodotObject _data;
	public TwitchPrediction[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchEndPredictionResponse object.
    /// </summary> 
    public static TwitchEndPredictionResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchEndPredictionResponse
		{
			Data = dataArray.Select(TwitchPrediction.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_end_prediction.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
