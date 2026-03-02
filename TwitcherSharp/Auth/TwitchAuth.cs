using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Auth;

public partial class TwitchAuth : Resource, ITwitcherSharp<TwitchAuth>
{
	private GodotObject _data;

	public bool ForceVerify
	{
		get;
		set
		{
			_data?.Set("force_verify", value);
			field = value;
		}
	}
	
	public bool IsAuthenticated() => _data.Get("is_authenticated").AsBool();
	
	public bool Authorize() => _data.CallAsync("authorize").Result.AsBool();
	
	public void DoUnSetup() => _data.Call("do_unsetup");
	
	public void RefreshToken() => _data.Call("refresh_token");
	
	public bool IsConfigured() => _data.Call("is_configured").AsBool();
	
	

	public static TwitchAuth FromObject(GodotObject data)
	{
		throw new NotImplementedException();
	}

	public GodotObject ToGodotObject()
	{
		throw new NotImplementedException();
	}
}