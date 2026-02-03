using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Conduits;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateConduitShardsBody : Resource, ITwitcherSharp<UpdateConduitShardsBody>
{
    private GodotObject _data;
	public string ConduitId { get; set; }
	public Shards[] Shards { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateConduitShardsBody object.
    /// </summary> 
    public static UpdateConduitShardsBody FromObject(GodotObject data)
    {
        return new UpdateConduitShardsBody
        {

			ConduitId = data.Get("conduit_id").AsString(),
			Shards = data.Get("shards").As<Shards[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduit_shards_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("conduit_id", ConduitId);
		request.Set("shards", Shards);
		return request;
	}
}
