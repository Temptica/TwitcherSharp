using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchExtension : RefCounted, ITwitcherSharp<TwitchExtension>
{
    private Variant _data;
    public string AuthorName { get; set; } = null!;
    public bool BitsEnabled { get; set; }
    public bool CanInstall { get; set; }
    public string ConfigurationLocation { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string EulaTosUrl { get; set; } = null!;
    public bool HasChatSupport { get; set; }
    public string IconUrl { get; set; } = null!;
    public TwitchExtensionIconUrls IconUrls { get => field ??= _data.Get<TwitchExtensionIconUrls>("icon_urls")!; set; } = null!;
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
    public TwitchViews Views { get => field ??= _data.Get<TwitchViews>("views")!; set; } = null!;
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
            AuthorName = data.Read("author_name", static v => v.AsString()),
            BitsEnabled = data.Read("bits_enabled", static v => v.AsBool()),
            CanInstall = data.Read("can_install", static v => v.AsBool()),
            ConfigurationLocation = data.Read("configuration_location", static v => v.AsString()),
            Description = data.Read("description", static v => v.AsString()),
            EulaTosUrl = data.Read("eula_tos_url", static v => v.AsString()),
            HasChatSupport = data.Read("has_chat_support", static v => v.AsBool()),
            IconUrl = data.Read("icon_url", static v => v.AsString()),
            Id = data.Read("id", static v => v.AsString()),
            Name = data.Read("name", static v => v.AsString()),
            PrivacyPolicyUrl = data.Read("privacy_policy_url", static v => v.AsString()),
            RequestIdentityLink = data.Read("request_identity_link", static v => v.AsBool()),
            ScreenshotUrls = data.Read("screenshot_urls", static v => v.AsStringArray()),
            State = data.Read("state", static v => v.AsString()),
            SubscriptionsSupportLevel = data.Read("subscriptions_support_level", static v => v.AsString()),
            Summary = data.Read("summary", static v => v.AsString()),
            SupportEmail = data.Read("support_email", static v => v.AsString()),
            Version = data.Read("version", static v => v.AsString()),
            ViewerSummary = data.Read("viewer_summary", static v => v.AsString()),
            AllowlistedConfigUrls = data.Read("allowlisted_config_urls", static v => v.AsStringArray()),
            AllowlistedPanelUrls = data.Read("allowlisted_panel_urls", static v => v.AsStringArray()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_extension.gd");
        if(AuthorName != null) request.SetValue("author_name", AuthorName);
        request.SetValue("bits_enabled", BitsEnabled);
        request.SetValue("can_install", CanInstall);
        if(ConfigurationLocation != null) request.SetValue("configuration_location", ConfigurationLocation);
        if(Description != null) request.SetValue("description", Description);
        if(EulaTosUrl != null) request.SetValue("eula_tos_url", EulaTosUrl);
        request.SetValue("has_chat_support", HasChatSupport);
        if(IconUrl != null) request.SetValue("icon_url", IconUrl);
        if(IconUrls != null) request.SetObject("icon_urls", IconUrls);
        if(Id != null) request.SetValue("id", Id);
        if(Name != null) request.SetValue("name", Name);
        if(PrivacyPolicyUrl != null) request.SetValue("privacy_policy_url", PrivacyPolicyUrl);
        request.SetValue("request_identity_link", RequestIdentityLink);
        if(ScreenshotUrls != null) request.SetValue("screenshot_urls", new Godot.Collections.Array<string>(ScreenshotUrls));
        if(State != null) request.SetValue("state", State);
        if(SubscriptionsSupportLevel != null) request.SetValue("subscriptions_support_level", SubscriptionsSupportLevel);
        if(Summary != null) request.SetValue("summary", Summary);
        if(SupportEmail != null) request.SetValue("support_email", SupportEmail);
        if(Version != null) request.SetValue("version", Version);
        if(ViewerSummary != null) request.SetValue("viewer_summary", ViewerSummary);
        if(Views != null) request.SetObject("views", Views);
        if(AllowlistedConfigUrls != null) request.SetValue("allowlisted_config_urls", new Godot.Collections.Array<string>(AllowlistedConfigUrls));
        if(AllowlistedPanelUrls != null) request.SetValue("allowlisted_panel_urls", new Godot.Collections.Array<string>(AllowlistedPanelUrls));
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// Describes all views-related information such as how the extension is displayed on mobile devices. 
    /// </summary>
    public partial class TwitchViews : RefCounted, ITwitcherSharp<TwitchViews>
    {
        private Variant _data;
        public TwitchMobile Mobile { get => field ??= _data.Get<TwitchMobile>("mobile")!; set; } = null!;
        public TwitchPanel Panel { get => field ??= _data.Get<TwitchPanel>("panel")!; set; } = null!;
        public TwitchVideoOverlay VideoOverlay { get => field ??= _data.Get<TwitchVideoOverlay>("video_overlay")!; set; } = null!;
        public TwitchComponent Component { get => field ??= _data.Get<TwitchComponent>("component")!; set; } = null!;
        public TwitchConfig Config { get => field ??= _data.Get<TwitchConfig>("config")!; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchViews object.
        /// </summary> 
        public static TwitchViews? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchViews();
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_extension.gd", "Views");
            if(Mobile != null) request.SetObject("mobile", Mobile);
            if(Panel != null) request.SetObject("panel", Panel);
            if(VideoOverlay != null) request.SetObject("video_overlay", VideoOverlay);
            if(Component != null) request.SetObject("component", Component);
            if(Config != null) request.SetObject("config", Config);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
        
        /// <summary> 
        /// Describes how the extension is displayed on mobile devices. 
        /// </summary>
        public partial class TwitchMobile : RefCounted, ITwitcherSharp<TwitchMobile>
        {
            private Variant _data;
            public string ViewerUrl { get; set; } = null!;
        
            /// <summary> 
            /// Transforms the godot data into a TwitchMobile object.
            /// </summary> 
            public static TwitchMobile? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchMobile
                {
                    ViewerUrl = data.Read("viewer_url", static v => v.AsString()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_extension.gd", "Mobile");
                if(ViewerUrl != null) request.SetValue("viewer_url", ViewerUrl);
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
        /// Describes how the extension is rendered if the extension may be activated as a panel extension. 
        /// </summary>
        public partial class TwitchPanel : RefCounted, ITwitcherSharp<TwitchPanel>
        {
            private Variant _data;
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
                    ViewerUrl = data.Read("viewer_url", static v => v.AsString()),
                    Height = data.Read("height", static v => v.AsInt32()),
                    CanLinkExternalContent = data.Read("can_link_external_content", static v => v.AsBool()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_extension.gd", "Panel");
                if(ViewerUrl != null) request.SetValue("viewer_url", ViewerUrl);
                request.SetValue("height", Height);
                request.SetValue("can_link_external_content", CanLinkExternalContent);
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
        /// Describes how the extension is rendered if the extension may be activated as a video-overlay extension. 
        /// </summary>
        public partial class TwitchVideoOverlay : RefCounted, ITwitcherSharp<TwitchVideoOverlay>
        {
            private Variant _data;
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
                    ViewerUrl = data.Read("viewer_url", static v => v.AsString()),
                    CanLinkExternalContent = data.Read("can_link_external_content", static v => v.AsBool()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_extension.gd", "VideoOverlay");
                if(ViewerUrl != null) request.SetValue("viewer_url", ViewerUrl);
                request.SetValue("can_link_external_content", CanLinkExternalContent);
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
        /// Describes how the extension is rendered if the extension may be activated as a video-component extension. 
        /// </summary>
        public partial class TwitchComponent : RefCounted, ITwitcherSharp<TwitchComponent>
        {
            private Variant _data;
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
                    ViewerUrl = data.Read("viewer_url", static v => v.AsString()),
                    AspectRatioX = data.Read("aspect_ratio_x", static v => v.AsInt32()),
                    AspectRatioY = data.Read("aspect_ratio_y", static v => v.AsInt32()),
                    Autoscale = data.Read("autoscale", static v => v.AsBool()),
                    ScalePixels = data.Read("scale_pixels", static v => v.AsInt32()),
                    TargetHeight = data.Read("target_height", static v => v.AsInt32()),
                    CanLinkExternalContent = data.Read("can_link_external_content", static v => v.AsBool()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_extension.gd", "Component");
                if(ViewerUrl != null) request.SetValue("viewer_url", ViewerUrl);
                request.SetValue("aspect_ratio_x", AspectRatioX);
                request.SetValue("aspect_ratio_y", AspectRatioY);
                request.SetValue("autoscale", Autoscale);
                request.SetValue("scale_pixels", ScalePixels);
                request.SetValue("target_height", TargetHeight);
                request.SetValue("can_link_external_content", CanLinkExternalContent);
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
        /// Describes the view that is shown to broadcasters while they are configuring your extension within the Extension Manager. 
        /// </summary>
        public partial class TwitchConfig : RefCounted, ITwitcherSharp<TwitchConfig>
        {
            private Variant _data;
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
                    ViewerUrl = data.Read("viewer_url", static v => v.AsString()),
                    CanLinkExternalContent = data.Read("can_link_external_content", static v => v.AsBool()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_extension.gd", "Config");
                if(ViewerUrl != null) request.SetValue("viewer_url", ViewerUrl);
                request.SetValue("can_link_external_content", CanLinkExternalContent);
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
