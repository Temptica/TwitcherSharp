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
			_data?.Set("force_verify", value);
			field = value;
		}
	}
	
	public bool IsAuthenticated() => _data?.Get("is_authenticated").AsBool() ?? false;
	
	public async Task<bool> Authorize(bool force = false)
	{
		if (_data is null) return false;
		var result = await _data.CallAsync("authorize", force);
		return result.AsBool();
	}

	public void DoUnSetup() => _data?.Call("do_unsetup");
	
	public async Task RefreshToken()
	{
		if(_data is null) return;
		await _data.CallAsync("refresh_token");
	}

	public bool IsConfigured() => _data?.Call("is_configured").AsBool() ?? false;
	

	public static TwitchAuth? FromObject(GodotObject? data)
	{
		if (data == null) return null;
		var auth = new TwitchAuth();
		auth._data = data;
		auth.ForceVerify = data.Get("force_verify").AsBool();
		return auth;
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/auth/twitch_auth.gd");
		var token = script.New().AsGodotObject();
		token.Set("force_verify", ForceVerify);
		
		return token;
	}
}