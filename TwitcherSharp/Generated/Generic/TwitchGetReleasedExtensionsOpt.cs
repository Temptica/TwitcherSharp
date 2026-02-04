using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetReleasedExtensions 
/// </summary>
public partial class TwitchGetReleasedExtensionsOpt : Resource, ITwitcherSharp<TwitchGetReleasedExtensionsOpt>
{
    private GodotObject _data;
	public string ExtensionVersion { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetReleasedExtensionsOpt object.
    /// </summary> 
    public static TwitchGetReleasedExtensionsOpt FromObject(GodotObject data)
    {
		return new TwitchGetReleasedExtensionsOpt
		{
			ExtensionVersion = data.Get("extension_version").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_released_extensions.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("extension_version", ExtensionVersion);
		return request;
	}
}
