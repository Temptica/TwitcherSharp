using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Conduits;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateConduitsBody : Resource, ITwitcherSharp<UpdateConduitsBody>
{
    private GodotObject _data;
	public string Id { get; set; }
	public int ShardCount { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateConduitsBody object.
    /// </summary> 
    public static UpdateConduitsBody FromObject(GodotObject data)
    {
        return new UpdateConduitsBody
        {

			Id = data.Get("id").AsString(),
			ShardCount = data.Get("shard_count").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduits_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("shard_count", ShardCount);
		return request;
	}
}
