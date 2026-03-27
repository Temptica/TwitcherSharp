using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.EventSub;

public partial class TwitchCreateEventSubSubscriptionResponse<T> : RefCounted, ITwitcherSharp<TwitchCreateEventSubSubscriptionResponse<T>> where T : ITwitcherSharpCondition<T>
{
    private GodotObject _data;
    public TwitchEventSubSubscription<T>[] Data { get; set; }
    public int Total { get; set; }
    public int TotalCost { get; set; }
    public int MaxTotalCost { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateEventSubSubscriptionResponse object.
    /// </summary> 
    public static TwitchCreateEventSubSubscriptionResponse<T> FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchCreateEventSubSubscriptionResponse<T>
        {
            Data = dataArray.Select(TwitchEventSubSubscription<T>.FromObject).ToArray(),
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
        request.Set("data", Data?.Select(x => x.ToGodotObject()).ToArray());
        request.Set("total", Total);
        request.Set("total_cost", TotalCost);
        request.Set("max_total_cost", MaxTotalCost);
        return request;
    }

}
