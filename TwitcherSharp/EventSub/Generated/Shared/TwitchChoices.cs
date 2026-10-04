using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchChoices : RefCounted, ITwitcherSharpEventSub<TwitchChoices>
{
    private Variant _data;
    
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
            Id = data.Read("id", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            BitsVotes = data.Read("bits_votes", static v => v.AsInt32()),
            ChannelPointsVotes = data.Read("channel_points_votes", static v => v.AsInt32()),
            Votes = data.Read("votes", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_choices.gd");
        if(Id != null) request.SetValue("id", Id);
        if(Title != null) request.SetValue("title", Title);
        request.SetValue("bits_votes", BitsVotes);
        request.SetValue("channel_points_votes", ChannelPointsVotes);
        request.SetValue("votes", Votes);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
