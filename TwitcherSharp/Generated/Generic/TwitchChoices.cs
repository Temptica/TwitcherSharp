using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// A list of choices that viewers may choose from. The list must contain a minimum of 2 choices and up to a maximum of 5 choices. 
/// </summary>
public partial class TwitchChoices : Resource, ITwitcherSharp<TwitchChoices>
{
    private GodotObject _data;
	public string Title { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchChoices object.
    /// </summary> 
    public static TwitchChoices FromObject(GodotObject data)
    {
		return new TwitchChoices
		{
			Title = data.Get("title").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_choices.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("title", Title);
		return request;
	}
}
