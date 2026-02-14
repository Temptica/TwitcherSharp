using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUpdateConduitShardsResponse : Resource, ITwitcherSharp<TwitchUpdateConduitShardsResponse>
{
    private GodotObject _data;
	public TwitchData[] Data { get; set; }
	public TwitchErrors[] Errors { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateConduitShardsResponse object.
    /// </summary> 
    public static TwitchUpdateConduitShardsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		var errorsArray = data.Get("errors").AsGodotArray<GodotObject>();
		return new TwitchUpdateConduitShardsResponse
		{
			Data = dataArray.Select(TwitchData.FromObject).ToArray(),
			Errors = errorsArray.Select(TwitchErrors.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduit_shards.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("errors", Errors);
		return request;
	}
}
