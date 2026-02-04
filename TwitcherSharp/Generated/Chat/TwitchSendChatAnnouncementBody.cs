using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchSendChatAnnouncementBody : Resource, ITwitcherSharp<TwitchSendChatAnnouncementBody>
{
    private GodotObject _data;
	public string Message { get; set; }
	public string Color { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchSendChatAnnouncementBody object.
    /// </summary> 
    public static TwitchSendChatAnnouncementBody FromObject(GodotObject data)
    {
		return new TwitchSendChatAnnouncementBody
		{
			Message = data.Get("message").AsString(),
			Color = data.Get("color").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_chat_announcement.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("message", Message);
		request.Set("color", Color);
		return request;
	}
}
