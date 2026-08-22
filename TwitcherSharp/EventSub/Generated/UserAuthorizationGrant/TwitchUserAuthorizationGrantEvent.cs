using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.UserAuthorizationGrant;

public partial class TwitchUserAuthorizationGrantEvent : RefCounted, ITwitcherSharpEventSub<TwitchUserAuthorizationGrantEvent>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The client_id of the application that was granted user access.
    /// </summary>
    public string? ClientId { get; set; }

    /// <summary> 
    /// The user id for the user who has granted authorization for your client id.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The user login for the user who has granted authorization for your client id.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The user display name for the user who has granted authorization for your client id.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserAuthorizationGrantEvent object.
    /// </summary> 
    public static TwitchUserAuthorizationGrantEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUserAuthorizationGrantEvent
        {
            ClientId = data.Get("client_id").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_user_authorization_grant.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(ClientId != null) request.Set("client_id", ClientId);
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        return request;
    }
}
