using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchGetUnbanRequestsResponse : RefCounted, ITwitcherSharp<TwitchGetUnbanRequestsResponse>
{
    private GodotObject? _data;
    public TwitchResponseData[] Data { get => field ??= _data?.GetArray<TwitchResponseData>("data")!; set; } = null!;
    public ResponsePagination? Pagination { get => field ??= _data?.Get<ResponsePagination>("pagination"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUnbanRequestsResponse object.
    /// </summary> 
    public static TwitchGetUnbanRequestsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUnbanRequestsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_unban_requests.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        if(Pagination != null) request.Set("pagination", Pagination);
        return request;
    }
    public async Task<TwitchGetUnbanRequestsResponse> NextPage() =>
        await _data!.CallAsync<TwitchGetUnbanRequestsResponse>("next_page");
    
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_unban_requests.gd");
            var responsePaginationClass = script.Get("ResponsePagination").AsGodotObject();
            var request = responsePaginationClass.Call("new").AsGodotObject();
            if(Cursor != null) request.Set("cursor", Cursor);
            return request;
        }
    
    }
    
    /// <summary> 
    /// A list that contains information about the channel's unban requests. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject? _data;
        public string Id { get; set; } = null!;
        public string BroadcasterId { get; set; } = null!;
        public string BroadcasterName { get; set; } = null!;
        public string BroadcasterLogin { get; set; } = null!;
        public string ModeratorId { get; set; } = null!;
        public string ModeratorLogin { get; set; } = null!;
        public string ModeratorName { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string UserLogin { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Text { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string CreatedAt { get; set; } = null!;
        public string ResolvedAt { get; set; } = null!;
        public string ResolutionText { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                Id = data.Get("id").AsString(),
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                BroadcasterName = data.Get("broadcaster_name").AsString(),
                BroadcasterLogin = data.Get("broadcaster_login").AsString(),
                ModeratorId = data.Get("moderator_id").AsString(),
                ModeratorLogin = data.Get("moderator_login").AsString(),
                ModeratorName = data.Get("moderator_name").AsString(),
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                Text = data.Get("text").AsString(),
                Status = data.Get("status").AsString(),
                CreatedAt = data.Get("created_at").AsString(),
                ResolvedAt = data.Get("resolved_at").AsString(),
                ResolutionText = data.Get("resolution_text").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_unban_requests.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            if(Id != null) request.Set("id", Id);
            if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
            if(BroadcasterName != null) request.Set("broadcaster_name", BroadcasterName);
            if(BroadcasterLogin != null) request.Set("broadcaster_login", BroadcasterLogin);
            if(ModeratorId != null) request.Set("moderator_id", ModeratorId);
            if(ModeratorLogin != null) request.Set("moderator_login", ModeratorLogin);
            if(ModeratorName != null) request.Set("moderator_name", ModeratorName);
            if(UserId != null) request.Set("user_id", UserId);
            if(UserLogin != null) request.Set("user_login", UserLogin);
            if(UserName != null) request.Set("user_name", UserName);
            if(Text != null) request.Set("text", Text);
            if(Status != null) request.Set("status", Status);
            if(CreatedAt != null) request.Set("created_at", CreatedAt);
            if(ResolvedAt != null) request.Set("resolved_at", ResolvedAt);
            if(ResolutionText != null) request.Set("resolution_text", ResolutionText);
            return request;
        }
    
    }

}
