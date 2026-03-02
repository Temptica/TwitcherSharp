using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchCustomReward : Resource, ITwitcherSharp<TwitchCustomReward>
{
    private GodotObject _data;
    public string BroadcasterId { get; set; }
    public string BroadcasterLogin { get; set; }
    public string BroadcasterName { get; set; }
    public string Id { get; set; }
    public string Title { get; set; }
    public string Prompt { get; set; }
    public int Cost { get; set; }
    public TwitchImage Image { get; set; }
    public TwitchDefaultImage DefaultImage { get; set; }
    public string BackgroundColor { get; set; }
    public bool IsEnabled { get; set; }
    public bool IsUserInputRequired { get; set; }
    public TwitchMaxPerStreamSetting MaxPerStreamSetting { get; set; }
    public TwitchMaxPerUserPerStreamSetting MaxPerUserPerStreamSetting { get; set; }
    public TwitchGlobalCooldownSetting GlobalCooldownSetting { get; set; }
    public bool IsPaused { get; set; }
    public bool IsInStock { get; set; }
    public bool ShouldRedemptionsSkipRequestQueue { get; set; }
    public int RedemptionsRedeemedCurrentStream { get; set; }
    public string CooldownExpiresAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCustomReward object.
    /// </summary> 
    public static TwitchCustomReward FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchCustomReward
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            BroadcasterLogin = data.Get("broadcaster_login").AsString(),
            BroadcasterName = data.Get("broadcaster_name").AsString(),
            Id = data.Get("id").AsString(),
            Title = data.Get("title").AsString(),
            Prompt = data.Get("prompt").AsString(),
            Cost = data.Get("cost").AsInt32(),
            Image = data.Get("image").As<TwitchImage>(),
            DefaultImage = data.Get("default_image").As<TwitchDefaultImage>(),
            BackgroundColor = data.Get("background_color").AsString(),
            IsEnabled = data.Get("is_enabled").AsBool(),
            IsUserInputRequired = data.Get("is_user_input_required").AsBool(),
            MaxPerStreamSetting = data.Get("max_per_stream_setting").As<TwitchMaxPerStreamSetting>(),
            MaxPerUserPerStreamSetting = data.Get("max_per_user_per_stream_setting").As<TwitchMaxPerUserPerStreamSetting>(),
            GlobalCooldownSetting = data.Get("global_cooldown_setting").As<TwitchGlobalCooldownSetting>(),
            IsPaused = data.Get("is_paused").AsBool(),
            IsInStock = data.Get("is_in_stock").AsBool(),
            ShouldRedemptionsSkipRequestQueue = data.Get("should_redemptions_skip_request_queue").AsBool(),
            RedemptionsRedeemedCurrentStream = data.Get("redemptions_redeemed_current_stream").AsInt32(),
            CooldownExpiresAt = data.Get("cooldown_expires_at").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_custom_reward.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("broadcaster_id", BroadcasterId);
        request.Set("broadcaster_login", BroadcasterLogin);
        request.Set("broadcaster_name", BroadcasterName);
        request.Set("id", Id);
        request.Set("title", Title);
        request.Set("prompt", Prompt);
        request.Set("cost", Cost);
        request.Set("image", Image);
        request.Set("default_image", DefaultImage);
        request.Set("background_color", BackgroundColor);
        request.Set("is_enabled", IsEnabled);
        request.Set("is_user_input_required", IsUserInputRequired);
        request.Set("max_per_stream_setting", MaxPerStreamSetting);
        request.Set("max_per_user_per_stream_setting", MaxPerUserPerStreamSetting);
        request.Set("global_cooldown_setting", GlobalCooldownSetting);
        request.Set("is_paused", IsPaused);
        request.Set("is_in_stock", IsInStock);
        request.Set("should_redemptions_skip_request_queue", ShouldRedemptionsSkipRequestQueue);
        request.Set("redemptions_redeemed_current_stream", RedemptionsRedeemedCurrentStream);
        request.Set("cooldown_expires_at", CooldownExpiresAt);
        return request;
    }
    
    /// <summary> 
    /// A set of custom images for the reward. This field is **null** if the broadcaster didn’t upload images. 
    /// </summary>
    public partial class TwitchImage : Resource, ITwitcherSharp<TwitchImage>
    {
        private GodotObject _data;
        public string Url1x { get; set; }
        public string Url2x { get; set; }
        public string Url4x { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchImage object.
        /// </summary> 
        public static TwitchImage FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchImage
            {
                Url1x = data.Get("url_1x").AsString(),
                Url2x = data.Get("url_2x").AsString(),
                Url4x = data.Get("url_4x").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_image.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("url_1x", Url1x);
            request.Set("url_2x", Url2x);
            request.Set("url_4x", Url4x);
            return request;
        }
    
    }
    
    /// <summary> 
    /// A set of default images for the reward. 
    /// </summary>
    public partial class TwitchDefaultImage : Resource, ITwitcherSharp<TwitchDefaultImage>
    {
        private GodotObject _data;
        public string Url1x { get; set; }
        public string Url2x { get; set; }
        public string Url4x { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchDefaultImage object.
        /// </summary> 
        public static TwitchDefaultImage FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchDefaultImage
            {
                Url1x = data.Get("url_1x").AsString(),
                Url2x = data.Get("url_2x").AsString(),
                Url4x = data.Get("url_4x").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_default_image.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("url_1x", Url1x);
            request.Set("url_2x", Url2x);
            request.Set("url_4x", Url4x);
            return request;
        }
    
    }
    
    /// <summary> 
    /// The settings used to determine whether to apply a maximum to the number of redemptions allowed per live stream. 
    /// </summary>
    public partial class TwitchMaxPerStreamSetting : Resource, ITwitcherSharp<TwitchMaxPerStreamSetting>
    {
        private GodotObject _data;
        public bool IsEnabled { get; set; }
        public int MaxPerStream { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMaxPerStreamSetting object.
        /// </summary> 
        public static TwitchMaxPerStreamSetting FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchMaxPerStreamSetting
            {
                IsEnabled = data.Get("is_enabled").AsBool(),
                MaxPerStream = data.Get("max_per_stream").AsInt32(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_max_per_stream_setting.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("is_enabled", IsEnabled);
            request.Set("max_per_stream", MaxPerStream);
            return request;
        }
    
    }
    
    /// <summary> 
    /// The settings used to determine whether to apply a maximum to the number of redemptions allowed per user per live stream. 
    /// </summary>
    public partial class TwitchMaxPerUserPerStreamSetting : Resource, ITwitcherSharp<TwitchMaxPerUserPerStreamSetting>
    {
        private GodotObject _data;
        public bool IsEnabled { get; set; }
        public int MaxPerUserPerStream { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMaxPerUserPerStreamSetting object.
        /// </summary> 
        public static TwitchMaxPerUserPerStreamSetting FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchMaxPerUserPerStreamSetting
            {
                IsEnabled = data.Get("is_enabled").AsBool(),
                MaxPerUserPerStream = data.Get("max_per_user_per_stream").AsInt32(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_max_per_user_per_stream_setting.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("is_enabled", IsEnabled);
            request.Set("max_per_user_per_stream", MaxPerUserPerStream);
            return request;
        }
    
    }
    
    /// <summary> 
    /// The settings used to determine whether to apply a cooldown period between redemptions and the length of the cooldown. 
    /// </summary>
    public partial class TwitchGlobalCooldownSetting : Resource, ITwitcherSharp<TwitchGlobalCooldownSetting>
    {
        private GodotObject _data;
        public bool IsEnabled { get; set; }
        public int GlobalCooldownSeconds { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchGlobalCooldownSetting object.
        /// </summary> 
        public static TwitchGlobalCooldownSetting FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchGlobalCooldownSetting
            {
                IsEnabled = data.Get("is_enabled").AsBool(),
                GlobalCooldownSeconds = data.Get("global_cooldown_seconds").AsInt32(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_global_cooldown_setting.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("is_enabled", IsEnabled);
            request.Set("global_cooldown_seconds", GlobalCooldownSeconds);
            return request;
        }
    
    }

}
