using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;

public partial class TwitchCreatePredictionResponse : RefCounted, ITwitcherSharp<TwitchCreatePredictionResponse>
{
    private Variant _data;
    public TwitchPrediction[] Data { get => field ??= _data.GetArray<TwitchPrediction>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchCreatePredictionResponse object.
    /// </summary> 
    public static TwitchCreatePredictionResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreatePredictionResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_prediction.gd", "Response");
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
