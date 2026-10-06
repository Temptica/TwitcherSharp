using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.UserUpdate;

public partial class TwitchUserUpdateEvent : RefCounted, ITwitcherSharpEventSub<TwitchUserUpdateEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The user’s user id.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The user’s user login.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The user’s user display name.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The user’s email address. The event includes the user’s email address only if the app used to request this event type includes the user:read:email scope for the user; otherwise, the field is set to an empty string. See Create EventSub Subscription.
    /// </summary>
    public string? Email { get; set; }

    /// <summary> 
    /// A Boolean value that determines whether Twitch has verified the user’s email address. Is true if Twitch has verified the email address; otherwise, false.NOTE: Ignore this field if the email field contains an empty string.
    /// </summary>
    public bool EmailVerified { get; set; }

    /// <summary> 
    /// The user’s description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserUpdateEvent object.
    /// </summary> 
    public static TwitchUserUpdateEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUserUpdateEvent
        {
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            Email = data.Read("email", static v => v.AsString()),
            EmailVerified = data.Read("email_verified", static v => v.AsBool()),
            Description = data.Read("description", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_user_update.gd", "Event");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(Email != null) request.SetValue("email", Email);
        request.SetValue("email_verified", EmailVerified);
        if(Description != null) request.SetValue("description", Description);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
