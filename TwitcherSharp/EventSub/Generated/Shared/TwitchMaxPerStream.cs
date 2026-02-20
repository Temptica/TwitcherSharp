using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchMaxPerStream : Resource, ITwitcherSharpEventSub<TwitchMaxPerStream>
{
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
    public static TwitchMaxPerStream FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchMaxPerStream
        {
            IsEnabled = data.Get("is_enabled").AsBool(),
            Value = data.Get("value").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_max_per_stream.gd");
        var twitchMaxPerStreamClass = script.Get("TwitchMaxPerStream").AsGodotObject();
        var request = twitchMaxPerStreamClass.Call("new").AsGodotObject();
        request.Set("is_enabled", IsEnabled);
        request.Set("value", Value);
        return request;
    }
}
