using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchGetCustomPowerUpResponse : RefCounted, ITwitcherSharp<TwitchGetCustomPowerUpResponse>
{
    private GodotObject _data;
    public TwitchResponseData[] Data { get => field ??= _data?.GetArray<TwitchResponseData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCustomPowerUpResponse object.
    /// </summary> 
    public static TwitchGetCustomPowerUpResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCustomPowerUpResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_power_up.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// A list of custom Power-ups. The list is in ascending order by `id`. If the broadcaster hasn’t created custom Power-ups, the list is empty. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public string BroadcasterId { get; set; }
        public string BroadcasterLogin { get; set; }
        public string BroadcasterName { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Prompt { get; set; }
        public int Bits { get; set; }
        public TwitchResponseImage Image { get => field ??= _data?.Get<TwitchResponseImage>("image"); set; }
        public TwitchResponseDefaultImage DefaultImage { get => field ??= _data?.Get<TwitchResponseDefaultImage>("default_image"); set; }
        public string BackgroundColor { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsUserInputRequired { get; set; }
        public TwitchResponseMaxPerStreamSetting MaxPerStreamSetting { get => field ??= _data?.Get<TwitchResponseMaxPerStreamSetting>("max_per_stream_setting"); set; }
        public TwitchResponseMaxPerUserPerStreamSetting MaxPerUserPerStreamSetting { get => field ??= _data?.Get<TwitchResponseMaxPerUserPerStreamSetting>("max_per_user_per_stream_setting"); set; }
        public TwitchResponseGlobalCooldownSetting GlobalCooldownSetting { get => field ??= _data?.Get<TwitchResponseGlobalCooldownSetting>("global_cooldown_setting"); set; }
        public bool IsPaused { get; set; }
        public bool IsInStock { get; set; }
        public int RedemptionsRedeemedCurrentStream { get; set; }
        public string CooldownExpiresAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                BroadcasterLogin = data.Get("broadcaster_login").AsString(),
                BroadcasterName = data.Get("broadcaster_name").AsString(),
                Id = data.Get("id").AsString(),
                Title = data.Get("title").AsString(),
                Prompt = data.Get("prompt").AsString(),
                Bits = data.Get("bits").AsInt32(),
                BackgroundColor = data.Get("background_color").AsString(),
                IsEnabled = data.Get("is_enabled").AsBool(),
                IsUserInputRequired = data.Get("is_user_input_required").AsBool(),
                IsPaused = data.Get("is_paused").AsBool(),
                IsInStock = data.Get("is_in_stock").AsBool(),
                RedemptionsRedeemedCurrentStream = data.Get("redemptions_redeemed_current_stream").AsInt32(),
                CooldownExpiresAt = data.Get("cooldown_expires_at").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_power_up.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            request.Set("broadcaster_id", BroadcasterId);
            request.Set("broadcaster_login", BroadcasterLogin);
            request.Set("broadcaster_name", BroadcasterName);
            request.Set("id", Id);
            request.Set("title", Title);
            request.Set("prompt", Prompt);
            request.Set("bits", Bits);
            request.Set("image", Image?.ToGodotObject());
            request.Set("default_image", DefaultImage?.ToGodotObject());
            request.Set("background_color", BackgroundColor);
            request.Set("is_enabled", IsEnabled);
            request.Set("is_user_input_required", IsUserInputRequired);
            request.Set("max_per_stream_setting", MaxPerStreamSetting?.ToGodotObject());
            request.Set("max_per_user_per_stream_setting", MaxPerUserPerStreamSetting?.ToGodotObject());
            request.Set("global_cooldown_setting", GlobalCooldownSetting?.ToGodotObject());
            request.Set("is_paused", IsPaused);
            request.Set("is_in_stock", IsInStock);
            request.Set("redemptions_redeemed_current_stream", RedemptionsRedeemedCurrentStream);
            request.Set("cooldown_expires_at", CooldownExpiresAt);
            return request;
        }
        
        /// <summary> 
        /// A set of custom images for the custom Power-up. This field is **null** if the broadcaster didn’t upload images. 
        /// </summary>
        public partial class TwitchResponseImage : RefCounted, ITwitcherSharp<TwitchResponseImage>
        {
            private GodotObject _data;
            public string Url1x { get; set; }
            public string Url2x { get; set; }
            public string Url4x { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseImage object.
            /// </summary> 
            public static TwitchResponseImage FromObject(GodotObject data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseImage
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
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_power_up.gd");
                var twitchResponseImageClass = script.Get("ResponseImage").AsGodotObject();
                var request = twitchResponseImageClass.Call("new").AsGodotObject();
                request.Set("url_1x", Url1x);
                request.Set("url_2x", Url2x);
                request.Set("url_4x", Url4x);
                return request;
            }
        
        }
        
        /// <summary> 
        /// A set of default images for the custom Power-up. 
        /// </summary>
        public partial class TwitchResponseDefaultImage : RefCounted, ITwitcherSharp<TwitchResponseDefaultImage>
        {
            private GodotObject _data;
            public string Url1x { get; set; }
            public string Url2x { get; set; }
            public string Url4x { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseDefaultImage object.
            /// </summary> 
            public static TwitchResponseDefaultImage FromObject(GodotObject data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseDefaultImage
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
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_power_up.gd");
                var twitchResponseDefaultImageClass = script.Get("ResponseDefaultImage").AsGodotObject();
                var request = twitchResponseDefaultImageClass.Call("new").AsGodotObject();
                request.Set("url_1x", Url1x);
                request.Set("url_2x", Url2x);
                request.Set("url_4x", Url4x);
                return request;
            }
        
        }
        
        /// <summary> 
        /// The settings used to determine whether to apply a maximum to the number of redemptions allowed per live stream. 
        /// </summary>
        public partial class TwitchResponseMaxPerStreamSetting : RefCounted, ITwitcherSharp<TwitchResponseMaxPerStreamSetting>
        {
            private GodotObject _data;
            public bool IsEnabled { get; set; }
            public int MaxPerStream { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseMaxPerStreamSetting object.
            /// </summary> 
            public static TwitchResponseMaxPerStreamSetting FromObject(GodotObject data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseMaxPerStreamSetting
                {
                    IsEnabled = data.Get("is_enabled").AsBool(),
                    MaxPerStream = data.Get("max_per_stream").AsInt32(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_power_up.gd");
                var twitchResponseMaxPerStreamSettingClass = script.Get("ResponseMaxPerStreamSetting").AsGodotObject();
                var request = twitchResponseMaxPerStreamSettingClass.Call("new").AsGodotObject();
                request.Set("is_enabled", IsEnabled);
                request.Set("max_per_stream", MaxPerStream);
                return request;
            }
        
        }
        
        /// <summary> 
        /// The settings used to determine whether to apply a maximum to the number of redemptions allowed per user per live stream. 
        /// </summary>
        public partial class TwitchResponseMaxPerUserPerStreamSetting : RefCounted, ITwitcherSharp<TwitchResponseMaxPerUserPerStreamSetting>
        {
            private GodotObject _data;
            public bool IsEnabled { get; set; }
            public int MaxPerUserPerStream { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseMaxPerUserPerStreamSetting object.
            /// </summary> 
            public static TwitchResponseMaxPerUserPerStreamSetting FromObject(GodotObject data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseMaxPerUserPerStreamSetting
                {
                    IsEnabled = data.Get("is_enabled").AsBool(),
                    MaxPerUserPerStream = data.Get("max_per_user_per_stream").AsInt32(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_power_up.gd");
                var twitchResponseMaxPerUserPerStreamSettingClass = script.Get("ResponseMaxPerUserPerStreamSetting").AsGodotObject();
                var request = twitchResponseMaxPerUserPerStreamSettingClass.Call("new").AsGodotObject();
                request.Set("is_enabled", IsEnabled);
                request.Set("max_per_user_per_stream", MaxPerUserPerStream);
                return request;
            }
        
        }
        
        /// <summary> 
        /// The settings used to determine whether to apply a cooldown period between redemptions and the length of the cooldown. 
        /// </summary>
        public partial class TwitchResponseGlobalCooldownSetting : RefCounted, ITwitcherSharp<TwitchResponseGlobalCooldownSetting>
        {
            private GodotObject _data;
            public bool IsEnabled { get; set; }
            public int GlobalCooldownSeconds { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseGlobalCooldownSetting object.
            /// </summary> 
            public static TwitchResponseGlobalCooldownSetting FromObject(GodotObject data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseGlobalCooldownSetting
                {
                    IsEnabled = data.Get("is_enabled").AsBool(),
                    GlobalCooldownSeconds = data.Get("global_cooldown_seconds").AsInt32(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_power_up.gd");
                var twitchResponseGlobalCooldownSettingClass = script.Get("ResponseGlobalCooldownSetting").AsGodotObject();
                var request = twitchResponseGlobalCooldownSettingClass.Call("new").AsGodotObject();
                request.Set("is_enabled", IsEnabled);
                request.Set("global_cooldown_seconds", GlobalCooldownSeconds);
                return request;
            }
        
        }
    
    }

}
