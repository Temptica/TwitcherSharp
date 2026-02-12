using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetBroadcasterSubscriptions 
/// </summary>
public partial class TwitchGetBroadcasterSubscriptionsOpt : Resource, ITwitcherSharp<TwitchGetBroadcasterSubscriptionsOpt>
{
    private GodotObject _data;
	public string[] UserId { get; set; }
	public string First { get; set; }
	public string After { get; set; }
	public string Before { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetBroadcasterSubscriptionsOpt object.
    /// </summary> 
    public static TwitchGetBroadcasterSubscriptionsOpt FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchGetBroadcasterSubscriptionsOpt
		{
			UserId = data.Get("user_id").AsStringArray(),
			First = data.Get("first").AsString(),
			After = data.Get("after").AsString(),
			Before = data.Get("before").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_broadcaster_subscriptions.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		if(UserId != null) request.Set("user_id", UserId);
		if(First != null) request.Set("first", First);
		if(After != null) request.Set("after", After);
		if(Before != null) request.Set("before", Before);
		return request;
	}
}
