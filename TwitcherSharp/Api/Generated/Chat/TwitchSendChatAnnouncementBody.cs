using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchSendChatAnnouncementBody : RefCounted, ITwitcherSharp<TwitchSendChatAnnouncementBody>
{
    private GodotObject _data;
    public string Message { get; set; }
    public string Color { get; set; }
    public bool? ForSourceOnly { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSendChatAnnouncementBody object.
    /// </summary> 
    public static TwitchSendChatAnnouncementBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchSendChatAnnouncementBody
        {
            Message = data.Get("message").AsString(),
            Color = data.Get("color").AsString(),
            ForSourceOnly = data.Get("for_source_only").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_send_chat_announcement.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("message", Message);
        if(Color != null) request.Set("color", Color);
        if(ForSourceOnly.HasValue) request.Set("for_source_only", ForSourceOnly.Value);
        return request;
    }

}
