using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.HypeTrain;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetHypeTrainEvents 
/// </summary>
public partial class GetHypeTrainEventsOpt : Resource, ITwitcherSharp<GetHypeTrainEventsOpt>
{
    private GodotObject _data;
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetHypeTrainEventsOpt object.
    /// </summary> 
    public static GetHypeTrainEventsOpt FromObject(GodotObject data)
    {
        return new GetHypeTrainEventsOpt
        {

			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_events_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
