using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchBitsVoting : RefCounted, ITwitcherSharpEventSub<TwitchBitsVoting>
{
    /// <summary> 
    /// Not used; will be set to false.
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary> 
    /// Not used; will be set to 0.
    /// </summary>
    public int AmountPerVote { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchBitsVoting object.
    /// </summary> 
    public static TwitchBitsVoting FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchBitsVoting
        {
            IsEnabled = data.Get("is_enabled").AsBool(),
            AmountPerVote = data.Get("amount_per_vote").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_bits_voting.gd");
        var twitchBitsVotingClass = script.Get("TwitchBitsVoting").AsGodotObject();
        var request = twitchBitsVotingClass.Call("new").AsGodotObject();
        request.Set("is_enabled", IsEnabled);
        request.Set("amount_per_vote", AmountPerVote);
        return request;
    }
}
