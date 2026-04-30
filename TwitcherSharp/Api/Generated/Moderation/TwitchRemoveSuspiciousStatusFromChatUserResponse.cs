using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchRemoveSuspiciousStatusFromChatUserResponse : RefCounted, ITwitcherSharp<TwitchRemoveSuspiciousStatusFromChatUserResponse>
{
    private GodotObject _data;
    public TwitchResponseData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchRemoveSuspiciousStatusFromChatUserResponse object.
    /// </summary> 
    public static TwitchRemoveSuspiciousStatusFromChatUserResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchRemoveSuspiciousStatusFromChatUserResponse
        {
            Data = dataArray.Select(TwitchResponseData.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_remove_suspicious_status_from_chat_user.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// An array with one object containing information about the suspicious user action. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public string UserId { get; set; }
        public string BroadcasterId { get; set; }
        public string ModeratorId { get; set; }
        public string UpdatedAt { get; set; }
        public string Status { get; set; }
        public string[] Types { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchResponseData
            {
                UserId = data.Get("user_id").AsString(),
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                ModeratorId = data.Get("moderator_id").AsString(),
                UpdatedAt = data.Get("updated_at").AsString(),
                Status = data.Get("status").AsString(),
                Types = data.Get("types").AsStringArray(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_remove_suspicious_status_from_chat_user.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("broadcaster_id", BroadcasterId);
            request.Set("moderator_id", ModeratorId);
            request.Set("updated_at", UpdatedAt);
            request.Set("status", Status);
            if(Types != null) request.Set("types", new Godot.Collections.Array<string>(Types));
            return request;
        }
    
    }

}
