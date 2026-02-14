using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCreateEventSubSubscriptionResponse : Resource, ITwitcherSharp<TwitchCreateEventSubSubscriptionResponse>
{
    private GodotObject _data;
	public TwitchEventSubSubscription[] Data { get; set; }
	public int Total { get; set; }
	public int TotalCost { get; set; }
	public int MaxTotalCost { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateEventSubSubscriptionResponse object.
    /// </summary> 
    public static TwitchCreateEventSubSubscriptionResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchCreateEventSubSubscriptionResponse
		{
			Data = dataArray.Select(TwitchEventSubSubscription.FromObject).ToArray(),
			Total = data.Get("total").AsInt32(),
			TotalCost = data.Get("total_cost").AsInt32(),
			MaxTotalCost = data.Get("max_total_cost").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_event_sub_subscription.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("total", Total);
		request.Set("total_cost", TotalCost);
		request.Set("max_total_cost", MaxTotalCost);
		return request;
	}
}
