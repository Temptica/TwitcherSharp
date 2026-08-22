using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;

public partial class TwitchGetFollowedChannelsResponse : RefCounted, ITwitcherSharp<TwitchGetFollowedChannelsResponse>
{
    private GodotObject? _data;
    public TwitchResponseData[]? Data { get => field ??= _data?.GetArray<TwitchResponseData>("data"); set; }
    public ResponsePagination? Pagination { get => field ??= _data?.Get<ResponsePagination>("pagination"); set; }
    public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetFollowedChannelsResponse object.
    /// </summary> 
    public static TwitchGetFollowedChannelsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetFollowedChannelsResponse
        {
            Total = data.Get("total").AsInt32(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_followed_channels.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        request.Set("total", Total);
        return request;
    }
    public async Task<TwitchGetFollowedChannelsResponse> NextPage() =>
        await _data!.CallAsync<TwitchGetFollowedChannelsResponse>("next_page");
    
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_followed_channels.gd");
            var responsePaginationClass = script.Get("ResponsePagination").AsGodotObject();
            var request = responsePaginationClass.Call("new").AsGodotObject();
            if(Cursor != null) request.Set("cursor", Cursor);
            return request;
        }
    
    }
    
    /// <summary> 
    /// The list of broadcasters that the user follows. The list is in descending order by `followed_at` (with the most recently followed broadcaster first). The list is empty if the user doesn’t follow anyone. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject? _data;
        public string? BroadcasterId { get; set; }
        public string? BroadcasterLogin { get; set; }
        public string? BroadcasterName { get; set; }
        public string? FollowedAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                BroadcasterLogin = data.Get("broadcaster_login").AsString(),
                BroadcasterName = data.Get("broadcaster_name").AsString(),
                FollowedAt = data.Get("followed_at").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_followed_channels.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
            if(BroadcasterLogin != null) request.Set("broadcaster_login", BroadcasterLogin);
            if(BroadcasterName != null) request.Set("broadcaster_name", BroadcasterName);
            if(FollowedAt != null) request.Set("followed_at", FollowedAt);
            return request;
        }
    
    }

}
