using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchCheermoteImageTheme : RefCounted, ITwitcherSharp<TwitchCheermoteImageTheme>
{
    private GodotObject? _data;
    public TwitchCheermoteImageFormat? Animated { get => field ??= _data?.Get<TwitchCheermoteImageFormat>("animated"); set; }
    public TwitchCheermoteImageFormat? Static { get => field ??= _data?.Get<TwitchCheermoteImageFormat>("static"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheermoteImageTheme object.
    /// </summary> 
    public static TwitchCheermoteImageTheme? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCheermoteImageTheme();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cheermote_image_theme.gd");
        var request = script.Call("new").AsGodotObject();
        if(Animated != null) request.Set("animated", Animated);
        if(Static != null) request.Set("static", Static);
        return request;
    }

}
