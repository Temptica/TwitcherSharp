using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;

public partial class TwitchCreateConduitsBody : RefCounted, ITwitcherSharp<TwitchCreateConduitsBody>
{
    private Variant _data;
    public int ShardCount { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateConduitsBody object.
    /// </summary> 
    public static TwitchCreateConduitsBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreateConduitsBody
        {
            ShardCount = data.Read("shard_count", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_conduits.gd", "Body");
        request.SetValue("shard_count", ShardCount);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
