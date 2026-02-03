using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Users;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetUsers 
/// </summary>
public partial class GetUsersOpt : Resource, ITwitcherSharp<GetUsersOpt>
{
    private GodotObject _data;
	public string[] Id { get; set; }
	public string[] Login { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetUsersOpt object.
    /// </summary> 
    public static GetUsersOpt FromObject(GodotObject data)
    {
        return new GetUsersOpt
        {

			Id = data.Get("id").AsStringArray(),
			Login = data.Get("login").AsStringArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_users_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("login", Login);
		return request;
	}
}
