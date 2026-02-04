using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetEventsubSubscriptions 
/// </summary>
public partial class TwitchGetEventsubSubscriptionsOpt : Resource, ITwitcherSharp<TwitchGetEventsubSubscriptionsOpt>
{
    private GodotObject _data;
	public string Status { get; set; }
	public string Type { get; set; }
	public string UserId { get; set; }
	public string SubscriptionId { get; set; }
	public string After { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetEventsubSubscriptionsOpt object.
    /// </summary> 
    public static TwitchGetEventsubSubscriptionsOpt FromObject(GodotObject data)
    {
		return new TwitchGetEventsubSubscriptionsOpt
		{
			Status = data.Get("status").AsString(),
			Type = data.Get("type").AsString(),
			UserId = data.Get("user_id").AsString(),
			SubscriptionId = data.Get("subscription_id").AsString(),
			After = data.Get("after").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_eventsub_subscriptions.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("status", Status);
		request.Set("type", Type);
		request.Set("user_id", UserId);
		request.Set("subscription_id", SubscriptionId);
		request.Set("after", After);
		return request;
	}
}
