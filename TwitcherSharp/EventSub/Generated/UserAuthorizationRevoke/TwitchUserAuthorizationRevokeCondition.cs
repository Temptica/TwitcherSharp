using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.UserAuthorizationRevoke;

public partial class TwitchUserAuthorizationRevokeCondition : RefCounted, ITwitcherSharpCondition<TwitchUserAuthorizationRevokeCondition>
{
    public string Name => nameof(TwitchUserAuthorizationRevokeCondition);

    /// <summary> 
    /// Your application’s client id. The provided client_id must match the client id in the application access token.
    /// </summary>
    public string ClientId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUserAuthorizationRevokeCondition object.
    /// </summary> 
    public static TwitchUserAuthorizationRevokeCondition FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchUserAuthorizationRevokeCondition
        {
            ClientId = data.Get("client_id").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_user_authorization_revoke.gd");
        var conditionClass = script.Get("Condition").AsGodotObject();
        var request = conditionClass.Call("new").AsGodotObject();
        request.Set("client_id", ClientId);
        return request;
    }
}
