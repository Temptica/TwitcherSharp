using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchExtensionConfigurationSegment : RefCounted, ITwitcherSharp<TwitchExtensionConfigurationSegment>
{
    private Variant _data;
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
            Segment = data.Read("segment", static v => v.AsString()),
            BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
            Content = data.Read("content", static v => v.AsString()),
            Version = data.Read("version", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewObject("res://addons/twitcher/generated/twitch_extension_configuration_segment.gd");
        if(Segment != null) request.SetValue("segment", Segment);
        if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
        if(Content != null) request.SetValue("content", Content);
        if(Version != null) request.SetValue("version", Version);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
