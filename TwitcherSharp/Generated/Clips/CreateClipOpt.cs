using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Clips;
 
/// <summary> 
/// All optional parameters for TwitchAPI.CreateClip 
/// </summary>
public partial class CreateClipOpt : Resource, ITwitcherSharp<CreateClipOpt>
{
    private GodotObject _data;
	public string Title { get; set; }
	public double Duration { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreateClipOpt object.
    /// </summary> 
    public static CreateClipOpt FromObject(GodotObject data)
    {
        return new CreateClipOpt
        {

			Title = data.Get("title").AsString(),
			Duration = data.Get("duration").AsDouble(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_clip_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("title", Title);
		request.Set("duration", Duration);
		return request;
	}
}
