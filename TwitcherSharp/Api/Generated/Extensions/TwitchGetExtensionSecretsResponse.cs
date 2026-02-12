using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetExtensionSecretsResponse : Resource, ITwitcherSharp<TwitchGetExtensionSecretsResponse>
{
    private GodotObject _data;
	public TwitchExtensionSecret[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionSecretsResponse object.
    /// </summary> 
    public static TwitchGetExtensionSecretsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetExtensionSecretsResponse
		{
			Data = dataArray.Select(TwitchExtensionSecret.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_secrets.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
