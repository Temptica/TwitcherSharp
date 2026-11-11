using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelPointsCustomRewardRemove;

public partial class TwitchChannelPointsCustomRewardRemoveEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelPointsCustomRewardRemoveEvent>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The reward identifier.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// The requested broadcaster ID.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The requested broadcaster login.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The requested broadcaster display name.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// Is the reward currently enabled. If false, the reward won't show up to viewers.
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary> 
    /// Is the reward currently paused. If true, viewers can't redeem.
    /// </summary>
    public bool IsPaused { get; set; }

    /// <summary> 
    /// Is the reward currently in stock. If false, viewers can't redeem.
    /// </summary>
    public bool IsInStock { get; set; }

    /// <summary> 
    /// The reward title.
    /// </summary>
    public string? Title { get; set; }

    /// <summary> 
    /// The reward cost.
    /// </summary>
    public int Cost { get; set; }

    /// <summary> 
    /// The reward description.
    /// </summary>
    public string? Prompt { get; set; }

    /// <summary> 
    /// Does the viewer need to enter information when redeeming the reward.
    /// </summary>
    public bool IsUserInputRequired { get; set; }

    /// <summary> 
    /// Should redemptions be set to **fulfilled** status immediately when redeemed and skip the request queue instead of the normal **unfulfilled** status.
    /// </summary>
    public bool ShouldRedemptionsSkipRequestQueue { get; set; }

    /// <summary> 
    /// Whether a maximum per stream is enabled and what the maximum is.
    /// </summary>
    public TwitchMaxPerStream? MaxPerStream { get => field ??= _data?.Get<TwitchMaxPerStream>("max_per_stream"); set; }

    /// <summary> 
    /// Whether a maximum per user per stream is enabled and what the maximum is.
    /// </summary>
    public TwitchMaxPerUserPerStream? MaxPerUserPerStream { get => field ??= _data?.Get<TwitchMaxPerUserPerStream>("max_per_user_per_stream"); set; }

    /// <summary> 
    /// Custom background color for the reward. Format: Hex with \# prefix. Example: `#FA1ED2`.
    /// </summary>
    public string? BackgroundColor { get; set; }

    /// <summary> 
    /// Set of custom images of 1x, 2x and 4x sizes for the reward. Can be **null** if no images have been uploaded.
    /// </summary>
    public TwitchImage? Image { get => field ??= _data?.Get<TwitchImage>("image"); set; }

    /// <summary> 
    /// Set of default images of 1x, 2x and 4x sizes for the reward.
    /// </summary>
    public TwitchDefaultImage? DefaultImage { get => field ??= _data?.Get<TwitchDefaultImage>("default_image"); set; }

    /// <summary> 
    /// Whether a cooldown is enabled and what the cooldown is in seconds.
    /// </summary>
    public TwitchGlobalCooldown? GlobalCooldown { get => field ??= _data?.Get<TwitchGlobalCooldown>("global_cooldown"); set; }

    /// <summary> 
    /// Timestamp of the cooldown expiration. **null** if the reward isn't on cooldown.
    /// </summary>
    public string? CooldownExpiresAt { get; set; }

    /// <summary> 
    /// The number of redemptions redeemed during the current live stream. Counts against the `max_per_stream` limit. **null** if the broadcasters stream isn't live or `max_per_stream` isn't enabled.
    /// </summary>
    public int RedemptionsRedeemedCurrentStream { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsCustomRewardRemoveEvent object.
    /// </summary> 
    public static TwitchChannelPointsCustomRewardRemoveEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPointsCustomRewardRemoveEvent
        {
            Id = data.Get("id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            IsEnabled = data.Get("is_enabled").AsBool(),
            IsPaused = data.Get("is_paused").AsBool(),
            IsInStock = data.Get("is_in_stock").AsBool(),
            Title = data.Get("title").AsString(),
            Cost = data.Get("cost").AsInt32(),
            Prompt = data.Get("prompt").AsString(),
            IsUserInputRequired = data.Get("is_user_input_required").AsBool(),
            ShouldRedemptionsSkipRequestQueue = data.Get("should_redemptions_skip_request_queue").AsBool(),
            BackgroundColor = data.Get("background_color").AsString(),
            CooldownExpiresAt = data.Get("cooldown_expires_at").AsString(),
            RedemptionsRedeemedCurrentStream = data.Get("redemptions_redeemed_current_stream").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_custom_reward_remove.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("is_enabled", IsEnabled);
        request.Set("is_paused", IsPaused);
        request.Set("is_in_stock", IsInStock);
        if(Title != null) request.Set("title", Title);
        request.Set("cost", Cost);
        if(Prompt != null) request.Set("prompt", Prompt);
        request.Set("is_user_input_required", IsUserInputRequired);
        request.Set("should_redemptions_skip_request_queue", ShouldRedemptionsSkipRequestQueue);
        if(MaxPerStream != null) request.Set("max_per_stream", MaxPerStream.ToGodotObject());
        if(MaxPerUserPerStream != null) request.Set("max_per_user_per_stream", MaxPerUserPerStream.ToGodotObject());
        if(BackgroundColor != null) request.Set("background_color", BackgroundColor);
        if(Image != null) request.Set("image", Image.ToGodotObject());
        if(DefaultImage != null) request.Set("default_image", DefaultImage.ToGodotObject());
        if(GlobalCooldown != null) request.Set("global_cooldown", GlobalCooldown.ToGodotObject());
        if(CooldownExpiresAt != null) request.Set("cooldown_expires_at", CooldownExpiresAt);
        request.Set("redemptions_redeemed_current_stream", RedemptionsRedeemedCurrentStream);
        return request;
    }


    public partial class TwitchDefaultImage : RefCounted, ITwitcherSharpEventSub<TwitchDefaultImage>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// URL for the image at 1x size.
        /// </summary>
        public string? Url1x { get; set; }
    
        /// <summary> 
        /// URL for the image at 2x size.
        /// </summary>
        public string? Url2x { get; set; }
    
        /// <summary> 
        /// URL for the image at 4x size.
        /// </summary>
        public string? Url4x { get; set; }
    
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_custom_reward_remove.gd");
            var defaultImageClass = script.Get("DefaultImage").As<GDScript>();
            var request = defaultImageClass.New().AsGodotObject();
            if(Url1x != null) request.Set("url_1x", Url1x);
            if(Url2x != null) request.Set("url_2x", Url2x);
            if(Url4x != null) request.Set("url_4x", Url4x);
            return request;
        }
    }
}
