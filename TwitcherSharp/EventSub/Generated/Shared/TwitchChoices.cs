using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchChoices : Resource, ITwitcherSharpEventSub<TwitchChoices>
{
    /// <summary> 
    /// ID for the choice.
    /// </summary>
    public string Id { get; set; }

    /// <summary> 
    /// Text displayed for the choice.
    /// </summary>
    public string Title { get; set; }

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
    public static TwitchChoices FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChoices
        {
            Id = data.Get("id").AsString(),
            Title = data.Get("title").AsString(),
            BitsVotes = data.Get("bits_votes").AsInt32(),
            ChannelPointsVotes = data.Get("channel_points_votes").AsInt32(),
            Votes = data.Get("votes").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_choices.gd");
        var twitchChoicesClass = script.Get("TwitchChoices").AsGodotObject();
        var request = twitchChoicesClass.Call("new").AsGodotObject();
        request.Set("id", Id);
        request.Set("title", Title);
        request.Set("bits_votes", BitsVotes);
        request.Set("channel_points_votes", ChannelPointsVotes);
        request.Set("votes", Votes);
        return request;
    }
}
