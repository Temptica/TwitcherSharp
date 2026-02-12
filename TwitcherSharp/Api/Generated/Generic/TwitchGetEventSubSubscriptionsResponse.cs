using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetEventSubSubscriptionsResponse : Resource, ITwitcherSharp<TwitchGetEventSubSubscriptionsResponse>
{
    private GodotObject _data;
	public TwitchEventSubSubscription[] Data { get; set; }
	public int Total { get; set; }
	public int TotalCost { get; set; }
	public int MaxTotalCost { get; set; }
	public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetEventSubSubscriptionsResponse object.
    /// </summary> 
    public static TwitchGetEventSubSubscriptionsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetEventSubSubscriptionsResponse
		{
			Data = dataArray.Select(TwitchEventSubSubscription.FromObject).ToArray(),
			Total = data.Get("total").AsInt32(),
			TotalCost = data.Get("total_cost").AsInt32(),
			MaxTotalCost = data.Get("max_total_cost").AsInt32(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_event_sub_subscriptions.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("total", Total);
		request.Set("total_cost", TotalCost);
		request.Set("max_total_cost", MaxTotalCost);
		if(Pagination != null) request.Set("pagination", Pagination);
		return request;
	}
}
