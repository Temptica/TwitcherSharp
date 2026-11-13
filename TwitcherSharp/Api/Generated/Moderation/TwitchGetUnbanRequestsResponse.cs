using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchGetUnbanRequestsResponse : RefCounted, ITwitcherSharp<TwitchGetUnbanRequestsResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;
    public ResponsePagination? Pagination { get => field ??= _data.Get<ResponsePagination>("pagination"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetUnbanRequestsResponse object.
    /// </summary> 
    public static TwitchGetUnbanRequestsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetUnbanRequestsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_unban_requests.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        if(Pagination != null) request.SetValue("pagination", Pagination);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    public async Task<TwitchGetUnbanRequestsResponse> NextPage() =>
        await _data.CallAsync<TwitchGetUnbanRequestsResponse>("next_page");
    
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
                Cursor = data.ReadAsString("cursor"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_unban_requests.gd", "ResponsePagination");
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
    
    /// <summary> 
    /// A list that contains information about the channel's unban requests. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
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
                Id = data.ReadAsString("id"),
                BroadcasterId = data.ReadAsString("broadcaster_id"),
                BroadcasterName = data.ReadAsString("broadcaster_name"),
                BroadcasterLogin = data.ReadAsString("broadcaster_login"),
                ModeratorId = data.ReadAsString("moderator_id"),
                ModeratorLogin = data.ReadAsString("moderator_login"),
                ModeratorName = data.ReadAsString("moderator_name"),
                UserId = data.ReadAsString("user_id"),
                UserLogin = data.ReadAsString("user_login"),
                UserName = data.ReadAsString("user_name"),
                Text = data.ReadAsString("text"),
                Status = data.ReadAsString("status"),
                CreatedAt = data.ReadAsString("created_at"),
                ResolvedAt = data.ReadAsString("resolved_at"),
                ResolutionText = data.ReadAsString("resolution_text"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_unban_requests.gd", "ResponseData");
            if(Id != null) request.SetValue("id", Id);
            if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
            if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
            if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
            if(ModeratorId != null) request.SetValue("moderator_id", ModeratorId);
            if(ModeratorLogin != null) request.SetValue("moderator_login", ModeratorLogin);
            if(ModeratorName != null) request.SetValue("moderator_name", ModeratorName);
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(UserName != null) request.SetValue("user_name", UserName);
            if(Text != null) request.SetValue("text", Text);
            if(Status != null) request.SetValue("status", Status);
            if(CreatedAt != null) request.SetValue("created_at", CreatedAt);
            if(ResolvedAt != null) request.SetValue("resolved_at", ResolvedAt);
            if(ResolutionText != null) request.SetValue("resolution_text", ResolutionText);
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
