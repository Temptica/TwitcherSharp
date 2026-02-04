using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Users;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUpdateUserExtensionsResponse : Resource, ITwitcherSharp<TwitchUpdateUserExtensionsResponse>
{
    private GodotObject _data;
	public TwitchData Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateUserExtensionsResponse object.
    /// </summary> 
    public static TwitchUpdateUserExtensionsResponse FromObject(GodotObject data)
    {
		return new TwitchUpdateUserExtensionsResponse
		{
			Data = data.Get("data").As<TwitchData>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_user_extensions.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
