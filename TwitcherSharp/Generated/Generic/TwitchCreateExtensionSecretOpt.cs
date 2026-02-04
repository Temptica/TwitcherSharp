using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.CreateExtensionSecret 
/// </summary>
public partial class TwitchCreateExtensionSecretOpt : Resource, ITwitcherSharp<TwitchCreateExtensionSecretOpt>
{
    private GodotObject _data;
	public int Delay { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchCreateExtensionSecretOpt object.
    /// </summary> 
    public static TwitchCreateExtensionSecretOpt FromObject(GodotObject data)
    {
		return new TwitchCreateExtensionSecretOpt
		{
			Delay = data.Get("delay").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_extension_secret.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("delay", Delay);
		return request;
	}
}
