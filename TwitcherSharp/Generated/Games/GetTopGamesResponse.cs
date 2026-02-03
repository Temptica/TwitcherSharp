using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Games;
 
/// <summary> 
///  
/// </summary>
public partial class GetTopGamesResponse : Resource, ITwitcherSharp<GetTopGamesResponse>
{
    private GodotObject _data;
	public Game[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetTopGamesResponse object.
    /// </summary> 
    public static GetTopGamesResponse FromObject(GodotObject data)
    {
        return new GetTopGamesResponse
        {

			Data = data.Get("data").As<Game[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_top_games_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
