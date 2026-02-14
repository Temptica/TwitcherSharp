using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Subscriptions;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetBroadcasterSubscriptionsResponse : Resource, ITwitcherSharp<TwitchGetBroadcasterSubscriptionsResponse>
{
    private GodotObject _data;
	public TwitchBroadcasterSubscription[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }
	public int Points { get; set; }
	public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetBroadcasterSubscriptionsResponse object.
    /// </summary> 
    public static TwitchGetBroadcasterSubscriptionsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetBroadcasterSubscriptionsResponse
		{
			Data = dataArray.Select(TwitchBroadcasterSubscription.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
			Points = data.Get("points").AsInt32(),
			Total = data.Get("total").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_broadcaster_subscriptions.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		request.Set("points", Points);
		request.Set("total", Total);
		return request;
	}
}
