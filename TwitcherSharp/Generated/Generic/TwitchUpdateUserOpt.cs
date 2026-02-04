using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.UpdateUser 
/// </summary>
public partial class TwitchUpdateUserOpt : Resource, ITwitcherSharp<TwitchUpdateUserOpt>
{
    private GodotObject _data;
	public string Description { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateUserOpt object.
    /// </summary> 
    public static TwitchUpdateUserOpt FromObject(GodotObject data)
    {
		return new TwitchUpdateUserOpt
		{
			Description = data.Get("description").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_user.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("description", Description);
		return request;
	}
}
