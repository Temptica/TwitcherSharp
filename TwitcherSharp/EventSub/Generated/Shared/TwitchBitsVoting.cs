using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchBitsVoting : RefCounted, ITwitcherSharpEventSub<TwitchBitsVoting>
{
    private Variant _data;
    
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
    public static TwitchBitsVoting? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchBitsVoting
        {
            IsEnabled = data.Read("is_enabled", static v => v.AsBool()),
            AmountPerVote = data.Read("amount_per_vote", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_bits_voting.gd");
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
