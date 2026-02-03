using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Analytics;
 
/// <summary> 
///  
/// </summary>
public partial class GetGameAnalyticsResponse : Resource, ITwitcherSharp<GetGameAnalyticsResponse>
{
    private GodotObject _data;
	public GameAnalytics[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetGameAnalyticsResponse object.
    /// </summary> 
    public static GetGameAnalyticsResponse FromObject(GodotObject data)
    {
        return new GetGameAnalyticsResponse
        {

			Data = data.Get("data").As<GameAnalytics[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_game_analytics_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
