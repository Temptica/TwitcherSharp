using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;


/// <summary> 
/// All optional parameters for TwitchAPI.GetReleasedExtensions 
/// </summary>
public partial class TwitchGetReleasedExtensionsOpt : RefCounted, ITwitcherSharp<TwitchGetReleasedExtensionsOpt>
{
    private GodotObject _data;
    public string ExtensionVersion { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetReleasedExtensionsOpt object.
    /// </summary> 
    public static TwitchGetReleasedExtensionsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetReleasedExtensionsOpt
        {
            ExtensionVersion = data.Get("extension_version").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_released_extensions.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(ExtensionVersion != null) request.Set("extension_version", ExtensionVersion);
        return request;
    }

}
