using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;


/// <summary> 
/// All optional parameters for TwitchAPI.GetPredictions 
/// </summary>
public partial class TwitchGetPredictionsOpt : RefCounted, ITwitcherSharp<TwitchGetPredictionsOpt>
{
    private GodotObject _data;
    public string[] Id { get; set; }
    public string First { get; set; }
    public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetPredictionsOpt object.
    /// </summary> 
    public static TwitchGetPredictionsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetPredictionsOpt
        {
            Id = data.Get("id").AsStringArray(),
            First = data.Get("first").AsString(),
            After = data.Get("after").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_predictions.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(Id != null) request.Set("id", new Godot.Collections.Array<string>(Id));
        if(First != null) request.Set("first", First);
        if(After != null) request.Set("after", After);
        return request;
    }

}
