using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.EventSub;

public partial class TwitchGetEventSubSubscriptionsResponse<T> : RefCounted, ITwitcherSharp<TwitchGetEventSubSubscriptionsResponse<T>> where T : RefCounted, ITwitcherSharpCondition<T>
{
    private Variant _data;
    public TwitchEventSubSubscription<T>[] Data { get => field ??= _data.GetArray<TwitchEventSubSubscription<T>>("data")!; set; } = null!;
    public int Total { get; set; }
    public int TotalCost { get; set; }
    public int MaxTotalCost { get; set; }
    public ResponsePagination? Pagination { get => field ??= _data.Get<ResponsePagination>("pagination"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetEventSubSubscriptionsResponse object.
    /// </summary> 
    public static TwitchGetEventSubSubscriptionsResponse<T>? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetEventSubSubscriptionsResponse<T>
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
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_eventsub_subscriptions.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        request.SetValue("total", Total);
        request.SetValue("total_cost", TotalCost);
        request.SetValue("max_total_cost", MaxTotalCost);
        if(Pagination != null) request.SetValue("pagination", Pagination);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    public async Task<TwitchGetEventSubSubscriptionsResponse<T>> NextPage() =>
        await _data.CallAsync<TwitchGetEventSubSubscriptionsResponse<T>>("next_page");
    
    /// <summary> 
    /// Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through 
    /// </summary>
    public partial class ResponsePagination : RefCounted, ITwitcherSharp<ResponsePagination>
    {
        private Variant _data;
        public string? Cursor { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a ResponsePagination object.
        /// </summary> 
        public static ResponsePagination? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new ResponsePagination
            {
                Cursor = data.Read("cursor", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_eventsub_subscriptions.gd", "ResponsePagination");
            if(Cursor != null) request.SetValue("cursor", Cursor);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    }

}
