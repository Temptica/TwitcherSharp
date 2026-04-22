using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelGuestStarSessionBegin;

public partial class TwitchChannelGuestStarSessionBeginEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelGuestStarSessionBeginEvent>
{
    /// <summary> 
    /// The broadcaster user ID.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster display name.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The broadcaster login.
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
    /// Transforms the godot data into a TwitchChannelGuestStarSessionBeginEvent object.
    /// </summary> 
    public static TwitchChannelGuestStarSessionBeginEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelGuestStarSessionBeginEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            SessionId = data.Get("session_id").AsString(),
            StartedAt = data.Get("started_at").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_guest_star_session_begin.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("session_id", SessionId);
        request.Set("started_at", StartedAt);
        return request;
    }
}
