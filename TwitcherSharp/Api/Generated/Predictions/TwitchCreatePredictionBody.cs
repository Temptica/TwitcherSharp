using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;

public partial class TwitchCreatePredictionBody : RefCounted, ITwitcherSharp<TwitchCreatePredictionBody>
{
    private GodotObject _data;
    public string BroadcasterId { get; set; }
    public string Title { get; set; }
    public TwitchOutcomes[] Outcomes { get; set; }
    public int PredictionWindow { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreatePredictionBody object.
    /// </summary> 
    public static TwitchCreatePredictionBody FromObject(GodotObject data)
    {
        if(data == null) return null;
        var outcomesArray = data.Get("outcomes").AsGodotArray<GodotObject>();
        return new TwitchCreatePredictionBody
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            Title = data.Get("title").AsString(),
            Outcomes = outcomesArray.Select(TwitchOutcomes.FromObject).ToArray(),
            PredictionWindow = data.Get("prediction_window").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_prediction.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        request.Set("broadcaster_id", BroadcasterId);
        request.Set("title", Title);
        request.Set("outcomes", Outcomes);
        request.Set("prediction_window", PredictionWindow);
        return request;
    }
    
    /// <summary> 
    /// The list of possible outcomes that the viewers may choose from. The list must contain a minimum of 2 choices and up to a maximum of 10 choices. 
    /// </summary>
    public partial class TwitchOutcomes : RefCounted, ITwitcherSharp<TwitchOutcomes>
    {
        private GodotObject _data;
        public string Title { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchOutcomes object.
        /// </summary> 
        public static TwitchOutcomes FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchOutcomes
            {
                Title = data.Get("title").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_outcomes.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("title", Title);
            return request;
        }
    
    }

}
