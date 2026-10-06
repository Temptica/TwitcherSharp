using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Conduits;


/// <summary> 
/// All optional parameters for TwitchAPI.GetConduitShards 
/// </summary>
public partial class TwitchGetConduitShardsOpt : RefCounted, ITwitcherSharp<TwitchGetConduitShardsOpt>
{
    private Variant _data;
    public string? Status { get; set; }
    public string? After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetConduitShardsOpt object.
    /// </summary> 
    public static TwitchGetConduitShardsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetConduitShardsOpt
        {
            Status = data.Read("status", static v => v.AsString()),
            After = data.Read("after", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_conduit_shards.gd", "Opt");
        if(Status != null) request.SetValue("status", Status);
        if(After != null) request.SetValue("after", After);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
