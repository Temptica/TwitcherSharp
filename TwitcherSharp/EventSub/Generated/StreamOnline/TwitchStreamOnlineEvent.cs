using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.StreamOnline;

public partial class TwitchStreamOnlineEvent : RefCounted, ITwitcherSharpEventSub<TwitchStreamOnlineEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The id of the stream.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// The broadcaster’s user id.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster’s user login.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The broadcaster’s user display name.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The stream type. Valid values are: live, playlist, watch_party, premiere, rerun.
    /// </summary>
    public string? Type { get; set; }

    /// <summary> 
    /// The timestamp at which the stream went online at.
    /// </summary>
    public string? StartedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStreamOnlineEvent object.
    /// </summary> 
    public static TwitchStreamOnlineEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchStreamOnlineEvent
        {
            Id = data.Read("id", static v => v.AsString()),
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            Type = data.Read("type", static v => v.AsString()),
            StartedAt = data.Read("started_at", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_stream_online.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(Type != null) request.SetValue("type", Type);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
