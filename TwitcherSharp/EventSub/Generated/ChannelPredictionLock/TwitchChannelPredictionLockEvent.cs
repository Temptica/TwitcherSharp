using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelPredictionLock;

public partial class TwitchChannelPredictionLockEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelPredictionLockEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// Channel Points Prediction ID.
    /// </summary>
    public string? Id { get; set; }

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
    /// Title for the Channel Points Prediction.
    /// </summary>
    public string? Title { get; set; }

    /// <summary> 
    /// An array of outcomes for the Channel Points Prediction. Includes top_predictors.
    /// </summary>
    public TwitchOutcomes[]? Outcomes { get => field ??= _data.GetArray<TwitchOutcomes>("outcomes"); set; }

    /// <summary> 
    /// The time the Channel Points Prediction started.
    /// </summary>
    public string? StartedAt { get; set; }

    /// <summary> 
    /// The time the Channel Points Prediction was locked.
    /// </summary>
    public string? LockedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPredictionLockEvent object.
    /// </summary> 
    public static TwitchChannelPredictionLockEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPredictionLockEvent
        {
            Id = data.Read("id", static v => v.AsString()),
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            StartedAt = data.Read("started_at", static v => v.AsString()),
            LockedAt = data.Read("locked_at", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_prediction_lock.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(Title != null) request.SetValue("title", Title);
        if(Outcomes != null) request.SetArray("outcomes", Outcomes);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        if(LockedAt != null) request.SetValue("locked_at", LockedAt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
