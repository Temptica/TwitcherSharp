using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetReleasedExtensions 
/// </summary>
public partial class GetReleasedExtensionsOpt : Resource, ITwitcherSharp<GetReleasedExtensionsOpt>
{
    private GodotObject _data;
	public string ExtensionVersion { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetReleasedExtensionsOpt object.
    /// </summary> 
    public static GetReleasedExtensionsOpt FromObject(GodotObject data)
    {
        return new GetReleasedExtensionsOpt
        {

			ExtensionVersion = data.Get("extension_version").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_released_extensions_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("extension_version", ExtensionVersion);
		return request;
	}
}
