using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchImage : RefCounted, ITwitcherSharpEventSub<TwitchImage>
{
    private GodotObject _data;
    
    /// <summary> 
    /// URL for the image at 1x size.
    /// </summary>
    public string Url1x { get; set; }

    /// <summary> 
    /// URL for the image at 2x size.
    /// </summary>
    public string Url2x { get; set; }

    /// <summary> 
    /// URL for the image at 4x size.
    /// </summary>
    public string Url4x { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchImage object.
    /// </summary> 
    public static TwitchImage FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchImage
        {
            Url1x = data.Get("url_1x").AsString(),
            Url2x = data.Get("url_2x").AsString(),
            Url4x = data.Get("url_4x").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_twitch_image.gd");
        var request = script.New().AsGodotObject();
        request.Set("url_1x", Url1x);
        request.Set("url_2x", Url2x);
        request.Set("url_4x", Url4x);
        return request;
    }
}
