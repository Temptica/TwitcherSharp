using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
///  
/// </summary>
public partial class CreateExtensionSecretResponse : Resource, ITwitcherSharp<CreateExtensionSecretResponse>
{
    private GodotObject _data;
	public ExtensionSecret[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreateExtensionSecretResponse object.
    /// </summary> 
    public static CreateExtensionSecretResponse FromObject(GodotObject data)
    {
        return new CreateExtensionSecretResponse
        {

			Data = data.Get("data").As<ExtensionSecret[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_extension_secret_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
