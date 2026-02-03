using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class Light : Resource, ITwitcherSharp<Light>
{
    private GodotObject _data;
	public Animated Animated { get; set; }
	public Static Static { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Light object.
    /// </summary> 
    public static Light FromObject(GodotObject data)
    {
        return new Light
        {

			Animated = data.Get("animated").As<Animated>(),
			Static = data.Get("static").As<Static>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_light.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("animated", Animated);
		request.Set("static", Static);
		return request;
	}
}
