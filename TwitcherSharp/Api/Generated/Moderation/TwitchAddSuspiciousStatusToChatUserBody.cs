using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchAddSuspiciousStatusToChatUserBody : RefCounted, ITwitcherSharp<TwitchAddSuspiciousStatusToChatUserBody>
{
    private Variant _data;
    public string UserId { get; set; } = null!;
    public string Status { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchAddSuspiciousStatusToChatUserBody object.
    /// </summary> 
    public static TwitchAddSuspiciousStatusToChatUserBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchAddSuspiciousStatusToChatUserBody
        {
            UserId = data.Read("user_id", static v => v.AsString()),
            Status = data.Read("status", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_add_suspicious_status_to_chat_user.gd", "Body");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(Status != null) request.SetValue("status", Status);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
