using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Games;
 
/// <summary> 
///  
/// </summary>
public partial class GetGamesResponse : Resource, ITwitcherSharp<GetGamesResponse>
{
    private GodotObject _data;
	public Game[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetGamesResponse object.
    /// </summary> 
    public static GetGamesResponse FromObject(GodotObject data)
    {
        return new GetGamesResponse
        {

			Data = data.Get("data").As<Game[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_games_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
