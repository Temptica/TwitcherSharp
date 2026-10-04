using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Raids;


/// <summary> 
/// All optional parameters for TwitchAPI.StartARaid 
/// </summary>
public partial class TwitchStartARaidOpt : RefCounted, ITwitcherSharp<TwitchStartARaidOpt>
{
    private Variant _data;
    public string? FromBroadcasterId { get; set; }
    public string? ToBroadcasterId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStartARaidOpt object.
    /// </summary> 
    public static TwitchStartARaidOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchStartARaidOpt
        {
            FromBroadcasterId = data.Read("from_broadcaster_id", static v => v.AsString()),
            ToBroadcasterId = data.Read("to_broadcaster_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_start_a_raid.gd", "Opt");
        if(FromBroadcasterId != null) request.SetValue("from_broadcaster_id", FromBroadcasterId);
        if(ToBroadcasterId != null) request.SetValue("to_broadcaster_id", ToBroadcasterId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
