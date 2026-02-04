using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetTopGames 
/// </summary>
public partial class TwitchGetTopGamesOpt : Resource, ITwitcherSharp<TwitchGetTopGamesOpt>
{
    private GodotObject _data;
	public int First { get; set; }
	public string After { get; set; }
	public string Before { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetTopGamesOpt object.
    /// </summary> 
    public static TwitchGetTopGamesOpt FromObject(GodotObject data)
    {
		return new TwitchGetTopGamesOpt
		{
			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
			Before = data.Get("before").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_top_games.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("first", First);
		request.Set("after", After);
		request.Set("before", Before);
		return request;
	}
}
