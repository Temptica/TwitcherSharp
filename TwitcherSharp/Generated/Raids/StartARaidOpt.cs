using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Raids;
 
/// <summary> 
/// All optional parameters for TwitchAPI.StartARaid 
/// </summary>
public partial class StartARaidOpt : Resource, ITwitcherSharp<StartARaidOpt>
{
    private GodotObject _data;
	public string FromBroadcasterId { get; set; }
	public string ToBroadcasterId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a StartARaidOpt object.
    /// </summary> 
    public static StartARaidOpt FromObject(GodotObject data)
    {
        return new StartARaidOpt
        {

			FromBroadcasterId = data.Get("from_broadcaster_id").AsString(),
			ToBroadcasterId = data.Get("to_broadcaster_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_start_a_raid_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("from_broadcaster_id", FromBroadcasterId);
		request.Set("to_broadcaster_id", ToBroadcasterId);
		return request;
	}
}
