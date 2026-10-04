using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;


/// <summary> 
/// All optional parameters for TwitchAPI.GetReleasedExtensions 
/// </summary>
public partial class TwitchGetReleasedExtensionsOpt : RefCounted, ITwitcherSharp<TwitchGetReleasedExtensionsOpt>
{
    private Variant _data;
    public string? ExtensionVersion { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetReleasedExtensionsOpt object.
    /// </summary> 
    public static TwitchGetReleasedExtensionsOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetReleasedExtensionsOpt
        {
            ExtensionVersion = data.Read("extension_version", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_released_extensions.gd", "Opt");
        if(ExtensionVersion != null) request.SetValue("extension_version", ExtensionVersion);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
