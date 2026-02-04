using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// Information about the guest’s audio settings 
/// </summary>
public partial class TwitchAudioSettings : Resource, ITwitcherSharp<TwitchAudioSettings>
{
    private GodotObject _data;
	public bool IsHostEnabled { get; set; }
	public bool IsGuestEnabled { get; set; }
	public bool IsAvailable { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchAudioSettings object.
    /// </summary> 
    public static TwitchAudioSettings FromObject(GodotObject data)
    {
		return new TwitchAudioSettings
		{
			IsHostEnabled = data.Get("is_host_enabled").AsBool(),
			IsGuestEnabled = data.Get("is_guest_enabled").AsBool(),
			IsAvailable = data.Get("is_available").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_audio_settings.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("is_host_enabled", IsHostEnabled);
		request.Set("is_guest_enabled", IsGuestEnabled);
		request.Set("is_available", IsAvailable);
		return request;
	}
}
