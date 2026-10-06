using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.AutomodTermsUpdate;

public partial class TwitchAutomodTermsUpdateEvent : RefCounted, ITwitcherSharpEventSub<TwitchAutomodTermsUpdateEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The ID of the broadcaster specified in the request.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the broadcaster specified in the request.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user name of the broadcaster specified in the request.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The ID of the moderator who changed the channel settings.
    /// </summary>
    public string? ModeratorUserId { get; set; }

    /// <summary> 
    /// The moderator’s login.
    /// </summary>
    public string? ModeratorUserLogin { get; set; }

    /// <summary> 
    /// The moderator’s user name.
    /// </summary>
    public string? ModeratorUserName { get; set; }

    /// <summary> 
    /// The status change applied to the terms. Possible options are: add_permittedremove_permittedadd_blockedremove_blocked
    /// </summary>
    public string? Action { get; set; }

    /// <summary> 
    /// Indicates whether this term was added due to an Automod message approve/deny action.
    /// </summary>
    public bool FromAutomod { get; set; }

    /// <summary> 
    /// The list of terms that had a status change.
    /// </summary>
    public string[]? Terms { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAutomodTermsUpdateEvent object.
    /// </summary> 
    public static TwitchAutomodTermsUpdateEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchAutomodTermsUpdateEvent
        {
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            ModeratorUserId = data.Read("moderator_user_id", static v => v.AsString()),
            ModeratorUserLogin = data.Read("moderator_user_login", static v => v.AsString()),
            ModeratorUserName = data.Read("moderator_user_name", static v => v.AsString()),
            Action = data.Read("action", static v => v.AsString()),
            FromAutomod = data.Read("from_automod", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_automod_terms_update.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(ModeratorUserId != null) request.SetValue("moderator_user_id", ModeratorUserId);
        if(ModeratorUserLogin != null) request.SetValue("moderator_user_login", ModeratorUserLogin);
        if(ModeratorUserName != null) request.SetValue("moderator_user_name", ModeratorUserName);
        if(Action != null) request.SetValue("action", Action);
        request.SetValue("from_automod", FromAutomod);
        if(Terms != null) request.SetValue("terms", new Godot.Collections.Array<string>(Terms));
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
