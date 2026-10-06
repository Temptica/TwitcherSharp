using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Clips;


/// <summary> 
/// All optional parameters for TwitchAPI.CreateClipFromVod 
/// </summary>
public partial class TwitchCreateClipFromVodOpt : RefCounted, ITwitcherSharp<TwitchCreateClipFromVodOpt>
{
    private Variant _data;
    public double? Duration { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateClipFromVodOpt object.
    /// </summary> 
    public static TwitchCreateClipFromVodOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreateClipFromVodOpt
        {
            Duration = data.Read("duration", static v => v.AsDouble()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_clip_from_vod.gd", "Opt");
        if(Duration.HasValue) request.SetValue("duration", Duration.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
