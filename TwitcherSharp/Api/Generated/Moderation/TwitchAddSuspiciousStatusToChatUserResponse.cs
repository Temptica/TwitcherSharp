using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchAddSuspiciousStatusToChatUserResponse : RefCounted, ITwitcherSharp<TwitchAddSuspiciousStatusToChatUserResponse>
{
    private GodotObject _data;
    public TwitchData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchAddSuspiciousStatusToChatUserResponse object.
    /// </summary> 
    public static TwitchAddSuspiciousStatusToChatUserResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchAddSuspiciousStatusToChatUserResponse
        {
            Data = dataArray.Select(TwitchData.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_add_suspicious_status_to_chat_user.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", new Godot.Collections.Array<GodotObject>(Data.Select(x => x.ToGodotObject()).ToArray()));
        return request;
    }
    
    /// <summary> 
    /// An array with one object containing information about the suspicious user action. 
    /// </summary>
    public partial class TwitchData : RefCounted, ITwitcherSharp<TwitchData>
    {
        private GodotObject _data;
        public string UserId { get; set; }
        public string BroadcasterId { get; set; }
        public string ModeratorId { get; set; }
        public string UpdatedAt { get; set; }
        public string Status { get; set; }
        public string[] Types { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchData object.
        /// </summary> 
        public static TwitchData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchData
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("broadcaster_id", BroadcasterId);
            request.Set("moderator_id", ModeratorId);
            request.Set("updated_at", UpdatedAt);
            request.Set("status", Status);
            request.Set("types", new Godot.Collections.Array<string>(Types));
            return request;
        }
    
    }

}
