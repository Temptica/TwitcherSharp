using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchEmotes : RefCounted, ITwitcherSharpEventSub<TwitchEmotes>
{
    private Variant _data;
    
    /// <summary> 
    /// The index of where the Emote starts in the text.
    /// </summary>
    public int Begin { get; set; }

    /// <summary> 
    /// The index of where the Emote ends in the text.
    /// </summary>
    public int End { get; set; }

    /// <summary> 
    /// The emote ID.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchEmotes object.
    /// </summary> 
    public static TwitchEmotes? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchEmotes
        {
            Begin = data.Read("begin", static v => v.AsInt32()),
            End = data.Read("end", static v => v.AsInt32()),
            Id = data.Read("id", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_emotes.gd");
        request.SetValue("begin", Begin);
        request.SetValue("end", End);
        if(Id != null) request.SetValue("id", Id);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
