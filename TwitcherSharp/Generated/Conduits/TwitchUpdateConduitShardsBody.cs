using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Conduits;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUpdateConduitShardsBody : Resource, ITwitcherSharp<TwitchUpdateConduitShardsBody>
{
    private GodotObject _data;
	public string ConduitId { get; set; }
	public TwitchShards[] Shards { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateConduitShardsBody object.
    /// </summary> 
    public static TwitchUpdateConduitShardsBody FromObject(GodotObject data)
    {
		var shardsArray = data.Get("shards").AsGodotArray<GodotObject>();
		return new TwitchUpdateConduitShardsBody
		{
			ConduitId = data.Get("conduit_id").AsString(),
			Shards = shardsArray.Select(TwitchShards.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduit_shards.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("conduit_id", ConduitId);
		request.Set("shards", Shards);
		return request;
	}
}
