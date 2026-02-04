using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.CreateClipFromVod 
/// </summary>
public partial class TwitchCreateClipFromVodOpt : Resource, ITwitcherSharp<TwitchCreateClipFromVodOpt>
{
    private GodotObject _data;
	public double Duration { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchCreateClipFromVodOpt object.
    /// </summary> 
    public static TwitchCreateClipFromVodOpt FromObject(GodotObject data)
    {
		return new TwitchCreateClipFromVodOpt
		{
			Duration = data.Get("duration").AsDouble(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_clip_from_vod.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("duration", Duration);
		return request;
	}
}
