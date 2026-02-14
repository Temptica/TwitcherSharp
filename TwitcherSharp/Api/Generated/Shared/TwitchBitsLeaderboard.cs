using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchBitsLeaderboard : Resource, ITwitcherSharp<TwitchBitsLeaderboard>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string UserLogin { get; set; }
	public string UserName { get; set; }
	public int Rank { get; set; }
	public int Score { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchBitsLeaderboard object.
    /// </summary> 
    public static TwitchBitsLeaderboard FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchBitsLeaderboard
		{
			UserId = data.Get("user_id").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			UserName = data.Get("user_name").AsString(),
			Rank = data.Get("rank").AsInt32(),
			Score = data.Get("score").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_bits_leaderboard.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("user_login", UserLogin);
		request.Set("user_name", UserName);
		request.Set("rank", Rank);
		request.Set("score", Score);
		return request;
	}
}
