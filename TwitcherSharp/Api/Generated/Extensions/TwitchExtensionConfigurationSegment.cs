using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchExtensionConfigurationSegment : RefCounted, ITwitcherSharp<TwitchExtensionConfigurationSegment>
{
    private GodotObject? _data;
    public string Segment { get; set; } = null!;
    public string? BroadcasterId { get; set; }
    public string Content { get; set; } = null!;
    public string Version { get; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionConfigurationSegment object.
    /// </summary> 
    public static TwitchExtensionConfigurationSegment? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchExtensionConfigurationSegment
        {
            Segment = data.Get("segment").AsString(),
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            Content = data.Get("content").AsString(),
            Version = data.Get("version").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_configuration_segment.gd");
        var request = script.Call("new").AsGodotObject();
        if(Segment != null) request.Set("segment", Segment);
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        if(Content != null) request.Set("content", Content);
        if(Version != null) request.Set("version", Version);
        return request;
    }

}
