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
            AuthorName = data.ReadAsString("author_name"),
            BitsEnabled = data.ReadAsBool("bits_enabled"),
            CanInstall = data.ReadAsBool("can_install"),
            ConfigurationLocation = data.ReadAsString("configuration_location"),
            Description = data.ReadAsString("description"),
            EulaTosUrl = data.ReadAsString("eula_tos_url"),
            HasChatSupport = data.ReadAsBool("has_chat_support"),
            IconUrl = data.ReadAsString("icon_url"),
            Id = data.ReadAsString("id"),
            Name = data.ReadAsString("name"),
            PrivacyPolicyUrl = data.ReadAsString("privacy_policy_url"),
            RequestIdentityLink = data.ReadAsBool("request_identity_link"),
            ScreenshotUrls = data.ReadAsStringArray("screenshot_urls"),
            State = data.ReadAsString("state"),
            SubscriptionsSupportLevel = data.ReadAsString("subscriptions_support_level"),
            Summary = data.ReadAsString("summary"),
            SupportEmail = data.ReadAsString("support_email"),
            Version = data.ReadAsString("version"),
            ViewerSummary = data.ReadAsString("viewer_summary"),
            AllowlistedConfigUrls = data.ReadAsStringArray("allowlisted_config_urls"),
            AllowlistedPanelUrls = data.ReadAsStringArray("allowlisted_panel_urls"),
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
                    ViewerUrl = data.ReadAsString("viewer_url"),
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
                    ViewerUrl = data.ReadAsString("viewer_url"),
                    Height = data.ReadAsInt32("height"),
                    CanLinkExternalContent = data.ReadAsBool("can_link_external_content"),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_extension.gd", "TwitchPanel");
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
                    ViewerUrl = data.ReadAsString("viewer_url"),
                    CanLinkExternalContent = data.ReadAsBool("can_link_external_content"),
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
                    ViewerUrl = data.ReadAsString("viewer_url"),
                    AspectRatioX = data.ReadAsInt32("aspect_ratio_x"),
                    AspectRatioY = data.ReadAsInt32("aspect_ratio_y"),
                    Autoscale = data.ReadAsBool("autoscale"),
                    ScalePixels = data.ReadAsInt32("scale_pixels"),
                    TargetHeight = data.ReadAsInt32("target_height"),
                    CanLinkExternalContent = data.ReadAsBool("can_link_external_content"),
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
                    ViewerUrl = data.ReadAsString("viewer_url"),
                    CanLinkExternalContent = data.ReadAsBool("can_link_external_content"),
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
