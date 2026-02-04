using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetBitsLeaderboard 
/// </summary>
public partial class TwitchGetBitsLeaderboardOpt : Resource, ITwitcherSharp<TwitchGetBitsLeaderboardOpt>
{
    private GodotObject _data;
	public int Count { get; set; }
	public string Period { get; set; }
	public string StartedAt { get; set; }
	public string UserId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetBitsLeaderboardOpt object.
    /// </summary> 
    public static TwitchGetBitsLeaderboardOpt FromObject(GodotObject data)
    {
		return new TwitchGetBitsLeaderboardOpt
		{
			Count = data.Get("count").AsInt32(),
			Period = data.Get("period").AsString(),
			StartedAt = data.Get("started_at").AsString(),
			UserId = data.Get("user_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_bits_leaderboard.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("count", Count);
		request.Set("period", Period);
		request.Set("started_at", StartedAt);
		request.Set("user_id", UserId);
		return request;
	}
}
