using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSubscriptionGift;

public partial class TwitchChannelSubscriptionGiftEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelSubscriptionGiftEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The user ID of the user who sent the subscription gift. Set to null if it was an anonymous subscription gift.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The user login of the user who sent the gift. Set to null if it was an anonymous subscription gift.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The user display name of the user who sent the gift. Set to null if it was an anonymous subscription gift.
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
    /// The number of subscriptions in the subscription gift.
    /// </summary>
    public int Total { get; set; }

    /// <summary> 
    /// The tier of subscriptions in the subscription gift.
    /// </summary>
    public string? Tier { get; set; }

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
    public static TwitchChannelSubscriptionGiftEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelSubscriptionGiftEvent
        {
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            Total = data.Read("total", static v => v.AsInt32()),
            Tier = data.Read("tier", static v => v.AsString()),
            CumulativeTotal = data.Read("cumulative_total", static v => v.AsInt32()),
            IsAnonymous = data.Read("is_anonymous", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_subscription_gift.gd", "Event");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        request.SetValue("total", Total);
        if(Tier != null) request.SetValue("tier", Tier);
        request.SetValue("cumulative_total", CumulativeTotal);
        request.SetValue("is_anonymous", IsAnonymous);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
