using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchLight : Resource, ITwitcherSharp<TwitchLight>
{
    private GodotObject _data;
	public TwitchAnimated Animated { get; set; }
	public TwitchStatic Static { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchLight object.
    /// </summary> 
    public static TwitchLight FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchLight
		{
			Animated = data.Get("animated").As<TwitchAnimated>(),
			Static = data.Get("static").As<TwitchStatic>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_light.gd");
		var request = script.Call("new").AsGodotObject();
		if(Animated != null) request.Set("animated", Animated);
		if(Static != null) request.Set("static", Static);
		return request;
	}
}
