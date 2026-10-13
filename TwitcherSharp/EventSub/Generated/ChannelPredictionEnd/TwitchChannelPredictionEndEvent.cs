using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelPredictionEnd;

public partial class TwitchChannelPredictionEndEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelPredictionEndEvent>
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
    /// ID of the winning outcome.
    /// </summary>
    public string? WinningOutcomeId { get; set; }

    /// <summary> 
    /// An array of outcomes for the Channel Points Prediction. Includes top_predictors.
    /// </summary>
    public TwitchOutcomes[]? Outcomes { get => field ??= _data.GetArray<TwitchOutcomes>("outcomes"); set; }

    /// <summary> 
    /// The status of the Channel Points Prediction. Valid values are resolved and canceled.
    /// </summary>
    public string? Status { get; set; }

    /// <summary> 
    /// The time the Channel Points Prediction started.
    /// </summary>
    public string? StartedAt { get; set; }

    /// <summary> 
    /// The time the Channel Points Prediction ended.
    /// </summary>
    public string? EndedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPredictionEndEvent object.
    /// </summary> 
    public static TwitchChannelPredictionEndEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPredictionEndEvent
        {
            Id = data.ReadAsString("id"),
            BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
            BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
            BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
            Title = data.ReadAsString("title"),
            WinningOutcomeId = data.ReadAsString("winning_outcome_id"),
            Status = data.ReadAsString("status"),
            StartedAt = data.ReadAsString("started_at"),
            EndedAt = data.ReadAsString("ended_at"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_prediction_end.gd", "Event");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(Title != null) request.SetValue("title", Title);
        if(WinningOutcomeId != null) request.SetValue("winning_outcome_id", WinningOutcomeId);
        if(Outcomes != null) request.SetArray("outcomes", Outcomes);
        if(Status != null) request.SetValue("status", Status);
        if(StartedAt != null) request.SetValue("started_at", StartedAt);
        if(EndedAt != null) request.SetValue("ended_at", EndedAt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
