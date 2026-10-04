using Godot;
using TwitcherSharp.Extensions;
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
    private Variant _data;

    /// <summary>
    /// Returns if it's a user access token or app accessToken
    /// </summary>
    public StringName? Type { get; set; }
    
    /// <summary>
    /// Called when the token was resolved / accessToken got refreshed
    /// </summary>
    [Signal]
    public delegate void AuthorizedEventHandler();

    public void update_values(string accessToken, string refreshToken, int expireIn, string[] scopes, string tokenType)
        => _data.Invoke("update_values", accessToken, refreshToken, expireIn, scopes, tokenType);

    public bool LoadTokens() => _data.Invoke("load_tokens", static v => v.AsBool());

    public void RemoveTokens() => _data.Invoke("remove_tokens");

    public string GetRefreshToken() => _data.Invoke("get_refresh_token", static v => v.AsString()) ?? "";

    public string GetAccessToken() => _data.Invoke("get_access_token", static v => v.AsString()) ?? "";


    public List<string> GetScopes() => (_data.Invoke("get_scopes", static v => v.AsStringArray()) ?? []).ToList();

    public int GetExpiration() => _data.Invoke("get_expiration", static v => v.AsInt32());

    public string GetExpirationReadable() => _data.Invoke("get_expiration_readable", static v => v.AsString()) ?? "";

    public void Invalidate() => _data.Invoke("invalidate");
    
    public bool HasRefreshToken() => _data.Invoke("has_refresh_token", static v => v.AsBool());
    
    public bool IsTokenValid() => _data.Invoke("is_token_valid", static v => v.AsBool());
    
    public override string ToString() => _data.Invoke("to_string", static v => v.AsString()) ?? "";

    public static List<string> GetIdentifiers(string cacheFile) 
    {
        using var script = GD.Load<GDScript>("res://addons/twitcher/lib/oOuch/oauth_token.gd");
        return script.Invoke("get_identifiers", static v => v.AsStringArray(), cacheFile).ToList();
    }

    private void ConnectSignals()
    {
        _data.With(data => data.Connect("authorized", Callable.From(EmitSignalAuthorized)));
    }

    public static OAuthToken? FromObject(GodotObject? data)
    {
        if(data is null) return null;
        
        var tokenHandler = new OAuthToken()
        {
            _data = Variant.CreateFrom(data),
            Type = data.Read("type", static v => v.AsString())
        };
        
        tokenHandler.ConnectSignals();
        return tokenHandler;
    }

    public GodotObject ToGodotObject()
    {
        var instance = InteropExtension.NewObject("res://addons/twitcher/lib/oOuch/oauth_token.gd");
        if (Type != null) instance.SetValue("type", Type);
        
        return instance;
    }
}