using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchGetExtensionConfigurationSegmentResponse : RefCounted, ITwitcherSharp<TwitchGetExtensionConfigurationSegmentResponse>
{
    private Variant _data;
    public TwitchExtensionConfigurationSegment[] Data { get => field ??= _data.GetArray<TwitchExtensionConfigurationSegment>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionConfigurationSegmentResponse object.
    /// </summary> 
    public static TwitchGetExtensionConfigurationSegmentResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetExtensionConfigurationSegmentResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_extension_configuration_segment.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
