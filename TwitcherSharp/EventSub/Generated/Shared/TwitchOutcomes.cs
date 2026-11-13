using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchOutcomes : RefCounted, ITwitcherSharpEventSub<TwitchOutcomes>
{
    private Variant _data;
    
    /// <summary> 
    /// The outcome ID.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// The outcome title.
    /// </summary>
    public string? Title { get; set; }

    /// <summary> 
    /// The color for the outcome. Valid values are pink and blue.
    /// </summary>
    public string? Color { get; set; }

    /// <summary> 
    /// The number of users who used Channel Points on this outcome.
    /// </summary>
    public int Users { get; set; }

    /// <summary> 
    /// The total number of Channel Points used on this outcome.
    /// </summary>
    public int ChannelPoints { get; set; }

    /// <summary> 
    /// An array of users who used the most Channel Points on this outcome.
    /// </summary>
    public TwitchTopPredictors[]? TopPredictors { get => field ??= _data.GetArray<TwitchTopPredictors>("top_predictors"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchOutcomes object.
    /// </summary> 
    public static TwitchOutcomes? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchOutcomes
        {
            Id = data.ReadAsString("id"),
            Title = data.ReadAsString("title"),
            Color = data.ReadAsString("color"),
            Users = data.ReadAsInt32("users"),
            ChannelPoints = data.ReadAsInt32("channel_points"),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_outcomes.gd");
        if(Id != null) request.SetValue("id", Id);
        if(Title != null) request.SetValue("title", Title);
        if(Color != null) request.SetValue("color", Color);
        request.SetValue("users", Users);
        request.SetValue("channel_points", ChannelPoints);
        if(TopPredictors != null) request.SetArray("top_predictors", TopPredictors);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
