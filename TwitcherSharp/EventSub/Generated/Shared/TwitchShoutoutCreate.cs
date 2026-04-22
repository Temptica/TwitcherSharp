using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchShoutoutCreate : RefCounted, ITwitcherSharpEventSub<TwitchShoutoutCreate>
{
    /// <summary> 
    /// An ID that identifies the broadcaster that sent the Shoutout.
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
    /// An ID that identifies the broadcaster that received the Shoutout.
    /// </summary>
    public string ToBroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster’s login name.
    /// </summary>
    public string ToBroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster’s display name.
    /// </summary>
    public string ToBroadcasterUserName { get; set; }

    /// <summary> 
    /// An ID that identifies the moderator that sent the Shoutout. If the broadcaster sent the Shoutout, this ID is the same as the ID in broadcaster_user_id.
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
    /// The number of users that were watching the broadcaster’s stream at the time of the Shoutout.
    /// </summary>
    public int ViewerCount { get; set; }

    /// <summary> 
    /// The UTC timestamp (in RFC3339 format) of when the moderator sent the Shoutout.
    /// </summary>
    public string StartedAt { get; set; }

    /// <summary> 
    /// The UTC timestamp (in RFC3339 format) of when the broadcaster may send a Shoutout to a different broadcaster.
    /// </summary>
    public string CooldownEndsAt { get; set; }

    /// <summary> 
    /// The UTC timestamp (in RFC3339 format) of when the broadcaster may send another Shoutout to the broadcaster in to_broadcaster_user_id.
    /// </summary>
    public string TargetCooldownEndsAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchShoutoutCreate object.
    /// </summary> 
    public static TwitchShoutoutCreate FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchShoutoutCreate
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            ToBroadcasterUserId = data.Get("to_broadcaster_user_id").AsString(),
            ToBroadcasterUserLogin = data.Get("to_broadcaster_user_login").AsString(),
            ToBroadcasterUserName = data.Get("to_broadcaster_user_name").AsString(),
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
            ModeratorUserLogin = data.Get("moderator_user_login").AsString(),
            ModeratorUserName = data.Get("moderator_user_name").AsString(),
            ViewerCount = data.Get("viewer_count").AsInt32(),
            StartedAt = data.Get("started_at").AsString(),
            CooldownEndsAt = data.Get("cooldown_ends_at").AsString(),
            TargetCooldownEndsAt = data.Get("target_cooldown_ends_at").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_shoutout_create.gd");
        var request = script.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("to_broadcaster_user_id", ToBroadcasterUserId);
        request.Set("to_broadcaster_user_login", ToBroadcasterUserLogin);
        request.Set("to_broadcaster_user_name", ToBroadcasterUserName);
        request.Set("moderator_user_id", ModeratorUserId);
        request.Set("moderator_user_login", ModeratorUserLogin);
        request.Set("moderator_user_name", ModeratorUserName);
        request.Set("viewer_count", ViewerCount);
        request.Set("started_at", StartedAt);
        request.Set("cooldown_ends_at", CooldownEndsAt);
        request.Set("target_cooldown_ends_at", TargetCooldownEndsAt);
        return request;
    }
}
