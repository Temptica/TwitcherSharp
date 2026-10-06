using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelBan;

public partial class TwitchChannelBanEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelBanEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The user ID for the user who was banned on the specified channel.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The user login for the user who was banned on the specified channel.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The user display name for the user who was banned on the specified channel.
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
    /// The user ID of the issuer of the ban.
    /// </summary>
    public string? ModeratorUserId { get; set; }

    /// <summary> 
    /// The user login of the issuer of the ban.
    /// </summary>
    public string? ModeratorUserLogin { get; set; }

    /// <summary> 
    /// The user name of the issuer of the ban.
    /// </summary>
    public string? ModeratorUserName { get; set; }

    /// <summary> 
    /// The reason behind the ban.
    /// </summary>
    public string? Reason { get; set; }

    /// <summary> 
    /// The UTC date and time (in RFC3339 format) of when the user was banned or put in a timeout.
    /// </summary>
    public string? BannedAt { get; set; }

    /// <summary> 
    /// The UTC date and time (in RFC3339 format) of when the timeout ends. Is null if the user was banned instead of put in a timeout.
    /// </summary>
    public string? EndsAt { get; set; }

    /// <summary> 
    /// Indicates whether the ban is permanent (true) or a timeout (false). If true, ends_at will be null.
    /// </summary>
    public bool IsPermanent { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelBanEvent object.
    /// </summary> 
    public static TwitchChannelBanEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelBanEvent
        {
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            ModeratorUserId = data.Read("moderator_user_id", static v => v.AsString()),
            ModeratorUserLogin = data.Read("moderator_user_login", static v => v.AsString()),
            ModeratorUserName = data.Read("moderator_user_name", static v => v.AsString()),
            Reason = data.Read("reason", static v => v.AsString()),
            BannedAt = data.Read("banned_at", static v => v.AsString()),
            EndsAt = data.Read("ends_at", static v => v.AsString()),
            IsPermanent = data.Read("is_permanent", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_ban.gd", "Event");
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(ModeratorUserId != null) request.SetValue("moderator_user_id", ModeratorUserId);
        if(ModeratorUserLogin != null) request.SetValue("moderator_user_login", ModeratorUserLogin);
        if(ModeratorUserName != null) request.SetValue("moderator_user_name", ModeratorUserName);
        if(Reason != null) request.SetValue("reason", Reason);
        if(BannedAt != null) request.SetValue("banned_at", BannedAt);
        if(EndsAt != null) request.SetValue("ends_at", EndsAt);
        request.SetValue("is_permanent", IsPermanent);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
