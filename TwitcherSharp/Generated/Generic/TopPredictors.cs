using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// A list of viewers who were the top predictors; otherwise, **null** if none. 
/// </summary>
public partial class TopPredictors : Resource, ITwitcherSharp<TopPredictors>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string UserName { get; set; }
	public string UserLogin { get; set; }
	public int ChannelPointsUsed { get; set; }
	public int ChannelPointsWon { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TopPredictors object.
    /// </summary> 
    public static TopPredictors FromObject(GodotObject data)
    {
        return new TopPredictors
        {

			UserId = data.Get("user_id").AsString(),
			UserName = data.Get("user_name").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			ChannelPointsUsed = data.Get("channel_points_used").AsInt32(),
			ChannelPointsWon = data.Get("channel_points_won").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_top_predictors.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("user_name", UserName);
		request.Set("user_login", UserLogin);
		request.Set("channel_points_used", ChannelPointsUsed);
		request.Set("channel_points_won", ChannelPointsWon);
		return request;
	}
}
