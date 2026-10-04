using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchImage : RefCounted, ITwitcherSharpEventSub<TwitchImage>
{
    private Variant _data;
    
    /// <summary> 
    /// URL for the image at 1x size.
    /// </summary>
    public string? Url1x { get; set; }

    /// <summary> 
    /// URL for the image at 2x size.
    /// </summary>
    public string? Url2x { get; set; }

    /// <summary> 
    /// URL for the image at 4x size.
    /// </summary>
    public string? Url4x { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchImage object.
    /// </summary> 
    public static TwitchImage? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchImage
        {
            Url1x = data.Read("url_1x", static v => v.AsString()),
            Url2x = data.Read("url_2x", static v => v.AsString()),
            Url4x = data.Read("url_4x", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_twitch_image.gd");
        if(Url1x != null) request.SetValue("url_1x", Url1x);
        if(Url2x != null) request.SetValue("url_2x", Url2x);
        if(Url4x != null) request.SetValue("url_4x", Url4x);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
