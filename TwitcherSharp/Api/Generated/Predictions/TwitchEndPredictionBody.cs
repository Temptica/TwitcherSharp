using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;

public partial class TwitchEndPredictionBody : RefCounted, ITwitcherSharp<TwitchEndPredictionBody>
{
    private Variant _data;
    public string BroadcasterId { get; set; } = null!;
    public string Id { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string? WinningOutcomeId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEndPredictionBody object.
    /// </summary> 
    public static TwitchEndPredictionBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchEndPredictionBody
        {
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            Id = data.Read("id", static v => v.AsString()),
            Status = data.Read("status", static v => v.AsString()),
            WinningOutcomeId = data.Read("winning_outcome_id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_end_prediction.gd", "Body");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(Id != null) request.SetValue("id", Id);
        if(Status != null) request.SetValue("status", Status);
        if(WinningOutcomeId != null) request.SetValue("winning_outcome_id", WinningOutcomeId);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
