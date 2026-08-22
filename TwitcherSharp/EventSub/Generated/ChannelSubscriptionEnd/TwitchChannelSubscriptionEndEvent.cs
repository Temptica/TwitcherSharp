using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSubscriptionEnd;

public partial class TwitchChannelSubscriptionEndEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelSubscriptionEndEvent>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The user ID for the user whose subscription ended.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The user login for the user whose subscription ended.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The user display name for the user whose subscription ended.
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
    /// The tier of the subscription that ended. Valid values are 1000, 2000, and 3000.
    /// </summary>
    public string? Tier { get; set; }

    /// <summary> 
    /// Whether the subscription was a gift.
    /// </summary>
    public bool IsGift { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSubscriptionEndEvent object.
    /// </summary> 
    public static TwitchChannelSubscriptionEndEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelSubscriptionEndEvent
        {
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            Tier = data.Get("tier").AsString(),
            IsGift = data.Get("is_gift").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_subscription_end.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(UserId != null) request.Set("user_id", UserId);
        if(UserLogin != null) request.Set("user_login", UserLogin);
        if(UserName != null) request.Set("user_name", UserName);
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(Tier != null) request.Set("tier", Tier);
        request.Set("is_gift", IsGift);
        return request;
    }
}
