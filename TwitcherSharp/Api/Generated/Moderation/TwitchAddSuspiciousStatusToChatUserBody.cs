using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchAddSuspiciousStatusToChatUserBody : RefCounted, ITwitcherSharp<TwitchAddSuspiciousStatusToChatUserBody>
{
    private GodotObject _data;
    public string UserId { get; set; }
    public string Status { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAddSuspiciousStatusToChatUserBody object.
    /// </summary> 
    public static TwitchAddSuspiciousStatusToChatUserBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchAddSuspiciousStatusToChatUserBody
        {
            UserId = data.Get("user_id").AsString(),
            Status = data.Get("status").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_add_suspicious_status_to_chat_user.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("status", Status);
        return request;
    }

}
