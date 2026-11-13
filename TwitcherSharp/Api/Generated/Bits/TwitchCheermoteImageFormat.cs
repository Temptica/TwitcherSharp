using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchCheermoteImageFormat : RefCounted, ITwitcherSharp<TwitchCheermoteImageFormat>
{
    private Variant _data;
    public string? _1 { get; set; }
    public string? _2 { get; set; }
    public string? _3 { get; set; }
    public string? _4 { get; set; }
    public string? _1_5 { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheermoteImageFormat object.
    /// </summary> 
    public static TwitchCheermoteImageFormat? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCheermoteImageFormat
        {
            _1 = data.ReadAsString("_1"),
            _2 = data.ReadAsString("_2"),
            _3 = data.ReadAsString("_3"),
            _4 = data.ReadAsString("_4"),
            _1_5 = data.ReadAsString("_1_5"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_cheermote_image_format.gd");
        if(_1 != null) request.SetValue("_1", _1);
        if(_2 != null) request.SetValue("_2", _2);
        if(_3 != null) request.SetValue("_3", _3);
        if(_4 != null) request.SetValue("_4", _4);
        if(_1_5 != null) request.SetValue("_1_5", _1_5);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
