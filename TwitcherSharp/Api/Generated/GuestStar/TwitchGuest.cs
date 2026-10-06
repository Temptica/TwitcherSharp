using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchGuest : RefCounted, ITwitcherSharp<TwitchGuest>
{
    private Variant _data;
    public string SlotId { get; set; } = null!;
    public bool IsLive { get; set; }
    public string UserId { get; set; } = null!;
    public string UserDisplayName { get; set; } = null!;
    public string UserLogin { get; set; } = null!;
    public int Volume { get; set; }
    public string AssignedAt { get; set; } = null!;
    public TwitchAudioSettings AudioSettings { get => field ??= _data.Get<TwitchAudioSettings>("audio_settings")!; set; } = null!;
    public TwitchVideoSettings VideoSettings { get => field ??= _data.Get<TwitchVideoSettings>("video_settings")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGuest object.
    /// </summary> 
    public static TwitchGuest? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGuest
        {
            SlotId = data.Read("slot_id", static v => v.AsString()),
            IsLive = data.Read("is_live", static v => v.AsBool()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserDisplayName = data.Read("user_display_name", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            Volume = data.Read("volume", static v => v.AsInt32()),
            AssignedAt = data.Read("assigned_at", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_guest.gd");
        if(SlotId != null) request.SetValue("slot_id", SlotId);
        request.SetValue("is_live", IsLive);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserDisplayName != null) request.SetValue("user_display_name", UserDisplayName);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        request.SetValue("volume", Volume);
        if(AssignedAt != null) request.SetValue("assigned_at", AssignedAt);
        if(AudioSettings != null) request.SetObject("audio_settings", AudioSettings);
        if(VideoSettings != null) request.SetObject("video_settings", VideoSettings);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// Information about the guest’s audio settings 
    /// </summary>
    public partial class TwitchAudioSettings : RefCounted, ITwitcherSharp<TwitchAudioSettings>
    {
        private Variant _data;
        public bool IsHostEnabled { get; set; }
        public bool IsGuestEnabled { get; set; }
        public bool IsAvailable { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchAudioSettings object.
        /// </summary> 
        public static TwitchAudioSettings? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchAudioSettings
            {
                IsHostEnabled = data.Read("is_host_enabled", static v => v.AsBool()),
                IsGuestEnabled = data.Read("is_guest_enabled", static v => v.AsBool()),
                IsAvailable = data.Read("is_available", static v => v.AsBool()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_guest.gd", "AudioSettings");
            request.SetValue("is_host_enabled", IsHostEnabled);
            request.SetValue("is_guest_enabled", IsGuestEnabled);
            request.SetValue("is_available", IsAvailable);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    }
    
    /// <summary> 
    /// Information about the guest’s video settings 
    /// </summary>
    public partial class TwitchVideoSettings : RefCounted, ITwitcherSharp<TwitchVideoSettings>
    {
        private Variant _data;
        public bool IsHostEnabled { get; set; }
        public bool IsGuestEnabled { get; set; }
        public bool IsAvailable { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchVideoSettings object.
        /// </summary> 
        public static TwitchVideoSettings? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchVideoSettings
            {
                IsHostEnabled = data.Read("is_host_enabled", static v => v.AsBool()),
                IsGuestEnabled = data.Read("is_guest_enabled", static v => v.AsBool()),
                IsAvailable = data.Read("is_available", static v => v.AsBool()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_guest.gd", "VideoSettings");
            request.SetValue("is_host_enabled", IsHostEnabled);
            request.SetValue("is_guest_enabled", IsGuestEnabled);
            request.SetValue("is_available", IsAvailable);
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
