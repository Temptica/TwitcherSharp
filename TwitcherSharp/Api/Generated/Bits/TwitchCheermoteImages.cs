using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchCheermoteImages : RefCounted, ITwitcherSharp<TwitchCheermoteImages>
{
    private Variant _data;
    public TwitchCheermoteImageTheme? Light { get => field ??= _data.Get<TwitchCheermoteImageTheme>("light"); set; }
    public TwitchCheermoteImageTheme? Dark { get => field ??= _data.Get<TwitchCheermoteImageTheme>("dark"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheermoteImages object.
    /// </summary> 
    public static TwitchCheermoteImages? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCheermoteImages();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_cheermote_images.gd");
        if(Light != null) request.SetValue("light", Light);
        if(Dark != null) request.SetValue("dark", Dark);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
