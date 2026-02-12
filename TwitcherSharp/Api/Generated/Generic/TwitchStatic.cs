using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchStatic : Resource, ITwitcherSharp<TwitchStatic>
{
    private GodotObject _data;
	public string _1 { get; set; }
	public string _2 { get; set; }
	public string _3 { get; set; }
	public string _4 { get; set; }
	public string _1_5 { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchStatic object.
    /// </summary> 
    public static TwitchStatic FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchStatic
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
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_static.gd");
		var request = script.Call("new").AsGodotObject();
		if(_1 != null) request.Set("__1", _1);
		if(_2 != null) request.Set("__2", _2);
		if(_3 != null) request.Set("__3", _3);
		if(_4 != null) request.Set("__4", _4);
		if(_1_5 != null) request.Set("__1___5", _1_5);
		return request;
	}
}
