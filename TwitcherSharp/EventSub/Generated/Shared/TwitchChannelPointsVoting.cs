using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchChannelPointsVoting : RefCounted, ITwitcherSharpEventSub<TwitchChannelPointsVoting>
{
    /// <summary> 
    /// Indicates if Channel Points can be used for voting.
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary> 
    /// Number of Channel Points required to vote once with Channel Points.
    /// </summary>
    public int AmountPerVote { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelPointsVoting object.
    /// </summary> 
    public static TwitchChannelPointsVoting FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelPointsVoting
        {
            IsEnabled = data.Get("is_enabled").AsBool(),
            AmountPerVote = data.Get("amount_per_vote").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_voting.gd");
        var twitchChannelPointsVotingClass = script.Get("TwitchChannelPointsVoting").AsGodotObject();
        var request = twitchChannelPointsVotingClass.Call("new").AsGodotObject();
        request.Set("is_enabled", IsEnabled);
        request.Set("amount_per_vote", AmountPerVote);
        return request;
    }
}
