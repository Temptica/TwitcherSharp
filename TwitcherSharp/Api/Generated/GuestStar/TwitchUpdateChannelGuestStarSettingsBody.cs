using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchUpdateChannelGuestStarSettingsBody : RefCounted, ITwitcherSharp<TwitchUpdateChannelGuestStarSettingsBody>
{
    private Variant _data;
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
            IsModeratorSendLiveEnabled = data.Read("is_moderator_send_live_enabled", static v => v.AsBool()),
            SlotCount = data.Read("slot_count", static v => v.AsInt32()),
            IsBrowserSourceAudioEnabled = data.Read("is_browser_source_audio_enabled", static v => v.AsBool()),
            GroupLayout = data.Read("group_layout", static v => v.AsString()),
            RegenerateBrowserSources = data.Read("regenerate_browser_sources", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_channel_guest_star_settings.gd", "Body");
        if(IsModeratorSendLiveEnabled.HasValue) request.SetValue("is_moderator_send_live_enabled", IsModeratorSendLiveEnabled.Value);
        if(SlotCount.HasValue) request.SetValue("slot_count", SlotCount.Value);
        if(IsBrowserSourceAudioEnabled.HasValue) request.SetValue("is_browser_source_audio_enabled", IsBrowserSourceAudioEnabled.Value);
        if(GroupLayout != null) request.SetValue("group_layout", GroupLayout);
        if(RegenerateBrowserSources.HasValue) request.SetValue("regenerate_browser_sources", RegenerateBrowserSources.Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
