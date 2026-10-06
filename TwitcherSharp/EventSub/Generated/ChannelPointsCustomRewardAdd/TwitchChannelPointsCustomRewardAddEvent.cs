using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelPointsCustomRewardAdd;

public partial class TwitchChannelPointsCustomRewardAddEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelPointsCustomRewardAddEvent>
{
    private Variant _data;
    
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
    /// Should redemptions be set to fulfilled status immediately when redeemed and skip the request queue instead of the normal unfulfilled status.
    /// </summary>
    public bool ShouldRedemptionsSkipRequestQueue { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMaxPerStream? MaxPerStream { get => field ??= _data.Get<TwitchMaxPerStream>("max_per_stream"); set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMaxPerUserPerStream? MaxPerUserPerStream { get => field ??= _data.Get<TwitchMaxPerUserPerStream>("max_per_user_per_stream"); set; }

    /// <summary> 
    /// Custom background color for the reward. Format: Hex with # prefix. Example: #FA1ED2.
    /// </summary>
    public string? BackgroundColor { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchImage? Image { get => field ??= _data.Get<TwitchImage>("image"); set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchGlobalCooldown? GlobalCooldown { get => field ??= _data.Get<TwitchGlobalCooldown>("global_cooldown"); set; }

    /// <summary> 
    /// Timestamp of the cooldown expiration. null if the reward isn’t on cooldown.
    /// </summary>
    public string? CooldownExpiresAt { get; set; }

    /// <summary> 
    /// The number of redemptions redeemed during the current live stream. Counts against the max_per_stream limit. null if the broadcasters stream isn’t live or max_per_stream isn’t enabled.
    /// </summary>
    public int RedemptionsRedeemedCurrentStream { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsCustomRewardAddEvent object.
    /// </summary> 
    public static TwitchChannelPointsCustomRewardAddEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPointsCustomRewardAddEvent
        {
            Id = data.Read("id", static v => v.AsString()),
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            IsEnabled = data.Read("is_enabled", static v => v.AsBool()),
            IsPaused = data.Read("is_paused", static v => v.AsBool()),
            IsInStock = data.Read("is_in_stock", static v => v.AsBool()),
            Title = data.Read("title", static v => v.AsString()),
            Cost = data.Read("cost", static v => v.AsInt32()),
            Prompt = data.Read("prompt", static v => v.AsString()),
            IsUserInputRequired = data.Read("is_user_input_required", static v => v.AsBool()),
            ShouldRedemptionsSkipRequestQueue = data.Read("should_redemptions_skip_request_queue", static v => v.AsBool()),
            BackgroundColor = data.Read("background_color", static v => v.AsString()),
            CooldownExpiresAt = data.Read("cooldown_expires_at", static v => v.AsString()),
            RedemptionsRedeemedCurrentStream = data.Read("redemptions_redeemed_current_stream", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_custom_reward_add.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        request.SetValue("is_enabled", IsEnabled);
        request.SetValue("is_paused", IsPaused);
        request.SetValue("is_in_stock", IsInStock);
        if(Title != null) request.SetValue("title", Title);
        request.SetValue("cost", Cost);
        if(Prompt != null) request.SetValue("prompt", Prompt);
        request.SetValue("is_user_input_required", IsUserInputRequired);
        request.SetValue("should_redemptions_skip_request_queue", ShouldRedemptionsSkipRequestQueue);
        if(MaxPerStream != null) request.SetObject("max_per_stream", MaxPerStream);
        if(MaxPerUserPerStream != null) request.SetObject("max_per_user_per_stream", MaxPerUserPerStream);
        if(BackgroundColor != null) request.SetValue("background_color", BackgroundColor);
        if(Image != null) request.SetObject("image", Image);
        if(GlobalCooldown != null) request.SetObject("global_cooldown", GlobalCooldown);
        if(CooldownExpiresAt != null) request.SetValue("cooldown_expires_at", CooldownExpiresAt);
        request.SetValue("redemptions_redeemed_current_stream", RedemptionsRedeemedCurrentStream);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
