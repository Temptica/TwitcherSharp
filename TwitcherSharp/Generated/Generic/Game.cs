using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class Game : Resource, ITwitcherSharp<Game>
{
    private GodotObject _data;
	public string Id { get; set; }
	public string Name { get; set; }
	public string BoxArtUrl { get; set; }
	public string IgdbId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Game object.
    /// </summary> 
    public static Game FromObject(GodotObject data)
    {
        return new Game
        {

			Id = data.Get("id").AsString(),
			Name = data.Get("name").AsString(),
			BoxArtUrl = data.Get("box_art_url").AsString(),
			IgdbId = data.Get("igdb_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_game.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("name", Name);
		request.Set("box_art_url", BoxArtUrl);
		request.Set("igdb_id", IgdbId);
		return request;
	}
}
