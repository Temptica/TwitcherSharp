using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.Shared;

public partial class TwitchCustomPowerUp : RefCounted, ITwitcherSharpEventSub<TwitchCustomPowerUp>
{
    private Variant _data;
    
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
            Id = data.Read("id", static v => v.AsString()),
            Title = data.Read("title", static v => v.AsString()),
            Bits = data.Read("bits", static v => v.AsInt32()),
            Prompt = data.Read("prompt", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated_eventsub/twitch_es_custom_power_up.gd");
        if(Id != null) request.SetValue("id", Id);
        if(Title != null) request.SetValue("title", Title);
        request.SetValue("bits", Bits);
        if(Prompt != null) request.SetValue("prompt", Prompt);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}
