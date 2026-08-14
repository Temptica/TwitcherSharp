using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchChoices : RefCounted, ITwitcherSharpEventSub<TwitchChoices>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// ID for the choice.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// Text displayed for the choice.
    /// </summary>
    public string? Title { get; set; }

    /// <summary> 
    /// Not used; will be set to 0.
    /// </summary>
    public int BitsVotes { get; set; }

    /// <summary> 
    /// Number of votes received via Channel Points.
    /// </summary>
    public int ChannelPointsVotes { get; set; }

    /// <summary> 
    /// Total number of votes received for the choice across all methods of voting.
    /// </summary>
    public int Votes { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChoices object.
    /// </summary> 
    public static TwitchChoices? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChoices
        {
            Id = data.Get("id").AsString(),
            Title = data.Get("title").AsString(),
            BitsVotes = data.Get("bits_votes").AsInt32(),
            ChannelPointsVotes = data.Get("channel_points_votes").AsInt32(),
            Votes = data.Get("votes").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_choices.gd");
        var request = script.New().AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(Title != null) request.Set("title", Title);
        request.Set("bits_votes", BitsVotes);
        request.Set("channel_points_votes", ChannelPointsVotes);
        request.Set("votes", Votes);
        return request;
    }
}
