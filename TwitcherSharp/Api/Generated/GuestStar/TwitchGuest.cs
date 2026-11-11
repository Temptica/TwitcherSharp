using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.GuestStar;

public partial class TwitchGuest : RefCounted, ITwitcherSharp<TwitchGuest>
{
    private GodotObject? _data;
    public string SlotId { get; set; } = null!;
    public bool IsLive { get; set; }
    public string UserId { get; set; } = null!;
    public int Volume { get; set; }
    public string AssignedAt { get; set; } = null!;
    public TwitchAudio Audio { get => field ??= _data?.Get<TwitchAudio>("audio")!; set; } = null!;
    public TwitchVideo Video { get => field ??= _data?.Get<TwitchVideo>("video")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGuest object.
    /// </summary> 
    public static TwitchGuest? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGuest
        {
            SlotId = data.Get("slot_id").AsString(),
            IsLive = data.Get("is_live").AsBool(),
            UserId = data.Get("user_id").AsString(),
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
        if(SlotId != null) request.Set("slot_id", SlotId);
        request.Set("is_live", IsLive);
        if(UserId != null) request.Set("user_id", UserId);
        request.Set("volume", Volume);
        if(AssignedAt != null) request.Set("assigned_at", AssignedAt);
        if(Audio != null) request.Set("audio", Audio.ToGodotObject());
        if(Video != null) request.Set("video", Video.ToGodotObject());
        return request;
    }
    
    /// <summary> 
    /// Information about the guest's audio settings 
    /// </summary>
    public partial class TwitchAudio : RefCounted, ITwitcherSharp<TwitchAudio>
    {
        private GodotObject? _data;
        public bool IsHostEnabled { get; set; }
        public bool IsGuestEnabled { get; set; }
        public bool IsAvailable { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchAudio object.
        /// </summary> 
        public static TwitchAudio? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchAudio
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
            var twitchAudioClass = script.Get("Audio").AsGodotObject();
            var request = twitchAudioClass.Call("new").AsGodotObject();
            request.Set("is_host_enabled", IsHostEnabled);
            request.Set("is_guest_enabled", IsGuestEnabled);
            request.Set("is_available", IsAvailable);
            return request;
        }
    
    }
    
    /// <summary> 
    /// Information about the guest's video settings 
    /// </summary>
    public partial class TwitchVideo : RefCounted, ITwitcherSharp<TwitchVideo>
    {
        private GodotObject? _data;
        public bool IsHostEnabled { get; set; }
        public bool IsGuestEnabled { get; set; }
        public bool IsAvailable { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchVideo object.
        /// </summary> 
        public static TwitchVideo? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchVideo
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
            var twitchVideoClass = script.Get("Video").AsGodotObject();
            var request = twitchVideoClass.Call("new").AsGodotObject();
            request.Set("is_host_enabled", IsHostEnabled);
            request.Set("is_guest_enabled", IsGuestEnabled);
            request.Set("is_available", IsAvailable);
            return request;
        }
    
    }

}
