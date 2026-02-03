using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class GetEventSubSubscriptionsResponse : Resource, ITwitcherSharp<GetEventSubSubscriptionsResponse>
{
    private GodotObject _data;
	public EventSubSubscription[] Data { get; set; }
	public int Total { get; set; }
	public int TotalCost { get; set; }
	public int MaxTotalCost { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetEventSubSubscriptionsResponse object.
    /// </summary> 
    public static GetEventSubSubscriptionsResponse FromObject(GodotObject data)
    {
        return new GetEventSubSubscriptionsResponse
        {

			Data = data.Get("data").As<EventSubSubscription[]>(),
			Total = data.Get("total").AsInt32(),
			TotalCost = data.Get("total_cost").AsInt32(),
			MaxTotalCost = data.Get("max_total_cost").AsInt32(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_event_sub_subscriptions_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("total", Total);
		request.Set("total_cost", TotalCost);
		request.Set("max_total_cost", MaxTotalCost);
		request.Set("pagination", Pagination);
		return request;
	}
}
