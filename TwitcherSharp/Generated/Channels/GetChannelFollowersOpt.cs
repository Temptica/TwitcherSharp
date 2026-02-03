using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Channels;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetChannelFollowers 
/// </summary>
public partial class GetChannelFollowersOpt : Resource, ITwitcherSharp<GetChannelFollowersOpt>
{
    private GodotObject _data;
	public string UserId { get; set; }
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetChannelFollowersOpt object.
    /// </summary> 
    public static GetChannelFollowersOpt FromObject(GodotObject data)
    {
        return new GetChannelFollowersOpt
        {

			UserId = data.Get("user_id").AsString(),
			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_followers_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
