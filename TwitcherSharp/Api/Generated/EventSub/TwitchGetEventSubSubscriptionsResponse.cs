using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.EventSub;

public partial class TwitchGetEventSubSubscriptionsResponse<T> : RefCounted, ITwitcherSharp<TwitchGetEventSubSubscriptionsResponse<T>> where T : RefCounted, ITwitcherSharpCondition<T>
{
    private GodotObject _data;
    public TwitchEventSubSubscription<T>[] Data { get; set; }
    public int Total { get; set; }
    public int TotalCost { get; set; }
    public int MaxTotalCost { get; set; }
    public ResponsePagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetEventSubSubscriptionsResponse object.
    /// </summary> 
    public static TwitchGetEventSubSubscriptionsResponse<T> FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetEventSubSubscriptionsResponse<T>
        {
            Data = dataArray.Select(TwitchEventSubSubscription<T>.FromObject).ToArray(),
            Total = data.Get("total").AsInt32(),
            TotalCost = data.Get("total_cost").AsInt32(),
            MaxTotalCost = data.Get("max_total_cost").AsInt32(),
            Pagination = data.Get("pagination").As<ResponsePagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_event_sub_subscriptions.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        request.Set("total", Total);
        request.Set("total_cost", TotalCost);
        request.Set("max_total_cost", MaxTotalCost);
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchGetEventSubSubscriptionsResponse<T>> NextPage() =>
        await _data.CallAsync<TwitchGetEventSubSubscriptionsResponse<T>>("next_page");
    
    /// <summary> 
    /// Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through 
    /// </summary>
    public partial class ResponsePagination : RefCounted, ITwitcherSharp<ResponsePagination>
    {
        private GodotObject _data;
        public string Cursor { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a ResponsePagination object.
        /// </summary> 
        public static ResponsePagination FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new ResponsePagination
            {
                Cursor = data.Get("cursor").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_event_sub_subscriptions.gd");
            var responsePaginationClass = script.Get("ResponsePagination").AsGodotObject();
            var request = responsePaginationClass.Call("new").AsGodotObject();
            if(Cursor != null) request.Set("cursor", Cursor);
            return request;
        }
    
    }

}
