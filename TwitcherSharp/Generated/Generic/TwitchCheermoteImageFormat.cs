using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCheermoteImageFormat : Resource, ITwitcherSharp<TwitchCheermoteImageFormat>
{
    private GodotObject _data;
	public string _1 { get; set; }
	public string _2 { get; set; }
	public string _3 { get; set; }
	public string _4 { get; set; }
	public string _1_5 { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchCheermoteImageFormat object.
    /// </summary> 
    public static TwitchCheermoteImageFormat FromObject(GodotObject data)
    {
		return new TwitchCheermoteImageFormat
		{
			_1 = data.Get("__1").AsString(),
			_2 = data.Get("__2").AsString(),
			_3 = data.Get("__3").AsString(),
			_4 = data.Get("__4").AsString(),
			_1_5 = data.Get("__1___5").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cheermote_image_format.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("__1", _1);
		request.Set("__2", _2);
		request.Set("__3", _3);
		request.Set("__4", _4);
		request.Set("__1___5", _1_5);
		return request;
	}
}
