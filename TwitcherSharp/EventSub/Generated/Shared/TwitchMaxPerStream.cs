using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchMaxPerStream : RefCounted, ITwitcherSharpEventSub<TwitchMaxPerStream>
{
    private Variant _data;
    
    /// <summary> 
    /// Is the setting enabled.
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary> 
    /// The max per stream limit.
    /// </summary>
    public int Value { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchMaxPerStream object.
    /// </summary> 
    public static TwitchMaxPerStream? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchMaxPerStream
        {
            IsEnabled = data.Read("is_enabled", static v => v.AsBool()),
            Value = data.Read("value", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_max_per_stream.gd");
        request.SetValue("is_enabled", IsEnabled);
        request.SetValue("value", Value);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
