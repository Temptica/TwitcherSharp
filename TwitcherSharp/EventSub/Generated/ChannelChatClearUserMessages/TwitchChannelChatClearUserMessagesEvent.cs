using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatClearUserMessages;

public partial class TwitchChannelChatClearUserMessagesEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelChatClearUserMessagesEvent>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The broadcaster user ID.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster display name.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The broadcaster login.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The ID of the user that was banned or put in a timeout. All of their messages are deleted.
    /// </summary>
    public string? TargetUserId { get; set; }

    /// <summary> 
    /// The user name of the user that was banned or put in a timeout.
    /// </summary>
    public string? TargetUserName { get; set; }

    /// <summary> 
    /// The user login of the user that was banned or put in a timeout.
    /// </summary>
    public string? TargetUserLogin { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatClearUserMessagesEvent object.
    /// </summary> 
    public static TwitchChannelChatClearUserMessagesEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelChatClearUserMessagesEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            TargetUserId = data.Get("target_user_id").AsString(),
            TargetUserName = data.Get("target_user_name").AsString(),
            TargetUserLogin = data.Get("target_user_login").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_clear_user_messages.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(TargetUserId != null) request.Set("target_user_id", TargetUserId);
        if(TargetUserName != null) request.Set("target_user_name", TargetUserName);
        if(TargetUserLogin != null) request.Set("target_user_login", TargetUserLogin);
        return request;
    }
}
