using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;

public partial class TwitchEndPredictionResponse : RefCounted, ITwitcherSharp<TwitchEndPredictionResponse>
{
    private Variant _data;
    public TwitchPrediction[] Data { get => field ??= _data.GetArray<TwitchPrediction>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchEndPredictionResponse object.
    /// </summary> 
    public static TwitchEndPredictionResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchEndPredictionResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_end_prediction.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
