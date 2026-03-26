using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetChattersResponse : RefCounted, ITwitcherSharp<TwitchGetChattersResponse>
{
    private GodotObject _data;
    public TwitchChatter[] Data { get; set; }
    public ResponsePagination Pagination { get; set; }
    public int Total { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetChattersResponse object.
    /// </summary> 
    public static TwitchGetChattersResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetChattersResponse
        {
            Data = dataArray.Select(TwitchChatter.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<ResponsePagination>(),
            Total = data.Get("total").AsInt32(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_chatters.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        request.Set("total", Total);
        return request;
    }
    public async Task<TwitchGetChattersResponse> NextPage() =>
        await _data.CallAsync<TwitchGetChattersResponse>("next_page");
    
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
    public partial class TwitchChatter : RefCounted, ITwitcherSharp<TwitchChatter>
    {
        private GodotObject _data;
        public string UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchChatter object.
        /// </summary> 
        public static TwitchChatter FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchChatter
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_chatter.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    
    }

}
