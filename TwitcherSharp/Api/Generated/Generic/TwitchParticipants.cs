using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
/// The list of participants in the session. 
/// </summary>
public partial class TwitchParticipants : Resource, ITwitcherSharp<TwitchParticipants>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchParticipants object.
    /// </summary> 
    public static TwitchParticipants FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchParticipants
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
