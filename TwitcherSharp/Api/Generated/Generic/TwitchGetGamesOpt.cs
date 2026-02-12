using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
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
        if(data == null) return null;
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
		if(Id != null) request.Set("id", Id);
		if(Name != null) request.Set("name", Name);
		if(IgdbId != null) request.Set("igdb_id", IgdbId);
		return request;
	}
}
