using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Subscriptions;

public partial class TwitchGetBroadcasterSubscriptionsResponse : RefCounted, ITwitcherSharp<TwitchGetBroadcasterSubscriptionsResponse>
{
    private GodotObject? _data;
    public TwitchBroadcasterSubscription[] Data { get => field ??= _data?.GetArray<TwitchBroadcasterSubscription>("data")!; set; } = null!;
    public ResponsePagination? Pagination { get => field ??= _data?.Get<ResponsePagination>("pagination"); set; }
    public int Points { get; set; }
    public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetBroadcasterSubscriptionsResponse object.
    /// </summary> 
    public static TwitchGetBroadcasterSubscriptionsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetBroadcasterSubscriptionsResponse
        {
            Points = data.Get("points").AsInt32(),
            Total = data.Get("total").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_broadcaster_subscriptions.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        request.Set("points", Points);
        request.Set("total", Total);
        return request;
    }
    public async Task<TwitchGetBroadcasterSubscriptionsResponse> NextPage() =>
        await _data!.CallAsync<TwitchGetBroadcasterSubscriptionsResponse>("next_page");
    
    /// <summary> 
    /// Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through 
    /// </summary>
    public partial class ResponsePagination : RefCounted, ITwitcherSharp<ResponsePagination>
    {
        private GodotObject? _data;
        public string? Cursor { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a ResponsePagination object.
        /// </summary> 
        public static ResponsePagination? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new ResponsePagination
            {
                Cursor = data.Get("cursor").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_broadcaster_subscriptions.gd");
            var responsePaginationClass = script.Get("ResponsePagination").AsGodotObject();
            var request = responsePaginationClass.Call("new").AsGodotObject();
            if(Cursor != null) request.Set("cursor", Cursor);
            return request;
        }
    
    }

}
