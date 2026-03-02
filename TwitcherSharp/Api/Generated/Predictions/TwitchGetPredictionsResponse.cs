using TwitcherSharp.Api.Generated.Shared;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;

public partial class TwitchGetPredictionsResponse : Resource, ITwitcherSharp<TwitchGetPredictionsResponse>
{
    private GodotObject _data;
    public TwitchPrediction[] Data { get; set; }
    public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetPredictionsResponse object.
    /// </summary> 
    public static TwitchGetPredictionsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetPredictionsResponse
        {
            Data = dataArray.Select(TwitchPrediction.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<TwitchPagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_predictions.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }

}
