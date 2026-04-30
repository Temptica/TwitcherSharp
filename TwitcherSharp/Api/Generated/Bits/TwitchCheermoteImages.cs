using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchCheermoteImages : RefCounted, ITwitcherSharp<TwitchCheermoteImages>
{
    private GodotObject _data;
    public TwitchCheermoteImageTheme Light { get; set; }
    public TwitchCheermoteImageTheme Dark { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheermoteImages object.
    /// </summary> 
    public static TwitchCheermoteImages FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchCheermoteImages
        {
            Light = data.Get("light").As<TwitchCheermoteImageTheme>(),
            Dark = data.Get("dark").As<TwitchCheermoteImageTheme>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cheermote_images.gd");
        var request = script.Call("new").AsGodotObject();
        if(Light != null) request.Set("light", Light);
        if(Dark != null) request.Set("dark", Dark);
        return request;
    }

}
