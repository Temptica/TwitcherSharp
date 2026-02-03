using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// The list of possible outcomes that the viewers may choose from. The list must contain a minimum of 2 choices and up to a maximum of 10 choices. 
/// </summary>
public partial class Outcomes : Resource, ITwitcherSharp<Outcomes>
{
    private GodotObject _data;
	public string Title { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Outcomes object.
    /// </summary> 
    public static Outcomes FromObject(GodotObject data)
    {
        return new Outcomes
        {

			Title = data.Get("title").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_outcomes.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("title", Title);
		return request;
	}
}
