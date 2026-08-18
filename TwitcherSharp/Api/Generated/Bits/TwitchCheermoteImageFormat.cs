using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchCheermoteImageFormat : RefCounted, ITwitcherSharp<TwitchCheermoteImageFormat>
{
    private GodotObject _data;
    public string _1 { get; set; }
    public string _2 { get; set; }
    public string _3 { get; set; }
    public string _4 { get; set; }
    public string _1_5 { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheermoteImageFormat object.
    /// </summary> 
    public static TwitchCheermoteImageFormat FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchCheermoteImageFormat
        {
            _1 = data.Get("_1").AsString(),
            _2 = data.Get("_2").AsString(),
            _3 = data.Get("_3").AsString(),
            _4 = data.Get("_4").AsString(),
            _1_5 = data.Get("_1_5").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cheermote_image_format.gd");
        var request = script.Call("new").AsGodotObject();
        if(_1 != null) request.Set("_1", _1);
        if(_2 != null) request.Set("_2", _2);
        if(_3 != null) request.Set("_3", _3);
        if(_4 != null) request.Set("_4", _4);
        if(_1_5 != null) request.Set("_1_5", _1_5);
        return request;
    }

}
