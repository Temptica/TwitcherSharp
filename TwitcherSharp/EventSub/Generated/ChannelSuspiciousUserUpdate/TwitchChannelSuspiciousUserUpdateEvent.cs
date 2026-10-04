using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSuspiciousUserUpdate;

public partial class TwitchChannelSuspiciousUserUpdateEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelSuspiciousUserUpdateEvent>
{
    private Variant _data;
    
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
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            ModeratorUserId = data.Read("moderator_user_id", static v => v.AsString()),
            ModeratorUserName = data.Read("moderator_user_name", static v => v.AsString()),
            ModeratorUserLogin = data.Read("moderator_user_login", static v => v.AsString()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            LowTrustStatus = data.Read("low_trust_status", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_suspicious_user_update.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(ModeratorUserId != null) request.SetValue("moderator_user_id", ModeratorUserId);
        if(ModeratorUserName != null) request.SetValue("moderator_user_name", ModeratorUserName);
        if(ModeratorUserLogin != null) request.SetValue("moderator_user_login", ModeratorUserLogin);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(LowTrustStatus != null) request.SetValue("low_trust_status", LowTrustStatus);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
