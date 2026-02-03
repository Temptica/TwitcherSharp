using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class GameAnalytics : Resource, ITwitcherSharp<GameAnalytics>
{
    private GodotObject _data;
	public string GameId { get; set; }
	public string URL { get; set; }
	public string Type { get; set; }
	public DateRange DateRange { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GameAnalytics object.
    /// </summary> 
    public static GameAnalytics FromObject(GodotObject data)
    {
        return new GameAnalytics
        {

			GameId = data.Get("game_id").AsString(),
			URL = data.Get("u_r_l").AsString(),
			Type = data.Get("type").AsString(),
			DateRange = data.Get("date_range").As<DateRange>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_game_analytics.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("game_id", GameId);
		request.Set("u_r_l", URL);
		request.Set("type", Type);
		request.Set("date_range", DateRange);
		return request;
	}
}
