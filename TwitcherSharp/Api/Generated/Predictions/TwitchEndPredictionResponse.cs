using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;

public partial class TwitchEndPredictionResponse : RefCounted, ITwitcherSharp<TwitchEndPredictionResponse>
{
    private GodotObject _data;
    public TwitchPrediction[] Data { get => field ??= _data?.GetArray<TwitchPrediction>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEndPredictionResponse object.
    /// </summary> 
    public static TwitchEndPredictionResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchEndPredictionResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_end_prediction.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
