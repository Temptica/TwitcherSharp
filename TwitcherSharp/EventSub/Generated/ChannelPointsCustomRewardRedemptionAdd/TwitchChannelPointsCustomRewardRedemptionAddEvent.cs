using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelPointsCustomRewardRedemptionAdd;

public partial class TwitchChannelPointsCustomRewardRedemptionAddEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelPointsCustomRewardRedemptionAddEvent>
{
    private Variant _data;
    
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
    /// RFC3339 timestamp of when the reward was redeemed.
    /// </summary>
    public string? RedeemedAt { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchReward? Reward { get => field ??= _data.Get<TwitchReward>("reward"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsCustomRewardRedemptionAddEvent object.
    /// </summary> 
    public static TwitchChannelPointsCustomRewardRedemptionAddEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPointsCustomRewardRedemptionAddEvent
        {
            Id = data.Read("id", static v => v.AsString()),
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            UserInput = data.Read("user_input", static v => v.AsString()),
            Status = data.Read("status", static v => v.AsString()),
            RedeemedAt = data.Read("redeemed_at", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_custom_reward_redemption_add.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(UserInput != null) request.SetValue("user_input", UserInput);
        if(Status != null) request.SetValue("status", Status);
        if(RedeemedAt != null) request.SetValue("redeemed_at", RedeemedAt);
        if(Reward != null) request.SetObject("reward", Reward);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
