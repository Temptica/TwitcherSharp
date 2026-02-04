using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetExtensionConfigurationSegment 
/// </summary>
public partial class TwitchGetExtensionConfigurationSegmentOpt : Resource, ITwitcherSharp<TwitchGetExtensionConfigurationSegmentOpt>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetExtensionConfigurationSegmentOpt object.
    /// </summary> 
    public static TwitchGetExtensionConfigurationSegmentOpt FromObject(GodotObject data)
    {
		return new TwitchGetExtensionConfigurationSegmentOpt
		{
			BroadcasterId = data.Get("broadcaster_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_extension_configuration_segment.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		return request;
	}
}
