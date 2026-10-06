using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatClearUserMessages;

public partial class TwitchChannelChatClearUserMessagesEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelChatClearUserMessagesEvent>
{
    private Variant _data;
    
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
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            TargetUserId = data.Read("target_user_id", static v => v.AsString()),
            TargetUserName = data.Read("target_user_name", static v => v.AsString()),
            TargetUserLogin = data.Read("target_user_login", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_clear_user_messages.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(TargetUserId != null) request.SetValue("target_user_id", TargetUserId);
        if(TargetUserName != null) request.SetValue("target_user_name", TargetUserName);
        if(TargetUserLogin != null) request.SetValue("target_user_login", TargetUserLogin);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
