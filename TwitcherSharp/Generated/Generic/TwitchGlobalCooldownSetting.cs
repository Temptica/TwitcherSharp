using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// The settings used to determine whether to apply a cooldown period between redemptions and the length of the cooldown. 
/// </summary>
public partial class TwitchGlobalCooldownSetting : Resource, ITwitcherSharp<TwitchGlobalCooldownSetting>
{
    private GodotObject _data;
	public bool IsEnabled { get; set; }
	public int GlobalCooldownSeconds { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGlobalCooldownSetting object.
    /// </summary> 
    public static TwitchGlobalCooldownSetting FromObject(GodotObject data)
    {
		return new TwitchGlobalCooldownSetting
		{
			IsEnabled = data.Get("is_enabled").AsBool(),
			GlobalCooldownSeconds = data.Get("global_cooldown_seconds").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_global_cooldown_setting.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("is_enabled", IsEnabled);
		request.Set("global_cooldown_seconds", GlobalCooldownSeconds);
		return request;
	}
}
