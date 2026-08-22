using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchCustomReward : RefCounted, ITwitcherSharp<TwitchCustomReward>
{
    private GodotObject? _data;
    public string BroadcasterId { get; set; } = null!;
    public string BroadcasterLogin { get; set; } = null!;
    public string BroadcasterName { get; set; } = null!;
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Prompt { get; set; } = null!;
    public int Cost { get; set; }
    public TwitchImage Image { get => field ??= _data?.Get<TwitchImage>("image")!; set; } = null!;
    public TwitchDefaultImage DefaultImage { get => field ??= _data?.Get<TwitchDefaultImage>("default_image")!; set; } = null!;
    public string BackgroundColor { get; set; } = null!;
    public bool IsEnabled { get; set; }
    public bool IsUserInputRequired { get; set; }
    public TwitchMaxPerStreamSetting MaxPerStreamSetting { get => field ??= _data?.Get<TwitchMaxPerStreamSetting>("max_per_stream_setting")!; set; } = null!;
    public TwitchMaxPerUserPerStreamSetting MaxPerUserPerStreamSetting { get => field ??= _data?.Get<TwitchMaxPerUserPerStreamSetting>("max_per_user_per_stream_setting")!; set; } = null!;
    public TwitchGlobalCooldownSetting GlobalCooldownSetting { get => field ??= _data?.Get<TwitchGlobalCooldownSetting>("global_cooldown_setting")!; set; } = null!;
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
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            BroadcasterLogin = data.Get("broadcaster_login").AsString(),
            BroadcasterName = data.Get("broadcaster_name").AsString(),
            Id = data.Get("id").AsString(),
            Title = data.Get("title").AsString(),
            Prompt = data.Get("prompt").AsString(),
            Cost = data.Get("cost").AsInt32(),
            BackgroundColor = data.Get("background_color").AsString(),
            IsEnabled = data.Get("is_enabled").AsBool(),
            IsUserInputRequired = data.Get("is_user_input_required").AsBool(),
            IsPaused = data.Get("is_paused").AsBool(),
            IsInStock = data.Get("is_in_stock").AsBool(),
            ShouldRedemptionsSkipRequestQueue = data.Get("should_redemptions_skip_request_queue").AsBool(),
            RedemptionsRedeemedCurrentStream = data.Get("redemptions_redeemed_current_stream").AsInt32(),
            CooldownExpiresAt = data.Get("cooldown_expires_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_custom_reward.gd");
        var request = script.Call("new").AsGodotObject();
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        if(BroadcasterLogin != null) request.Set("broadcaster_login", BroadcasterLogin);
        if(BroadcasterName != null) request.Set("broadcaster_name", BroadcasterName);
        if(Id != null) request.Set("id", Id);
        if(Title != null) request.Set("title", Title);
        if(Prompt != null) request.Set("prompt", Prompt);
        request.Set("cost", Cost);
        if(Image != null) request.Set("image", Image.ToGodotObject());
        if(DefaultImage != null) request.Set("default_image", DefaultImage.ToGodotObject());
        if(BackgroundColor != null) request.Set("background_color", BackgroundColor);
        request.Set("is_enabled", IsEnabled);
        request.Set("is_user_input_required", IsUserInputRequired);
        if(MaxPerStreamSetting != null) request.Set("max_per_stream_setting", MaxPerStreamSetting.ToGodotObject());
        if(MaxPerUserPerStreamSetting != null) request.Set("max_per_user_per_stream_setting", MaxPerUserPerStreamSetting.ToGodotObject());
        if(GlobalCooldownSetting != null) request.Set("global_cooldown_setting", GlobalCooldownSetting.ToGodotObject());
        request.Set("is_paused", IsPaused);
        request.Set("is_in_stock", IsInStock);
        request.Set("should_redemptions_skip_request_queue", ShouldRedemptionsSkipRequestQueue);
        request.Set("redemptions_redeemed_current_stream", RedemptionsRedeemedCurrentStream);
        if(CooldownExpiresAt != null) request.Set("cooldown_expires_at", CooldownExpiresAt);
        return request;
    }
    
    /// <summary> 
    /// A set of custom images for the reward. This field is **null** if the broadcaster didn’t upload images. 
    /// </summary>
    public partial class TwitchImage : RefCounted, ITwitcherSharp<TwitchImage>
    {
        private GodotObject? _data;
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
                Url1x = data.Get("url_1x").AsString(),
                Url2x = data.Get("url_2x").AsString(),
                Url4x = data.Get("url_4x").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_custom_reward.gd");
            var twitchImageClass = script.Get("Image").AsGodotObject();
            var request = twitchImageClass.Call("new").AsGodotObject();
            if(Url1x != null) request.Set("url_1x", Url1x);
            if(Url2x != null) request.Set("url_2x", Url2x);
            if(Url4x != null) request.Set("url_4x", Url4x);
            return request;
        }
    
    }
    
    /// <summary> 
    /// A set of default images for the reward. 
    /// </summary>
    public partial class TwitchDefaultImage : RefCounted, ITwitcherSharp<TwitchDefaultImage>
    {
        private GodotObject? _data;
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
                Url1x = data.Get("url_1x").AsString(),
                Url2x = data.Get("url_2x").AsString(),
                Url4x = data.Get("url_4x").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_custom_reward.gd");
            var twitchDefaultImageClass = script.Get("DefaultImage").AsGodotObject();
            var request = twitchDefaultImageClass.Call("new").AsGodotObject();
            if(Url1x != null) request.Set("url_1x", Url1x);
            if(Url2x != null) request.Set("url_2x", Url2x);
            if(Url4x != null) request.Set("url_4x", Url4x);
            return request;
        }
    
    }
    
    /// <summary> 
    /// The settings used to determine whether to apply a maximum to the number of redemptions allowed per live stream. 
    /// </summary>
    public partial class TwitchMaxPerStreamSetting : RefCounted, ITwitcherSharp<TwitchMaxPerStreamSetting>
    {
        private GodotObject? _data;
        public bool IsEnabled { get; set; }
        public int MaxPerStream { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMaxPerStreamSetting object.
        /// </summary> 
        public static TwitchMaxPerStreamSetting? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchMaxPerStreamSetting
            {
                IsEnabled = data.Get("is_enabled").AsBool(),
                MaxPerStream = data.Get("max_per_stream").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_custom_reward.gd");
            var twitchMaxPerStreamSettingClass = script.Get("MaxPerStreamSetting").AsGodotObject();
            var request = twitchMaxPerStreamSettingClass.Call("new").AsGodotObject();
            request.Set("is_enabled", IsEnabled);
            request.Set("max_per_stream", MaxPerStream);
            return request;
        }
    
    }
    
    /// <summary> 
    /// The settings used to determine whether to apply a maximum to the number of redemptions allowed per user per live stream. 
    /// </summary>
    public partial class TwitchMaxPerUserPerStreamSetting : RefCounted, ITwitcherSharp<TwitchMaxPerUserPerStreamSetting>
    {
        private GodotObject? _data;
        public bool IsEnabled { get; set; }
        public int MaxPerUserPerStream { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMaxPerUserPerStreamSetting object.
        /// </summary> 
        public static TwitchMaxPerUserPerStreamSetting? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchMaxPerUserPerStreamSetting
            {
                IsEnabled = data.Get("is_enabled").AsBool(),
                MaxPerUserPerStream = data.Get("max_per_user_per_stream").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_custom_reward.gd");
            var twitchMaxPerUserPerStreamSettingClass = script.Get("MaxPerUserPerStreamSetting").AsGodotObject();
            var request = twitchMaxPerUserPerStreamSettingClass.Call("new").AsGodotObject();
            request.Set("is_enabled", IsEnabled);
            request.Set("max_per_user_per_stream", MaxPerUserPerStream);
            return request;
        }
    
    }
    
    /// <summary> 
    /// The settings used to determine whether to apply a cooldown period between redemptions and the length of the cooldown. 
    /// </summary>
    public partial class TwitchGlobalCooldownSetting : RefCounted, ITwitcherSharp<TwitchGlobalCooldownSetting>
    {
        private GodotObject? _data;
        public bool IsEnabled { get; set; }
        public int GlobalCooldownSeconds { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchGlobalCooldownSetting object.
        /// </summary> 
        public static TwitchGlobalCooldownSetting? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchGlobalCooldownSetting
            {
                IsEnabled = data.Get("is_enabled").AsBool(),
                GlobalCooldownSeconds = data.Get("global_cooldown_seconds").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_custom_reward.gd");
            var twitchGlobalCooldownSettingClass = script.Get("GlobalCooldownSetting").AsGodotObject();
            var request = twitchGlobalCooldownSettingClass.Call("new").AsGodotObject();
            request.Set("is_enabled", IsEnabled);
            request.Set("global_cooldown_seconds", GlobalCooldownSeconds);
            return request;
        }
    
    }

}
