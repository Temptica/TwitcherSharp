using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
/// The list of team members. 
/// </summary>
public partial class TwitchUsers : Resource, ITwitcherSharp<TwitchUsers>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string UserLogin { get; set; }
	public string UserName { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUsers object.
    /// </summary> 
    public static TwitchUsers FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchUsers
		{
			UserId = data.Get("user_id").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			UserName = data.Get("user_name").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_users.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("user_login", UserLogin);
		request.Set("user_name", UserName);
		return request;
	}
}
