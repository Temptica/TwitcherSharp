using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchGetChannelGuestStarSettingsResponse : RefCounted, ITwitcherSharp<TwitchGetChannelGuestStarSettingsResponse>
{
    private GodotObject _data;
    public bool IsModeratorSendLiveEnabled { get; set; }
    public int SlotCount { get; set; }
    public bool IsBrowserSourceAudioEnabled { get; set; }
    public string GroupLayout { get; set; }
    public string BrowserSourceToken { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelGuestStarSettingsResponse object.
    /// </summary> 
    public static TwitchGetChannelGuestStarSettingsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetChannelGuestStarSettingsResponse
        {
            IsModeratorSendLiveEnabled = data.Get("is_moderator_send_live_enabled").AsBool(),
            SlotCount = data.Get("slot_count").AsInt32(),
            IsBrowserSourceAudioEnabled = data.Get("is_browser_source_audio_enabled").AsBool(),
            GroupLayout = data.Get("group_layout").AsString(),
            BrowserSourceToken = data.Get("browser_source_token").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_guest_star_settings.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("is_moderator_send_live_enabled", IsModeratorSendLiveEnabled);
        request.Set("slot_count", SlotCount);
        request.Set("is_browser_source_audio_enabled", IsBrowserSourceAudioEnabled);
        request.Set("group_layout", GroupLayout);
        request.Set("browser_source_token", BrowserSourceToken);
        return request;
    }

}
