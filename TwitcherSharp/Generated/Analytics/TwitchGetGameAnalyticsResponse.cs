using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Analytics;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetGameAnalyticsResponse : Resource, ITwitcherSharp<TwitchGetGameAnalyticsResponse>
{
    private GodotObject _data;
	public TwitchGameAnalytics[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetGameAnalyticsResponse object.
    /// </summary> 
    public static TwitchGetGameAnalyticsResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetGameAnalyticsResponse
		{
			Data = dataArray.Select(TwitchGameAnalytics.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_game_analytics.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
