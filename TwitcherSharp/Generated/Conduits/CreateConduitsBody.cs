using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Conduits;
 
/// <summary> 
///  
/// </summary>
public partial class CreateConduitsBody : Resource, ITwitcherSharp<CreateConduitsBody>
{
    private GodotObject _data;
	public int ShardCount { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreateConduitsBody object.
    /// </summary> 
    public static CreateConduitsBody FromObject(GodotObject data)
    {
        return new CreateConduitsBody
        {

			ShardCount = data.Get("shard_count").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_conduits_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("shard_count", ShardCount);
		return request;
	}
}
