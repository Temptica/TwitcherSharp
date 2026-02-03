using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Polls;
 
/// <summary> 
///  
/// </summary>
public partial class EndPollResponse : Resource, ITwitcherSharp<EndPollResponse>
{
    private GodotObject _data;
	public Poll[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a EndPollResponse object.
    /// </summary> 
    public static EndPollResponse FromObject(GodotObject data)
    {
        return new EndPollResponse
        {

			Data = data.Get("data").As<Poll[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_end_poll_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
