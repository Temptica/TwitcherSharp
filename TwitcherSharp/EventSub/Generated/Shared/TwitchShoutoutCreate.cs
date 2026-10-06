using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchShoutoutCreate : RefCounted, ITwitcherSharpEventSub<TwitchShoutoutCreate>
{
    private Variant _data;
    
    /// <summary> 
    /// An ID that identifies the broadcaster that sent the Shoutout.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster’s login name.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster’s display name.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// An ID that identifies the broadcaster that received the Shoutout.
    /// </summary>
    public string? ToBroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster’s login name.
    /// </summary>
    public string? ToBroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster’s display name.
    /// </summary>
    public string? ToBroadcasterUserName { get; set; }

    /// <summary> 
    /// An ID that identifies the moderator that sent the Shoutout. If the broadcaster sent the Shoutout, this ID is the same as the ID in broadcaster_user_id.
    /// </summary>
    public string? ModeratorUserId { get; set; }

    /// <summary> 
    /// The moderator’s login name.
    /// </summary>
    public string? ModeratorUserLogin { get; set; }

    /// <summary> 
    /// The moderator’s display name.
    /// </summary>
    public string? ModeratorUserName { get; set; }

    /// <summary> 
    /// The number of users that were watching the broadcaster’s stream at the time of the Shoutout.
    /// </summary>
    public int ViewerCount { get; set; }

    /// <summary> 
    /// The UTC timestamp (in RFC3339 format) of when the moderator sent the Shoutout.
    /// </summary>
    public string? StartedAt { get; set; }

    /// <summary> 
    /// The UTC timestamp (in RFC3339 format) of when the broadcaster may send a Shoutout to a different broadcaster.
    /// </summary>
    public string? CooldownEndsAt { get; set; }

    /// <summary> 
    /// The UTC timestamp (in RFC3339 format) of when the broadcaster may send another Shoutout to the broadcaster in to_broadcaster_user_id.
    /// </summary>
    public string? TargetCooldownEndsAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchShoutoutCreate object.
    /// </summary> 
    public static TwitchShoutoutCreate? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchShoutoutCreate
        {
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            ToBroadcasterUserId = data.Read("to_broadcaster_user_id", static v => v.AsString()),
            ToBroadcasterUserLogin = data.Read("to_broadcaster_user_login", static v => v.AsString()),
            ToBroadcasterUserName = data.Read("to_broadcaster_user_name", static v => v.AsString()),
            ModeratorUserId = data.Read("moderator_user_id", static v => v.AsString()),
            ModeratorUserLogin = data.Read("moderator_user_login", static v => v.AsString()),
            ModeratorUserName = data.Read("moderator_user_name", static v => v.AsString()),
            ViewerCount = data.Read("viewer_count", static v => v.AsInt32()),
            StartedAt = data.Read("started_at", static v => v.AsString()),
            CooldownEndsAt = data.Read("cooldown_ends_at", static v => v.AsString()),
            TargetCooldownEndsAt = data.Read("target_cooldown_ends_at", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_shoutout_create.gd");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(ToBroadcasterUserId != null) request.SetValue("to_broadcaster_user_id", ToBroadcasterUserId);
        if(ToBroadcasterUserLogin != null) request.SetValue("to_broadcaster_user_login", ToBroadcasterUserLogin);
        if(ToBroadcasterUserName != null) request.SetValue("to_broadcaster_user_name", ToBroadcasterUserName);
        if(ModeratorUserId != null) request.SetValue("moderator_user_id", ModeratorUserId);
        if(ModeratorUserLogin != null) request.SetValue("moderator_user_login", ModeratorUserLogin);
        if(ModeratorUserName != null) request.SetValue("moderator_user_name", ModeratorUserName);
        request.SetValue("viewer_count", ViewerCount);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        if(CooldownEndsAt != null) request.SetValue("cooldown_ends_at", CooldownEndsAt);
        if(TargetCooldownEndsAt != null) request.SetValue("target_cooldown_ends_at", TargetCooldownEndsAt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
