using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;


/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensionConfigurationSegment 
/// </summary>
public partial class TwitchGetExtensionConfigurationSegmentOpt : RefCounted, ITwitcherSharp<TwitchGetExtensionConfigurationSegmentOpt>
{
    private GodotObject? _data;
    public string? BroadcasterId { get; set; }
    public string[]? Segment { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionConfigurationSegmentOpt object.
    /// </summary> 
    public static TwitchGetExtensionConfigurationSegmentOpt? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetExtensionConfigurationSegmentOpt
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            Segment = data.Get("segment").AsStringArray(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_configuration_segment.gd");
        var optClass = script.Get("Opt").AsGodotObject();
        var request = optClass.Call("new").AsGodotObject();
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        if(Segment != null) request.Set("segment", new Godot.Collections.Array<string>(Segment));
        return request;
    }

}
