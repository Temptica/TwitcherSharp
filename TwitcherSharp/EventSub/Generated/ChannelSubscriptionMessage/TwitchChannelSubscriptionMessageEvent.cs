using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelSubscriptionMessage;

public partial class TwitchChannelSubscriptionMessageEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelSubscriptionMessageEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The user ID of the user who sent a resubscription chat message.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The user login of the user who sent a resubscription chat message.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The user display name of the user who a resubscription chat message.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// The broadcaster user ID.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster login.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster display name.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The tier of the user’s subscription.
    /// </summary>
    public string? Tier { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMessage? Message { get => field ??= _data.Get<TwitchMessage>("message"); set; }

    /// <summary> 
    /// The total number of months the user has been subscribed to the channel.
    /// </summary>
    public int CumulativeMonths { get; set; }

    /// <summary> 
    /// The number of consecutive months the user’s current subscription has been active. This value is null if the user has opted out of sharing this information.
    /// </summary>
    public int StreakMonths { get; set; }

    /// <summary> 
    /// The month duration of the subscription.
    /// </summary>
    public int DurationMonths { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSubscriptionMessageEvent object.
    /// </summary> 
    public static TwitchChannelSubscriptionMessageEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelSubscriptionMessageEvent
        {
            UserId = data.ReadAsString("user_id"),
            UserLogin = data.ReadAsString("user_login"),
            UserName = data.ReadAsString("user_name"),
            BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
            BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
            BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
            Tier = data.ReadAsString("tier"),
            CumulativeMonths = data.ReadAsInt32("cumulative_months"),
            StreakMonths = data.ReadAsInt32("streak_months"),
            DurationMonths = data.ReadAsInt32("duration_months"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_subscription_message.gd", "Event");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(Tier != null) request.SetValue("tier", Tier);
        if(Message != null) request.SetObject("message", Message);
        request.SetValue("cumulative_months", CumulativeMonths);
        request.SetValue("streak_months", StreakMonths);
        request.SetValue("duration_months", DurationMonths);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
