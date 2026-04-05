using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchSendChatAnnouncementBody : RefCounted, ITwitcherSharp<TwitchSendChatAnnouncementBody>
{
    private GodotObject _data;
    public string Message { get; set; }
    public string Color { get; set; }
    public bool? SourceOnly { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSendChatAnnouncementBody object.
    /// </summary> 
    public static TwitchSendChatAnnouncementBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchSendChatAnnouncementBody
        {
            Message = data.Get("message").AsString(),
            Color = data.Get("color").AsString(),
            SourceOnly = data.Get("source_only").AsBool(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_chat_announcement.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("message", Message);
        if(Color != null) request.Set("color", Color);
        if(SourceOnly.HasValue) request.Set("source_only", SourceOnly.Value);
        return request;
    }

}
