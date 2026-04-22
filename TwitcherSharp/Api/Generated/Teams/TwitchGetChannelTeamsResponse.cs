using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Teams;

public partial class TwitchGetChannelTeamsResponse : RefCounted, ITwitcherSharp<TwitchGetChannelTeamsResponse>
{
    private GodotObject _data;
    public TwitchChannelTeam[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelTeamsResponse object.
    /// </summary> 
    public static TwitchGetChannelTeamsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetChannelTeamsResponse
        {
            Data = dataArray.Select(TwitchChannelTeam.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_teams.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }

}
