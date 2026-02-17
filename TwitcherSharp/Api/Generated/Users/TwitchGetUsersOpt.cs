using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Users;

/// <summary> 
/// All optional parameters for TwitchAPI.GetUsers 
/// </summary>
public partial class TwitchGetUsersOpt : Resource, ITwitcherSharp<TwitchGetUsersOpt>
{
    private GodotObject _data;
	public string[] Id { get; set; }
	public string[] Login { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUsersOpt object.
    /// </summary> 
    public static TwitchGetUsersOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchGetUsersOpt
		{
			Id = data.Get("id").AsStringArray(),
			Login = data.Get("login").AsStringArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_users.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		if(Id != null) request.Set("id", Id);
		if(Login != null) request.Set("login", Login);
		return request;
	}

}
