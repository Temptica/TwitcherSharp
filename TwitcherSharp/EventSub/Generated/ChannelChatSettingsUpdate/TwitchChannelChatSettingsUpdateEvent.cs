using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatSettingsUpdate;

public partial class TwitchChannelChatSettingsUpdateEvent : Resource, ITwitcherSharpEventSub<TwitchChannelChatSettingsUpdateEvent>
{
    /// <summary> 
    /// The ID of the broadcaster specified in the request.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the broadcaster specified in the request.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user name of the broadcaster specified in the request.
    /// </summary>
    public string BroadcasterUserName { get; set; }

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
    public static TwitchChannelChatSettingsUpdateEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelChatSettingsUpdateEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            EmoteMode = data.Get("emote_mode").AsBool(),
            FollowerMode = data.Get("follower_mode").AsBool(),
            FollowerModeDurationMinutes = data.Get("follower_mode_duration_minutes").AsInt32(),
            SlowMode = data.Get("slow_mode").AsBool(),
            SlowModeWaitTimeSeconds = data.Get("slow_mode_wait_time_seconds").AsInt32(),
            SubscriberMode = data.Get("subscriber_mode").AsBool(),
            UniqueChatMode = data.Get("unique_chat_mode").AsBool(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_settings_update.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("emote_mode", EmoteMode);
        request.Set("follower_mode", FollowerMode);
        request.Set("follower_mode_duration_minutes", FollowerModeDurationMinutes);
        request.Set("slow_mode", SlowMode);
        request.Set("slow_mode_wait_time_seconds", SlowModeWaitTimeSeconds);
        request.Set("subscriber_mode", SubscriberMode);
        request.Set("unique_chat_mode", UniqueChatMode);
        return request;
    }
}
