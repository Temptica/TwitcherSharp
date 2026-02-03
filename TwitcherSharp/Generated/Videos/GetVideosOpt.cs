using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Videos;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetVideos 
/// </summary>
public partial class GetVideosOpt : Resource, ITwitcherSharp<GetVideosOpt>
{
    private GodotObject _data;
	public string[] Id { get; set; }
	public string UserId { get; set; }
	public string GameId { get; set; }
	public string Language { get; set; }
	public string Period { get; set; }
	public string Sort { get; set; }
	public string Type { get; set; }
	public string First { get; set; }
	public string After { get; set; }
	public string Before { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetVideosOpt object.
    /// </summary> 
    public static GetVideosOpt FromObject(GodotObject data)
    {
        return new GetVideosOpt
        {

			Id = data.Get("id").AsStringArray(),
			UserId = data.Get("user_id").AsString(),
			GameId = data.Get("game_id").AsString(),
			Language = data.Get("language").AsString(),
			Period = data.Get("period").AsString(),
			Sort = data.Get("sort").AsString(),
			Type = data.Get("type").AsString(),
			First = data.Get("first").AsString(),
			After = data.Get("after").AsString(),
			Before = data.Get("before").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_videos_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("user_id", UserId);
		request.Set("game_id", GameId);
		request.Set("language", Language);
		request.Set("period", Period);
		request.Set("sort", Sort);
		request.Set("type", Type);
		request.Set("first", First);
		request.Set("after", After);
		request.Set("before", Before);
		return request;
	}
}
