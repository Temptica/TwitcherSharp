using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchSendChatMessageBody : Resource, ITwitcherSharp<TwitchSendChatMessageBody>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public string SenderId { get; set; }
	public string Message { get; set; }
	public string ReplyParentMessageId { get; set; }
	public bool? ForSourceOnly { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSendChatMessageBody object.
    /// </summary> 
    public static TwitchSendChatMessageBody FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchSendChatMessageBody
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
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_chat_message.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("sender_id", SenderId);
		request.Set("message", Message);
		if(ReplyParentMessageId != null) request.Set("reply_parent_message_id", ReplyParentMessageId);
		if(ForSourceOnly.HasValue) request.Set("for_source_only", ForSourceOnly.Value);
		return request;
	}
}
