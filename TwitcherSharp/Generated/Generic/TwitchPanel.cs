using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// Describes how the extension is rendered if the extension may be activated as a panel extension. 
/// </summary>
public partial class TwitchPanel : Resource, ITwitcherSharp<TwitchPanel>
{
    private GodotObject _data;
	public string ViewerUrl { get; set; }
	public int Height { get; set; }
	public bool CanLinkExternalContent { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchPanel object.
    /// </summary> 
    public static TwitchPanel FromObject(GodotObject data)
    {
		return new TwitchPanel
		{
			ViewerUrl = data.Get("viewer_url").AsString(),
			Height = data.Get("height").AsInt32(),
			CanLinkExternalContent = data.Get("can_link_external_content").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_panel.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("viewer_url", ViewerUrl);
		request.Set("height", Height);
		request.Set("can_link_external_content", CanLinkExternalContent);
		return request;
	}
}
