using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Users;
 
/// <summary> 
///  
/// </summary>
public partial class GetUserExtensionsResponse : Resource, ITwitcherSharp<GetUserExtensionsResponse>
{
    private GodotObject _data;
	public UserExtension[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetUserExtensionsResponse object.
    /// </summary> 
    public static GetUserExtensionsResponse FromObject(GodotObject data)
    {
        return new GetUserExtensionsResponse
        {

			Data = data.Get("data").As<UserExtension[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_extensions_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
