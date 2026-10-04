using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchResolveUnbanRequestsResponse : RefCounted, ITwitcherSharp<TwitchResolveUnbanRequestsResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchResolveUnbanRequestsResponse object.
    /// </summary> 
    public static TwitchResolveUnbanRequestsResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchResolveUnbanRequestsResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_resolve_unban_requests.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public string Id { get; set; } = null!;
        public string BroadcasterId { get; set; } = null!;
        public string BroadcasterLogin { get; set; } = null!;
        public string BroadcasterName { get; set; } = null!;
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
                Id = data.Read("id", static v => v.AsString()),
                BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
                BroadcasterLogin = data.Read("broadcaster_login", static v => v.AsString()),
                BroadcasterName = data.Read("broadcaster_name", static v => v.AsString()),
                ModeratorId = data.Read("moderator_id", static v => v.AsString()),
                ModeratorLogin = data.Read("moderator_login", static v => v.AsString()),
                ModeratorName = data.Read("moderator_name", static v => v.AsString()),
                UserId = data.Read("user_id", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
                Text = data.Read("text", static v => v.AsString()),
                Status = data.Read("status", static v => v.AsString()),
                CreatedAt = data.Read("created_at", static v => v.AsString()),
                ResolvedAt = data.Read("resolved_at", static v => v.AsString()),
                ResolutionText = data.Read("resolution_text", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_resolve_unban_requests.gd", "ResponseData");
            if(Id != null) request.SetValue("id", Id);
            if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
            if(BroadcasterLogin != null) request.SetValue("broadcaster_login", BroadcasterLogin);
            if(BroadcasterName != null) request.SetValue("broadcaster_name", BroadcasterName);
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
