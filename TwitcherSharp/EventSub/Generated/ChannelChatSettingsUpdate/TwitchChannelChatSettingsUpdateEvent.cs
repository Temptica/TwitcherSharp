using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatSettingsUpdate;

public partial class TwitchChannelChatSettingsUpdateEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelChatSettingsUpdateEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The ID of the broadcaster specified in the request.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the broadcaster specified in the request.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user name of the broadcaster specified in the request.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// A Boolean value that determines whether chat messages must contain only emotes. True if only messages that are 100% emotes are allowed; otherwise false.
    /// </summary>
    public bool EmoteMode { get; set; }

    /// <summary> 
    /// A Boolean value that determines whether the broadcaster restricts the chat room to followers only, based on how long they’ve followed.True if the broadcaster restricts the chat room to followers only; otherwise false.See follower_mode_duration_minutes for how long the followers must have followed the broadcaster to participate in the chat room.
    /// </summary>
    public bool FollowerMode { get; set; }

    /// <summary> 
    /// The length of time, in minutes, that the followers must have followed the broadcaster to participate in the chat room. See follower_mode.Null if follower_mode is false.
    /// </summary>
    public int FollowerModeDurationMinutes { get; set; }

    /// <summary> 
    /// A Boolean value that determines whether the broadcaster limits how often users in the chat room are allowed to send messages.Is true, if the broadcaster applies a delay; otherwise, false.See slow_mode_wait_time_seconds for the delay.
    /// </summary>
    public bool SlowMode { get; set; }

    /// <summary> 
    /// The amount of time, in seconds, that users need to wait between sending messages. See slow_mode.Null if slow_mode is false.
    /// </summary>
    public int SlowModeWaitTimeSeconds { get; set; }

    /// <summary> 
    /// A Boolean value that determines whether only users that subscribe to the broadcaster’s channel can talk in the chat room.True if the broadcaster restricts the chat room to subscribers only; otherwise false.
    /// </summary>
    public bool SubscriberMode { get; set; }

    /// <summary> 
    /// A Boolean value that determines whether the broadcaster requires users to post only unique messages in the chat room.True if the broadcaster requires unique messages only; otherwise false.
    /// </summary>
    public bool UniqueChatMode { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatSettingsUpdateEvent object.
    /// </summary> 
    public static TwitchChannelChatSettingsUpdateEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelChatSettingsUpdateEvent
        {
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            EmoteMode = data.Read("emote_mode", static v => v.AsBool()),
            FollowerMode = data.Read("follower_mode", static v => v.AsBool()),
            FollowerModeDurationMinutes = data.Read("follower_mode_duration_minutes", static v => v.AsInt32()),
            SlowMode = data.Read("slow_mode", static v => v.AsBool()),
            SlowModeWaitTimeSeconds = data.Read("slow_mode_wait_time_seconds", static v => v.AsInt32()),
            SubscriberMode = data.Read("subscriber_mode", static v => v.AsBool()),
            UniqueChatMode = data.Read("unique_chat_mode", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_settings_update.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        request.SetValue("emote_mode", EmoteMode);
        request.SetValue("follower_mode", FollowerMode);
        request.SetValue("follower_mode_duration_minutes", FollowerModeDurationMinutes);
        request.SetValue("slow_mode", SlowMode);
        request.SetValue("slow_mode_wait_time_seconds", SlowModeWaitTimeSeconds);
        request.SetValue("subscriber_mode", SubscriberMode);
        request.SetValue("unique_chat_mode", UniqueChatMode);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
