using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.UserAuthorizationGrant;

public partial class TwitchUserAuthorizationGrantEvent : RefCounted, ITwitcherSharpEventSub<TwitchUserAuthorizationGrantEvent>
{
    private Variant _data;
    
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
            ClientId = data.ReadAsString("client_id"),
            UserId = data.ReadAsString("user_id"),
            UserLogin = data.ReadAsString("user_login"),
            UserName = data.ReadAsString("user_name"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_user_authorization_grant.gd", "Event");
        if(ClientId != null) request.SetValue("client_id", ClientId);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
