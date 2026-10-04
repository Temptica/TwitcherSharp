using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchGuestStarInvite : RefCounted, ITwitcherSharp<TwitchGuestStarInvite>
{
    private Variant _data;
    public string UserId { get; set; } = null!;
    public string InvitedAt { get; set; } = null!;
    public string Status { get; set; } = null!;
    public bool IsVideoEnabled { get; set; }
    public bool IsAudioEnabled { get; set; }
    public bool IsVideoAvailable { get; set; }
    public bool IsAudioAvailable { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGuestStarInvite object.
    /// </summary> 
    public static TwitchGuestStarInvite? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGuestStarInvite
        {
            UserId = data.Read("user_id", static v => v.AsString()),
            InvitedAt = data.Read("invited_at", static v => v.AsString()),
            Status = data.Read("status", static v => v.AsString()),
            IsVideoEnabled = data.Read("is_video_enabled", static v => v.AsBool()),
            IsAudioEnabled = data.Read("is_audio_enabled", static v => v.AsBool()),
            IsVideoAvailable = data.Read("is_video_available", static v => v.AsBool()),
            IsAudioAvailable = data.Read("is_audio_available", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_guest_star_invite.gd");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(InvitedAt != null) request.SetValue("invited_at", InvitedAt);
        if(Status != null) request.SetValue("status", Status);
        request.SetValue("is_video_enabled", IsVideoEnabled);
        request.SetValue("is_audio_enabled", IsAudioEnabled);
        request.SetValue("is_video_available", IsVideoAvailable);
        request.SetValue("is_audio_available", IsAudioAvailable);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
