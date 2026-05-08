using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchOutcomes : RefCounted, ITwitcherSharpEventSub<TwitchOutcomes>
{
    private GodotObject _data;
    
    /// <summary> 
    /// The outcome ID.
    /// </summary>
    public string Id { get; set; }

    /// <summary> 
    /// The outcome title.
    /// </summary>
    public string Title { get; set; }

    /// <summary> 
    /// The color for the outcome. Valid values are pink and blue.
    /// </summary>
    public string Color { get; set; }

    /// <summary> 
    /// The number of users who used Channel Points on this outcome.
    /// </summary>
    public int Users { get; set; }

    /// <summary> 
    /// The total number of Channel Points used on this outcome.
    /// </summary>
    public int ChannelPoints { get; set; }

    /// <summary> 
    /// An array of up to 10 objects that describe users who participated in a Channel Points Prediction.
    /// </summary>
    public TwitchTopPredictors TopPredictors { get => field ??= _data?.Get<TwitchTopPredictors>("top_predictors"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchOutcomes object.
    /// </summary> 
    public static TwitchOutcomes FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchOutcomes
        {
            Id = data.Get("id").AsString(),
            Title = data.Get("title").AsString(),
            Color = data.Get("color").AsString(),
            Users = data.Get("users").AsInt32(),
            ChannelPoints = data.Get("channel_points").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_outcomes.gd");
        var request = script.New().AsGodotObject();
        request.Set("id", Id);
        request.Set("title", Title);
        request.Set("color", Color);
        request.Set("users", Users);
        request.Set("channel_points", ChannelPoints);
        request.Set("top_predictors", TopPredictors?.ToGodotObject());
        return request;
    }
}
