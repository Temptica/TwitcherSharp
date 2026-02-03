using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class SendChatMessageBody : Resource, ITwitcherSharp<SendChatMessageBody>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public string SenderId { get; set; }
	public string Message { get; set; }
	public string ReplyParentMessageId { get; set; }
	public bool ForSourceOnly { get; set; }
    /// <summary> 
    /// Transforms the godot data into a SendChatMessageBody object.
    /// </summary> 
    public static SendChatMessageBody FromObject(GodotObject data)
    {
        return new SendChatMessageBody
        {

			BroadcasterId = data.Get("broadcaster_id").AsString(),
			SenderId = data.Get("sender_id").AsString(),
			Message = data.Get("message").AsString(),
			ReplyParentMessageId = data.Get("reply_parent_message_id").AsString(),
			ForSourceOnly = data.Get("for_source_only").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_chat_message_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("sender_id", SenderId);
		request.Set("message", Message);
		request.Set("reply_parent_message_id", ReplyParentMessageId);
		request.Set("for_source_only", ForSourceOnly);
		return request;
	}
}
