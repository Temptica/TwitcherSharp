using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchExtension : RefCounted, ITwitcherSharp<TwitchExtension>
{
    private GodotObject? _data;
    public string AuthorName { get; set; } = null!;
    public bool BitsEnabled { get; set; }
    public bool CanInstall { get; set; }
    public string ConfigurationLocation { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string EulaTosUrl { get; set; } = null!;
    public bool HasChatSupport { get; set; }
    public string IconUrl { get; set; } = null!;
    public TwitchExtensionIconUrls IconUrls { get => field ??= _data?.Get<TwitchExtensionIconUrls>("icon_urls")!; set; } = null!;
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string PrivacyPolicyUrl { get; set; } = null!;
    public bool RequestIdentityLink { get; set; }
    public string[] ScreenshotUrls { get; set; } = null!;
    public string State { get; set; } = null!;
    public string SubscriptionsSupportLevel { get; set; } = null!;
    public string Summary { get; set; } = null!;
    public string SupportEmail { get; set; } = null!;
    public string Version { get; set; } = null!;
    public string ViewerSummary { get; set; } = null!;
    public TwitchViews Views { get => field ??= _data?.Get<TwitchViews>("views")!; set; } = null!;
    public string[] AllowlistedConfigUrls { get; set; } = null!;
    public string[] AllowlistedPanelUrls { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchExtension object.
    /// </summary> 
    public static TwitchExtension? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchExtension
        {
            AuthorName = data.Get("author_name").AsString(),
            BitsEnabled = data.Get("bits_enabled").AsBool(),
            CanInstall = data.Get("can_install").AsBool(),
            ConfigurationLocation = data.Get("configuration_location").AsString(),
            Description = data.Get("description").AsString(),
            EulaTosUrl = data.Get("eula_tos_url").AsString(),
            HasChatSupport = data.Get("has_chat_support").AsBool(),
            IconUrl = data.Get("icon_url").AsString(),
            Id = data.Get("id").AsString(),
            Name = data.Get("name").AsString(),
            PrivacyPolicyUrl = data.Get("privacy_policy_url").AsString(),
            RequestIdentityLink = data.Get("request_identity_link").AsBool(),
            ScreenshotUrls = data.Get("screenshot_urls").AsStringArray(),
            State = data.Get("state").AsString(),
            SubscriptionsSupportLevel = data.Get("subscriptions_support_level").AsString(),
            Summary = data.Get("summary").AsString(),
            SupportEmail = data.Get("support_email").AsString(),
            Version = data.Get("version").AsString(),
            ViewerSummary = data.Get("viewer_summary").AsString(),
            AllowlistedConfigUrls = data.Get("allowlisted_config_urls").AsStringArray(),
            AllowlistedPanelUrls = data.Get("allowlisted_panel_urls").AsStringArray(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension.gd");
        var request = script.Call("new").AsGodotObject();
        if(AuthorName != null) request.Set("author_name", AuthorName);
        request.Set("bits_enabled", BitsEnabled);
        request.Set("can_install", CanInstall);
        if(ConfigurationLocation != null) request.Set("configuration_location", ConfigurationLocation);
        if(Description != null) request.Set("description", Description);
        if(EulaTosUrl != null) request.Set("eula_tos_url", EulaTosUrl);
        request.Set("has_chat_support", HasChatSupport);
        if(IconUrl != null) request.Set("icon_url", IconUrl);
        if(IconUrls != null) request.Set("icon_urls", IconUrls.ToGodotObject());
        if(Id != null) request.Set("id", Id);
        if(Name != null) request.Set("name", Name);
        if(PrivacyPolicyUrl != null) request.Set("privacy_policy_url", PrivacyPolicyUrl);
        request.Set("request_identity_link", RequestIdentityLink);
        if(ScreenshotUrls != null) request.Set("screenshot_urls", new Godot.Collections.Array<string>(ScreenshotUrls));
        if(State != null) request.Set("state", State);
        if(SubscriptionsSupportLevel != null) request.Set("subscriptions_support_level", SubscriptionsSupportLevel);
        if(Summary != null) request.Set("summary", Summary);
        if(SupportEmail != null) request.Set("support_email", SupportEmail);
        if(Version != null) request.Set("version", Version);
        if(ViewerSummary != null) request.Set("viewer_summary", ViewerSummary);
        if(Views != null) request.Set("views", Views.ToGodotObject());
        if(AllowlistedConfigUrls != null) request.Set("allowlisted_config_urls", new Godot.Collections.Array<string>(AllowlistedConfigUrls));
        if(AllowlistedPanelUrls != null) request.Set("allowlisted_panel_urls", new Godot.Collections.Array<string>(AllowlistedPanelUrls));
        return request;
    }
    
    /// <summary> 
    /// Describes all views-related information such as how the extension is displayed on mobile devices. 
    /// </summary>
    public partial class TwitchViews : RefCounted, ITwitcherSharp<TwitchViews>
    {
        private GodotObject? _data;
        public TwitchMobile Mobile { get => field ??= _data?.Get<TwitchMobile>("mobile")!; set; } = null!;
        public TwitchPanel Panel { get => field ??= _data?.Get<TwitchPanel>("panel")!; set; } = null!;
        public TwitchVideoOverlay VideoOverlay { get => field ??= _data?.Get<TwitchVideoOverlay>("video_overlay")!; set; } = null!;
        public TwitchComponent Component { get => field ??= _data?.Get<TwitchComponent>("component")!; set; } = null!;
        public TwitchConfig Config { get => field ??= _data?.Get<TwitchConfig>("config")!; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchViews object.
        /// </summary> 
        public static TwitchViews? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchViews();
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension.gd");
            var twitchViewsClass = script.Get("Views").AsGodotObject();
            var request = twitchViewsClass.Call("new").AsGodotObject();
            if(Mobile != null) request.Set("mobile", Mobile.ToGodotObject());
            if(Panel != null) request.Set("panel", Panel.ToGodotObject());
            if(VideoOverlay != null) request.Set("video_overlay", VideoOverlay.ToGodotObject());
            if(Component != null) request.Set("component", Component.ToGodotObject());
            if(Config != null) request.Set("config", Config.ToGodotObject());
            return request;
        }
        
        /// <summary> 
        /// Describes how the extension is displayed on mobile devices. 
        /// </summary>
        public partial class TwitchMobile : RefCounted, ITwitcherSharp<TwitchMobile>
        {
            private GodotObject? _data;
            public string ViewerUrl { get; set; } = null!;
        
            /// <summary> 
            /// Transforms the godot data into a TwitchMobile object.
            /// </summary> 
            public static TwitchMobile? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchMobile
                {
                    ViewerUrl = data.Get("viewer_url").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension.gd");
                var twitchMobileClass = script.Get("Mobile").AsGodotObject();
                var request = twitchMobileClass.Call("new").AsGodotObject();
                if(ViewerUrl != null) request.Set("viewer_url", ViewerUrl);
                return request;
            }
        
        }
        
        /// <summary> 
        /// Describes how the extension is rendered if the extension may be activated as a panel extension. 
        /// </summary>
        public partial class TwitchPanel : RefCounted, ITwitcherSharp<TwitchPanel>
        {
            private GodotObject? _data;
            public string ViewerUrl { get; set; } = null!;
            public int Height { get; set; }
            public bool CanLinkExternalContent { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchPanel object.
            /// </summary> 
            public static TwitchPanel? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchPanel
                {
                    ViewerUrl = data.Get("viewer_url").AsString(),
                    Height = data.Get("height").AsInt32(),
                    CanLinkExternalContent = data.Get("can_link_external_content").AsBool(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension.gd");
                var twitchPanelClass = script.Get("Panel").AsGodotObject();
                var request = twitchPanelClass.Call("new").AsGodotObject();
                if(ViewerUrl != null) request.Set("viewer_url", ViewerUrl);
                request.Set("height", Height);
                request.Set("can_link_external_content", CanLinkExternalContent);
                return request;
            }
        
        }
        
        /// <summary> 
        /// Describes how the extension is rendered if the extension may be activated as a video-overlay extension. 
        /// </summary>
        public partial class TwitchVideoOverlay : RefCounted, ITwitcherSharp<TwitchVideoOverlay>
        {
            private GodotObject? _data;
            public string ViewerUrl { get; set; } = null!;
            public bool CanLinkExternalContent { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchVideoOverlay object.
            /// </summary> 
            public static TwitchVideoOverlay? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchVideoOverlay
                {
                    ViewerUrl = data.Get("viewer_url").AsString(),
                    CanLinkExternalContent = data.Get("can_link_external_content").AsBool(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension.gd");
                var twitchVideoOverlayClass = script.Get("VideoOverlay").AsGodotObject();
                var request = twitchVideoOverlayClass.Call("new").AsGodotObject();
                if(ViewerUrl != null) request.Set("viewer_url", ViewerUrl);
                request.Set("can_link_external_content", CanLinkExternalContent);
                return request;
            }
        
        }
        
        /// <summary> 
        /// Describes how the extension is rendered if the extension may be activated as a video-component extension. 
        /// </summary>
        public partial class TwitchComponent : RefCounted, ITwitcherSharp<TwitchComponent>
        {
            private GodotObject? _data;
            public string ViewerUrl { get; set; } = null!;
            public int AspectRatioX { get; set; }
            public int AspectRatioY { get; set; }
            public bool Autoscale { get; set; }
            public int ScalePixels { get; set; }
            public int TargetHeight { get; set; }
            public bool CanLinkExternalContent { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchComponent object.
            /// </summary> 
            public static TwitchComponent? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchComponent
                {
                    ViewerUrl = data.Get("viewer_url").AsString(),
                    AspectRatioX = data.Get("aspect_ratio_x").AsInt32(),
                    AspectRatioY = data.Get("aspect_ratio_y").AsInt32(),
                    Autoscale = data.Get("autoscale").AsBool(),
                    ScalePixels = data.Get("scale_pixels").AsInt32(),
                    TargetHeight = data.Get("target_height").AsInt32(),
                    CanLinkExternalContent = data.Get("can_link_external_content").AsBool(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension.gd");
                var twitchComponentClass = script.Get("Component").AsGodotObject();
                var request = twitchComponentClass.Call("new").AsGodotObject();
                if(ViewerUrl != null) request.Set("viewer_url", ViewerUrl);
                request.Set("aspect_ratio_x", AspectRatioX);
                request.Set("aspect_ratio_y", AspectRatioY);
                request.Set("autoscale", Autoscale);
                request.Set("scale_pixels", ScalePixels);
                request.Set("target_height", TargetHeight);
                request.Set("can_link_external_content", CanLinkExternalContent);
                return request;
            }
        
        }
        
        /// <summary> 
        /// Describes the view that is shown to broadcasters while they are configuring your extension within the Extension Manager. 
        /// </summary>
        public partial class TwitchConfig : RefCounted, ITwitcherSharp<TwitchConfig>
        {
            private GodotObject? _data;
            public string ViewerUrl { get; set; } = null!;
            public bool CanLinkExternalContent { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchConfig object.
            /// </summary> 
            public static TwitchConfig? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchConfig
                {
                    ViewerUrl = data.Get("viewer_url").AsString(),
                    CanLinkExternalContent = data.Get("can_link_external_content").AsBool(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension.gd");
                var twitchConfigClass = script.Get("Config").AsGodotObject();
                var request = twitchConfigClass.Call("new").AsGodotObject();
                if(ViewerUrl != null) request.Set("viewer_url", ViewerUrl);
                request.Set("can_link_external_content", CanLinkExternalContent);
                return request;
            }
        
        }
    
    }

}
