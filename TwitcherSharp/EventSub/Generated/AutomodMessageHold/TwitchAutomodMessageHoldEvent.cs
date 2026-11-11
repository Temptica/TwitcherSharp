using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.AutomodMessageHold;

public partial class TwitchAutomodMessageHoldEvent : RefCounted, ITwitcherSharpEventSub<TwitchAutomodMessageHoldEvent>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The ID of the broadcaster specified in the subscription condition.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the broadcaster specified in the subscription condition.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The display name of the broadcaster specified in the subscription condition.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The message sender's User ID.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The message sender's login name.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The message sender's display name.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The ID of the message that was flagged by AutoMod.
    /// </summary>
    public string? MessageId { get; set; }

    /// <summary> 
    /// The body of the message.
    /// </summary>
    public TwitchMessage? Message { get => field ??= _data?.Get<TwitchMessage>("message"); set; }

    /// <summary> 
    /// The category of the message.
    /// </summary>
    public string? Category { get; set; }

    /// <summary> 
    /// The level of severity. Measured between 1 to 4.
    /// </summary>
    public int Level { get; set; }

    /// <summary> 
    /// The timestamp of when AutoMod saved the message.
    /// </summary>
    public string? HeldAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAutomodMessageHoldEvent object.
    /// </summary> 
    public static TwitchAutomodMessageHoldEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchAutomodMessageHoldEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            MessageId = data.Get("message_id").AsString(),
            Category = data.Get("category").AsString(),
            Level = data.Get("level").AsInt32(),
            HeldAt = data.Get("held_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_message_hold.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        if(MessageId != null) request.Set("message_id", MessageId);
        if(Message != null) request.Set("message", Message.ToGodotObject());
        if(Category != null) request.Set("category", Category);
        request.Set("level", Level);
        if(HeldAt != null) request.Set("held_at", HeldAt);
        return request;
    }
}
