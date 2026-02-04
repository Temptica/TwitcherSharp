using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetGames 
/// </summary>
public partial class TwitchGetGamesOpt : Resource, ITwitcherSharp<TwitchGetGamesOpt>
{
    private GodotObject _data;
	public string[] Id { get; set; }
	public string[] Name { get; set; }
	public string[] IgdbId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetGamesOpt object.
    /// </summary> 
    public static TwitchGetGamesOpt FromObject(GodotObject data)
    {
		return new TwitchGetGamesOpt
		{
			Id = data.Get("id").AsStringArray(),
			Name = data.Get("name").AsStringArray(),
			IgdbId = data.Get("igdb_id").AsStringArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_games.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("name", Name);
		request.Set("igdb_id", IgdbId);
		return request;
	}
}
