using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelPredictionEnd;

public partial class TwitchChannelPredictionEndEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelPredictionEndEvent>
{
    private GodotObject? _data;
    
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
    public TwitchOutcomes[]? Outcomes { get => field ??= _data?.GetArray<TwitchOutcomes>("outcomes"); set; }

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
            Id = data.Get("id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            Title = data.Get("title").AsString(),
            WinningOutcomeId = data.Get("winning_outcome_id").AsString(),
            Status = data.Get("status").AsString(),
            StartedAt = data.Get("started_at").AsString(),
            EndedAt = data.Get("ended_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_prediction_end.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(Title != null) request.Set("title", Title);
        if(WinningOutcomeId != null) request.Set("winning_outcome_id", WinningOutcomeId);
        if(Outcomes != null) request.Set("outcomes", Outcomes.ToGodotArray());
        if(Status != null) request.Set("status", Status);
        if(StartedAt != null) request.Set("started_at", StartedAt);
        if(EndedAt != null) request.Set("ended_at", EndedAt);
        return request;
    }
}
