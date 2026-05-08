using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchGetExtensionConfigurationSegmentResponse : RefCounted, ITwitcherSharp<TwitchGetExtensionConfigurationSegmentResponse>
{
    private GodotObject _data;
    public TwitchExtensionConfigurationSegment[] Data { get => field ??= _data?.GetArray<TwitchExtensionConfigurationSegment>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionConfigurationSegmentResponse object.
    /// </summary> 
    public static TwitchGetExtensionConfigurationSegmentResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetExtensionConfigurationSegmentResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_configuration_segment.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
