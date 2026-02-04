using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCheermoteImageTheme : Resource, ITwitcherSharp<TwitchCheermoteImageTheme>
{
    private GodotObject _data;
	public TwitchAnimated Animated { get; set; }
	public TwitchStatic Static { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchCheermoteImageTheme object.
    /// </summary> 
    public static TwitchCheermoteImageTheme FromObject(GodotObject data)
    {
		return new TwitchCheermoteImageTheme
		{
			Animated = data.Get("animated").As<TwitchAnimated>(),
			Static = data.Get("static").As<TwitchStatic>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cheermote_image_theme.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("animated", Animated);
		request.Set("static", Static);
		return request;
	}
}
