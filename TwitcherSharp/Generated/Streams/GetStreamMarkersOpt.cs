using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Streams;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetStreamMarkers 
/// </summary>
public partial class GetStreamMarkersOpt : Resource, ITwitcherSharp<GetStreamMarkersOpt>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string VideoId { get; set; }
	public string First { get; set; }
	public string Before { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetStreamMarkersOpt object.
    /// </summary> 
    public static GetStreamMarkersOpt FromObject(GodotObject data)
    {
        return new GetStreamMarkersOpt
        {

			UserId = data.Get("user_id").AsString(),
			VideoId = data.Get("video_id").AsString(),
			First = data.Get("first").AsString(),
			Before = data.Get("before").AsString(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_stream_markers_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("video_id", VideoId);
		request.Set("first", First);
		request.Set("before", Before);
		request.Set("after", After);
		return request;
	}
}
