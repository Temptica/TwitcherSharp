using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Teams;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetTeamsResponse : Resource, ITwitcherSharp<TwitchGetTeamsResponse>
{
    private GodotObject _data;
	public TwitchTeam[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetTeamsResponse object.
    /// </summary> 
    public static TwitchGetTeamsResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetTeamsResponse
		{
			Data = dataArray.Select(TwitchTeam.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_teams.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
