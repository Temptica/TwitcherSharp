using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Auth;

public partial class TwitchAuth : RefCounted, ITwitcherSharp<TwitchAuth>
{
	private GodotObject? _data;

	public bool ForceVerify
	{
		get;
		set
		{
			_data?.SetValue("force_verify", value);
			field = value;
		}
	}
	
	public bool IsAuthenticated() => _data?.Read("is_authenticated", static v => v.AsBool()) ?? false;
	
	/// <summary>
	/// Logs in unless already logged in (or always with <paramref name="force"/>). twitcher awaits the login, so
	/// this must be awaited: blocking on it would wait on the main thread for frames that never come.
	/// </summary>
	public async Task<bool> Authorize(bool force = false)
	{
		if (_data is null) return false;
		using var result = await _data.CallAsync("authorize", force);
		return result.AsBool();
	}
	
	public void DoUnSetup() => _data?.Invoke("do_unsetup");
	
	public void RefreshToken() => _data?.Invoke("refresh_token");
	
	public bool IsConfigured() => _data?.Invoke("is_configured", static v => v.AsBool()) ?? false;
	

	public static TwitchAuth? FromObject(GodotObject? data)
	{
		if (data == null) return null;
		var auth = new TwitchAuth();
		auth._data = data;
		auth.ForceVerify = data.Read("force_verify", static v => v.AsBool());
		return auth;
	}

	public GodotObject ToGodotObject()
	{
		var token = InteropExtension.NewObject("res://addons/twitcher/auth/twitch_auth.gd");
		token.SetValue("force_verify", ForceVerify);
		
		return token;
	}
}