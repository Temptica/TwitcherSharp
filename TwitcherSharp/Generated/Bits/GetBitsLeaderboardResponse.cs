using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Bits;
 
/// <summary> 
///  
/// </summary>
public partial class GetBitsLeaderboardResponse : Resource, ITwitcherSharp<GetBitsLeaderboardResponse>
{
    private GodotObject _data;
	public BitsLeaderboard[] Data { get; set; }
	public DateRange DateRange { get; set; }
	public int Total { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetBitsLeaderboardResponse object.
    /// </summary> 
    public static GetBitsLeaderboardResponse FromObject(GodotObject data)
    {
        return new GetBitsLeaderboardResponse
        {

			Data = data.Get("data").As<BitsLeaderboard[]>(),
			DateRange = data.Get("date_range").As<DateRange>(),
			Total = data.Get("total").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_bits_leaderboard_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("date_range", DateRange);
		request.Set("total", Total);
		return request;
	}
}
