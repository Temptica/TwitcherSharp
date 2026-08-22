using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchGlobalCooldown : RefCounted, ITwitcherSharpEventSub<TwitchGlobalCooldown>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// Is the setting enabled.
    /// </summary>
    public bool IsEnabled { get; set; }

    /// <summary> 
    /// The cooldown in seconds.
    /// </summary>
    public int Seconds { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGlobalCooldown object.
    /// </summary> 
    public static TwitchGlobalCooldown? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGlobalCooldown
        {
            IsEnabled = data.Get("is_enabled").AsBool(),
            Seconds = data.Get("seconds").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_global_cooldown.gd");
        var request = script.New().AsGodotObject();
        request.Set("is_enabled", IsEnabled);
        request.Set("seconds", Seconds);
        return request;
    }
}
