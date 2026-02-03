using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
///  
/// </summary>
public partial class GetExtensionSecretsResponse : Resource, ITwitcherSharp<GetExtensionSecretsResponse>
{
    private GodotObject _data;
	public ExtensionSecret[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetExtensionSecretsResponse object.
    /// </summary> 
    public static GetExtensionSecretsResponse FromObject(GodotObject data)
    {
        return new GetExtensionSecretsResponse
        {

			Data = data.Get("data").As<ExtensionSecret[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_secrets_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
