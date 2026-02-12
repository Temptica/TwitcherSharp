using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Teams;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetChannelTeamsResponse : Resource, ITwitcherSharp<TwitchGetChannelTeamsResponse>
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
		request.Set("data", Data);
		return request;
	}
}
