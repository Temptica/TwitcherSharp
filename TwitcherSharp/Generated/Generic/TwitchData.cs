using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// The extensions that the broadcaster updated. 
/// </summary>
public partial class TwitchData : Resource, ITwitcherSharp<TwitchData>
{
    private GodotObject _data;
	public Variant Panel { get; set; }
	public Variant Overlay { get; set; }
	public Variant Component { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchData object.
    /// </summary> 
    public static TwitchData FromObject(GodotObject data)
    {
		return new TwitchData
		{
			Panel = data.Get("panel").As<Variant>(),
			Overlay = data.Get("overlay").As<Variant>(),
			Component = data.Get("component").As<Variant>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("panel", Panel);
		request.Set("overlay", Overlay);
		request.Set("component", Component);
		return request;
	}
}
