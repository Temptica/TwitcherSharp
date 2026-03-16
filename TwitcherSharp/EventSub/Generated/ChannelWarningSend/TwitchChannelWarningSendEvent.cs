using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelWarningSend;

public partial class TwitchChannelWarningSendEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelWarningSendEvent>
{
    /// <summary> 
    /// The user ID of the broadcaster.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the broadcaster.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user name of the broadcaster.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The user ID of the moderator who sent the warning.
    /// </summary>
    public string ModeratorUserId { get; set; }

    /// <summary> 
    /// The login of the moderator.
    /// </summary>
    public string ModeratorUserLogin { get; set; }

    /// <summary> 
    /// The user name of the moderator.
    /// </summary>
    public string ModeratorUserName { get; set; }

    /// <summary> 
    /// The ID of the user being warned.
    /// </summary>
    public string UserId { get; set; }

    /// <summary> 
    /// The login of the user being warned.
    /// </summary>
    public string UserLogin { get; set; }

    /// <summary> 
    /// The user name of the user being.
    /// </summary>
    public string UserName { get; set; }

    /// <summary> 
    /// Optional. The reason given for the warning.
    /// </summary>
    public string Reason { get; set; }

    /// <summary> 
    /// Optional. The chat rules cited for the warning.
    /// </summary>
    public string[] ChatRulesCited { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelWarningSendEvent object.
    /// </summary> 
    public static TwitchChannelWarningSendEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelWarningSendEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
            ModeratorUserLogin = data.Get("moderator_user_login").AsString(),
            ModeratorUserName = data.Get("moderator_user_name").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            UserName = data.Get("user_name").AsString(),
            Reason = data.Get("reason").AsString(),
            ChatRulesCited = data.Get("chat_rules_cited").AsStringArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_warning_send.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("moderator_user_id", ModeratorUserId);
        request.Set("moderator_user_login", ModeratorUserLogin);
        request.Set("moderator_user_name", ModeratorUserName);
        request.Set("user_id", UserId);
        request.Set("user_login", UserLogin);
        request.Set("user_name", UserName);
        request.Set("reason", Reason);
        request.Set("chat_rules_cited", ChatRulesCited);
        return request;
    }
}
