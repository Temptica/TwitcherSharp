using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Teams;
 
/// <summary> 
///  
/// </summary>
public partial class GetTeamsResponse : Resource, ITwitcherSharp<GetTeamsResponse>
{
    private GodotObject _data;
	public Team[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetTeamsResponse object.
    /// </summary> 
    public static GetTeamsResponse FromObject(GodotObject data)
    {
        return new GetTeamsResponse
        {

			Data = data.Get("data").As<Team[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_teams_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
