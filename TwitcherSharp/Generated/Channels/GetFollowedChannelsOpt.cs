using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Channels;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetFollowedChannels 
/// </summary>
public partial class GetFollowedChannelsOpt : Resource, ITwitcherSharp<GetFollowedChannelsOpt>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public int First { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetFollowedChannelsOpt object.
    /// </summary> 
    public static GetFollowedChannelsOpt FromObject(GodotObject data)
    {
        return new GetFollowedChannelsOpt
        {

			BroadcasterId = data.Get("broadcaster_id").AsString(),
			First = data.Get("first").AsInt32(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_followed_channels_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("first", First);
		request.Set("after", After);
		return request;
	}
}
