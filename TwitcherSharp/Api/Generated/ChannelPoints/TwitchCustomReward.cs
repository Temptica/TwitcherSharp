using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchCustomReward : RefCounted, ITwitcherSharp<TwitchCustomReward>
{
    private Variant _data;
    public string BroadcasterId { get; set; } = null!;
    public string BroadcasterLogin { get; set; } = null!;
    public string BroadcasterName { get; set; } = null!;
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Prompt { get; set; } = null!;
    public long Cost { get; set; }
    public TwitchImage Image { get => field ??= _data.Get<TwitchImage>("image")!; set; } = null!;
    public TwitchDefaultImage DefaultImage { get => field ??= _data.Get<TwitchDefaultImage>("default_image")!; set; } = null!;
    public string BackgroundColor { get; set; } = null!;
    public bool IsEnabled { get; set; }
    public bool IsUserInputRequired { get; set; }
    public TwitchMaxPerStreamSetting MaxPerStreamSetting { get => field ??= _data.Get<TwitchMaxPerStreamSetting>("max_per_stream_setting")!; set; } = null!;
    public TwitchMaxPerUserPerStreamSetting MaxPerUserPerStreamSetting { get => field ??= _data.Get<TwitchMaxPerUserPerStreamSetting>("max_per_user_per_stream_setting")!; set; } = null!;
    public TwitchGlobalCooldownSetting GlobalCooldownSetting { get => field ??= _data.Get<TwitchGlobalCooldownSetting>("global_cooldown_setting")!; set; } = null!;
    public bool IsPaused { get; set; }
    public bool IsInStock { get; set; }
    public bool ShouldRedemptionsSkipRequestQueue { get; set; }
    public int RedemptionsRedeemedCurrentStream { get; set; }
    public string CooldownExpiresAt { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchCustomReward object.
    /// </summary> 
    public static TwitchCustomReward? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCustomReward
        {
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            BroadcasterLogin = data.Read("broadcaster_login", static v => v.AsString()),
            BroadcasterName = data.Read("broadcaster_name", static v => v.AsString()),
            Id = data.Read("id", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            Prompt = data.Read("prompt", static v => v.AsString()),
            Cost = data.Read("cost", static v => v.AsInt64()),
            BackgroundColor = data.Read("background_color", static v => v.AsString()),
            IsEnabled = data.Read("is_enabled", static v => v.AsBool()),
            IsUserInputRequired = data.Read("is_user_input_required", static v => v.AsBool()),
            IsPaused = data.Read("is_paused", static v => v.AsBool()),
            IsInStock = data.Read("is_in_stock", static v => v.AsBool()),
            ShouldRedemptionsSkipRequestQueue = data.Read("should_redemptions_skip_request_queue", static v => v.AsBool()),
            RedemptionsRedeemedCurrentStream = data.Read("redemptions_redeemed_current_stream", static v => v.AsInt32()),
            CooldownExpiresAt = data.Read("cooldown_expires_at", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_custom_reward.gd");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
        if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
        if(Id != null) request.SetValue("id", Id);
        if(Title != null) request.SetValue("title", Title);
        if(Prompt != null) request.SetValue("prompt", Prompt);
        request.SetValue("cost", Cost);
        if(Image != null) request.SetObject("image", Image);
        if(DefaultImage != null) request.SetObject("default_image", DefaultImage);
        if(BackgroundColor != null) request.SetValue("background_color", BackgroundColor);
        request.SetValue("is_enabled", IsEnabled);
        request.SetValue("is_user_input_required", IsUserInputRequired);
        if(MaxPerStreamSetting != null) request.SetObject("max_per_stream_setting", MaxPerStreamSetting);
        if(MaxPerUserPerStreamSetting != null) request.SetObject("max_per_user_per_stream_setting", MaxPerUserPerStreamSetting);
        if(GlobalCooldownSetting != null) request.SetObject("global_cooldown_setting", GlobalCooldownSetting);
        request.SetValue("is_paused", IsPaused);
        request.SetValue("is_in_stock", IsInStock);
        request.SetValue("should_redemptions_skip_request_queue", ShouldRedemptionsSkipRequestQueue);
        request.SetValue("redemptions_redeemed_current_stream", RedemptionsRedeemedCurrentStream);
        if(CooldownExpiresAt != null) request.SetValue("cooldown_expires_at", CooldownExpiresAt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// A set of custom images for the reward. This field is **null** if the broadcaster didn’t upload images. 
    /// </summary>
    public partial class TwitchImage : RefCounted, ITwitcherSharp<TwitchImage>
    {
        private Variant _data;
        public string Url1x { get; set; } = null!;
        public string Url2x { get; set; } = null!;
        public string Url4x { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchImage object.
        /// </summary> 
        public static TwitchImage? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchImage
            {
                Url1x = data.Read("url_1x", static v => v.AsString()),
                Url2x = data.Read("url_2x", static v => v.AsString()),
                Url4x = data.Read("url_4x", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_custom_reward.gd", "TwitchImage");
            if(Url1x != null) request.SetValue("url_1x", Url1x);
            if(Url2x != null) request.SetValue("url_2x", Url2x);
            if(Url4x != null) request.SetValue("url_4x", Url4x);
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
    /// A set of default images for the reward. 
    /// </summary>
    public partial class TwitchDefaultImage : RefCounted, ITwitcherSharp<TwitchDefaultImage>
    {
        private Variant _data;
        public string Url1x { get; set; } = null!;
        public string Url2x { get; set; } = null!;
        public string Url4x { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchDefaultImage object.
        /// </summary> 
        public static TwitchDefaultImage? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchDefaultImage
            {
                Url1x = data.Read("url_1x", static v => v.AsString()),
                Url2x = data.Read("url_2x", static v => v.AsString()),
                Url4x = data.Read("url_4x", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_custom_reward.gd", "DefaultImage");
            if(Url1x != null) request.SetValue("url_1x", Url1x);
            if(Url2x != null) request.SetValue("url_2x", Url2x);
            if(Url4x != null) request.SetValue("url_4x", Url4x);
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
    /// The settings used to determine whether to apply a maximum to the number of redemptions allowed per live stream. 
    /// </summary>
    public partial class TwitchMaxPerStreamSetting : RefCounted, ITwitcherSharp<TwitchMaxPerStreamSetting>
    {
        private Variant _data;
        public bool IsEnabled { get; set; }
        public long MaxPerStream { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMaxPerStreamSetting object.
        /// </summary> 
        public static TwitchMaxPerStreamSetting? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchMaxPerStreamSetting
            {
                IsEnabled = data.Read("is_enabled", static v => v.AsBool()),
                MaxPerStream = data.Read("max_per_stream", static v => v.AsInt64()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_custom_reward.gd", "MaxPerStreamSetting");
            request.SetValue("is_enabled", IsEnabled);
            request.SetValue("max_per_stream", MaxPerStream);
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
    /// The settings used to determine whether to apply a maximum to the number of redemptions allowed per user per live stream. 
    /// </summary>
    public partial class TwitchMaxPerUserPerStreamSetting : RefCounted, ITwitcherSharp<TwitchMaxPerUserPerStreamSetting>
    {
        private Variant _data;
        public bool IsEnabled { get; set; }
        public long MaxPerUserPerStream { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMaxPerUserPerStreamSetting object.
        /// </summary> 
        public static TwitchMaxPerUserPerStreamSetting? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchMaxPerUserPerStreamSetting
            {
                IsEnabled = data.Read("is_enabled", static v => v.AsBool()),
                MaxPerUserPerStream = data.Read("max_per_user_per_stream", static v => v.AsInt64()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_custom_reward.gd", "MaxPerUserPerStreamSetting");
            request.SetValue("is_enabled", IsEnabled);
            request.SetValue("max_per_user_per_stream", MaxPerUserPerStream);
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
    /// The settings used to determine whether to apply a cooldown period between redemptions and the length of the cooldown. 
    /// </summary>
    public partial class TwitchGlobalCooldownSetting : RefCounted, ITwitcherSharp<TwitchGlobalCooldownSetting>
    {
        private Variant _data;
        public bool IsEnabled { get; set; }
        public long GlobalCooldownSeconds { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchGlobalCooldownSetting object.
        /// </summary> 
        public static TwitchGlobalCooldownSetting? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchGlobalCooldownSetting
            {
                IsEnabled = data.Read("is_enabled", static v => v.AsBool()),
                GlobalCooldownSeconds = data.Read("global_cooldown_seconds", static v => v.AsInt64()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_custom_reward.gd", "GlobalCooldownSetting");
            request.SetValue("is_enabled", IsEnabled);
            request.SetValue("global_cooldown_seconds", GlobalCooldownSeconds);
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
