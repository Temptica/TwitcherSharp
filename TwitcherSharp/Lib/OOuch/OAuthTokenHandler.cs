using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Lib.OOuch;

public partial class OAuthTokenHandler : Resource, ITwitcherSharp<OAuthTokenHandler>
{
    private GodotObject? _data;

    [Signal]
    public delegate void TokenResolvedEventHandler(OAuthToken tokens);

    [Signal]
    public delegate void UnauthenticatedEventHandler();

    public OAuthToken? Token
    {
        get;
        set
        {
            _data?.Call("_update_token", value?.ToGodotObject() ?? new Variant());
            field = value;
        }
    }

    public void UpdateExpirationCheck() => _data!.Call("update_expiration_check");

    public async Task<OAuthToken> RequestToken(string grantType, string authCode = "")
        => await _data!.CallAsync<OAuthToken>("request_token", grantType, authCode);

    public async Task RequestDeviceToken(OAuthDeviceCodeResponse deviceCodeResponse, string scope,
        string grantType = "urn:ietf:params:oauth:grant-type:device_code")
        => await _data!.CallAsync("request_device_token", deviceCodeResponse.ToGodotObject(), scope, grantType);

    public async Task RefreshTokens() => await _data!.CallAsync("refresh_tokens");

    /// <summary>
    /// Updates the token. The result is the response data of a token request.
    /// </summary>
    /// <param name="accessToken"></param>
    /// <param name="refreshToken"></param>
    /// <param name="expireIn"></param>
    /// <param name="scopes"></param>
    /// <param name="type"></param>
    public void UpdateTokens(string accessToken, string refreshToken, int expireIn, string[] scopes, string type)
        => _data!.Call("update_tokens", accessToken, refreshToken, expireIn, scopes, type);

    public string GetTokenExpiration()
        => _data!.Call("get_token_expiration").AsString();

    public bool TokenIsValid() => _data!.Call("is_token_valid").AsBool();

    public bool TokenNeedsRefresh() => _data!.Call("token_needs_refresh").AsBool();

    public async Task<string> GetAccessToken() => (await _data!.CallAsync("get_access_token")).AsString();

    public async Task<bool> HasRefreshToken() => (await _data!.CallAsync("has_refresh_token")).AsBool();

    public List<string> GetScopes() => _data!.Call("get_scopes").AsStringArray().ToList();

    private void ConnectSignals()
    {
        _data!.Connect("token_resolved", Callable.FromTwitcherSharp<OAuthToken>(EmitSignalTokenResolved));
        _data!.Connect("unauthenticated", Callable.From(EmitSignalUnauthenticated));
    }

    public static OAuthTokenHandler? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var token = new OAuthTokenHandler();
        token._data = data;
        token.Token = OAuthToken.FromObject(data.Get("token").AsGodotObject());
        token.ConnectSignals();

        return token;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/lib/oOuch/oauth_token_handler.gd");
        var token = script.New().AsGodotObject();
        token.Set("token", Token?.ToGodotObject() ?? new Variant());
        
        return token;
    }
}