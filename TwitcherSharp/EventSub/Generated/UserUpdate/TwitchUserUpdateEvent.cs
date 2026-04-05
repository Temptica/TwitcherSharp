using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.UserUpdate;

public partial class TwitchUserUpdateEvent : RefCounted, ITwitcherSharpEventSub<TwitchUserUpdateEvent>
{
    /// <summary> 
    /// The user’s user id.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The user’s user login.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The user’s user display name.
    /// </summary>
    public string UserName { get; set; }

    /// <summary> 
    /// The user’s email address. The event includes the user’s email address only if the app used to request this event type includes the user:read:email scope for the user; otherwise, the field is set to an empty string. See Create EventSub Subscription.
    /// </summary>
    public string Email { get; set; }

    /// <summary> 
    /// A Boolean value that determines whether Twitch has verified the user’s email address. Is true if Twitch has verified the email address; otherwise, false.NOTE: Ignore this field if the email field contains an empty string.
    /// </summary>
    public bool EmailVerified { get; set; }

    /// <summary> 
    /// The user’s description.
    /// </summary>
    public string Description { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserUpdateEvent object.
    /// </summary> 
    public static TwitchUserUpdateEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchUserUpdateEvent
        {
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            Email = data.Get("email").AsString(),
            EmailVerified = data.Get("email_verified").AsBool(),
            Description = data.Get("description").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_user_update.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("email", Email);
        request.Set("email_verified", EmailVerified);
        request.Set("description", Description);
        return request;
    }
}
