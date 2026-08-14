using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchBanUserResponse : RefCounted, ITwitcherSharp<TwitchBanUserResponse>
{
    private GodotObject? _data;
    public TwitchResponseData[]? Data { get => field ??= _data?.GetArray<TwitchResponseData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchBanUserResponse object.
    /// </summary> 
    public static TwitchBanUserResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchBanUserResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_ban_user.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// A list that contains the user you successfully banned or put in a timeout. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject? _data;
        public string? BroadcasterId { get; set; }
        public string? ModeratorId { get; set; }
        public string? UserId { get; set; }
        public string? CreatedAt { get; set; }
        public string? EndTime { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                ModeratorId = data.Get("moderator_id").AsString(),
                UserId = data.Get("user_id").AsString(),
                CreatedAt = data.Get("created_at").AsString(),
                EndTime = data.Get("end_time").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_ban_user.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
            if(ModeratorId != null) request.Set("moderator_id", ModeratorId);
            if(UserId != null) request.Set("user_id", UserId);
            if(CreatedAt != null) request.Set("created_at", CreatedAt);
            if(EndTime != null) request.Set("end_time", EndTime);
            return request;
        }
    
    }

}
