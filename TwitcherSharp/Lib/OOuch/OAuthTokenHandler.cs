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
            using var token = GodotObjectExtension.ToVariant(value);
            _data?.Invoke("_update_token", token);
            field = value;
        }
    }

    public void UpdateExpirationCheck() => _data!.Invoke("update_expiration_check");

    public async Task<OAuthToken> RequestToken(string grantType, string authCode = "")
        => await _data!.CallAsync<OAuthToken>("request_token", grantType, authCode);

    public async Task RequestDeviceToken(OAuthDeviceCodeResponse deviceCodeResponse, string scope,
        string grantType = "urn:ietf:params:oauth:grant-type:device_code")
    {
        using var response = GodotObjectExtension.ToVariant(deviceCodeResponse);
        using var _ = await _data!.CallAsync("request_device_token", response, scope, grantType);
    }

    public async Task RefreshTokens()
    {
        using var _ = await _data!.CallAsync("refresh_tokens");
    }

    /// <summary>
    /// Updates the token. The result is the response data of a token request.
    /// </summary>
    /// <param name="accessToken"></param>
    /// <param name="refreshToken"></param>
    /// <param name="expireIn"></param>
    /// <param name="scopes"></param>
    /// <param name="type"></param>
    public void UpdateTokens(string accessToken, string refreshToken, int expireIn, string[] scopes, string type)
        => _data!.Invoke("update_tokens", accessToken, refreshToken, expireIn, scopes, type);

    public string GetTokenExpiration()
        => _data!.Invoke("get_token_expiration", static v => v.AsString());

    public bool TokenIsValid() => _data!.Invoke("is_token_valid", static v => v.AsBool());

    public bool TokenNeedsRefresh() => _data!.Invoke("token_needs_refresh", static v => v.AsBool());

    public async Task<string> GetAccessToken() => await _data!.InvokeAsync("get_access_token", static v => v.AsString());

    public async Task<bool> HasRefreshToken() => await _data!.InvokeAsync("has_refresh_token", static v => v.AsBool());

    public List<string> GetScopes() => _data!.Invoke("get_scopes", static v => v.AsStringArray()).ToList();

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
        token.Token = data.Get<OAuthToken>("token");
        token.ConnectSignals();

        return token;
    }

    public GodotObject ToGodotObject()
    {
        var token = InteropExtension.NewObject("res://addons/twitcher/lib/oOuch/oauth_token_handler.gd");
        token.SetObject("token", Token);
        
        return token;
    }
}