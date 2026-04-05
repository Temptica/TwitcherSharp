using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelFollow;

public partial class TwitchChannelFollowEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelFollowEvent>
{
    /// <summary> 
    /// The user ID for the user now following the specified channel.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The user login for the user now following the specified channel.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The user display name for the user now following the specified channel.
    /// </summary>
    public string UserName { get; set; }

    /// <summary> 
    /// The requested broadcaster ID.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The requested broadcaster login.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The requested broadcaster display name.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// RFC3339 timestamp of when the follow occurred.
    /// </summary>
    public string FollowedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelFollowEvent object.
    /// </summary> 
    public static TwitchChannelFollowEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelFollowEvent
        {
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            FollowedAt = data.Get("followed_at").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_follow.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("followed_at", FollowedAt);
        return request;
    }
}
