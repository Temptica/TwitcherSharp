using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchShieldMode : RefCounted, ITwitcherSharpEventSub<TwitchShieldMode>
{
    private GodotObject _data;
    
    /// <summary> 
    /// An ID that identifies the broadcaster whose Shield Mode status was updated.
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
    /// An ID that identifies the moderator that updated the Shield Mode’s status. If the broadcaster updated the status, this ID will be the same as broadcaster_user_id.
    /// </summary>
    public string ModeratorUserId { get; set; }

    /// <summary> 
    /// The moderator’s login name.
    /// </summary>
    public string ModeratorUserLogin { get; set; }

    /// <summary> 
    /// The moderator’s display name.
    /// </summary>
    public string ModeratorUserName { get; set; }

    /// <summary> 
    /// The UTC timestamp (in RFC3339 format) of when the moderator activated Shield Mode. The object includes this field only for channel.shield_mode.begin events.
    /// </summary>
    public string StartedAt { get; set; }

    /// <summary> 
    /// The UTC timestamp (in RFC3339 format) of when the moderator deactivated Shield Mode. The object includes this field only for channel.shield_mode.end events.
    /// </summary>
    public string EndedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchShieldMode object.
    /// </summary> 
    public static TwitchShieldMode FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchShieldMode
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
            ModeratorUserLogin = data.Get("moderator_user_login").AsString(),
            ModeratorUserName = data.Get("moderator_user_name").AsString(),
            StartedAt = data.Get("started_at").AsString(),
            EndedAt = data.Get("ended_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_shield_mode.gd");
        var request = script.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("moderator_user_id", ModeratorUserId);
        request.Set("moderator_user_login", ModeratorUserLogin);
        request.Set("moderator_user_name", ModeratorUserName);
        request.Set("started_at", StartedAt);
        request.Set("ended_at", EndedAt);
        return request;
    }
}
