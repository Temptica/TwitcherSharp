using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Polls;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchEndPollBody : Resource, ITwitcherSharp<TwitchEndPollBody>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public string Id { get; set; }
	public string Status { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchEndPollBody object.
    /// </summary> 
    public static TwitchEndPollBody FromObject(GodotObject data)
    {
		return new TwitchEndPollBody
		{
			BroadcasterId = data.Get("broadcaster_id").AsString(),
			Id = data.Get("id").AsString(),
			Status = data.Get("status").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_end_poll.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("id", Id);
		request.Set("status", Status);
		return request;
	}
}
