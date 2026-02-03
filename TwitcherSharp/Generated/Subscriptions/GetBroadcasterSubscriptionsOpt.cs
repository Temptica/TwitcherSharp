using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Subscriptions;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetBroadcasterSubscriptions 
/// </summary>
public partial class GetBroadcasterSubscriptionsOpt : Resource, ITwitcherSharp<GetBroadcasterSubscriptionsOpt>
{
    private GodotObject _data;
	public string[] UserId { get; set; }
	public string First { get; set; }
	public string After { get; set; }
	public string Before { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetBroadcasterSubscriptionsOpt object.
    /// </summary> 
    public static GetBroadcasterSubscriptionsOpt FromObject(GodotObject data)
    {
        return new GetBroadcasterSubscriptionsOpt
        {

			UserId = data.Get("user_id").AsStringArray(),
			First = data.Get("first").AsString(),
			After = data.Get("after").AsString(),
			Before = data.Get("before").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_broadcaster_subscriptions_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("user_id", UserId);
		request.Set("first", First);
		request.Set("after", After);
		request.Set("before", Before);
		return request;
	}
}
