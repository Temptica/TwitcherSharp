using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetExtensionConfigurationSegmentResponse : Resource, ITwitcherSharp<TwitchGetExtensionConfigurationSegmentResponse>
{
    private GodotObject _data;
	public TwitchExtensionConfigurationSegment[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionConfigurationSegmentResponse object.
    /// </summary> 
    public static TwitchGetExtensionConfigurationSegmentResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetExtensionConfigurationSegmentResponse
		{
			Data = dataArray.Select(TwitchExtensionConfigurationSegment.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_configuration_segment.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
