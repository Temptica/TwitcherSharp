using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensionConfigurationSegment 
/// </summary>
public partial class GetExtensionConfigurationSegmentOpt : Resource, ITwitcherSharp<GetExtensionConfigurationSegmentOpt>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetExtensionConfigurationSegmentOpt object.
    /// </summary> 
    public static GetExtensionConfigurationSegmentOpt FromObject(GodotObject data)
    {
        return new GetExtensionConfigurationSegmentOpt
        {

			BroadcasterId = data.Get("broadcaster_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_configuration_segment_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		return request;
	}
}
