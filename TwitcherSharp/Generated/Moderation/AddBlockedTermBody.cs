using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
///  
/// </summary>
public partial class AddBlockedTermBody : Resource, ITwitcherSharp<AddBlockedTermBody>
{
    private GodotObject _data;
	public string Text { get; set; }
    /// <summary> 
    /// Transforms the godot data into a AddBlockedTermBody object.
    /// </summary> 
    public static AddBlockedTermBody FromObject(GodotObject data)
    {
        return new AddBlockedTermBody
        {

			Text = data.Get("text").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_add_blocked_term_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("text", Text);
		return request;
	}
}
