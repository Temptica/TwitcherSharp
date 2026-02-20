using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelModeratorAdd;

public partial class TwitchChannelModeratorAddEvent : Resource, ITwitcherSharpEventSub<TwitchChannelModeratorAddEvent>
{
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
    /// The user ID of the new moderator.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The user login of the new moderator.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The display name of the new moderator.
    /// </summary>
    public string UserName { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelModeratorAddEvent object.
    /// </summary> 
    public static TwitchChannelModeratorAddEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelModeratorAddEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderator_add.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        return request;
    }
}
