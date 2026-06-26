using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelGuestStarSessionEnd;

public partial class TwitchChannelGuestStarSessionEndEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelGuestStarSessionEndEvent>
{
    private GodotObject _data;
    
    /// <summary> 
    /// The non-host broadcaster user ID.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The non-host broadcaster display name.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The non-host broadcaster login.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// ID representing the unique session that was started.
    /// </summary>
    public string SessionId { get; set; }

    /// <summary> 
    /// RFC3339 timestamp indicating the time the session began.
    /// </summary>
    public string StartedAt { get; set; }

    /// <summary> 
    /// RFC3339 timestamp indicating the time the session ended.
    /// </summary>
    public string EndedAt { get; set; }

    /// <summary> 
    /// User ID of the host channel.
    /// </summary>
    public string HostUserId { get; set; }

    /// <summary> 
    /// The host display name.
    /// </summary>
    public string HostUserName { get; set; }

    /// <summary> 
    /// The host login.
    /// </summary>
    public string HostUserLogin { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelGuestStarSessionEndEvent object.
    /// </summary> 
    public static TwitchChannelGuestStarSessionEndEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelGuestStarSessionEndEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            SessionId = data.Get("session_id").AsString(),
            StartedAt = data.Get("started_at").AsString(),
            EndedAt = data.Get("ended_at").AsString(),
            HostUserId = data.Get("host_user_id").AsString(),
            HostUserName = data.Get("host_user_name").AsString(),
            HostUserLogin = data.Get("host_user_login").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_guest_star_session_end.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("session_id", SessionId);
        request.Set("started_at", StartedAt);
        request.Set("ended_at", EndedAt);
        request.Set("host_user_id", HostUserId);
        request.Set("host_user_name", HostUserName);
        request.Set("host_user_login", HostUserLogin);
        return request;
    }
}
