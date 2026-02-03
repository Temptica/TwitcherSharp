using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Conduits;
 
/// <summary> 
///  
/// </summary>
public partial class GetConduitShardsResponse : Resource, ITwitcherSharp<GetConduitShardsResponse>
{
    private GodotObject _data;
	public Data[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetConduitShardsResponse object.
    /// </summary> 
    public static GetConduitShardsResponse FromObject(GodotObject data)
    {
        return new GetConduitShardsResponse
        {

			Data = data.Get("data").As<Data[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_conduit_shards_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
