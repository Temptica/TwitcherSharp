using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Moderation;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetBannedUsers 
/// </summary>
public partial class GetBannedUsersOpt : Resource, ITwitcherSharp<GetBannedUsersOpt>
{
    private GodotObject _data;
	public string[] UserId { get; set; }
	public int First { get; set; }
	public string After { get; set; }
	public string Before { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetBannedUsersOpt object.
    /// </summary> 
    public static GetBannedUsersOpt FromObject(GodotObject data)
    {
        return new GetBannedUsersOpt
        {

			UserId = data.Get("user_id").AsStringArray(),
			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
			Before = data.Get("before").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_banned_users_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("first", First);
		request.Set("after", After);
		request.Set("before", Before);
		return request;
	}
}
