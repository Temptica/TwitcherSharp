using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;

public partial class TwitchCreatePredictionResponse : RefCounted, ITwitcherSharp<TwitchCreatePredictionResponse>
{
    private GodotObject _data;
    public TwitchPrediction[] Data { get => field ??= _data?.GetArray<TwitchPrediction>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreatePredictionResponse object.
    /// </summary> 
    public static TwitchCreatePredictionResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchCreatePredictionResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_prediction.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
