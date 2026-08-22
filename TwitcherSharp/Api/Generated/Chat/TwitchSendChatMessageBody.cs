using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchSendChatMessageBody : RefCounted, ITwitcherSharp<TwitchSendChatMessageBody>
{
    private GodotObject? _data;
    public string BroadcasterId { get; set; } = null!;
    public string SenderId { get; set; } = null!;
    public string Message { get; set; } = null!;
    public string? ReplyParentMessageId { get; set; }
    public bool? ForSourceOnly { get; set; }
    public bool? Pin { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSendChatMessageBody object.
    /// </summary> 
    public static TwitchSendChatMessageBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchSendChatMessageBody
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            SenderId = data.Get("sender_id").AsString(),
            Message = data.Get("message").AsString(),
            ReplyParentMessageId = data.Get("reply_parent_message_id").AsString(),
            ForSourceOnly = data.Get("for_source_only").AsBool(),
            Pin = data.Get("pin").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_chat_message.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        if(SenderId != null) request.Set("sender_id", SenderId);
        if(Message != null) request.Set("message", Message);
        if(ReplyParentMessageId != null) request.Set("reply_parent_message_id", ReplyParentMessageId);
        if(ForSourceOnly.HasValue) request.Set("for_source_only", ForSourceOnly.Value);
        if(Pin.HasValue) request.Set("pin", Pin.Value);
        return request;
    }

}
