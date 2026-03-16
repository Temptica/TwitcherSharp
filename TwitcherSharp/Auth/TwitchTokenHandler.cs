using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Lib.Http;

namespace TwitcherSharp.Auth;

public partial class TwitchTokenHandler : RefCounted, ITwitcherSharp<TwitchTokenHandler>
{
    private GodotObject _data;

    /// <summary>
    /// Validates a token.
    /// Note: It might be easier to get the GodotObject and call <code>await godotObject.CallAsync<ResponseData>(TwitchTokenHandler.Methods.ValidateToken, token);</code>
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<ResponseData> ValidateToken(string token) => await _data.CallAsync<ResponseData>(Methods.ValidateToken, token);

    /*func validate_token(token: String) -> BufferedHTTPClient.ResponseData:*/
    /*revoke_token() -> void:*/
    public static TwitchTokenHandler FromObject(GodotObject data)
    {
        return new TwitchTokenHandler { _data = data };
    }

    public GodotObject ToGodotObject()
    {
        return _data;
    }

    public static class Methods
    {
        public static string ValidateToken = "validate_token";
        public static string RevokeToken = "revoke_token";
    }
}