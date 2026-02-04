using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.CreateClip 
/// </summary>
public partial class TwitchCreateClipOpt : Resource, ITwitcherSharp<TwitchCreateClipOpt>
{
    private GodotObject _data;
	public string Title { get; set; }
	public double Duration { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchCreateClipOpt object.
    /// </summary> 
    public static TwitchCreateClipOpt FromObject(GodotObject data)
    {
		return new TwitchCreateClipOpt
		{
			Title = data.Get("title").AsString(),
			Duration = data.Get("duration").AsDouble(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_clip.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("title", Title);
		request.Set("duration", Duration);
		return request;
	}
}
