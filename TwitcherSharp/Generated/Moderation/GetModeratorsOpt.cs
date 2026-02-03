using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetModerators 
/// </summary>
public partial class GetModeratorsOpt : Resource, ITwitcherSharp<GetModeratorsOpt>
{
    private GodotObject _data;
	public string[] UserId { get; set; }
	public string First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetModeratorsOpt object.
    /// </summary> 
    public static GetModeratorsOpt FromObject(GodotObject data)
    {
        return new GetModeratorsOpt
        {

			UserId = data.Get("user_id").AsStringArray(),
			First = data.Get("first").AsString(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_moderators_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
