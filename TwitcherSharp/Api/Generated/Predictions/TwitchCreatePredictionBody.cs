using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Predictions;

public partial class TwitchCreatePredictionBody : RefCounted, ITwitcherSharp<TwitchCreatePredictionBody>
{
    private Variant _data;
    public string BroadcasterId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public TwitchBodyOutcomes[] Outcomes { get => field ??= _data.GetArray<TwitchBodyOutcomes>("outcomes")!; set; } = null!;
    public int PredictionWindow { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreatePredictionBody object.
    /// </summary> 
    public static TwitchCreatePredictionBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreatePredictionBody
        {
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            PredictionWindow = data.Read("prediction_window", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_prediction.gd", "Body");
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(Title != null) request.SetValue("title", Title);
        if(Outcomes != null) request.SetArray("outcomes", Outcomes);
        request.SetValue("prediction_window", PredictionWindow);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// The list of possible outcomes that the viewers may choose from. The list must contain a minimum of 2 choices and up to a maximum of 10 choices. 
    /// </summary>
    public partial class TwitchBodyOutcomes : RefCounted, ITwitcherSharp<TwitchBodyOutcomes>
    {
        private Variant _data;
        public string Title { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBodyOutcomes object.
        /// </summary> 
        public static TwitchBodyOutcomes? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBodyOutcomes
            {
                Title = data.Read("title", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_prediction.gd", "BodyOutcomes");
            if(Title != null) request.SetValue("title", Title);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    }

}
