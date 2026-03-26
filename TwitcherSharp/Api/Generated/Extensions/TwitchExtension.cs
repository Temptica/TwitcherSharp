using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchExtension : RefCounted, ITwitcherSharp<TwitchExtension>
{
    private GodotObject _data;
    public string AuthorName { get; set; }
    public bool BitsEnabled { get; set; }
    public bool CanInstall { get; set; }
    public string ConfigurationLocation { get; set; }
    public string Description { get; set; }
    public string EulaTosUrl { get; set; }
    public bool HasChatSupport { get; set; }
    public string IconUrl { get; set; }
    public TwitchIconUrls IconUrls { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public string PrivacyPolicyUrl { get; set; }
    public bool RequestIdentityLink { get; set; }
    public string[] ScreenshotUrls { get; set; }
    public string State { get; set; }
    public string SubscriptionsSupportLevel { get; set; }
    public string Summary { get; set; }
    public string SupportEmail { get; set; }
    public string Version { get; set; }
    public string ViewerSummary { get; set; }
    public TwitchViews Views { get; set; }
    public string[] AllowlistedConfigUrls { get; set; }
    public string[] AllowlistedPanelUrls { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchExtension object.
    /// </summary> 
    public static TwitchExtension FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchExtension
        {
            AuthorName = data.Get("author_name").AsString(),
            BitsEnabled = data.Get("bits_enabled").AsBool(),
            CanInstall = data.Get("can_install").AsBool(),
            ConfigurationLocation = data.Get("configuration_location").AsString(),
            Description = data.Get("description").AsString(),
            EulaTosUrl = data.Get("eula_tos_url").AsString(),
            HasChatSupport = data.Get("has_chat_support").AsBool(),
            IconUrl = data.Get("icon_url").AsString(),
            IconUrls = data.Get("icon_urls").As<TwitchIconUrls>(),
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
            Views = data.Get("views").As<TwitchViews>(),
            AllowlistedConfigUrls = data.Get("allowlisted_config_urls").AsStringArray(),
            AllowlistedPanelUrls = data.Get("allowlisted_panel_urls").AsStringArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("author_name", AuthorName);
        request.Set("bits_enabled", BitsEnabled);
        request.Set("can_install", CanInstall);
        request.Set("configuration_location", ConfigurationLocation);
        request.Set("description", Description);
        request.Set("eula_tos_url", EulaTosUrl);
        request.Set("has_chat_support", HasChatSupport);
        request.Set("icon_url", IconUrl);
        request.Set("icon_urls", IconUrls);
        request.Set("id", Id);
        request.Set("name", Name);
        request.Set("privacy_policy_url", PrivacyPolicyUrl);
        request.Set("request_identity_link", RequestIdentityLink);
        request.Set("screenshot_urls", ScreenshotUrls);
        request.Set("state", State);
        request.Set("subscriptions_support_level", SubscriptionsSupportLevel);
        request.Set("summary", Summary);
        request.Set("support_email", SupportEmail);
        request.Set("version", Version);
        request.Set("viewer_summary", ViewerSummary);
        request.Set("views", Views);
        request.Set("allowlisted_config_urls", AllowlistedConfigUrls);
        request.Set("allowlisted_panel_urls", AllowlistedPanelUrls);
        return request;
    }
    
    /// <summary> 
    /// A dictionary that contains URLs to different sizes of the default icon. The dictionary’s key identifies the icon’s size (for example, 24x24), and the dictionary’s value contains the URL to the icon. 
    /// </summary>
    public partial class TwitchIconUrls : RefCounted, ITwitcherSharp<TwitchIconUrls>
    {
        private GodotObject _data;
        public string _100x100 { get; set; }
        public string _24x24 { get; set; }
        public string _300x200 { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchIconUrls object.
        /// </summary> 
        public static TwitchIconUrls FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchIconUrls
            {
                _100x100 = data.Get("100x_100").AsString(),
                _24x24 = data.Get("24x_24").AsString(),
                _300x200 = data.Get("300x_200").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_icon_urls.gd");
            var request = script.Call("new").AsGodotObject();
            if(_100x100 != null) request.Set("100x_100", _100x100);
            if(_24x24 != null) request.Set("24x_24", _24x24);
            if(_300x200 != null) request.Set("300x_200", _300x200);
            return request;
        }
    
    }
    
    /// <summary> 
    /// Describes all views-related information such as how the extension is displayed on mobile devices. 
    /// </summary>
    public partial class TwitchViews : RefCounted, ITwitcherSharp<TwitchViews>
    {
        private GodotObject _data;
        public TwitchMobile Mobile { get; set; }
        public TwitchPanel Panel { get; set; }
        public TwitchVideoOverlay VideoOverlay { get; set; }
        public TwitchComponent Component { get; set; }
        public TwitchConfig Config { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchViews object.
        /// </summary> 
        public static TwitchViews FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchViews
            {
                Mobile = data.Get("mobile").As<TwitchMobile>(),
                Panel = data.Get("panel").As<TwitchPanel>(),
                VideoOverlay = data.Get("video_overlay").As<TwitchVideoOverlay>(),
                Component = data.Get("component").As<TwitchComponent>(),
                Config = data.Get("config").As<TwitchConfig>(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_views.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("mobile", Mobile);
            request.Set("panel", Panel);
            request.Set("video_overlay", VideoOverlay);
            request.Set("component", Component);
            request.Set("config", Config);
            return request;
        }
        
        /// <summary> 
        /// Describes how the extension is displayed on mobile devices. 
        /// </summary>
        public partial class TwitchMobile : RefCounted, ITwitcherSharp<TwitchMobile>
        {
            private GodotObject _data;
            public string ViewerUrl { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchMobile object.
            /// </summary> 
            public static TwitchMobile FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchMobile
                {
                    ViewerUrl = data.Get("viewer_url").AsString(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_mobile.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("viewer_url", ViewerUrl);
                return request;
            }
        
        }
        
        /// <summary> 
        /// Describes how the extension is rendered if the extension may be activated as a panel extension. 
        /// </summary>
        public partial class TwitchPanel : RefCounted, ITwitcherSharp<TwitchPanel>
        {
            private GodotObject _data;
            public string ViewerUrl { get; set; }
            public int Height { get; set; }
            public bool CanLinkExternalContent { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchPanel object.
            /// </summary> 
            public static TwitchPanel FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchPanel
                {
                    ViewerUrl = data.Get("viewer_url").AsString(),
                    Height = data.Get("height").AsInt32(),
                    CanLinkExternalContent = data.Get("can_link_external_content").AsBool(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_panel.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("viewer_url", ViewerUrl);
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
            private GodotObject _data;
            public string ViewerUrl { get; set; }
            public bool CanLinkExternalContent { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchVideoOverlay object.
            /// </summary> 
            public static TwitchVideoOverlay FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchVideoOverlay
                {
                    ViewerUrl = data.Get("viewer_url").AsString(),
                    CanLinkExternalContent = data.Get("can_link_external_content").AsBool(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_video_overlay.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("viewer_url", ViewerUrl);
                request.Set("can_link_external_content", CanLinkExternalContent);
                return request;
            }
        
        }
        
        /// <summary> 
        /// Describes how the extension is rendered if the extension may be activated as a video-component extension. 
        /// </summary>
        public partial class TwitchComponent : RefCounted, ITwitcherSharp<TwitchComponent>
        {
            private GodotObject _data;
            public string ViewerUrl { get; set; }
            public int AspectRatioX { get; set; }
            public int AspectRatioY { get; set; }
            public bool Autoscale { get; set; }
            public int ScalePixels { get; set; }
            public int TargetHeight { get; set; }
            public bool CanLinkExternalContent { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchComponent object.
            /// </summary> 
            public static TwitchComponent FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchComponent
                {
                    ViewerUrl = data.Get("viewer_url").AsString(),
                    AspectRatioX = data.Get("aspect_ratio_x").AsInt32(),
                    AspectRatioY = data.Get("aspect_ratio_y").AsInt32(),
                    Autoscale = data.Get("autoscale").AsBool(),
                    ScalePixels = data.Get("scale_pixels").AsInt32(),
                    TargetHeight = data.Get("target_height").AsInt32(),
                    CanLinkExternalContent = data.Get("can_link_external_content").AsBool(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_component.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("viewer_url", ViewerUrl);
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
            private GodotObject _data;
            public string ViewerUrl { get; set; }
            public bool CanLinkExternalContent { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchConfig object.
            /// </summary> 
            public static TwitchConfig FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchConfig
                {
                    ViewerUrl = data.Get("viewer_url").AsString(),
                    CanLinkExternalContent = data.Get("can_link_external_content").AsBool(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_config.gd");
                var request = script.Call("new").AsGodotObject();
                request.Set("viewer_url", ViewerUrl);
                request.Set("can_link_external_content", CanLinkExternalContent);
                return request;
            }
        
        }
    
    }

}
