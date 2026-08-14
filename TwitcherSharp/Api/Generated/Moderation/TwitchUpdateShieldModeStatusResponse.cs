using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchUpdateShieldModeStatusResponse : RefCounted, ITwitcherSharp<TwitchUpdateShieldModeStatusResponse>
{
    private GodotObject? _data;
    public TwitchResponseData[]? Data { get => field ??= _data?.GetArray<TwitchResponseData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateShieldModeStatusResponse object.
    /// </summary> 
    public static TwitchUpdateShieldModeStatusResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateShieldModeStatusResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_shield_mode_status.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data.ToGodotArray());
        return request;
    }
    
    /// <summary> 
    /// A list that contains a single object with the broadcaster’s updated Shield Mode status. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject? _data;
        public bool IsActive { get; set; }
        public string? ModeratorId { get; set; }
        public string? ModeratorLogin { get; set; }
        public string? ModeratorName { get; set; }
        public string? LastActivatedAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                IsActive = data.Get("is_active").AsBool(),
                ModeratorId = data.Get("moderator_id").AsString(),
                ModeratorLogin = data.Get("moderator_login").AsString(),
                ModeratorName = data.Get("moderator_name").AsString(),
                LastActivatedAt = data.Get("last_activated_at").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_shield_mode_status.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            request.Set("is_active", IsActive);
            if(ModeratorId != null) request.Set("moderator_id", ModeratorId);
            if(ModeratorLogin != null) request.Set("moderator_login", ModeratorLogin);
            if(ModeratorName != null) request.Set("moderator_name", ModeratorName);
            if(LastActivatedAt != null) request.Set("last_activated_at", LastActivatedAt);
            return request;
        }
    
    }

}
