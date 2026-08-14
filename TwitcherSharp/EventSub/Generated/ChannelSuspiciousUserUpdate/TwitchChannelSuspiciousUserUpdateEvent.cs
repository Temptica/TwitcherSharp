using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSuspiciousUserUpdate;

public partial class TwitchChannelSuspiciousUserUpdateEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelSuspiciousUserUpdateEvent>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The ID of the channel where the treatment for a suspicious user was updated.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The display name of the channel where the treatment for a suspicious user was updated.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The Login of the channel where the treatment for a suspicious user was updated.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The ID of the moderator that updated the treatment for a suspicious user.
    /// </summary>
    public string? ModeratorUserId { get; set; }

    /// <summary> 
    /// The display name of the moderator that updated the treatment for a suspicious user.
    /// </summary>
    public string? ModeratorUserName { get; set; }

    /// <summary> 
    /// The login of the moderator that updated the treatment for a suspicious user.
    /// </summary>
    public string? ModeratorUserLogin { get; set; }

    /// <summary> 
    /// The ID of the suspicious user whose treatment was updated.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The display name of the suspicious user whose treatment was updated.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The login of the suspicious user whose treatment was updated.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The status set for the suspicious user. Can be the following: “none”, “active_monitoring”, or “restricted”.
    /// </summary>
    public string? LowTrustStatus { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSuspiciousUserUpdateEvent object.
    /// </summary> 
    public static TwitchChannelSuspiciousUserUpdateEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelSuspiciousUserUpdateEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
            ModeratorUserName = data.Get("moderator_user_name").AsString(),
            ModeratorUserLogin = data.Get("moderator_user_login").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserName = data.Get("user_name").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            LowTrustStatus = data.Get("low_trust_status").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_suspicious_user_update.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(ModeratorUserId != null) request.Set("moderator_user_id", ModeratorUserId);
        if(ModeratorUserName != null) request.Set("moderator_user_name", ModeratorUserName);
        if(ModeratorUserLogin != null) request.Set("moderator_user_login", ModeratorUserLogin);
        if(UserId != null) request.Set("user_id", UserId);
        if(UserName != null) request.Set("user_name", UserName);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(LowTrustStatus != null) request.Set("low_trust_status", LowTrustStatus);
        return request;
    }
}
