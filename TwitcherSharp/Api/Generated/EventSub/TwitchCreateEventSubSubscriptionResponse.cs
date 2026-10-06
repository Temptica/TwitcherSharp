using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.EventSub;

public partial class TwitchCreateEventSubSubscriptionResponse<T> : RefCounted, ITwitcherSharp<TwitchCreateEventSubSubscriptionResponse<T>> where T : RefCounted, ITwitcherSharpCondition<T>
{
    private Variant _data;
    public TwitchEventSubSubscription<T>[] Data { get => field ??= _data.GetArray<TwitchEventSubSubscription<T>>("data")!; set; } = null!;
    public int Total { get; set; }
    public int TotalCost { get; set; }
    public int MaxTotalCost { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateEventSubSubscriptionResponse object.
    /// </summary> 
    public static TwitchCreateEventSubSubscriptionResponse<T>? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchCreateEventSubSubscriptionResponse<T>
        {
            Total = data.Read("total", static v => v.AsInt32()),
            TotalCost = data.Read("total_cost", static v => v.AsInt32()),
            MaxTotalCost = data.Read("max_total_cost", static v => v.AsInt32()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_create_event_sub_subscription.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        request.SetValue("total", Total);
        request.SetValue("total_cost", TotalCost);
        request.SetValue("max_total_cost", MaxTotalCost);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }

}
