using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Games;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetTopGames 
/// </summary>
public partial class GetTopGamesOpt : Resource, ITwitcherSharp<GetTopGamesOpt>
{
    private GodotObject _data;
	public int First { get; set; }
	public string After { get; set; }
	public string Before { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetTopGamesOpt object.
    /// </summary> 
    public static GetTopGamesOpt FromObject(GodotObject data)
    {
        return new GetTopGamesOpt
        {

			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
			Before = data.Get("before").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_top_games_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("first", First);
		request.Set("after", After);
		request.Set("before", Before);
		return request;
	}
}
