using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Subscriptions;

public partial class TwitchGetBroadcasterSubscriptionsResponse : RefCounted, ITwitcherSharp<TwitchGetBroadcasterSubscriptionsResponse>
{
    private GodotObject _data;
    public TwitchBroadcasterSubscription[] Data { get; set; }
    public ResponsePagination Pagination { get; set; }
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
            Pagination = data.Get("pagination").As<ResponsePagination>(),
            Points = data.Get("points").AsInt32(),
            Total = data.Get("total").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_broadcaster_subscriptions.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        if(Pagination != null) request.Set("pagination", Pagination);
        request.Set("points", Points);
        request.Set("total", Total);
        return request;
    }
    public async Task<TwitchGetBroadcasterSubscriptionsResponse> NextPage() =>
        await _data.CallAsync<TwitchGetBroadcasterSubscriptionsResponse>("next_page");
    
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/response_pagination.gd");
            var paginationClass = script.Get("Pagination").AsGodotObject();
            var request = paginationClass.Call("new").AsGodotObject();
            if(Cursor != null) request.Set("cursor", Cursor);
            return request;
        }
    
    }

}
