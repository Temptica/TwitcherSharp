using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelPointsCustomRewardRedemptionUpdate;

public partial class TwitchChannelPointsCustomRewardRedemptionUpdateEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelPointsCustomRewardRedemptionUpdateEvent>
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
    /// Will be fulfilled or canceled. Possible values are unknown, unfulfilled, fulfilled, and canceled.
    /// </summary>
    public string? Status { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchReward? Reward { get => field ??= _data.Get<TwitchReward>("reward"); set; }

    /// <summary> 
    /// RFC3339 timestamp of when the reward was redeemed.
    /// </summary>
    public string? RedeemedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsCustomRewardRedemptionUpdateEvent object.
    /// </summary> 
    public static TwitchChannelPointsCustomRewardRedemptionUpdateEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPointsCustomRewardRedemptionUpdateEvent
        {
            Id = data.ReadAsString("id"),
            BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
            BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
            BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
            UserId = data.ReadAsString("user_id"),
            UserLogin = data.ReadAsString("user_login"),
            UserName = data.ReadAsString("user_name"),
            UserInput = data.ReadAsString("user_input"),
            Status = data.ReadAsString("status"),
            RedeemedAt = data.ReadAsString("redeemed_at"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_custom_reward_redemption_update.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(UserInput != null) request.SetValue("user_input", UserInput);
        if(Status != null) request.SetValue("status", Status);
        if(Reward != null) request.SetObject("reward", Reward);
        if(RedeemedAt != null) request.SetValue("redeemed_at", RedeemedAt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
