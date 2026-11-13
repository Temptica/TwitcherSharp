using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;

public partial class TwitchPrediction : RefCounted, ITwitcherSharp<TwitchPrediction>
{
    private Variant _data;
    public string Id { get; set; } = null!;
    public string BroadcasterId { get; set; } = null!;
    public string BroadcasterName { get; set; } = null!;
    public string BroadcasterLogin { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string WinningOutcomeId { get; set; } = null!;
    public TwitchPredictionOutcome[] Outcomes { get => field ??= _data.GetArray<TwitchPredictionOutcome>("outcomes")!; set; } = null!;
    public int PredictionWindow { get; set; }
    public string Status { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;
    public string EndedAt { get; set; } = null!;
    public string LockedAt { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchPrediction object.
    /// </summary> 
    public static TwitchPrediction? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchPrediction
        {
            Id = data.ReadAsString("id"),
            BroadcasterId = data.ReadAsString("broadcaster_id"),
            BroadcasterName = data.ReadAsString("broadcaster_name"),
            BroadcasterLogin = data.ReadAsString("broadcaster_login"),
            Title = data.ReadAsString("title"),
            WinningOutcomeId = data.ReadAsString("winning_outcome_id"),
            PredictionWindow = data.ReadAsInt32("prediction_window"),
            Status = data.ReadAsString("status"),
            CreatedAt = data.ReadAsString("created_at"),
            EndedAt = data.ReadAsString("ended_at"),
            LockedAt = data.ReadAsString("locked_at"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_prediction.gd");
        if(Id != null) request.SetValue("id", Id);
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
        if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
        if(Title != null) request.SetValue("title", Title);
        if(WinningOutcomeId != null) request.SetValue("winning_outcome_id", WinningOutcomeId);
        if(Outcomes != null) request.SetArray("outcomes", Outcomes);
        request.SetValue("prediction_window", PredictionWindow);
        if(Status != null) request.SetValue("status", Status);
        if(CreatedAt != null) request.SetValue("created_at", CreatedAt);
        if(EndedAt != null) request.SetValue("ended_at", EndedAt);
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
