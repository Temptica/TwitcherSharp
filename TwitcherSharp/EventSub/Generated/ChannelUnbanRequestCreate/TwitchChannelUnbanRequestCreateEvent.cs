using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelUnbanRequestCreate;

public partial class TwitchChannelUnbanRequestCreateEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelUnbanRequestCreateEvent>
{
    /// <summary> 
    /// The ID of the unban request.
    /// </summary>
    public string Id { get; set; }

    /// <summary> 
    /// The broadcaster’s user ID for the channel the unban request was created for.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster’s login name.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster’s display name.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// User ID of user that is requesting to be unbanned.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The user’s login name.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The user’s display name.
    /// </summary>
    public string UserName { get; set; }

    /// <summary> 
    /// Message sent in the unban request.
    /// </summary>
    public string Text { get; set; }

    /// <summary> 
    /// The UTC timestamp (in RFC3339 format) of when the unban request was created.
    /// </summary>
    public string CreatedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelUnbanRequestCreateEvent object.
    /// </summary> 
    public static TwitchChannelUnbanRequestCreateEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelUnbanRequestCreateEvent
        {
            Id = data.Get("id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            Text = data.Get("text").AsString(),
            CreatedAt = data.Get("created_at").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_unban_request_create.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("id", Id);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("text", Text);
        request.Set("created_at", CreatedAt);
        return request;
    }
}
