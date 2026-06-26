using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchGuest : RefCounted, ITwitcherSharp<TwitchGuest>
{
    private GodotObject _data;
    public string SlotId { get; set; }
    public bool IsLive { get; set; }
    public string UserId { get; set; }
    public string UserDisplayName { get; set; }
    public string UserLogin { get; set; }
    public int Volume { get; set; }
    public string AssignedAt { get; set; }
    public TwitchAudioSettings AudioSettings { get => field ??= _data?.Get<TwitchAudioSettings>("audio_settings"); set; }
    public TwitchVideoSettings VideoSettings { get => field ??= _data?.Get<TwitchVideoSettings>("video_settings"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGuest object.
    /// </summary> 
    public static TwitchGuest FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGuest
        {
            SlotId = data.Get("slot_id").AsString(),
            IsLive = data.Get("is_live").AsBool(),
            UserId = data.Get("user_id").AsString(),
            UserDisplayName = data.Get("user_display_name").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            Volume = data.Get("volume").AsInt32(),
            AssignedAt = data.Get("assigned_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_guest.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("slot_id", SlotId);
        request.Set("is_live", IsLive);
        request.Set("user_id", UserId);
        request.Set("user_display_name", UserDisplayName);
        request.Set("user_login", UserLogin);
        request.Set("volume", Volume);
        request.Set("assigned_at", AssignedAt);
        request.Set("audio_settings", AudioSettings?.ToGodotObject());
        request.Set("video_settings", VideoSettings?.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// Information about the guest’s audio settings 
    /// </summary>
    public partial class TwitchAudioSettings : RefCounted, ITwitcherSharp<TwitchAudioSettings>
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
            if(data == null) return null;
            var instance = new TwitchAudioSettings
            {
                IsHostEnabled = data.Get("is_host_enabled").AsBool(),
                IsGuestEnabled = data.Get("is_guest_enabled").AsBool(),
                IsAvailable = data.Get("is_available").AsBool(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_guest.gd");
            var twitchAudioSettingsClass = script.Get("AudioSettings").AsGodotObject();
            var request = twitchAudioSettingsClass.Call("new").AsGodotObject();
            request.Set("is_host_enabled", IsHostEnabled);
            request.Set("is_guest_enabled", IsGuestEnabled);
            request.Set("is_available", IsAvailable);
            return request;
        }
    
    }
    
    /// <summary> 
    /// Information about the guest’s video settings 
    /// </summary>
    public partial class TwitchVideoSettings : RefCounted, ITwitcherSharp<TwitchVideoSettings>
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
            if(data == null) return null;
            var instance = new TwitchVideoSettings
            {
                IsHostEnabled = data.Get("is_host_enabled").AsBool(),
                IsGuestEnabled = data.Get("is_guest_enabled").AsBool(),
                IsAvailable = data.Get("is_available").AsBool(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_guest.gd");
            var twitchVideoSettingsClass = script.Get("VideoSettings").AsGodotObject();
            var request = twitchVideoSettingsClass.Call("new").AsGodotObject();
            request.Set("is_host_enabled", IsHostEnabled);
            request.Set("is_guest_enabled", IsGuestEnabled);
            request.Set("is_available", IsAvailable);
            return request;
        }
    
    }

}
