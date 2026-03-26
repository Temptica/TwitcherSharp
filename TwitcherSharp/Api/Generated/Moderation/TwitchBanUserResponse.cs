using TwitcherSharp.Interfaces;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchBanUserResponse : RefCounted, ITwitcherSharp<TwitchBanUserResponse>
{
    private GodotObject _data;
    public TwitchData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchBanUserResponse object.
    /// </summary> 
    public static TwitchBanUserResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchBanUserResponse
        {
            Data = dataArray.Select(TwitchData.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_ban_user.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data.Select(x => x.ToGodotObject()).ToArray());
        return request;
    }
    
    /// <summary> 
    /// A list that contains the user you successfully banned or put in a timeout. 
    /// </summary>
    public partial class TwitchData : RefCounted, ITwitcherSharp<TwitchData>
    {
        private GodotObject _data;
        public string BroadcasterId { get; set; }
        public string ModeratorId { get; set; }
        public string UserId { get; set; }
        public string CreatedAt { get; set; }
        public string EndTime { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchData object.
        /// </summary> 
        public static TwitchData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchData
            {
                BroadcasterId = data.Get("broadcaster_id").AsString(),
                ModeratorId = data.Get("moderator_id").AsString(),
                UserId = data.Get("user_id").AsString(),
                CreatedAt = data.Get("created_at").AsString(),
                EndTime = data.Get("end_time").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("broadcaster_id", BroadcasterId);
            request.Set("moderator_id", ModeratorId);
            request.Set("user_id", UserId);
            request.Set("created_at", CreatedAt);
            request.Set("end_time", EndTime);
            return request;
        }
    
    }

}
