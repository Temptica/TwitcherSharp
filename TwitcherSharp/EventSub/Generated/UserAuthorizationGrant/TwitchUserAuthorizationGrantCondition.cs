using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.UserAuthorizationGrant;

public partial class TwitchUserAuthorizationGrantCondition(string clientId) : RefCounted, ITwitcherSharpCondition<TwitchUserAuthorizationGrantCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchUserAuthorizationGrantCondition);

    /// <summary> 
    /// Your application’s client id. The provided client_id must match the client id in the application access token.
    /// </summary>
    public string ClientId { get; set; } = clientId;

    /// <summary> 
    /// Transforms the godot data into a TwitchUserAuthorizationGrantCondition object.
    /// </summary> 
    public static TwitchUserAuthorizationGrantCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUserAuthorizationGrantCondition(data.Read("client_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_user_authorization_grant.gd", "Condition");
        request.SetValue("client_id", ClientId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchUserAuthorizationGrantCondition FromDictionary(Dictionary data)
    {
        return new TwitchUserAuthorizationGrantCondition(data["client_id"].AsString())
        {
        };
    }

    public Dictionary ToDictionary()
    {
        return new Dictionary
        {
            {"client_id", ClientId},
        };
    }
}
