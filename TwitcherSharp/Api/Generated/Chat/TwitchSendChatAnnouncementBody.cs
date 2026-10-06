using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchSendChatAnnouncementBody : RefCounted, ITwitcherSharp<TwitchSendChatAnnouncementBody>
{
    private Variant _data;
    public string Message { get; set; } = null!;
    public string? Color { get; set; }
    public bool? ForSourceOnly { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSendChatAnnouncementBody object.
    /// </summary> 
    public static TwitchSendChatAnnouncementBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchSendChatAnnouncementBody
        {
            Message = data.Read("message", static v => v.AsString()),
            Color = data.Read("color", static v => v.AsString()),
            ForSourceOnly = data.Read("for_source_only", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_send_chat_announcement.gd", "Body");
        if(Message != null) request.SetValue("message", Message);
        if(Color != null) request.SetValue("color", Color);
        if(ForSourceOnly.HasValue) request.SetValue("for_source_only", ForSourceOnly.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
