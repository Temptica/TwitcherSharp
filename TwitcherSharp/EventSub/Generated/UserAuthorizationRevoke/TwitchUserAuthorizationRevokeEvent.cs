using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.UserAuthorizationRevoke;

public partial class TwitchUserAuthorizationRevokeEvent : Resource, ITwitcherSharpEventSub<TwitchUserAuthorizationRevokeEvent>
{
    /// <summary> 
    /// The client_id of the application with revoked user access.
    /// </summary>
    public string ClientId { get; set; }

    /// <summary> 
    /// The user id for the user who has revoked authorization for your client id.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The user login for the user who has revoked authorization for your client id. This is null if the user no longer exists.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The user display name for the user who has revoked authorization for your client id. This is null if the user no longer exists.
    /// </summary>
    public string UserName { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserAuthorizationRevokeEvent object.
    /// </summary> 
    public static TwitchUserAuthorizationRevokeEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchUserAuthorizationRevokeEvent
        {
            ClientId = data.Get("client_id").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_user_authorization_revoke.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("client_id", ClientId);
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        return request;
    }
}
