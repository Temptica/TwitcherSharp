using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensions 
/// </summary>
public partial class TwitchGetExtensionsOpt : Resource, ITwitcherSharp<TwitchGetExtensionsOpt>
{
    private GodotObject _data;
	public string ExtensionVersion { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionsOpt object.
    /// </summary> 
    public static TwitchGetExtensionsOpt FromObject(GodotObject data)
    {
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
		request.Set("extension_version", ExtensionVersion);
		return request;
	}
}
