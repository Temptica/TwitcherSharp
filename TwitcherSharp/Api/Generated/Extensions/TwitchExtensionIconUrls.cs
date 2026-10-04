using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;


/// <summary> 
/// A dictionary that contains URLs to different sizes of the default icon. The dictionary’s key identifies the icon’s size (for example, 24x24), and the dictionary’s value contains the URL to the icon. 
/// </summary>
public partial class TwitchExtensionIconUrls : RefCounted, ITwitcherSharp<TwitchExtensionIconUrls>
{
    private Variant _data;
    public string? _100x100 { get; set; }
    public string? _24x24 { get; set; }
    public string? _300x200 { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionIconUrls object.
    /// </summary> 
    public static TwitchExtensionIconUrls? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchExtensionIconUrls
        {
            _100x100 = data.Read("_100x100", static v => v.AsString()),
            _24x24 = data.Read("_24x24", static v => v.AsString()),
            _300x200 = data.Read("_300x200", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_extension_icon_urls.gd");
        if(_100x100 != null) request.SetValue("_100x100", _100x100);
        if(_24x24 != null) request.SetValue("_24x24", _24x24);
        if(_300x200 != null) request.SetValue("_300x200", _300x200);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
