using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class UserChatColor : Resource, ITwitcherSharp<UserChatColor>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string UserLogin { get; set; }
	public string UserName { get; set; }
	public string Color { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UserChatColor object.
    /// </summary> 
    public static UserChatColor FromObject(GodotObject data)
    {
        return new UserChatColor
        {

			UserId = data.Get("user_id").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			UserName = data.Get("user_name").AsString(),
			Color = data.Get("color").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_user_chat_color.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("user_login", UserLogin);
		request.Set("user_name", UserName);
		request.Set("color", Color);
		return request;
	}
}
