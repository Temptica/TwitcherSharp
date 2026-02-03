using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Users;
 
/// <summary> 
///  
/// </summary>
public partial class GetUsersResponse : Resource, ITwitcherSharp<GetUsersResponse>
{
    private GodotObject _data;
	public User[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetUsersResponse object.
    /// </summary> 
    public static GetUsersResponse FromObject(GodotObject data)
    {
        return new GetUsersResponse
        {

			Data = data.Get("data").As<User[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_users_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
