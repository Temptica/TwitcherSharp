using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Teams;
 
/// <summary> 
///  
/// </summary>
public partial class GetChannelTeamsResponse : Resource, ITwitcherSharp<GetChannelTeamsResponse>
{
    private GodotObject _data;
	public ChannelTeam[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetChannelTeamsResponse object.
    /// </summary> 
    public static GetChannelTeamsResponse FromObject(GodotObject data)
    {
        return new GetChannelTeamsResponse
        {

			Data = data.Get("data").As<ChannelTeam[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_teams_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
