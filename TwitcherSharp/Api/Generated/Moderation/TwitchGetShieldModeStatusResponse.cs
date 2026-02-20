using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchGetShieldModeStatusResponse : Resource, ITwitcherSharp<TwitchGetShieldModeStatusResponse>
{
    private GodotObject _data;
    public TwitchData[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetShieldModeStatusResponse object.
    /// </summary> 
    public static TwitchGetShieldModeStatusResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var dataArray = data.Get("data").AsGodotArray<GodotObject>();
        return new TwitchGetShieldModeStatusResponse
        {
            Data = dataArray.Select(TwitchData.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_shield_mode_status.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        request.Set("data", Data);
        return request;
    }
    
    /// <summary> 
    /// A list that contains a single object with the broadcaster’s Shield Mode status. 
    /// </summary>
    public partial class TwitchData : Resource, ITwitcherSharp<TwitchData>
    {
        private GodotObject _data;
        public bool IsActive { get; set; }
        public string ModeratorId { get; set; }
        public string ModeratorLogin { get; set; }
        public string ModeratorName { get; set; }
        public string LastActivatedAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchData object.
        /// </summary> 
        public static TwitchData FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchData
            {
                IsActive = data.Get("is_active").AsBool(),
                ModeratorId = data.Get("moderator_id").AsString(),
                ModeratorLogin = data.Get("moderator_login").AsString(),
                ModeratorName = data.Get("moderator_name").AsString(),
                LastActivatedAt = data.Get("last_activated_at").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_data.gd");
            var request = script.Call("new").AsGodotObject();
            request.Set("is_active", IsActive);
            request.Set("moderator_id", ModeratorId);
            request.Set("moderator_login", ModeratorLogin);
            request.Set("moderator_name", ModeratorName);
            request.Set("last_activated_at", LastActivatedAt);
            return request;
        }
    
    }

}
