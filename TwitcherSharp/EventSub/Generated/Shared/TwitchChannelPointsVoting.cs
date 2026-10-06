using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchChannelPointsVoting : RefCounted, ITwitcherSharpEventSub<TwitchChannelPointsVoting>
{
    private Variant _data;
    
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
    public static TwitchChannelPointsVoting? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelPointsVoting
        {
            IsEnabled = data.Read("is_enabled", static v => v.AsBool()),
            AmountPerVote = data.Read("amount_per_vote", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_channel_points_voting.gd");
        request.SetValue("is_enabled", IsEnabled);
        request.SetValue("amount_per_vote", AmountPerVote);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
