using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Clips;

/// <summary> 
/// All optional parameters for TwitchAPI.GetClips 
/// </summary>
public partial class TwitchGetClipsOpt : Resource, ITwitcherSharp<TwitchGetClipsOpt>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public string GameId { get; set; }
	public string[] Id { get; set; }
	public string StartedAt { get; set; }
	public string EndedAt { get; set; }
	public int? First { get; set; }
	public string Before { get; set; }
	public string After { get; set; }
	public bool? IsFeatured { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetClipsOpt object.
    /// </summary> 
    public static TwitchGetClipsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchGetClipsOpt
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
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_clips.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
		if(GameId != null) request.Set("game_id", GameId);
		if(Id != null) request.Set("id", Id);
		if(StartedAt != null) request.Set("started_at", StartedAt);
		if(EndedAt != null) request.Set("ended_at", EndedAt);
		if(First.HasValue) request.Set("first", First.Value);
		if(Before != null) request.Set("before", Before);
		if(After != null) request.Set("after", After);
		if(IsFeatured.HasValue) request.Set("is_featured", IsFeatured.Value);
		return request;
	}

}
