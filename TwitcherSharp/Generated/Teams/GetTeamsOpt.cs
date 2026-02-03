using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Teams;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetTeams 
/// </summary>
public partial class GetTeamsOpt : Resource, ITwitcherSharp<GetTeamsOpt>
{
    private GodotObject _data;
	public string Name { get; set; }
	public string Id { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetTeamsOpt object.
    /// </summary> 
    public static GetTeamsOpt FromObject(GodotObject data)
    {
        return new GetTeamsOpt
        {

			Name = data.Get("name").AsString(),
			Id = data.Get("id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_teams_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("name", Name);
		request.Set("id", Id);
		return request;
	}
}
