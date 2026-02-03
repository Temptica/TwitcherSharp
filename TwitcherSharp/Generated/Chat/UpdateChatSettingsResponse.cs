using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateChatSettingsResponse : Resource, ITwitcherSharp<UpdateChatSettingsResponse>
{
    private GodotObject _data;
	public ChatSettingsUpdated[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateChatSettingsResponse object.
    /// </summary> 
    public static UpdateChatSettingsResponse FromObject(GodotObject data)
    {
        return new UpdateChatSettingsResponse
        {

			Data = data.Get("data").As<ChatSettingsUpdated[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_chat_settings_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
