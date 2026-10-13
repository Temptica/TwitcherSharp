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
            UserId = data.ReadAsString("user_id"),
            InvitedAt = data.ReadAsString("invited_at"),
            Status = data.ReadAsString("status"),
            IsVideoEnabled = data.ReadAsBool("is_video_enabled"),
            IsAudioEnabled = data.ReadAsBool("is_audio_enabled"),
            IsVideoAvailable = data.ReadAsBool("is_video_available"),
            IsAudioAvailable = data.ReadAsBool("is_audio_available"),
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
