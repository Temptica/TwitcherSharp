using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// Describes how the extension is displayed on mobile devices. 
/// </summary>
public partial class Mobile : Resource, ITwitcherSharp<Mobile>
{
    private GodotObject _data;
	public string ViewerUrl { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Mobile object.
    /// </summary> 
    public static Mobile FromObject(GodotObject data)
    {
        return new Mobile
        {

			ViewerUrl = data.Get("viewer_url").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_mobile.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("viewer_url", ViewerUrl);
		return request;
	}
}
