using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSubscribe;

public partial class TwitchChannelSubscribeEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelSubscribeEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The user ID for the user who subscribed to the specified channel.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The user login for the user who subscribed to the specified channel.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The user display name for the user who subscribed to the specified channel.
    /// </summary>
    public string? UserName { get; set; }

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
    /// The tier of the subscription. Valid values are 1000, 2000, and 3000.
    /// </summary>
    public string? Tier { get; set; }

    /// <summary> 
    /// Whether the subscription is a gift.
    /// </summary>
    public bool IsGift { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSubscribeEvent object.
    /// </summary> 
    public static TwitchChannelSubscribeEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelSubscribeEvent
        {
            UserId = data.ReadAsString("user_id"),
            UserLogin = data.ReadAsString("user_login"),
            UserName = data.ReadAsString("user_name"),
            BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
            BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
            BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
            Tier = data.ReadAsString("tier"),
            IsGift = data.ReadAsBool("is_gift"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_subscribe.gd", "Event");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(Tier != null) request.SetValue("tier", Tier);
        request.SetValue("is_gift", IsGift);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
