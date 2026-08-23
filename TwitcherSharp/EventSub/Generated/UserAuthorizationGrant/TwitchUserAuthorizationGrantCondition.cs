using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.UserAuthorizationGrant;

public partial class TwitchUserAuthorizationGrantCondition(string clientId) : RefCounted, ITwitcherSharpCondition<TwitchUserAuthorizationGrantCondition>
{
    private GodotObject? _data;
    
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
        var instance = new TwitchUserAuthorizationGrantCondition(data.Get("client_id").AsString());
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_user_authorization_grant.gd");
        var conditionClass = script.Get("Condition").As<GDScript>();
        var request = conditionClass.New().AsGodotObject();
        request.Set("client_id", ClientId);
        return request;
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
