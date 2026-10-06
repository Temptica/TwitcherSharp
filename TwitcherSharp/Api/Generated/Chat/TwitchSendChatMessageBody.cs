using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchSendChatMessageBody : RefCounted, ITwitcherSharp<TwitchSendChatMessageBody>
{
    private Variant _data;
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
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            SenderId = data.Read("sender_id", static v => v.AsString()),
            Message = data.Read("message", static v => v.AsString()),
            ReplyParentMessageId = data.Read("reply_parent_message_id", static v => v.AsString()),
            ForSourceOnly = data.Read("for_source_only", static v => v.AsBool()),
            Pin = data.Read("pin", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_send_chat_message.gd", "Body");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(SenderId != null) request.SetValue("sender_id", SenderId);
        if(Message != null) request.SetValue("message", Message);
        if(ReplyParentMessageId != null) request.SetValue("reply_parent_message_id", ReplyParentMessageId);
        if(ForSourceOnly.HasValue) request.SetValue("for_source_only", ForSourceOnly.Value);
        if(Pin.HasValue) request.SetValue("pin", Pin.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
