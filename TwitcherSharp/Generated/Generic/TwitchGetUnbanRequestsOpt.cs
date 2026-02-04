using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetUnbanRequests 
/// </summary>
public partial class TwitchGetUnbanRequestsOpt : Resource, ITwitcherSharp<TwitchGetUnbanRequestsOpt>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public string After { get; set; }
	public int First { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetUnbanRequestsOpt object.
    /// </summary> 
    public static TwitchGetUnbanRequestsOpt FromObject(GodotObject data)
    {
		return new TwitchGetUnbanRequestsOpt
		{
			UserId = data.Get("user_id").AsString(),
			After = data.Get("after").AsString(),
			First = data.Get("first").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_unban_requests.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("after", After);
		request.Set("first", First);
		return request;
	}
}
