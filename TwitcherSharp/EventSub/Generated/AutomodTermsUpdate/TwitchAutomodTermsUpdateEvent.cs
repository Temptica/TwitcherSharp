using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodTermsUpdate;

public partial class TwitchAutomodTermsUpdateEvent : Resource, ITwitcherSharpEventSub<TwitchAutomodTermsUpdateEvent>
{
    /// <summary> 
    /// The ID of the broadcaster specified in the request.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the broadcaster specified in the request.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user name of the broadcaster specified in the request.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The ID of the moderator who changed the channel settings.
    /// </summary>
    public string ModeratorUserId { get; set; }

    /// <summary> 
    /// The moderator’s login.
    /// </summary>
    public string ModeratorUserLogin { get; set; }

    /// <summary> 
    /// The moderator’s user name.
    /// </summary>
    public string ModeratorUserName { get; set; }

    /// <summary> 
    /// The status change applied to the terms. Possible options are: add_permittedremove_permittedadd_blockedremove_blocked
    /// </summary>
    public string Action { get; set; }

    /// <summary> 
    /// Indicates whether this term was added due to an Automod message approve/deny action.
    /// </summary>
    public bool FromAutomod { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAutomodTermsUpdateEvent object.
    /// </summary> 
    public static TwitchAutomodTermsUpdateEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchAutomodTermsUpdateEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
            ModeratorUserLogin = data.Get("moderator_user_login").AsString(),
            ModeratorUserName = data.Get("moderator_user_name").AsString(),
            Action = data.Get("action").AsString(),
            FromAutomod = data.Get("from_automod").AsBool(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_automod_terms_update.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("moderator_user_id", ModeratorUserId);
        request.Set("moderator_user_login", ModeratorUserLogin);
        request.Set("moderator_user_name", ModeratorUserName);
        request.Set("action", Action);
        request.Set("from_automod", FromAutomod);
        return request;
    }
}
