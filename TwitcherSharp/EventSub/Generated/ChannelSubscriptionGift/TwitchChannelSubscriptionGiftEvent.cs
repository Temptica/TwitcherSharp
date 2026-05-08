using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSubscriptionGift;

public partial class TwitchChannelSubscriptionGiftEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelSubscriptionGiftEvent>
{
    private GodotObject _data;
    
    /// <summary> 
    /// The user ID of the user who sent the subscription gift. Set to null if it was an anonymous subscription gift.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The user login of the user who sent the gift. Set to null if it was an anonymous subscription gift.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The user display name of the user who sent the gift. Set to null if it was an anonymous subscription gift.
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
    /// The number of subscriptions in the subscription gift.
    /// </summary>
    public int Total { get; set; }

    /// <summary> 
    /// The tier of subscriptions in the subscription gift.
    /// </summary>
    public string Tier { get; set; }

    /// <summary> 
    /// The number of subscriptions gifted by this user in the channel. This value is null for anonymous gifts or if the gifter has opted out of sharing this information.
    /// </summary>
    public int CumulativeTotal { get; set; }

    /// <summary> 
    /// Whether the subscription gift was anonymous.
    /// </summary>
    public bool IsAnonymous { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSubscriptionGiftEvent object.
    /// </summary> 
    public static TwitchChannelSubscriptionGiftEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelSubscriptionGiftEvent
        {
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            Total = data.Get("total").AsInt32(),
            Tier = data.Get("tier").AsString(),
            CumulativeTotal = data.Get("cumulative_total").AsInt32(),
            IsAnonymous = data.Get("is_anonymous").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_subscription_gift.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("total", Total);
        request.Set("tier", Tier);
        request.Set("cumulative_total", CumulativeTotal);
        request.Set("is_anonymous", IsAnonymous);
        return request;
    }
}
