using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelBan;

public partial class TwitchChannelBanEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelBanEvent>
{
    /// <summary> 
    /// The user ID for the user who was banned on the specified channel.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The user login for the user who was banned on the specified channel.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The user display name for the user who was banned on the specified channel.
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
    /// The user ID of the issuer of the ban.
    /// </summary>
    public string ModeratorUserId { get; set; }

    /// <summary> 
    /// The user login of the issuer of the ban.
    /// </summary>
    public string ModeratorUserLogin { get; set; }

    /// <summary> 
    /// The user name of the issuer of the ban.
    /// </summary>
    public string ModeratorUserName { get; set; }

    /// <summary> 
    /// The reason behind the ban.
    /// </summary>
    public string Reason { get; set; }

    /// <summary> 
    /// The UTC date and time (in RFC3339 format) of when the user was banned or put in a timeout.
    /// </summary>
    public string BannedAt { get; set; }

    /// <summary> 
    /// The UTC date and time (in RFC3339 format) of when the timeout ends. Is null if the user was banned instead of put in a timeout.
    /// </summary>
    public string EndsAt { get; set; }

    /// <summary> 
    /// Indicates whether the ban is permanent (true) or a timeout (false). If true, ends_at will be null.
    /// </summary>
    public bool IsPermanent { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelBanEvent object.
    /// </summary> 
    public static TwitchChannelBanEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelBanEvent
        {
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
            ModeratorUserLogin = data.Get("moderator_user_login").AsString(),
            ModeratorUserName = data.Get("moderator_user_name").AsString(),
            Reason = data.Get("reason").AsString(),
            BannedAt = data.Get("banned_at").AsString(),
            EndsAt = data.Get("ends_at").AsString(),
            IsPermanent = data.Get("is_permanent").AsBool(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_ban.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("moderator_user_id", ModeratorUserId);
        request.Set("moderator_user_login", ModeratorUserLogin);
        request.Set("moderator_user_name", ModeratorUserName);
        request.Set("reason", Reason);
        request.Set("banned_at", BannedAt);
        request.Set("ends_at", EndsAt);
        request.Set("is_permanent", IsPermanent);
        return request;
    }
}
