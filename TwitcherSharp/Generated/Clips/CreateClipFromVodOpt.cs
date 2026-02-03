using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Clips;
 
/// <summary> 
/// All optional parameters for TwitchAPI.CreateClipFromVod 
/// </summary>
public partial class CreateClipFromVodOpt : Resource, ITwitcherSharp<CreateClipFromVodOpt>
{
    private GodotObject _data;
	public double Duration { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreateClipFromVodOpt object.
    /// </summary> 
    public static CreateClipFromVodOpt FromObject(GodotObject data)
    {
        return new CreateClipFromVodOpt
        {

			Duration = data.Get("duration").AsDouble(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_clip_from_vod_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("duration", Duration);
		return request;
	}
}
