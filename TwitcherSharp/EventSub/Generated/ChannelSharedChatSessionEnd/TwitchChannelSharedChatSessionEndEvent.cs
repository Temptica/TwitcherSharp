using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSharedChatSessionEnd;

public partial class TwitchChannelSharedChatSessionEndEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelSharedChatSessionEndEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The unique identifier for the shared chat session.
    /// </summary>
    public string? SessionId { get; set; }

    /// <summary> 
    /// The User ID of the channel in the subscription condition which is no longer active in the shared chat session.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The display name of the channel in the subscription condition which is no longer active in the shared chat session.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The user login of the channel in the subscription condition which is no longer active in the shared chat session.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The User ID of the host channel.
    /// </summary>
    public string? HostBroadcasterUserId { get; set; }

    /// <summary> 
    /// The display name of the host channel.
    /// </summary>
    public string? HostBroadcasterUserName { get; set; }

    /// <summary> 
    /// The user login of the host channel.
    /// </summary>
    public string? HostBroadcasterUserLogin { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSharedChatSessionEndEvent object.
    /// </summary> 
    public static TwitchChannelSharedChatSessionEndEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelSharedChatSessionEndEvent
        {
            SessionId = data.Read("session_id", static v => v.AsString()),
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            HostBroadcasterUserId = data.Read("host_broadcaster_user_id", static v => v.AsString()),
            HostBroadcasterUserName = data.Read("host_broadcaster_user_name", static v => v.AsString()),
            HostBroadcasterUserLogin = data.Read("host_broadcaster_user_login", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_shared_chat_session_end.gd", "Event");
        if(SessionId != null) request.SetValue("session_id", SessionId);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(HostBroadcasterUserId != null) request.SetValue("host_broadcaster_user_id", HostBroadcasterUserId);
        if(HostBroadcasterUserName != null) request.SetValue("host_broadcaster_user_name", HostBroadcasterUserName);
        if(HostBroadcasterUserLogin != null) request.SetValue("host_broadcaster_user_login", HostBroadcasterUserLogin);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
