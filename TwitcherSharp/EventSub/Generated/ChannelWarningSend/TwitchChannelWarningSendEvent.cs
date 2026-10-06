using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelWarningSend;

public partial class TwitchChannelWarningSendEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelWarningSendEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The user ID of the broadcaster.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the broadcaster.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user name of the broadcaster.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The user ID of the moderator who sent the warning.
    /// </summary>
    public string? ModeratorUserId { get; set; }

    /// <summary> 
    /// The login of the moderator.
    /// </summary>
    public string? ModeratorUserLogin { get; set; }

    /// <summary> 
    /// The user name of the moderator.
    /// </summary>
    public string? ModeratorUserName { get; set; }

    /// <summary> 
    /// The ID of the user being warned.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary> 
    /// The login of the user being warned.
    /// </summary>
    public string? UserLogin { get; set; }

    /// <summary> 
    /// The user name of the user being.
    /// </summary>
    public string? UserName { get; set; }

    /// <summary> 
    /// Optional. The reason given for the warning.
    /// </summary>
    public string? Reason { get; set; }

    /// <summary> 
    /// Optional. The chat rules cited for the warning.
    /// </summary>
    public string[]? ChatRulesCited { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelWarningSendEvent object.
    /// </summary> 
    public static TwitchChannelWarningSendEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelWarningSendEvent
        {
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            ModeratorUserId = data.Read("moderator_user_id", static v => v.AsString()),
            ModeratorUserLogin = data.Read("moderator_user_login", static v => v.AsString()),
            ModeratorUserName = data.Read("moderator_user_name", static v => v.AsString()),
            UserId = data.Read("user_id", static v => v.AsString()),
            UserLogin = data.Read("user_login", static v => v.AsString()),
            UserName = data.Read("user_name", static v => v.AsString()),
            Reason = data.Read("reason", static v => v.AsString()),
            ChatRulesCited = data.Read("chat_rules_cited", static v => v.AsStringArray()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_warning_send.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(ModeratorUserId != null) request.SetValue("moderator_user_id", ModeratorUserId);
        if(ModeratorUserLogin != null) request.SetValue("moderator_user_login", ModeratorUserLogin);
        if(ModeratorUserName != null) request.SetValue("moderator_user_name", ModeratorUserName);
        if(UserId != null) request.SetValue("user_id", UserId);
        if(UserLogin != null) request.SetValue("user_login", UserLogin);
        if(UserName != null) request.SetValue("user_name", UserName);
        if(Reason != null) request.SetValue("reason", Reason);
        if(ChatRulesCited != null) request.SetValue("chat_rules_cited", ChatRulesCited);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
