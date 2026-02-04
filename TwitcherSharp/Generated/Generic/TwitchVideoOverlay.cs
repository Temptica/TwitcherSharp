using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// Describes how the extension is rendered if the extension may be activated as a video-overlay extension. 
/// </summary>
public partial class TwitchVideoOverlay : Resource, ITwitcherSharp<TwitchVideoOverlay>
{
    private GodotObject _data;
	public string ViewerUrl { get; set; }
	public bool CanLinkExternalContent { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchVideoOverlay object.
    /// </summary> 
    public static TwitchVideoOverlay FromObject(GodotObject data)
    {
		return new TwitchVideoOverlay
		{
			ViewerUrl = data.Get("viewer_url").AsString(),
			CanLinkExternalContent = data.Get("can_link_external_content").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_video_overlay.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("viewer_url", ViewerUrl);
		request.Set("can_link_external_content", CanLinkExternalContent);
		return request;
	}
}
