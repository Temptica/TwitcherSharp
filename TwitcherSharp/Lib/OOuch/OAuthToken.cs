using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Lib.OOuch;

/// <summary>
/// Used to store and load token's and to exchange them through the code.
/// Try to avoid debugging this object cause it leaks your access and refresh tokens
/// Hint never stores the token value as string in your code to reduce the chance
/// to leak the tokens always use the getter.
/// </summary>
public partial class OAuthToken : Resource, ITwitcherSharp<OAuthToken>
{
    private GodotObject _data;

    /// <summary>
    /// Returns if it's a user access token or app accessToken
    /// </summary>
    public StringName Type { get; set; }
    
    /// <summary>
    /// Called when the token was resolved / accessToken got refreshed
    /// </summary>
    [Signal]
    public delegate void AuthorizedEventHandler();

    public void update_values(string accessToken, string refreshToken, int expireIn, string[] scopes, string tokenType)
        => _data.Call("update_values", accessToken, refreshToken, expireIn, scopes, tokenType);

    public bool LoadTokens() => _data.Call("load_tokens").AsBool();

    public void RemoveTokens() => _data.Call("remove_tokens");

    public string GetRefreshToken() => _data.Call("get_refresh_token").AsString();

    public string GetAccessToken() => _data.Call("get_access_token").AsString();


    public List<string> GetScopes() => _data.Call("get_scopes").AsStringArray().ToList();

    public int GetExpiration() => _data.Call("get_expiration").AsInt32();

    public string GetExpirationReadable() => _data.Call("get_expiration_readable").AsString();

    public void Invalidate() => _data.Call("invalidate");
    
    public bool HasRefreshToken() => _data.Call("has_refresh_token").AsBool();
    
    public bool IsTokenValid() => _data.Call("is_token_valid").AsBool();
    
    public override string ToString() => _data.Call("to_string").AsString();

    public static List<string> GetIdentifiers(string cacheFile) 
        => GD.Load<GDScript>("res://addons/twitcher/lib/oOuch/oauth_token.gd")
            .Call("get_identifiers",cacheFile)
            .AsStringArray()
            .ToList();

    private void ConnectSignals()
    {
        _data.Connect("authorized", Callable.From(EmitSignalAuthorized));
    }

    public static OAuthToken FromObject(GodotObject data)
    {
        if(data is null) return null;
        
        var tokenHandler = new OAuthToken()
        {
            _data = data,
            Type = data.Get("type").AsString()
        };
        
        tokenHandler.ConnectSignals();
        return tokenHandler;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/lib/oOuch/oauth_token.gd");
        var instance = script.New().AsGodotObject();
        instance.Set("type", Type);
        
        return instance;
    }
}