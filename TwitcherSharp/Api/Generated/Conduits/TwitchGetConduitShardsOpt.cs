using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;

/// <summary> 
/// All optional parameters for TwitchAPI.GetConduitShards 
/// </summary>
public partial class TwitchGetConduitShardsOpt : Resource, ITwitcherSharp<TwitchGetConduitShardsOpt>
{
    private GodotObject _data;
	public string Status { get; set; }
	public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetConduitShardsOpt object.
    /// </summary> 
    public static TwitchGetConduitShardsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchGetConduitShardsOpt
		{
			Status = data.Get("status").AsString(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_conduit_shards.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		if(Status != null) request.Set("status", Status);
		if(After != null) request.Set("after", After);
		return request;
	}

}
