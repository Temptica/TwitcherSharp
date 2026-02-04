using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetTeams 
/// </summary>
public partial class TwitchGetTeamsOpt : Resource, ITwitcherSharp<TwitchGetTeamsOpt>
{
    private GodotObject _data;
	public string Name { get; set; }
	public string Id { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetTeamsOpt object.
    /// </summary> 
    public static TwitchGetTeamsOpt FromObject(GodotObject data)
    {
		return new TwitchGetTeamsOpt
		{
			Name = data.Get("name").AsString(),
			Id = data.Get("id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_teams.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("name", Name);
		request.Set("id", Id);
		return request;
	}
}
