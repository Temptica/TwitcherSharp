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
    public int Volume { get; set; }
    public string AssignedAt { get; set; } = null!;
    public TwitchAudio Audio { get => field ??= _data.Get<TwitchAudio>("audio")!; set; } = null!;
    public TwitchVideo Video { get => field ??= _data.Get<TwitchVideo>("video")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGuest object.
    /// </summary> 
    public static TwitchGuest? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGuest
        {
            SlotId = data.ReadAsString("slot_id"),
            IsLive = data.ReadAsBool("is_live"),
            UserId = data.ReadAsString("user_id"),
            Volume = data.ReadAsInt32("volume"),
            AssignedAt = data.ReadAsString("assigned_at"),
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
        request.SetValue("volume", Volume);
        if(AssignedAt != null) request.SetValue("assigned_at", AssignedAt);
        if(Audio != null) request.SetObject("audio", Audio);
        if(Video != null) request.SetObject("video", Video);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// Information about the guest's audio settings 
    /// </summary>
    public partial class TwitchAudio : RefCounted, ITwitcherSharp<TwitchAudio>
    {
        private Variant _data;
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
                IsHostEnabled = data.ReadAsBool("is_host_enabled"),
                IsGuestEnabled = data.ReadAsBool("is_guest_enabled"),
                IsAvailable = data.ReadAsBool("is_available"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_guest.gd", "Audio");
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
    /// Information about the guest's video settings 
    /// </summary>
    public partial class TwitchVideo : RefCounted, ITwitcherSharp<TwitchVideo>
    {
        private Variant _data;
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
                IsHostEnabled = data.ReadAsBool("is_host_enabled"),
                IsGuestEnabled = data.ReadAsBool("is_guest_enabled"),
                IsAvailable = data.ReadAsBool("is_available"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_guest.gd", "Video");
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
