using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Subscriptions;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCheckUserSubscriptionResponse : Resource, ITwitcherSharp<TwitchCheckUserSubscriptionResponse>
{
    private GodotObject _data;
	public TwitchUserSubscription[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCheckUserSubscriptionResponse object.
    /// </summary> 
    public static TwitchCheckUserSubscriptionResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchCheckUserSubscriptionResponse
		{
			Data = dataArray.Select(TwitchUserSubscription.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_check_user_subscription.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
