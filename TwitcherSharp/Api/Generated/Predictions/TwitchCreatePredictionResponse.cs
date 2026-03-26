using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;

public partial class TwitchCreatePredictionResponse : RefCounted, ITwitcherSharp<TwitchCreatePredictionResponse>
{
    private GodotObject _data;
    public TwitchPrediction[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreatePredictionResponse object.
    /// </summary> 
    public static TwitchCreatePredictionResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchCreatePredictionResponse
        {
            Data = dataArray.Select(TwitchPrediction.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_prediction.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        return request;
    }

}
