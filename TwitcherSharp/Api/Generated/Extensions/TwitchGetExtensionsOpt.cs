using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;


/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensions 
/// </summary>
public partial class TwitchGetExtensionsOpt : RefCounted, ITwitcherSharp<TwitchGetExtensionsOpt>
{
    private GodotObject _data;
    public string ExtensionVersion { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionsOpt object.
    /// </summary> 
    public static TwitchGetExtensionsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetExtensionsOpt
        {
            ExtensionVersion = data.Get("extension_version").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extensions.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(ExtensionVersion != null) request.Set("extension_version", ExtensionVersion);
        return request;
    }

}
