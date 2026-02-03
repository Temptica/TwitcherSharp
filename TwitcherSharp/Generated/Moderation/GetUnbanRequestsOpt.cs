using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetUnbanRequests 
/// </summary>
public partial class GetUnbanRequestsOpt : Resource, ITwitcherSharp<GetUnbanRequestsOpt>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string After { get; set; }
	public int First { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetUnbanRequestsOpt object.
    /// </summary> 
    public static GetUnbanRequestsOpt FromObject(GodotObject data)
    {
        return new GetUnbanRequestsOpt
        {

			UserId = data.Get("user_id").AsString(),
			After = data.Get("after").AsString(),
			First = data.Get("first").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_unban_requests_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("after", After);
		request.Set("first", First);
		return request;
	}
}
