using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Conduits;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUpdateConduitsBody : Resource, ITwitcherSharp<TwitchUpdateConduitsBody>
{
    private GodotObject _data;
	public string Id { get; set; }
	public int ShardCount { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateConduitsBody object.
    /// </summary> 
    public static TwitchUpdateConduitsBody FromObject(GodotObject data)
    {
		return new TwitchUpdateConduitsBody
		{
			Id = data.Get("id").AsString(),
			ShardCount = data.Get("shard_count").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_conduits.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("shard_count", ShardCount);
		return request;
	}
}
