using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Bits;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetBitsLeaderboardResponse : Resource, ITwitcherSharp<TwitchGetBitsLeaderboardResponse>
{
    private GodotObject _data;
	public TwitchBitsLeaderboard[] Data { get; set; }
	public TwitchDateRange DateRange { get; set; }
	public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetBitsLeaderboardResponse object.
    /// </summary> 
    public static TwitchGetBitsLeaderboardResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetBitsLeaderboardResponse
		{
			Data = dataArray.Select(TwitchBitsLeaderboard.FromObject).ToArray(),
			DateRange = data.Get("date_range").As<TwitchDateRange>(),
			Total = data.Get("total").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_bits_leaderboard.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("date_range", DateRange);
		request.Set("total", Total);
		return request;
	}
}
