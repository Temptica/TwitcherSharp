using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Lib.Http;

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
    }
}