using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Subscriptions;
 
/// <summary> 
///  
/// </summary>
public partial class CheckUserSubscriptionResponse : Resource, ITwitcherSharp<CheckUserSubscriptionResponse>
{
    private GodotObject _data;
	public UserSubscription[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CheckUserSubscriptionResponse object.
    /// </summary> 
    public static CheckUserSubscriptionResponse FromObject(GodotObject data)
    {
        return new CheckUserSubscriptionResponse
        {

			Data = data.Get("data").As<UserSubscription[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_check_user_subscription_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
