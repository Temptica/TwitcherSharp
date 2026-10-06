using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchGetChannelGuestStarSettingsResponse : RefCounted, ITwitcherSharp<TwitchGetChannelGuestStarSettingsResponse>
{
    private Variant _data;
    public bool IsModeratorSendLiveEnabled { get; set; }
    public int SlotCount { get; set; }
    public bool IsBrowserSourceAudioEnabled { get; set; }
    public string GroupLayout { get; set; } = null!;
    public string BrowserSourceToken { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelGuestStarSettingsResponse object.
    /// </summary> 
    public static TwitchGetChannelGuestStarSettingsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetChannelGuestStarSettingsResponse
        {
            IsModeratorSendLiveEnabled = data.Read("is_moderator_send_live_enabled", static v => v.AsBool()),
            SlotCount = data.Read("slot_count", static v => v.AsInt32()),
            IsBrowserSourceAudioEnabled = data.Read("is_browser_source_audio_enabled", static v => v.AsBool()),
            GroupLayout = data.Read("group_layout", static v => v.AsString()),
            BrowserSourceToken = data.Read("browser_source_token", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_channel_guest_star_settings.gd", "Response");
        request.SetValue("is_moderator_send_live_enabled", IsModeratorSendLiveEnabled);
        request.SetValue("slot_count", SlotCount);
        request.SetValue("is_browser_source_audio_enabled", IsBrowserSourceAudioEnabled);
        if(GroupLayout != null) request.SetValue("group_layout", GroupLayout);
        if(BrowserSourceToken != null) request.SetValue("browser_source_token", BrowserSourceToken);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
