using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Channels;

public partial class TwitchGetChannelFollowersResponse : RefCounted, ITwitcherSharp<TwitchGetChannelFollowersResponse>
{
    private GodotObject _data;
    public TwitchData[] Data { get; set; }
    public ResponsePagination Pagination { get; set; }
    public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChannelFollowersResponse object.
    /// </summary> 
    public static TwitchGetChannelFollowersResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetChannelFollowersResponse
        {
            Data = dataArray.Select(TwitchData.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<ResponsePagination>(),
            Total = data.Get("total").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_channel_followers.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        if(Pagination != null) request.Set("pagination", Pagination);
        request.Set("total", Total);
        return request;
    }
    public async Task<TwitchGetChannelFollowersResponse> NextPage() =>
        await _data.CallAsync<TwitchGetChannelFollowersResponse>("next_page");
    
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
    
    /// <summary> 
    /// The list of users that follow the specified broadcaster. The list is in descending order by `followed_at` (with the most recent follower first). The list is empty if nobody follows the broadcaster, the specified `user_id` isn’t in the follower list, the user access token is missing the **moderator:read:followers** scope, or the user isn’t the broadcaster or moderator for the channel. 
    /// </summary>
    public partial class TwitchData : RefCounted, ITwitcherSharp<TwitchData>
    {
        private GodotObject _data;
        public string FollowedAt { get; set; }
        public string UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchData object.
        /// </summary> 
        public static TwitchData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchData
            {
                FollowedAt = data.Get("followed_at").AsString(),
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("followed_at", FollowedAt);
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    
    }

}
