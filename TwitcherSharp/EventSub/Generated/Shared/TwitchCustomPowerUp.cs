using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchCustomPowerUp : RefCounted, ITwitcherSharpEventSub<TwitchCustomPowerUp>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The unique ID for this Custom Power-up.
    /// </summary>
    public string? Id { get; set; }

    /// <summary> 
    /// The user-viewable name of this Custom Power-up.
    /// </summary>
    public string? Title { get; set; }

    /// <summary> 
    /// The cost of the Custom Power-up to redeem.
    /// </summary>
    public int Bits { get; set; }

    /// <summary> 
    /// The creator-provided description for this Power-up.
    /// </summary>
    public string? Prompt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCustomPowerUp object.
    /// </summary> 
    public static TwitchCustomPowerUp? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCustomPowerUp
        {
            Id = data.Get("id").AsString(),
            Title = data.Get("title").AsString(),
            Bits = data.Get("bits").AsInt32(),
            Prompt = data.Get("prompt").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_custom_power_up.gd");
        var request = script.New().AsGodotObject();
        if(Id != null) request.Set("id", Id);
        if(Title != null) request.Set("title", Title);
        request.Set("bits", Bits);
        if(Prompt != null) request.Set("prompt", Prompt);
        return request;
    }
}
