using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Users;
 
/// <summary> 
/// All optional parameters for TwitchAPI.UpdateUser 
/// </summary>
public partial class UpdateUserOpt : Resource, ITwitcherSharp<UpdateUserOpt>
{
    private GodotObject _data;
	public string Description { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateUserOpt object.
    /// </summary> 
    public static UpdateUserOpt FromObject(GodotObject data)
    {
        return new UpdateUserOpt
        {

			Description = data.Get("description").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_user_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("description", Description);
		return request;
	}
}
