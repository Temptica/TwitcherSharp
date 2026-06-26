using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;

public partial class TwitchPrediction : RefCounted, ITwitcherSharp<TwitchPrediction>
{
    private GodotObject _data;
    public string Id { get; set; }
    public string BroadcasterId { get; set; }
    public string BroadcasterName { get; set; }
    public string BroadcasterLogin { get; set; }
    public string Title { get; set; }
    public string WinningOutcomeId { get; set; }
    public TwitchPredictionOutcome[] Outcomes { get => field ??= _data?.GetArray<TwitchPredictionOutcome>("outcomes"); set; }
    public int PredictionWindow { get; set; }
    public string Status { get; set; }
    public string CreatedAt { get; set; }
    public string EndedAt { get; set; }
    public string LockedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchPrediction object.
    /// </summary> 
    public static TwitchPrediction FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchPrediction
        {
            Id = data.Get("id").AsString(),
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            BroadcasterName = data.Get("broadcaster_name").AsString(),
            BroadcasterLogin = data.Get("broadcaster_login").AsString(),
            Title = data.Get("title").AsString(),
            WinningOutcomeId = data.Get("winning_outcome_id").AsString(),
            PredictionWindow = data.Get("prediction_window").AsInt32(),
            Status = data.Get("status").AsString(),
            CreatedAt = data.Get("created_at").AsString(),
            EndedAt = data.Get("ended_at").AsString(),
            LockedAt = data.Get("locked_at").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_prediction.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("id", Id);
        request.Set("broadcaster_id", BroadcasterId);
        request.Set("broadcaster_name", BroadcasterName);
        request.Set("broadcaster_login", BroadcasterLogin);
        request.Set("title", Title);
        request.Set("winning_outcome_id", WinningOutcomeId);
        if(Outcomes != null) request.Set("outcomes", Outcomes?.ToGodotArray());
        request.Set("prediction_window", PredictionWindow);
        request.Set("status", Status);
        request.Set("created_at", CreatedAt);
        request.Set("ended_at", EndedAt);
        request.Set("locked_at", LockedAt);
        return request;
    }

}
