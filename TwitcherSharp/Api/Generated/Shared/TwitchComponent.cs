using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
/// Describes how the extension is rendered if the extension may be activated as a video-component extension. 
/// </summary>
public partial class TwitchComponent : Resource, ITwitcherSharp<TwitchComponent>
{
    private GodotObject _data;
	public string ViewerUrl { get; set; }
	public int AspectRatioX { get; set; }
	public int AspectRatioY { get; set; }
	public bool Autoscale { get; set; }
	public int ScalePixels { get; set; }
	public int TargetHeight { get; set; }
	public bool CanLinkExternalContent { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchComponent object.
    /// </summary> 
    public static TwitchComponent FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchComponent
		{
			ViewerUrl = data.Get("viewer_url").AsString(),
			AspectRatioX = data.Get("aspect_ratio_x").AsInt32(),
			AspectRatioY = data.Get("aspect_ratio_y").AsInt32(),
			Autoscale = data.Get("autoscale").AsBool(),
			ScalePixels = data.Get("scale_pixels").AsInt32(),
			TargetHeight = data.Get("target_height").AsInt32(),
			CanLinkExternalContent = data.Get("can_link_external_content").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_component.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("viewer_url", ViewerUrl);
		request.Set("aspect_ratio_x", AspectRatioX);
		request.Set("aspect_ratio_y", AspectRatioY);
		request.Set("autoscale", Autoscale);
		request.Set("scale_pixels", ScalePixels);
		request.Set("target_height", TargetHeight);
		request.Set("can_link_external_content", CanLinkExternalContent);
		return request;
	}
}
