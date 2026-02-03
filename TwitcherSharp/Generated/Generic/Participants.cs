using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// The list of participants in the session. 
/// </summary>
public partial class Participants : Resource, ITwitcherSharp<Participants>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
    /// <summary> 
    /// Transforms the godot data into a Participants object.
    /// </summary> 
    public static Participants FromObject(GodotObject data)
    {
        return new Participants
        {

			BroadcasterId = data.Get("broadcaster_id").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_participants.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		return request;
	}
}
