using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSubscribe;

public partial class TwitchChannelSubscribeEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelSubscribeEvent>
{
    /// <summary> 
    /// The user ID for the user who subscribed to the specified channel.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The user login for the user who subscribed to the specified channel.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The user display name for the user who subscribed to the specified channel.
    /// </summary>
    public string UserName { get; set; }

    /// <summary> 
    /// The requested broadcaster ID.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The requested broadcaster login.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The requested broadcaster display name.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The tier of the subscription. Valid values are 1000, 2000, and 3000.
    /// </summary>
    public string Tier { get; set; }

    /// <summary> 
    /// Whether the subscription is a gift.
    /// </summary>
    public bool IsGift { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSubscribeEvent object.
    /// </summary> 
    public static TwitchChannelSubscribeEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelSubscribeEvent
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
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_subscribe.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("tier", Tier);
        request.Set("is_gift", IsGift);
        return request;
    }
}
