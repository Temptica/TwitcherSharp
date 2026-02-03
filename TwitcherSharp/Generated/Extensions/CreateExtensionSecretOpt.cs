using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
/// All optional parameters for TwitchAPI.CreateExtensionSecret 
/// </summary>
public partial class CreateExtensionSecretOpt : Resource, ITwitcherSharp<CreateExtensionSecretOpt>
{
    private GodotObject _data;
	public int Delay { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreateExtensionSecretOpt object.
    /// </summary> 
    public static CreateExtensionSecretOpt FromObject(GodotObject data)
    {
        return new CreateExtensionSecretOpt
        {

			Delay = data.Get("delay").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_extension_secret_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("delay", Delay);
		return request;
	}
}
