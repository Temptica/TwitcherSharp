using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Predictions;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetPredictions 
/// </summary>
public partial class GetPredictionsOpt : Resource, ITwitcherSharp<GetPredictionsOpt>
{
    private GodotObject _data;
	public string[] Id { get; set; }
	public string First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetPredictionsOpt object.
    /// </summary> 
    public static GetPredictionsOpt FromObject(GodotObject data)
    {
        return new GetPredictionsOpt
        {

			Id = data.Get("id").AsStringArray(),
			First = data.Get("first").AsString(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_predictions_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
