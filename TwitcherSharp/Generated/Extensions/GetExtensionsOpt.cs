using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensions 
/// </summary>
public partial class GetExtensionsOpt : Resource, ITwitcherSharp<GetExtensionsOpt>
{
    private GodotObject _data;
	public string ExtensionVersion { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetExtensionsOpt object.
    /// </summary> 
    public static GetExtensionsOpt FromObject(GodotObject data)
    {
        return new GetExtensionsOpt
        {

			ExtensionVersion = data.Get("extension_version").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extensions_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("extension_version", ExtensionVersion);
		return request;
	}
}
