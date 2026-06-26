using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Games;

public partial class TwitchGetGamesResponse : RefCounted, ITwitcherSharp<TwitchGetGamesResponse>
{
    private GodotObject _data;
    public TwitchGame[] Data { get => field ??= _data?.GetArray<TwitchGame>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetGamesResponse object.
    /// </summary> 
    public static TwitchGetGamesResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetGamesResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_games.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
