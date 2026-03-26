using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchGetBannedUsersResponse : RefCounted, ITwitcherSharp<TwitchGetBannedUsersResponse>
{
    private GodotObject _data;
    public TwitchBannedUser[] Data { get; set; }
    public ResponsePagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetBannedUsersResponse object.
    /// </summary> 
    public static TwitchGetBannedUsersResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetBannedUsersResponse
        {
            Data = dataArray.Select(TwitchBannedUser.FromObject).ToArray(),
            Pagination = data.Get("pagination").As<ResponsePagination>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_banned_users.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchGetBannedUsersResponse> NextPage() =>
        await _data.CallAsync<TwitchGetBannedUsersResponse>("next_page");
    
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
    public partial class TwitchBannedUser : RefCounted, ITwitcherSharp<TwitchBannedUser>
    {
        private GodotObject _data;
        public string UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
        public string ExpiresAt { get; set; }
        public string CreatedAt { get; set; }
        public string Reason { get; set; }
        public string ModeratorId { get; set; }
        public string ModeratorLogin { get; set; }
        public string ModeratorName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBannedUser object.
        /// </summary> 
        public static TwitchBannedUser FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchBannedUser
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                ExpiresAt = data.Get("expires_at").AsString(),
                CreatedAt = data.Get("created_at").AsString(),
                Reason = data.Get("reason").AsString(),
                ModeratorId = data.Get("moderator_id").AsString(),
                ModeratorLogin = data.Get("moderator_login").AsString(),
                ModeratorName = data.Get("moderator_name").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_banned_user.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("expires_at", ExpiresAt);
            request.Set("created_at", CreatedAt);
            request.Set("reason", Reason);
            request.Set("moderator_id", ModeratorId);
            request.Set("moderator_login", ModeratorLogin);
            request.Set("moderator_name", ModeratorName);
            return request;
        }
    
    }

}
