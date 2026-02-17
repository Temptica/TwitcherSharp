using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Streams;

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
        if(data == null) return null;
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
		if(UserId != null) request.Set("user_id", UserId);
		if(VideoId != null) request.Set("video_id", VideoId);
		if(First != null) request.Set("first", First);
		if(Before != null) request.Set("before", Before);
		if(After != null) request.Set("after", After);
		return request;
	}

}
