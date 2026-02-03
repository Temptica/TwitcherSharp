using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Games;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetGames 
/// </summary>
public partial class GetGamesOpt : Resource, ITwitcherSharp<GetGamesOpt>
{
    private GodotObject _data;
	public string[] Id { get; set; }
	public string[] Name { get; set; }
	public string[] IgdbId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetGamesOpt object.
    /// </summary> 
    public static GetGamesOpt FromObject(GodotObject data)
    {
        return new GetGamesOpt
        {

			Id = data.Get("id").AsStringArray(),
			Name = data.Get("name").AsStringArray(),
			IgdbId = data.Get("igdb_id").AsStringArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_games_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("name", Name);
		request.Set("igdb_id", IgdbId);
		return request;
	}
}
