using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUpdateShieldModeStatusBody : Resource, ITwitcherSharp<TwitchUpdateShieldModeStatusBody>
{
    private GodotObject _data;
	public bool IsActive { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateShieldModeStatusBody object.
    /// </summary> 
    public static TwitchUpdateShieldModeStatusBody FromObject(GodotObject data)
    {
		return new TwitchUpdateShieldModeStatusBody
		{
			IsActive = data.Get("is_active").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_shield_mode_status.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("is_active", IsActive);
		return request;
	}
}
