using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class Dark : Resource, ITwitcherSharp<Dark>
{
    private GodotObject _data;
	public Animated Animated { get; set; }
	public Static Static { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Dark object.
    /// </summary> 
    public static Dark FromObject(GodotObject data)
    {
        return new Dark
        {

			Animated = data.Get("animated").As<Animated>(),
			Static = data.Get("static").As<Static>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_dark.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("animated", Animated);
		request.Set("static", Static);
		return request;
	}
}
