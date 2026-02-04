using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetStreamMarkers 
/// </summary>
public partial class TwitchGetStreamMarkersOpt : Resource, ITwitcherSharp<TwitchGetStreamMarkersOpt>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string VideoId { get; set; }
	public string First { get; set; }
	public string Before { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetStreamMarkersOpt object.
    /// </summary> 
    public static TwitchGetStreamMarkersOpt FromObject(GodotObject data)
    {
		return new TwitchGetStreamMarkersOpt
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
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_stream_markers.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("video_id", VideoId);
		request.Set("first", First);
		request.Set("before", Before);
		request.Set("after", After);
		return request;
	}
}
