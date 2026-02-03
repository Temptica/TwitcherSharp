using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Goals;
 
/// <summary> 
///  
/// </summary>
public partial class GetCreatorGoalsResponse : Resource, ITwitcherSharp<GetCreatorGoalsResponse>
{
    private GodotObject _data;
	public CreatorGoal[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetCreatorGoalsResponse object.
    /// </summary> 
    public static GetCreatorGoalsResponse FromObject(GodotObject data)
    {
        return new GetCreatorGoalsResponse
        {

			Data = data.Get("data").As<CreatorGoal[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_creator_goals_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
