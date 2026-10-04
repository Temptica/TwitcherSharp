using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchGlobalCooldown : RefCounted, ITwitcherSharpEventSub<TwitchGlobalCooldown>
{
    private Variant _data;
    
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
            IsEnabled = data.Read("is_enabled", static v => v.AsBool()),
            Seconds = data.Read("seconds", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_global_cooldown.gd");
        request.SetValue("is_enabled", IsEnabled);
        request.SetValue("seconds", Seconds);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
