using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.UpdateGuestStarSlotSettings 
/// </summary>
public partial class TwitchUpdateGuestStarSlotSettingsOpt : Resource, ITwitcherSharp<TwitchUpdateGuestStarSlotSettingsOpt>
{
    private GodotObject _data;
	public bool IsAudioEnabled { get; set; }
	public bool IsVideoEnabled { get; set; }
	public bool IsLive { get; set; }
	public int Volume { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateGuestStarSlotSettingsOpt object.
    /// </summary> 
    public static TwitchUpdateGuestStarSlotSettingsOpt FromObject(GodotObject data)
    {
		return new TwitchUpdateGuestStarSlotSettingsOpt
		{
			IsAudioEnabled = data.Get("is_audio_enabled").AsBool(),
			IsVideoEnabled = data.Get("is_video_enabled").AsBool(),
			IsLive = data.Get("is_live").AsBool(),
			Volume = data.Get("volume").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_guest_star_slot_settings.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("is_audio_enabled", IsAudioEnabled);
		request.Set("is_video_enabled", IsVideoEnabled);
		request.Set("is_live", IsLive);
		request.Set("volume", Volume);
		return request;
	}
}
