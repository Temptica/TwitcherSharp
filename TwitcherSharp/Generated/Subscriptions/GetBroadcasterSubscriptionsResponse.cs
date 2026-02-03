using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Subscriptions;
 
/// <summary> 
///  
/// </summary>
public partial class GetBroadcasterSubscriptionsResponse : Resource, ITwitcherSharp<GetBroadcasterSubscriptionsResponse>
{
    private GodotObject _data;
	public BroadcasterSubscription[] Data { get; set; }
	public Pagination Pagination { get; set; }
	public int Points { get; set; }
	public int Total { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetBroadcasterSubscriptionsResponse object.
    /// </summary> 
    public static GetBroadcasterSubscriptionsResponse FromObject(GodotObject data)
    {
        return new GetBroadcasterSubscriptionsResponse
        {

			Data = data.Get("data").As<BroadcasterSubscription[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
			Points = data.Get("points").AsInt32(),
			Total = data.Get("total").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_broadcaster_subscriptions_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		request.Set("points", Points);
		request.Set("total", Total);
		return request;
	}
}
