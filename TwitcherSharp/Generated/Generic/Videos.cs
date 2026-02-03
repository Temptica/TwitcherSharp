using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// A list of videos that contain markers. The list contains a single video. 
/// </summary>
public partial class Videos : Resource, ITwitcherSharp<Videos>
{
    private GodotObject _data;
	public string VideoId { get; set; }
	public Markers[] Markers { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Videos object.
    /// </summary> 
    public static Videos FromObject(GodotObject data)
    {
        return new Videos
        {

			VideoId = data.Get("video_id").AsString(),
			Markers = data.Get("markers").As<Markers[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_videos.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("video_id", VideoId);
		request.Set("markers", Markers);
		return request;
	}
}
