using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchEmotes : RefCounted, ITwitcherSharpEventSub<TwitchEmotes>
{
    private GodotObject? _data;
    
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
            Begin = data.Get("begin").AsInt32(),
            End = data.Get("end").AsInt32(),
            Id = data.Get("id").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_emotes.gd");
        var request = script.New().AsGodotObject();
        request.Set("begin", Begin);
        request.Set("end", End);
        if(Id != null) request.Set("id", Id);
        return request;
    }
}
