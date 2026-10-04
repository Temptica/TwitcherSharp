using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;

public partial class TwitchUpdateConduitsBody : RefCounted, ITwitcherSharp<TwitchUpdateConduitsBody>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public int ShardCount { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateConduitsBody object.
    /// </summary> 
    public static TwitchUpdateConduitsBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateConduitsBody
        {
            Id = data.Read("id", static v => v.AsString()),
            ShardCount = data.Read("shard_count", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_conduits.gd", "Body");
        if(Id != null) request.SetValue("id", Id);
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
