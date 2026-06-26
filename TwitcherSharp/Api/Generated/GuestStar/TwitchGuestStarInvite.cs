using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchGuestStarInvite : RefCounted, ITwitcherSharp<TwitchGuestStarInvite>
{
    private GodotObject _data;
    public string UserId { get; set; }
    public string InvitedAt { get; set; }
    public string Status { get; set; }
    public bool IsVideoEnabled { get; set; }
    public bool IsAudioEnabled { get; set; }
    public bool IsVideoAvailable { get; set; }
    public bool IsAudioAvailable { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGuestStarInvite object.
    /// </summary> 
    public static TwitchGuestStarInvite FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGuestStarInvite
        {
            UserId = data.Get("user_id").AsString(),
            InvitedAt = data.Get("invited_at").AsString(),
            Status = data.Get("status").AsString(),
            IsVideoEnabled = data.Get("is_video_enabled").AsBool(),
            IsAudioEnabled = data.Get("is_audio_enabled").AsBool(),
            IsVideoAvailable = data.Get("is_video_available").AsBool(),
            IsAudioAvailable = data.Get("is_audio_available").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_guest_star_invite.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("invited_at", InvitedAt);
        request.Set("status", Status);
        request.Set("is_video_enabled", IsVideoEnabled);
        request.Set("is_audio_enabled", IsAudioEnabled);
        request.Set("is_video_available", IsVideoAvailable);
        request.Set("is_audio_available", IsAudioAvailable);
        return request;
    }

}
