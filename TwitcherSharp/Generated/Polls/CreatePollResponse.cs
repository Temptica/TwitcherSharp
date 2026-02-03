using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Polls;
 
/// <summary> 
///  
/// </summary>
public partial class CreatePollResponse : Resource, ITwitcherSharp<CreatePollResponse>
{
    private GodotObject _data;
	public Poll[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreatePollResponse object.
    /// </summary> 
    public static CreatePollResponse FromObject(GodotObject data)
    {
        return new CreatePollResponse
        {

			Data = data.Get("data").As<Poll[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_poll_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
