using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Clips;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetClips 
/// </summary>
public partial class GetClipsOpt : Resource, ITwitcherSharp<GetClipsOpt>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public string GameId { get; set; }
	public string[] Id { get; set; }
	public string StartedAt { get; set; }
	public string EndedAt { get; set; }
	public int First { get; set; }
	public string Before { get; set; }
	public string After { get; set; }
	public bool IsFeatured { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetClipsOpt object.
    /// </summary> 
    public static GetClipsOpt FromObject(GodotObject data)
    {
        return new GetClipsOpt
        {

			BroadcasterId = data.Get("broadcaster_id").AsString(),
			GameId = data.Get("game_id").AsString(),
			Id = data.Get("id").AsStringArray(),
			StartedAt = data.Get("started_at").AsString(),
			EndedAt = data.Get("ended_at").AsString(),
			First = data.Get("first").AsInt32(),
			Before = data.Get("before").AsString(),
			After = data.Get("after").AsString(),
			IsFeatured = data.Get("is_featured").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_clips_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("game_id", GameId);
		request.Set("id", Id);
		request.Set("started_at", StartedAt);
		request.Set("ended_at", EndedAt);
		request.Set("first", First);
		request.Set("before", Before);
		request.Set("after", After);
		request.Set("is_featured", IsFeatured);
		return request;
	}
}
