using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Users;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetUserActiveExtensions 
/// </summary>
public partial class GetUserActiveExtensionsOpt : Resource, ITwitcherSharp<GetUserActiveExtensionsOpt>
{
    private GodotObject _data;
	public string UserId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetUserActiveExtensionsOpt object.
    /// </summary> 
    public static GetUserActiveExtensionsOpt FromObject(GodotObject data)
    {
        return new GetUserActiveExtensionsOpt
        {

			UserId = data.Get("user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_user_active_extensions_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		return request;
	}
}
