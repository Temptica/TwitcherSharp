using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchWarnChatUserResponse : RefCounted, ITwitcherSharp<TwitchWarnChatUserResponse>
{
    private GodotObject? _data;
    public TwitchResponseData[]? Data { get => field ??= _data?.GetArray<TwitchResponseData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchWarnChatUserResponse object.
    /// </summary> 
    public static TwitchWarnChatUserResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchWarnChatUserResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_warn_chat_user.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// A list that contains information about the warning. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject? _data;
        public string? BroadcasterId { get; set; }
        public string? UserId { get; set; }
        public string? ModeratorId { get; set; }
        public string? Reason { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                UserId = data.Get("user_id").AsString(),
                ModeratorId = data.Get("moderator_id").AsString(),
                Reason = data.Get("reason").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_warn_chat_user.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            if(BroadcasterId != null) request.Set("broadcaster_id", BroadcasterId);
            if(UserId != null) request.Set("user_id", UserId);
            if(ModeratorId != null) request.Set("moderator_id", ModeratorId);
            if(Reason != null) request.Set("reason", Reason);
            return request;
        }
    
    }

}
