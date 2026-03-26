using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSharedChatSessionEnd;

public partial class TwitchChannelSharedChatSessionEndEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelSharedChatSessionEndEvent>
{
    /// <summary> 
    /// The unique identifier for the shared chat session.
    /// </summary>
    public string SessionId { get; set; }

    /// <summary> 
    /// The User ID of the channel in the subscription condition which is no longer active in the shared chat session.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The display name of the channel in the subscription condition which is no longer active in the shared chat session.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The user login of the channel in the subscription condition which is no longer active in the shared chat session.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The User ID of the host channel.
    /// </summary>
    public string HostBroadcasterUserId { get; set; }

    /// <summary> 
    /// The display name of the host channel.
    /// </summary>
    public string HostBroadcasterUserName { get; set; }

    /// <summary> 
    /// The user login of the host channel.
    /// </summary>
    public string HostBroadcasterUserLogin { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSharedChatSessionEndEvent object.
    /// </summary> 
    public static TwitchChannelSharedChatSessionEndEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelSharedChatSessionEndEvent
        {
            SessionId = data.Get("session_id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            HostBroadcasterUserId = data.Get("host_broadcaster_user_id").AsString(),
            HostBroadcasterUserName = data.Get("host_broadcaster_user_name").AsString(),
            HostBroadcasterUserLogin = data.Get("host_broadcaster_user_login").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_shared_chat_session_end.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("session_id", SessionId);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("host_broadcaster_user_id", HostBroadcasterUserId);
        request.Set("host_broadcaster_user_name", HostBroadcasterUserName);
        request.Set("host_broadcaster_user_login", HostBroadcasterUserLogin);
        return request;
    }
}
