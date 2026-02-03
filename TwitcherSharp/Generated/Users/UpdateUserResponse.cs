using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Users;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateUserResponse : Resource, ITwitcherSharp<UpdateUserResponse>
{
    private GodotObject _data;
	public User[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateUserResponse object.
    /// </summary> 
    public static UpdateUserResponse FromObject(GodotObject data)
    {
        return new UpdateUserResponse
        {

			Data = data.Get("data").As<User[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_user_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
