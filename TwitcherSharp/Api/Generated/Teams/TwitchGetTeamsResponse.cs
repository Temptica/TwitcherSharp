using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Teams;

public partial class TwitchGetTeamsResponse : RefCounted, ITwitcherSharp<TwitchGetTeamsResponse>
{
    private GodotObject? _data;
    public TwitchTeam[] Data { get => field ??= _data?.GetArray<TwitchTeam>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetTeamsResponse object.
    /// </summary> 
    public static TwitchGetTeamsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetTeamsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_teams.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }

}
