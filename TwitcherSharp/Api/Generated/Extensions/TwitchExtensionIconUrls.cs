using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;


/// <summary> 
/// A dictionary that contains URLs to different sizes of the default icon. The dictionary’s key identifies the icon’s size (for example, 24x24), and the dictionary’s value contains the URL to the icon. 
/// </summary>
public partial class TwitchExtensionIconUrls : RefCounted, ITwitcherSharp<TwitchExtensionIconUrls>
{
    private GodotObject _data;
    public string _100x100 { get; set; }
    public string _24x24 { get; set; }
    public string _300x200 { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionIconUrls object.
    /// </summary> 
    public static TwitchExtensionIconUrls FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchExtensionIconUrls
        {
            _100x100 = data.Get("_100x100").AsString(),
            _24x24 = data.Get("_24x24").AsString(),
            _300x200 = data.Get("_300x200").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_icon_urls.gd");
        var request = script.Call("new").AsGodotObject();
        if(_100x100 != null) request.Set("_100x100", _100x100);
        if(_24x24 != null) request.Set("_24x24", _24x24);
        if(_300x200 != null) request.Set("_300x200", _300x200);
        return request;
    }

}
