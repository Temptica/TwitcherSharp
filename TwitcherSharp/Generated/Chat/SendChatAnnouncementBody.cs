using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class SendChatAnnouncementBody : Resource, ITwitcherSharp<SendChatAnnouncementBody>
{
    private GodotObject _data;
	public string Message { get; set; }
	public string Color { get; set; }
    /// <summary> 
    /// Transforms the godot data into a SendChatAnnouncementBody object.
    /// </summary> 
    public static SendChatAnnouncementBody FromObject(GodotObject data)
    {
        return new SendChatAnnouncementBody
        {

			Message = data.Get("message").AsString(),
			Color = data.Get("color").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_chat_announcement_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("message", Message);
		request.Set("color", Color);
		return request;
	}
}
