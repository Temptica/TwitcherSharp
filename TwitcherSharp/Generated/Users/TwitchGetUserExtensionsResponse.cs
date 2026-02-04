using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Users;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetUserExtensionsResponse : Resource, ITwitcherSharp<TwitchGetUserExtensionsResponse>
{
    private GodotObject _data;
	public TwitchUserExtension[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserExtensionsResponse object.
    /// </summary> 
    public static TwitchGetUserExtensionsResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetUserExtensionsResponse
		{
			Data = dataArray.Select(TwitchUserExtension.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_extensions.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
