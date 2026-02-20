using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelSubscriptionMessage;

public partial class TwitchChannelSubscriptionMessageEvent : Resource, ITwitcherSharpEventSub<TwitchChannelSubscriptionMessageEvent>
{
    /// <summary> 
    /// The user ID of the user who sent a resubscription chat message.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The user login of the user who sent a resubscription chat message.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The user display name of the user who a resubscription chat message.
    /// </summary>
    public string UserName { get; set; }

    /// <summary> 
    /// The broadcaster user ID.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster login.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster display name.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The tier of the user’s subscription.
    /// </summary>
    public string Tier { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMessage Message { get; set; }

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
    public static TwitchChannelSubscriptionMessageEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelSubscriptionMessageEvent
        {
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            Tier = data.Get("tier").AsString(),
            Message = data.Get("message").As<TwitchMessage>(),
            CumulativeMonths = data.Get("cumulative_months").AsInt32(),
            StreakMonths = data.Get("streak_months").AsInt32(),
            DurationMonths = data.Get("duration_months").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_subscription_message.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("tier", Tier);
        request.Set("message", Message);
        request.Set("cumulative_months", CumulativeMonths);
        request.Set("streak_months", StreakMonths);
        request.Set("duration_months", DurationMonths);
        return request;
    }
}
