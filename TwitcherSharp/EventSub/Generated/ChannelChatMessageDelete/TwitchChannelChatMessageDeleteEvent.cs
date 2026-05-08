using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatMessageDelete;

public partial class TwitchChannelChatMessageDeleteEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelChatMessageDeleteEvent>
{
    private GodotObject _data;
    
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
    /// The ID of the user whose message was deleted.
    /// </summary>
    public string TargetUserId { get; set; }

    /// <summary> 
    /// The user name of the user whose message was deleted.
    /// </summary>
    public string TargetUserName { get; set; }

    /// <summary> 
    /// The user login of the user whose message was deleted.
    /// </summary>
    public string TargetUserLogin { get; set; }

    /// <summary> 
    /// A UUID that identifies the message that was removed.
    /// </summary>
    public string MessageId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatMessageDeleteEvent object.
    /// </summary> 
    public static TwitchChannelChatMessageDeleteEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelChatMessageDeleteEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            TargetUserId = data.Get("target_user_id").AsString(),
            TargetUserName = data.Get("target_user_name").AsString(),
            TargetUserLogin = data.Get("target_user_login").AsString(),
            MessageId = data.Get("message_id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message_delete.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("target_user_id", TargetUserId);
        request.Set("target_user_name", TargetUserName);
        request.Set("target_user_login", TargetUserLogin);
        request.Set("message_id", MessageId);
        return request;
    }
}
