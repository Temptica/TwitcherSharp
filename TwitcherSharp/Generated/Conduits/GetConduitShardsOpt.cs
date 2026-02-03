using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Conduits;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetConduitShards 
/// </summary>
public partial class GetConduitShardsOpt : Resource, ITwitcherSharp<GetConduitShardsOpt>
{
    private GodotObject _data;
	public string Status { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetConduitShardsOpt object.
    /// </summary> 
    public static GetConduitShardsOpt FromObject(GodotObject data)
    {
        return new GetConduitShardsOpt
        {

			Status = data.Get("status").AsString(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_conduit_shards_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("status", Status);
		request.Set("after", After);
		return request;
	}
}
