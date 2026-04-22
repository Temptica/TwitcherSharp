using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelVIPRemove;

public partial class TwitchChannelVIPRemoveEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelVIPRemoveEvent>
{
    /// <summary> 
    /// The ID of the user who was removed as a VIP.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The login of the user who was removed as a VIP.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The display name of the user who was removed as a VIP.
    /// </summary>
    public string UserName { get; set; }

    /// <summary> 
    /// The ID of the broadcaster.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the broadcaster.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The display name of the broadcaster.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelVIPRemoveEvent object.
    /// </summary> 
    public static TwitchChannelVIPRemoveEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelVIPRemoveEvent
        {
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_vip_remove.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        return request;
    }
}
