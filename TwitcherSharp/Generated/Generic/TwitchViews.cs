using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// Describes all views-related information such as how the extension is displayed on mobile devices. 
/// </summary>
public partial class TwitchViews : Resource, ITwitcherSharp<TwitchViews>
{
    private GodotObject _data;
	public TwitchMobile Mobile { get; set; }
	public TwitchPanel Panel { get; set; }
	public TwitchVideoOverlay VideoOverlay { get; set; }
	public TwitchComponent Component { get; set; }
	public TwitchConfig Config { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchViews object.
    /// </summary> 
    public static TwitchViews FromObject(GodotObject data)
    {
		return new TwitchViews
		{
			Mobile = data.Get("mobile").As<TwitchMobile>(),
			Panel = data.Get("panel").As<TwitchPanel>(),
			VideoOverlay = data.Get("video_overlay").As<TwitchVideoOverlay>(),
			Component = data.Get("component").As<TwitchComponent>(),
			Config = data.Get("config").As<TwitchConfig>(),
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
