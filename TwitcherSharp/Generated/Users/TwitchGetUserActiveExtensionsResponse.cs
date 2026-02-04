using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Users;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetUserActiveExtensionsResponse : Resource, ITwitcherSharp<TwitchGetUserActiveExtensionsResponse>
{
    private GodotObject _data;
	public TwitchData Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetUserActiveExtensionsResponse object.
    /// </summary> 
    public static TwitchGetUserActiveExtensionsResponse FromObject(GodotObject data)
    {
		return new TwitchGetUserActiveExtensionsResponse
		{
			Data = data.Get("data").As<TwitchData>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_active_extensions.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
