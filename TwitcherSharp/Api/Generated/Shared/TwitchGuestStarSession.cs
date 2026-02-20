using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;

public partial class TwitchGuestStarSession : Resource, ITwitcherSharp<TwitchGuestStarSession>
{
    private GodotObject _data;
    public string Id { get; set; }
    public TwitchGuest[] Guests { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGuestStarSession object.
    /// </summary> 
    public static TwitchGuestStarSession FromObject(GodotObject data)
    {
        if(data == null) return null;
        var guestsArray = data.Get("guests").AsGodotArray<GodotObject>();
        return new TwitchGuestStarSession
        {
            Id = data.Get("id").AsString(),
            Guests = guestsArray.Select(TwitchGuest.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_guest_star_session.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("id", Id);
        request.Set("guests", Guests);
        return request;
    }
    public partial class TwitchGuest : Resource, ITwitcherSharp<TwitchGuest>
    {
        private GodotObject _data;
        public string SlotId { get; set; }
        public bool IsLive { get; set; }
        public string UserId { get; set; }
        public string UserDisplayName { get; set; }
        public string UserLogin { get; set; }
        public int Volume { get; set; }
        public string AssignedAt { get; set; }
        public TwitchAudioSettings AudioSettings { get; set; }
        public TwitchVideoSettings VideoSettings { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchGuest object.
        /// </summary> 
        public static TwitchGuest FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchGuest
            {
                SlotId = data.Get("slot_id").AsString(),
                IsLive = data.Get("is_live").AsBool(),
                UserId = data.Get("user_id").AsString(),
                UserDisplayName = data.Get("user_display_name").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                Volume = data.Get("volume").AsInt32(),
                AssignedAt = data.Get("assigned_at").AsString(),
                AudioSettings = data.Get("audio_settings").As<TwitchAudioSettings>(),
                VideoSettings = data.Get("video_settings").As<TwitchVideoSettings>(),
            };
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
            request.Set("audio_settings", AudioSettings);
            request.Set("video_settings", VideoSettings);
            return request;
        }
        
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
                if(data == null) return null;
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
        
        /// <summary> 
        /// Information about the guest’s video settings 
        /// </summary>
        public partial class TwitchVideoSettings : Resource, ITwitcherSharp<TwitchVideoSettings>
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
                return new TwitchVideoSettings
                {
                    IsHostEnabled = data.Get("is_host_enabled").AsBool(),
                    IsGuestEnabled = data.Get("is_guest_enabled").AsBool(),
                    IsAvailable = data.Get("is_available").AsBool(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_video_settings.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("is_host_enabled", IsHostEnabled);
                request.Set("is_guest_enabled", IsGuestEnabled);
                request.Set("is_available", IsAvailable);
                return request;
            }
        
        }
    
    }

}
