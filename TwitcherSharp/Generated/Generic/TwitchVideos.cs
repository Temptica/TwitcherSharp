using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// A list of videos that contain markers. The list contains a single video. 
/// </summary>
public partial class TwitchVideos : Resource, ITwitcherSharp<TwitchVideos>
{
    private GodotObject _data;
	public string VideoId { get; set; }
	public TwitchMarkers[] Markers { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchVideos object.
    /// </summary> 
    public static TwitchVideos FromObject(GodotObject data)
    {
		var markersArray = data.Get("markers").AsGodotArray<GodotObject>();
		return new TwitchVideos
		{
			VideoId = data.Get("video_id").AsString(),
			Markers = markersArray.Select(TwitchMarkers.FromObject).ToArray(),
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
