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
        return new TwitchExtensionIconUrls
        {
            _100x100 = data.Get("100x_100").AsString(),
            _24x24 = data.Get("24x_24").AsString(),
            _300x200 = data.Get("300x_200").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_icon_urls.gd");
        var request = script.Call("new").AsGodotObject();
        if(_100x100 != null) request.Set("100x_100", _100x100);
        if(_24x24 != null) request.Set("24x_24", _24x24);
        if(_300x200 != null) request.Set("300x_200", _300x200);
        return request;
    }

}
