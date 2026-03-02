using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.HypeTrain;


/// <summary> 
/// All optional parameters for TwitchAPI.GetHypeTrainEvents 
/// </summary>
public partial class TwitchGetHypeTrainEventsOpt : Resource, ITwitcherSharp<TwitchGetHypeTrainEventsOpt>
{
    private GodotObject _data;
    public int? First { get; set; }
    public string After { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetHypeTrainEventsOpt object.
    /// </summary> 
    public static TwitchGetHypeTrainEventsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchGetHypeTrainEventsOpt
        {
            First = data.Get("first").AsInt32(),
            After = data.Get("after").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_hype_train_events.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(First.HasValue) request.Set("first", First.Value);
        if(After != null) request.Set("after", After);
        return request;
    }

}
