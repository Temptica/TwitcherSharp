using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchShoutoutReceived : RefCounted, ITwitcherSharpEventSub<TwitchShoutoutReceived>
{
    private GodotObject _data;
    
    /// <summary> 
    /// An ID that identifies the broadcaster that received the Shoutout.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster’s login name.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster’s display name.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// An ID that identifies the broadcaster that sent the Shoutout.
    /// </summary>
    public string FromBroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster’s login name.
    /// </summary>
    public string FromBroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster’s display name.
    /// </summary>
    public string FromBroadcasterUserName { get; set; }

    /// <summary> 
    /// The number of users that were watching the from-broadcaster’s stream at the time of the Shoutout.
    /// </summary>
    public int ViewerCount { get; set; }

    /// <summary> 
    /// The UTC timestamp (in RFC3339 format) of when the moderator sent the Shoutout.
    /// </summary>
    public string StartedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchShoutoutReceived object.
    /// </summary> 
    public static TwitchShoutoutReceived FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchShoutoutReceived
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            FromBroadcasterUserId = data.Get("from_broadcaster_user_id").AsString(),
            FromBroadcasterUserLogin = data.Get("from_broadcaster_user_login").AsString(),
            FromBroadcasterUserName = data.Get("from_broadcaster_user_name").AsString(),
            ViewerCount = data.Get("viewer_count").AsInt32(),
            StartedAt = data.Get("started_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_shoutout_received.gd");
        var request = script.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("from_broadcaster_user_id", FromBroadcasterUserId);
        request.Set("from_broadcaster_user_login", FromBroadcasterUserLogin);
        request.Set("from_broadcaster_user_name", FromBroadcasterUserName);
        request.Set("viewer_count", ViewerCount);
        request.Set("started_at", StartedAt);
        return request;
    }
}
