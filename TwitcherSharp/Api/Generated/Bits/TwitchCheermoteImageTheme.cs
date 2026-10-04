using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchCheermoteImageTheme : RefCounted, ITwitcherSharp<TwitchCheermoteImageTheme>
{
    private Variant _data;
    public TwitchCheermoteImageFormat? Animated { get => field ??= _data.Get<TwitchCheermoteImageFormat>("animated_format"); set; }
    public TwitchCheermoteImageFormat? Static { get => field ??= _data.Get<TwitchCheermoteImageFormat>("static_format"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheermoteImageTheme object.
    /// </summary> 
    public static TwitchCheermoteImageTheme? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCheermoteImageTheme();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_cheermote_image_theme.gd");
        if(Animated != null) request.SetValue("animated_format", Animated);
        if(Static != null) request.SetValue("static_format", Static);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
