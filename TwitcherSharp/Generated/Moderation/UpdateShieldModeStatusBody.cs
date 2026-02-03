using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateShieldModeStatusBody : Resource, ITwitcherSharp<UpdateShieldModeStatusBody>
{
    private GodotObject _data;
	public bool IsActive { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateShieldModeStatusBody object.
    /// </summary> 
    public static UpdateShieldModeStatusBody FromObject(GodotObject data)
    {
        return new UpdateShieldModeStatusBody
        {

			IsActive = data.Get("is_active").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_shield_mode_status_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("is_active", IsActive);
		return request;
	}
}
