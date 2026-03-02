using TwitcherSharp.Api.Generated.Shared;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Games;

public partial class TwitchGetTopGamesResponse : Resource, ITwitcherSharp<TwitchGetTopGamesResponse>
{
    private GodotObject _data;
    public TwitchGame[] Data { get; set; }
    public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetTopGamesResponse object.
    /// </summary> 
    public static TwitchGetTopGamesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetTopGamesResponse
        {
            Data = dataArray.Select(TwitchGame.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<TwitchPagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_top_games.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }

}
