using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;

public partial class TwitchUpdateConduitsBody : RefCounted, ITwitcherSharp<TwitchUpdateConduitsBody>
{
    private GodotObject _data;
    public string Id { get; set; }
    public int ShardCount { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateConduitsBody object.
    /// </summary> 
    public static TwitchUpdateConduitsBody FromObject(GodotObject data)
    {
        if(data == null) return null;
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
