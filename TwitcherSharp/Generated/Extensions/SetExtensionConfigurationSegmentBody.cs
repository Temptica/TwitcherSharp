using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Extensions;
 
/// <summary> 
///  
/// </summary>
public partial class SetExtensionConfigurationSegmentBody : Resource, ITwitcherSharp<SetExtensionConfigurationSegmentBody>
{
    private GodotObject _data;
	public string ExtensionId { get; set; }
	public string Segment { get; set; }
	public string BroadcasterId { get; set; }
	public string Content { get; set; }
	public string Version { get; set; }
    /// <summary> 
    /// Transforms the godot data into a SetExtensionConfigurationSegmentBody object.
    /// </summary> 
    public static SetExtensionConfigurationSegmentBody FromObject(GodotObject data)
    {
        return new SetExtensionConfigurationSegmentBody
        {

			ExtensionId = data.Get("extension_id").AsString(),
			Segment = data.Get("segment").AsString(),
			BroadcasterId = data.Get("broadcaster_id").AsString(),
			Content = data.Get("content").AsString(),
			Version = data.Get("version").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_set_extension_configuration_segment_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("extension_id", ExtensionId);
		request.Set("segment", Segment);
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("content", Content);
		request.Set("version", Version);
		return request;
	}
}
