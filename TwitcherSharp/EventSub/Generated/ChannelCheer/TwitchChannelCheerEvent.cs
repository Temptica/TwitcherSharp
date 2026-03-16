using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelCheer;

public partial class TwitchChannelCheerEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelCheerEvent>
{
    /// <summary> 
    /// Whether the user cheered anonymously or not.
    /// </summary>
    public bool IsAnonymous { get; set; }

    /// <summary> 
    /// The user ID for the user who cheered on the specified channel. This is null if is_anonymous is true.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The user login for the user who cheered on the specified channel. This is null if is_anonymous is true.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The user display name for the user who cheered on the specified channel. This is null if is_anonymous is true.
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
    /// The message sent with the cheer.
    /// </summary>
    public string Message { get; set; }

    /// <summary> 
    /// The number of Bits cheered.
    /// </summary>
    public int Bits { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelCheerEvent object.
    /// </summary> 
    public static TwitchChannelCheerEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelCheerEvent
        {
            IsAnonymous = data.Get("is_anonymous").AsBool(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            Message = data.Get("message").AsString(),
            Bits = data.Get("bits").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_cheer.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("is_anonymous", IsAnonymous);
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("message", Message);
        request.Set("bits", Bits);
        return request;
    }
}
