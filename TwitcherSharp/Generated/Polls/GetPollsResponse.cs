using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Polls;
 
/// <summary> 
///  
/// </summary>
public partial class GetPollsResponse : Resource, ITwitcherSharp<GetPollsResponse>
{
    private GodotObject _data;
	public Poll[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetPollsResponse object.
    /// </summary> 
    public static GetPollsResponse FromObject(GodotObject data)
    {
        return new GetPollsResponse
        {

			Data = data.Get("data").As<Poll[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_polls_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
