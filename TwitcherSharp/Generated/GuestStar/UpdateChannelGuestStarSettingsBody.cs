using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.GuestStar;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateChannelGuestStarSettingsBody : Resource, ITwitcherSharp<UpdateChannelGuestStarSettingsBody>
{
    private GodotObject _data;
	public bool IsModeratorSendLiveEnabled { get; set; }
	public int SlotCount { get; set; }
	public bool IsBrowserSourceAudioEnabled { get; set; }
	public string GroupLayout { get; set; }
	public bool RegenerateBrowserSources { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateChannelGuestStarSettingsBody object.
    /// </summary> 
    public static UpdateChannelGuestStarSettingsBody FromObject(GodotObject data)
    {
        return new UpdateChannelGuestStarSettingsBody
        {

			IsModeratorSendLiveEnabled = data.Get("is_moderator_send_live_enabled").AsBool(),
			SlotCount = data.Get("slot_count").AsInt32(),
			IsBrowserSourceAudioEnabled = data.Get("is_browser_source_audio_enabled").AsBool(),
			GroupLayout = data.Get("group_layout").AsString(),
			RegenerateBrowserSources = data.Get("regenerate_browser_sources").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_channel_guest_star_settings_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("is_moderator_send_live_enabled", IsModeratorSendLiveEnabled);
		request.Set("slot_count", SlotCount);
		request.Set("is_browser_source_audio_enabled", IsBrowserSourceAudioEnabled);
		request.Set("group_layout", GroupLayout);
		request.Set("regenerate_browser_sources", RegenerateBrowserSources);
		return request;
	}
}
