using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class GetUserChatColorResponse : Resource, ITwitcherSharp<GetUserChatColorResponse>
{
    private GodotObject _data;
	public UserChatColor[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetUserChatColorResponse object.
    /// </summary> 
    public static GetUserChatColorResponse FromObject(GodotObject data)
    {
        return new GetUserChatColorResponse
        {

			Data = data.Get("data").As<UserChatColor[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_chat_color_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
