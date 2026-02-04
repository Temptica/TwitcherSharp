using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// Information about the guest’s video settings 
/// </summary>
public partial class TwitchVideoSettings : Resource, ITwitcherSharp<TwitchVideoSettings>
{
    private GodotObject _data;
	public bool IsHostEnabled { get; set; }
	public bool IsGuestEnabled { get; set; }
	public bool IsAvailable { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchVideoSettings object.
    /// </summary> 
    public static TwitchVideoSettings FromObject(GodotObject data)
    {
		return new TwitchVideoSettings
		{
			IsHostEnabled = data.Get("is_host_enabled").AsBool(),
			IsGuestEnabled = data.Get("is_guest_enabled").AsBool(),
			IsAvailable = data.Get("is_available").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_video_settings.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("is_host_enabled", IsHostEnabled);
		request.Set("is_guest_enabled", IsGuestEnabled);
		request.Set("is_available", IsAvailable);
		return request;
	}
}
