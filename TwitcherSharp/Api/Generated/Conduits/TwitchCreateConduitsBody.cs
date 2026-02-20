using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;

public partial class TwitchCreateConduitsBody : Resource, ITwitcherSharp<TwitchCreateConduitsBody>
{
    private GodotObject _data;
    public int ShardCount { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateConduitsBody object.
    /// </summary> 
    public static TwitchCreateConduitsBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchCreateConduitsBody
        {
            ShardCount = data.Get("shard_count").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_conduits.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("shard_count", ShardCount);
        return request;
    }

}
