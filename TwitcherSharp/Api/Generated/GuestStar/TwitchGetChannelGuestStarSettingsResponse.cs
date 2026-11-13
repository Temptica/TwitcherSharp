using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchGetChannelGuestStarSettingsResponse : RefCounted, ITwitcherSharp<TwitchGetChannelGuestStarSettingsResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelGuestStarSettingsResponse object.
    /// </summary> 
    public static TwitchGetChannelGuestStarSettingsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetChannelGuestStarSettingsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_channel_guest_star_settings.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// A list that contains the channel's Guest Star settings. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public bool IsModeratorSendLiveEnabled { get; set; }
        public int SlotCount { get; set; }
        public bool IsBrowserSourceAudioEnabled { get; set; }
        public string GroupLayout { get; set; } = null!;
        public string? BrowserSourceToken { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                IsModeratorSendLiveEnabled = data.ReadAsBool("is_moderator_send_live_enabled"),
                SlotCount = data.ReadAsInt32("slot_count"),
                IsBrowserSourceAudioEnabled = data.ReadAsBool("is_browser_source_audio_enabled"),
                GroupLayout = data.ReadAsString("group_layout"),
                BrowserSourceToken = data.ReadAsString("browser_source_token"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_channel_guest_star_settings.gd", "ResponseData");
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

}
