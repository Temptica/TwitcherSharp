using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchSetExtensionConfigurationSegmentBody : RefCounted, ITwitcherSharp<TwitchSetExtensionConfigurationSegmentBody>
{
    private Variant _data;
    public string ExtensionId { get; set; } = null!;
    public string Segment { get; set; } = null!;
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
            ExtensionId = data.Read("extension_id", static v => v.AsString()),
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
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_set_extension_configuration_segment.gd", "Body");
        if(ExtensionId != null) request.SetValue("extension_id", ExtensionId);
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
