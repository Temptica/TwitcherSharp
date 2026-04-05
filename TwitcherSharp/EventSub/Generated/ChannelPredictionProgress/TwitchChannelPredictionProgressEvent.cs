using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.ChannelPredictionProgress;

public partial class TwitchChannelPredictionProgressEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelPredictionProgressEvent>
{
    /// <summary> 
    /// Channel Points Prediction ID.
    /// </summary>
    public string Id { get; set; }

    /// <summary> 
    /// The requested broadcaster ID.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The requested broadcaster login.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The requested broadcaster display name.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// Title for the Channel Points Prediction.
    /// </summary>
    public string Title { get; set; }

    /// <summary> 
    /// An array of outcomes for the Channel Points Prediction. Includes top_predictors.
    /// </summary>
    public TwitchOutcomes[] Outcomes { get; set; }

    /// <summary> 
    /// The time the Channel Points Prediction started.
    /// </summary>
    public string StartedAt { get; set; }

    /// <summary> 
    /// The time the Channel Points Prediction will automatically lock.
    /// </summary>
    public string LocksAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPredictionProgressEvent object.
    /// </summary> 
    public static TwitchChannelPredictionProgressEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        var outcomesArray = data.Get("outcomes").AsGodotArray<GodotObject>();
        return new TwitchChannelPredictionProgressEvent
        {
            Id = data.Get("id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            Title = data.Get("title").AsString(),
            Outcomes = outcomesArray.Select(TwitchOutcomes.FromObject).ToArray(),
            StartedAt = data.Get("started_at").AsString(),
            LocksAt = data.Get("locks_at").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_prediction_progress.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("id", Id);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("title", Title);
        request.Set("outcomes", new Godot.Collections.Array(Outcomes.Select(x => x.ToGodotObject()).ToArray()));
        request.Set("started_at", StartedAt);
        request.Set("locks_at", LocksAt);
        return request;
    }
}
