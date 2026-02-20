using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Games;


/// <summary> 
/// All optional parameters for TwitchAPI.GetTopGames 
/// </summary>
public partial class TwitchGetTopGamesOpt : Resource, ITwitcherSharp<TwitchGetTopGamesOpt>
{
    private GodotObject _data;
	public int? First { get; set; }
	public string After { get; set; }
	public string Before { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetTopGamesOpt object.
    /// </summary> 
    public static TwitchGetTopGamesOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
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
		if(First.HasValue) request.Set("first", First.Value);
		if(After != null) request.Set("after", After);
		if(Before != null) request.Set("before", Before);
		return request;
	}

}
