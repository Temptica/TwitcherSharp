using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelCustomPowerUpRedemptionAdd;

public partial class TwitchChannelCustomPowerUpRedemptionAddEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelCustomPowerUpRedemptionAddEvent>
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
    /// User ID of the user that redeemed the custom Power-up.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// Login of the user that redeemed the custom Power-up.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// Display name of the user that redeemed the custom Power-up.
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
    public TwitchCustomPowerUp? CustomPowerUp { get => field ??= _data.Get<TwitchCustomPowerUp>("custom_power_up"); set; }

    /// <summary> 
    /// RFC3339 timestamp of when the custom Power-up was redeemed.
    /// </summary>
    public string? RedeemedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelCustomPowerUpRedemptionAddEvent object.
    /// </summary> 
    public static TwitchChannelCustomPowerUpRedemptionAddEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelCustomPowerUpRedemptionAddEvent
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
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_custom_power_up_redemption_add.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(UserInput != null) request.SetValue("user_input", UserInput);
        if(Status != null) request.SetValue("status", Status);
        if(CustomPowerUp != null) request.SetObject("custom_power_up", CustomPowerUp);
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
