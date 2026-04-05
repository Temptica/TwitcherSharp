using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;

public partial class TwitchEndPredictionResponse : RefCounted, ITwitcherSharp<TwitchEndPredictionResponse>
{
    private GodotObject _data;
    public TwitchPrediction[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEndPredictionResponse object.
    /// </summary> 
    public static TwitchEndPredictionResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchEndPredictionResponse
        {
            Data = dataArray.Select(TwitchPrediction.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_end_prediction.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        return request;
    }

}
