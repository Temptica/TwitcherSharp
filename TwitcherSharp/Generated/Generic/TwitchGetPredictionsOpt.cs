using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetPredictions 
/// </summary>
public partial class TwitchGetPredictionsOpt : Resource, ITwitcherSharp<TwitchGetPredictionsOpt>
{
    private GodotObject _data;
	public string[] Id { get; set; }
	public string First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetPredictionsOpt object.
    /// </summary> 
    public static TwitchGetPredictionsOpt FromObject(GodotObject data)
    {
		return new TwitchGetPredictionsOpt
		{
			Id = data.Get("id").AsStringArray(),
			First = data.Get("first").AsString(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_predictions.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
