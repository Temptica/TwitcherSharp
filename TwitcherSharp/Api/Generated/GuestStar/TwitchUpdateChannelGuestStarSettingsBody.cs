using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchUpdateChannelGuestStarSettingsBody : RefCounted, ITwitcherSharp<TwitchUpdateChannelGuestStarSettingsBody>
{
    private GodotObject? _data;
    public bool? IsModeratorSendLiveEnabled { get; set; }
    public int? SlotCount { get; set; }
    public bool? IsBrowserSourceAudioEnabled { get; set; }
    public string? GroupLayout { get; set; }
    public bool? RegenerateBrowserSources { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateChannelGuestStarSettingsBody object.
    /// </summary> 
    public static TwitchUpdateChannelGuestStarSettingsBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateChannelGuestStarSettingsBody
        {
            IsModeratorSendLiveEnabled = data.Get("is_moderator_send_live_enabled").AsBool(),
            SlotCount = data.Get("slot_count").AsInt32(),
            IsBrowserSourceAudioEnabled = data.Get("is_browser_source_audio_enabled").AsBool(),
            GroupLayout = data.Get("group_layout").AsString(),
            RegenerateBrowserSources = data.Get("regenerate_browser_sources").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_channel_guest_star_settings.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        if(IsModeratorSendLiveEnabled.HasValue) request.Set("is_moderator_send_live_enabled", IsModeratorSendLiveEnabled.Value);
        if(SlotCount.HasValue) request.Set("slot_count", SlotCount.Value);
        if(IsBrowserSourceAudioEnabled.HasValue) request.Set("is_browser_source_audio_enabled", IsBrowserSourceAudioEnabled.Value);
        if(GroupLayout != null) request.Set("group_layout", GroupLayout);
        if(RegenerateBrowserSources.HasValue) request.Set("regenerate_browser_sources", RegenerateBrowserSources.Value);
        return request;
    }

}
