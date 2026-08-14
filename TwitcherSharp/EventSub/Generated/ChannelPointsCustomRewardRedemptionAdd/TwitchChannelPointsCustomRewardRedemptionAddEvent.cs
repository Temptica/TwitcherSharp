using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelPointsCustomRewardRedemptionAdd;

public partial class TwitchChannelPointsCustomRewardRedemptionAddEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelPointsCustomRewardRedemptionAddEvent>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The redemption identifier.
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
    /// User ID of the user that redeemed the reward.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// Login of the user that redeemed the reward.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// Display name of the user that redeemed the reward.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The user input provided. Empty string if not provided.
    /// </summary>
    public string? UserInput { get; set; }

    /// <summary> 
    /// Defaults to unfulfilled. Possible values are unknown, unfulfilled, fulfilled, and canceled.
    /// </summary>
    public string? Status { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchReward? Reward { get => field ??= _data?.Get<TwitchReward>("reward"); set; }

    /// <summary> 
    /// RFC3339 timestamp of when the reward was redeemed.
    /// </summary>
    public string? RedeemedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsCustomRewardRedemptionAddEvent object.
    /// </summary> 
    public static TwitchChannelPointsCustomRewardRedemptionAddEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPointsCustomRewardRedemptionAddEvent
        {
            Id = data.Get("id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            UserInput = data.Get("user_input").AsString(),
            Status = data.Get("status").AsString(),
            RedeemedAt = data.Get("redeemed_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_custom_reward_redemption_add.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        if(UserInput != null) request.Set("user_input", UserInput);
        if(Status != null) request.Set("status", Status);
        if(Reward != null) request.Set("reward", Reward.ToGodotObject());
        if(RedeemedAt != null) request.Set("redeemed_at", RedeemedAt);
        return request;
    }
}
