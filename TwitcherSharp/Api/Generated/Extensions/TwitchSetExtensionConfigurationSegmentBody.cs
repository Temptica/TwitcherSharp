using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchSetExtensionConfigurationSegmentBody : RefCounted, ITwitcherSharp<TwitchSetExtensionConfigurationSegmentBody>
{
    private GodotObject? _data;
    public string? ExtensionId { get; set; }
    public string? Segment { get; set; }
    public string? BroadcasterId { get; set; }
    public string? Content { get; set; }
    public string? Version { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchSetExtensionConfigurationSegmentBody object.
    /// </summary> 
    public static TwitchSetExtensionConfigurationSegmentBody? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchSetExtensionConfigurationSegmentBody
        {
            ExtensionId = data.Get("extension_id").AsString(),
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
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_set_extension_configuration_segment.gd");
        var bodyClass = script.Get("Body").AsGodotObject();
        var request = bodyClass.Call("new").AsGodotObject();
        if(ExtensionId != null) request.Set("extension_id", ExtensionId);
        if(Segment != null) request.Set("segment", Segment);
        if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
        if(Content != null) request.Set("content", Content);
        if(Version != null) request.Set("version", Version);
        return request;
    }

}
