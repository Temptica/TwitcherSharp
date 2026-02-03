using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class ExtensionConfigurationSegment : Resource, ITwitcherSharp<ExtensionConfigurationSegment>
{
    private GodotObject _data;
	public string Segment { get; set; }
	public string BroadcasterId { get; set; }
	public string Content { get; set; }
	public string Version { get; set; }
    /// <summary> 
    /// Transforms the godot data into a ExtensionConfigurationSegment object.
    /// </summary> 
    public static ExtensionConfigurationSegment FromObject(GodotObject data)
    {
        return new ExtensionConfigurationSegment
        {

			Segment = data.Get("segment").AsString(),
			BroadcasterId = data.Get("broadcaster_id").AsString(),
			Content = data.Get("content").AsString(),
			Version = data.Get("version").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_configuration_segment.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("segment", Segment);
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("content", Content);
		request.Set("version", Version);
		return request;
	}
}
