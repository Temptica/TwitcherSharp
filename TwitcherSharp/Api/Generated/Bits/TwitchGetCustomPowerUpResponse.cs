using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;

public partial class TwitchGetCustomPowerUpResponse : RefCounted, ITwitcherSharp<TwitchGetCustomPowerUpResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetCustomPowerUpResponse object.
    /// </summary> 
    public static TwitchGetCustomPowerUpResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetCustomPowerUpResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_custom_power_up.gd", "Response");
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
    /// A list of custom Power-ups. The list is in ascending order by `id`. If the broadcaster hasn’t created custom Power-ups, the list is empty. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public string BroadcasterId { get; set; } = null!;
        public string BroadcasterLogin { get; set; } = null!;
        public string BroadcasterName { get; set; } = null!;
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Prompt { get; set; } = null!;
        public int Bits { get; set; }
        public TwitchResponseImage Image { get => field ??= _data.Get<TwitchResponseImage>("image")!; set; } = null!;
        public TwitchResponseDefaultImage DefaultImage { get => field ??= _data.Get<TwitchResponseDefaultImage>("default_image")!; set; } = null!;
        public string BackgroundColor { get; set; } = null!;
        public bool IsEnabled { get; set; }
        public bool IsUserInputRequired { get; set; }
        public TwitchResponseMaxPerStreamSetting MaxPerStreamSetting { get => field ??= _data.Get<TwitchResponseMaxPerStreamSetting>("max_per_stream_setting")!; set; } = null!;
        public TwitchResponseMaxPerUserPerStreamSetting MaxPerUserPerStreamSetting { get => field ??= _data.Get<TwitchResponseMaxPerUserPerStreamSetting>("max_per_user_per_stream_setting")!; set; } = null!;
        public TwitchResponseGlobalCooldownSetting GlobalCooldownSetting { get => field ??= _data.Get<TwitchResponseGlobalCooldownSetting>("global_cooldown_setting")!; set; } = null!;
        public bool IsPaused { get; set; }
        public bool IsInStock { get; set; }
        public int RedemptionsRedeemedCurrentStream { get; set; }
        public string CooldownExpiresAt { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
                BroadcasterLogin = data.Read("broadcaster_login", static v => v.AsString()),
                BroadcasterName = data.Read("broadcaster_name", static v => v.AsString()),
                Id = data.Read("id", static v => v.AsString()),
                Title = data.Read("title", static v => v.AsString()),
                Prompt = data.Read("prompt", static v => v.AsString()),
                Bits = data.Read("bits", static v => v.AsInt32()),
                BackgroundColor = data.Read("background_color", static v => v.AsString()),
                IsEnabled = data.Read("is_enabled", static v => v.AsBool()),
                IsUserInputRequired = data.Read("is_user_input_required", static v => v.AsBool()),
                IsPaused = data.Read("is_paused", static v => v.AsBool()),
                IsInStock = data.Read("is_in_stock", static v => v.AsBool()),
                RedemptionsRedeemedCurrentStream = data.Read("redemptions_redeemed_current_stream", static v => v.AsInt32()),
                CooldownExpiresAt = data.Read("cooldown_expires_at", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_custom_power_up.gd", "ResponseData");
            if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
            if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
            if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
            if(Id != null) request.SetValue("id", Id);
            if(Title != null) request.SetValue("title", Title);
            if(Prompt != null) request.SetValue("prompt", Prompt);
            request.SetValue("bits", Bits);
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
        /// A set of custom images for the custom Power-up. This field is **null** if the broadcaster didn’t upload images. 
        /// </summary>
        public partial class TwitchResponseImage : RefCounted, ITwitcherSharp<TwitchResponseImage>
        {
            private Variant _data;
            public string Url1x { get; set; } = null!;
            public string Url2x { get; set; } = null!;
            public string Url4x { get; set; } = null!;
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseImage object.
            /// </summary> 
            public static TwitchResponseImage? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseImage
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
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_custom_power_up.gd", "ResponseTwitchImage");
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
        /// A set of default images for the custom Power-up. 
        /// </summary>
        public partial class TwitchResponseDefaultImage : RefCounted, ITwitcherSharp<TwitchResponseDefaultImage>
        {
            private Variant _data;
            public string Url1x { get; set; } = null!;
            public string Url2x { get; set; } = null!;
            public string Url4x { get; set; } = null!;
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseDefaultImage object.
            /// </summary> 
            public static TwitchResponseDefaultImage? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseDefaultImage
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
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_custom_power_up.gd", "ResponseDefaultImage");
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
        public partial class TwitchResponseMaxPerStreamSetting : RefCounted, ITwitcherSharp<TwitchResponseMaxPerStreamSetting>
        {
            private Variant _data;
            public bool IsEnabled { get; set; }
            public int MaxPerStream { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseMaxPerStreamSetting object.
            /// </summary> 
            public static TwitchResponseMaxPerStreamSetting? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseMaxPerStreamSetting
                {
                    IsEnabled = data.Read("is_enabled", static v => v.AsBool()),
                    MaxPerStream = data.Read("max_per_stream", static v => v.AsInt32()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_custom_power_up.gd", "ResponseMaxPerStreamSetting");
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
        public partial class TwitchResponseMaxPerUserPerStreamSetting : RefCounted, ITwitcherSharp<TwitchResponseMaxPerUserPerStreamSetting>
        {
            private Variant _data;
            public bool IsEnabled { get; set; }
            public int MaxPerUserPerStream { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseMaxPerUserPerStreamSetting object.
            /// </summary> 
            public static TwitchResponseMaxPerUserPerStreamSetting? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseMaxPerUserPerStreamSetting
                {
                    IsEnabled = data.Read("is_enabled", static v => v.AsBool()),
                    MaxPerUserPerStream = data.Read("max_per_user_per_stream", static v => v.AsInt32()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_custom_power_up.gd", "ResponseMaxPerUserPerStreamSetting");
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
        public partial class TwitchResponseGlobalCooldownSetting : RefCounted, ITwitcherSharp<TwitchResponseGlobalCooldownSetting>
        {
            private Variant _data;
            public bool IsEnabled { get; set; }
            public int GlobalCooldownSeconds { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseGlobalCooldownSetting object.
            /// </summary> 
            public static TwitchResponseGlobalCooldownSetting? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseGlobalCooldownSetting
                {
                    IsEnabled = data.Read("is_enabled", static v => v.AsBool()),
                    GlobalCooldownSeconds = data.Read("global_cooldown_seconds", static v => v.AsInt32()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_custom_power_up.gd", "ResponseGlobalCooldownSetting");
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

}
