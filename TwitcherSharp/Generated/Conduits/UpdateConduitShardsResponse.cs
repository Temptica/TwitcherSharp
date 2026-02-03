using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Conduits;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateConduitShardsResponse : Resource, ITwitcherSharp<UpdateConduitShardsResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
	public Errors[] Errors { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateConduitShardsResponse object.
    /// </summary> 
    public static UpdateConduitShardsResponse FromObject(GodotObject data)
    {
        return new UpdateConduitShardsResponse
        {

			Data = data.Get("data").As<Data[]>(),
			Errors = data.Get("errors").As<Errors[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduit_shards_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("errors", Errors);
		return request;
	}
}
