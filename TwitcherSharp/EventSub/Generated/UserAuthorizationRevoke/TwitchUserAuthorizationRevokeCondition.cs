using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.UserAuthorizationRevoke;

public partial class TwitchUserAuthorizationRevokeCondition(string clientId) : RefCounted, ITwitcherSharpCondition<TwitchUserAuthorizationRevokeCondition>
{
    private Variant _data;
    
    public string Name => nameof(TwitchUserAuthorizationRevokeCondition);

    /// <summary> 
    /// Your application’s client id. The provided client_id must match the client id in the application access token.
    /// </summary>
    public string ClientId { get; set; } = clientId;

    /// <summary> 
    /// Transforms the godot data into a TwitchUserAuthorizationRevokeCondition object.
    /// </summary> 
    public static TwitchUserAuthorizationRevokeCondition? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUserAuthorizationRevokeCondition(data.Read("client_id", static v => v.AsString()));
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_user_authorization_revoke.gd", "Condition");
        request.SetValue("client_id", ClientId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

    public static TwitchUserAuthorizationRevokeCondition FromDictionary(Dictionary data)
    {
        return new TwitchUserAuthorizationRevokeCondition(data["client_id"].AsString())
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
