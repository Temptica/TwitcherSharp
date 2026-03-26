using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Games;

public partial class TwitchGetGamesResponse : RefCounted, ITwitcherSharp<TwitchGetGamesResponse>
{
    private GodotObject _data;
    public TwitchGame[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGamesResponse object.
    /// </summary> 
    public static TwitchGetGamesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetGamesResponse
        {
            Data = dataArray.Select(TwitchGame.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_games.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        return request;
    }

}
