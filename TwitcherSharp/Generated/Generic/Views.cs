using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// Describes all views-related information such as how the extension is displayed on mobile devices. 
/// </summary>
public partial class Views : Resource, ITwitcherSharp<Views>
{
    private GodotObject _data;
	public Mobile Mobile { get; set; }
	public Panel Panel { get; set; }
	public VideoOverlay VideoOverlay { get; set; }
	public Component Component { get; set; }
	public Config Config { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Views object.
    /// </summary> 
    public static Views FromObject(GodotObject data)
    {
        return new Views
        {

			Mobile = data.Get("mobile").As<Mobile>(),
			Panel = data.Get("panel").As<Panel>(),
			VideoOverlay = data.Get("video_overlay").As<VideoOverlay>(),
			Component = data.Get("component").As<Component>(),
			Config = data.Get("config").As<Config>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_views.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("mobile", Mobile);
		request.Set("panel", Panel);
		request.Set("video_overlay", VideoOverlay);
		request.Set("component", Component);
		request.Set("config", Config);
		return request;
	}
}
