using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Lib.Http;
using TwitcherSharp.Lib.OOuch;

namespace TwitcherSharp.Auth;

public partial class TwitchTokenHandler : RefCounted, ITwitcherSharp<TwitchTokenHandler>
{
    private GodotObject _data = null!;

    /// <summary>
    /// Validates a token.
    /// </summary>
    /// <returns></returns>
    public async Task<ResponseData?> ValidateToken() => await _data.CallAsync<ResponseData>(Methods.ValidateToken) ;
    
    /// <summary>
    /// Revokes a token.
    /// </summary>
    public async Task RevokeToken() => await _data.CallAsync(Methods.RevokeToken);

    /// <summary>
    /// The current access token. twitcher refreshes it first when it expired, or waits for a running request.
    /// </summary>
    public async Task<string> GetAccessToken() =>
        await _data.InvokeAsync(Methods.GetAccessToken, static v => v.AsString());

    /// <summary>
    /// Exchanges the refresh token for a new access token.
    /// </summary>
    public async Task RefreshTokens() => await _data.InvokeAsync(Methods.RefreshTokens);

    /// <summary>
    /// The client id of the OAuth setting the handler authorizes with (the setting its owner, such as TwitchAuth,
    /// gives it), or an empty string when it has none.
    /// </summary>
    public string ClientId => OAuthTokenHandler.ClientIdOf(_data);

    /*func validate_token(token: String) -> BufferedHTTPClient.ResponseData:*/
    /*revoke_token() -> void:*/
    public static TwitchTokenHandler? FromObject(GodotObject? data)
    {
        return data == null ? null : new TwitchTokenHandler { _data = data };
    }

    public GodotObject ToGodotObject()
    {
        return _data;
    }

    public static class Methods
    {
        public const string ValidateToken = "validate_token";
        public const string RevokeToken = "revoke_token";
        public const string GetAccessToken = "get_access_token";
        public const string RefreshTokens = "refresh_tokens";
    }
}