using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchResolveUnbanRequestsResponse : RefCounted, ITwitcherSharp<TwitchResolveUnbanRequestsResponse>
{
    private GodotObject _data;
    public TwitchResponseData[] Data { get => field ??= _data?.GetArray<TwitchResponseData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchResolveUnbanRequestsResponse object.
    /// </summary> 
    public static TwitchResolveUnbanRequestsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchResolveUnbanRequestsResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_resolve_unban_requests.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string BroadcasterId { get; set; }
        public string BroadcasterLogin { get; set; }
        public string BroadcasterName { get; set; }
        public string ModeratorId { get; set; }
        public string ModeratorLogin { get; set; }
        public string ModeratorName { get; set; }
        public string UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        public string ResolvedAt { get; set; }
        public string ResolutionText { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                Id = data.Get("id").AsString(),
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                BroadcasterLogin = data.Get("broadcaster_login").AsString(),
                BroadcasterName = data.Get("broadcaster_name").AsString(),
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_resolve_unban_requests.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("broadcaster_id", BroadcasterId);
            request.Set("broadcaster_login", BroadcasterLogin);
            request.Set("broadcaster_name", BroadcasterName);
            request.Set("moderator_id", ModeratorId);
            request.Set("moderator_login", ModeratorLogin);
            request.Set("moderator_name", ModeratorName);
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("text", Text);
            request.Set("status", Status);
            request.Set("created_at", CreatedAt);
            request.Set("resolved_at", ResolvedAt);
            request.Set("resolution_text", ResolutionText);
            return request;
        }
    
    }

}
