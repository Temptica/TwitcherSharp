using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelGuestStarSessionEnd;

public partial class TwitchChannelGuestStarSessionEndEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelGuestStarSessionEndEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The non-host broadcaster user ID.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The non-host broadcaster display name.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The non-host broadcaster login.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user ID of the moderator who started or ended the session.
    /// </summary>
    public string? ModeratorUserId { get; set; }

    /// <summary> 
    /// The display name of the moderator.
    /// </summary>
    public string? ModeratorUserName { get; set; }

    /// <summary> 
    /// The login of the moderator.
    /// </summary>
    public string? ModeratorUserLogin { get; set; }

    /// <summary> 
    /// ID representing the unique session that was started.
    /// </summary>
    public string? SessionId { get; set; }

    /// <summary> 
    /// RFC3339 timestamp indicating the time the session began.
    /// </summary>
    public string? StartedAt { get; set; }

    /// <summary> 
    /// RFC3339 timestamp indicating the time the session ended.
    /// </summary>
    public string? EndedAt { get; set; }

    /// <summary> 
    /// User ID of the host channel.
    /// </summary>
    public string? HostUserId { get; set; }

    /// <summary> 
    /// The host display name.
    /// </summary>
    public string? HostUserName { get; set; }

    /// <summary> 
    /// The host login.
    /// </summary>
    public string? HostUserLogin { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelGuestStarSessionEndEvent object.
    /// </summary> 
    public static TwitchChannelGuestStarSessionEndEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelGuestStarSessionEndEvent
        {
            BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
            BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
            BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
            ModeratorUserId = data.ReadAsString("moderator_user_id"),
            ModeratorUserName = data.ReadAsString("moderator_user_name"),
            ModeratorUserLogin = data.ReadAsString("moderator_user_login"),
            SessionId = data.ReadAsString("session_id"),
            StartedAt = data.ReadAsString("started_at"),
            EndedAt = data.ReadAsString("ended_at"),
            HostUserId = data.ReadAsString("host_user_id"),
            HostUserName = data.ReadAsString("host_user_name"),
            HostUserLogin = data.ReadAsString("host_user_login"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_guest_star_session_end.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(ModeratorUserId != null) request.SetValue("moderator_user_id", ModeratorUserId);
        if(ModeratorUserName != null) request.SetValue("moderator_user_name", ModeratorUserName);
        if(ModeratorUserLogin != null) request.SetValue("moderator_user_login", ModeratorUserLogin);
        if(SessionId != null) request.SetValue("session_id", SessionId);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        if(EndedAt != null) request.SetValue("ended_at", EndedAt);
        if(HostUserId != null) request.SetValue("host_user_id", HostUserId);
        if(HostUserName != null) request.SetValue("host_user_name", HostUserName);
        if(HostUserLogin != null) request.SetValue("host_user_login", HostUserLogin);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
