using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelPointsCustomRewardAdd;

public partial class TwitchChannelPointsCustomRewardAddEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelPointsCustomRewardAddEvent>
{
    /// <summary> 
    /// The reward identifier.
    /// </summary>
    public string Id { get; set; }

    /// <summary> 
    /// The requested broadcaster ID.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The requested broadcaster login.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The requested broadcaster display name.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// Is the reward currently enabled. If false, the reward won’t show up to viewers.
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary> 
    /// Is the reward currently paused. If true, viewers can’t redeem.
    /// </summary>
    public bool IsPaused { get; set; }

    /// <summary> 
    /// Is the reward currently in stock. If false, viewers can’t redeem.
    /// </summary>
    public bool IsInStock { get; set; }

    /// <summary> 
    /// The reward title.
    /// </summary>
    public string Title { get; set; }

    /// <summary> 
    /// The reward cost.
    /// </summary>
    public int Cost { get; set; }

    /// <summary> 
    /// The reward description.
    /// </summary>
    public string Prompt { get; set; }

    /// <summary> 
    /// Does the viewer need to enter information when redeeming the reward.
    /// </summary>
    public bool IsUserInputRequired { get; set; }

    /// <summary> 
    /// Should redemptions be set to fulfilled status immediately when redeemed and skip the request queue instead of the normal unfulfilled status.
    /// </summary>
    public bool ShouldRedemptionsSkipRequestQueue { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMaxPerStream MaxPerStream { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMaxPerUserPerStream MaxPerUserPerStream { get; set; }

    /// <summary> 
    /// Custom background color for the reward. Format: Hex with # prefix. Example: #FA1ED2.
    /// </summary>
    public string BackgroundColor { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchImage Image { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchGlobalCooldown GlobalCooldown { get; set; }

    /// <summary> 
    /// Timestamp of the cooldown expiration. null if the reward isn’t on cooldown.
    /// </summary>
    public string CooldownExpiresAt { get; set; }

    /// <summary> 
    /// The number of redemptions redeemed during the current live stream. Counts against the max_per_stream limit. null if the broadcasters stream isn’t live or max_per_stream isn’t enabled.
    /// </summary>
    public int RedemptionsRedeemedCurrentStream { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsCustomRewardAddEvent object.
    /// </summary> 
    public static TwitchChannelPointsCustomRewardAddEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelPointsCustomRewardAddEvent
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
            MaxPerStream = data.Get("max_per_stream").As<TwitchMaxPerStream>(),
            MaxPerUserPerStream = data.Get("max_per_user_per_stream").As<TwitchMaxPerUserPerStream>(),
            BackgroundColor = data.Get("background_color").AsString(),
            Image = data.Get("image").As<TwitchImage>(),
            GlobalCooldown = data.Get("global_cooldown").As<TwitchGlobalCooldown>(),
            CooldownExpiresAt = data.Get("cooldown_expires_at").AsString(),
            RedemptionsRedeemedCurrentStream = data.Get("redemptions_redeemed_current_stream").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_custom_reward_add.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("id", Id);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("is_enabled", IsEnabled);
        request.Set("is_paused", IsPaused);
        request.Set("is_in_stock", IsInStock);
        request.Set("title", Title);
        request.Set("cost", Cost);
        request.Set("prompt", Prompt);
        request.Set("is_user_input_required", IsUserInputRequired);
        request.Set("should_redemptions_skip_request_queue", ShouldRedemptionsSkipRequestQueue);
        request.Set("max_per_stream", MaxPerStream);
        request.Set("max_per_user_per_stream", MaxPerUserPerStream);
        request.Set("background_color", BackgroundColor);
        request.Set("image", Image);
        request.Set("global_cooldown", GlobalCooldown);
        request.Set("cooldown_expires_at", CooldownExpiresAt);
        request.Set("redemptions_redeemed_current_stream", RedemptionsRedeemedCurrentStream);
        return request;
    }
}
