using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.UserAuthorizationRevoke;

public partial class TwitchUserAuthorizationRevokeCondition(string clientId) : RefCounted, ITwitcherSharpCondition<TwitchUserAuthorizationRevokeCondition>
{
    private GodotObject _data;
    
    public string Name => nameof(TwitchUserAuthorizationRevokeCondition);

    /// <summary> 
    /// Your application’s client id. The provided client_id must match the client id in the application access token.
    /// </summary>
    public string ClientId { get; set; } = clientId;

    /// <summary> 
    /// Transforms the godot data into a TwitchUserAuthorizationRevokeCondition object.
    /// </summary> 
    public static TwitchUserAuthorizationRevokeCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchUserAuthorizationRevokeCondition(data.Get("client_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_user_authorization_revoke.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("client_id", ClientId);
        return request;
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
