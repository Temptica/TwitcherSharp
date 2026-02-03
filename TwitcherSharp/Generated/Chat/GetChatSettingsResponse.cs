using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class GetChatSettingsResponse : Resource, ITwitcherSharp<GetChatSettingsResponse>
{
    private GodotObject _data;
	public ChatSettings[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetChatSettingsResponse object.
    /// </summary> 
    public static GetChatSettingsResponse FromObject(GodotObject data)
    {
        return new GetChatSettingsResponse
        {

			Data = data.Get("data").As<ChatSettings[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_chat_settings_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
