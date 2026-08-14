using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;

public partial class TwitchEndPredictionBody : RefCounted, ITwitcherSharp<TwitchEndPredictionBody>
{
    private GodotObject? _data;
    public string? BroadcasterId { get; set; }
    public string? Id { get; set; }
    public string? Status { get; set; }
    public string? WinningOutcomeId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEndPredictionBody object.
    /// </summary> 
    public static TwitchEndPredictionBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchEndPredictionBody
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            Id = data.Get("id").AsString(),
            Status = data.Get("status").AsString(),
            WinningOutcomeId = data.Get("winning_outcome_id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_end_prediction.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        if(Id != null) request.Set("id", Id);
        if(Status != null) request.Set("status", Status);
        if(WinningOutcomeId != null) request.Set("winning_outcome_id", WinningOutcomeId);
        return request;
    }

}
