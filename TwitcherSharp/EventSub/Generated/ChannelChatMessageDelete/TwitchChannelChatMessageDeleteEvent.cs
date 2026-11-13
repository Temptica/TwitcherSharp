using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatMessageDelete;

public partial class TwitchChannelChatMessageDeleteEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelChatMessageDeleteEvent>
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
    /// The ID of the user whose message was deleted.
    /// </summary>
    public string? TargetUserId { get; set; }

    /// <summary> 
    /// The user name of the user whose message was deleted.
    /// </summary>
    public string? TargetUserName { get; set; }

    /// <summary> 
    /// The user login of the user whose message was deleted.
    /// </summary>
    public string? TargetUserLogin { get; set; }

    /// <summary> 
    /// A UUID that identifies the message that was removed.
    /// </summary>
    public string? MessageId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatMessageDeleteEvent object.
    /// </summary> 
    public static TwitchChannelChatMessageDeleteEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelChatMessageDeleteEvent
        {
            BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
            BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
            BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
            TargetUserId = data.ReadAsString("target_user_id"),
            TargetUserName = data.ReadAsString("target_user_name"),
            TargetUserLogin = data.ReadAsString("target_user_login"),
            MessageId = data.ReadAsString("message_id"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message_delete.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(TargetUserId != null) request.SetValue("target_user_id", TargetUserId);
        if(TargetUserName != null) request.SetValue("target_user_name", TargetUserName);
        if(TargetUserLogin != null) request.SetValue("target_user_login", TargetUserLogin);
        if(MessageId != null) request.SetValue("message_id", MessageId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
