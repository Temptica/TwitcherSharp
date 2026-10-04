using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchUpdateShieldModeStatusResponse : RefCounted, ITwitcherSharp<TwitchUpdateShieldModeStatusResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateShieldModeStatusResponse object.
    /// </summary> 
    public static TwitchUpdateShieldModeStatusResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchUpdateShieldModeStatusResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_shield_mode_status.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    
    /// <summary> 
    /// A list that contains a single object with the broadcaster’s updated Shield Mode status. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public bool IsActive { get; set; }
        public string ModeratorId { get; set; } = null!;
        public string ModeratorLogin { get; set; } = null!;
        public string ModeratorName { get; set; } = null!;
        public string LastActivatedAt { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                IsActive = data.Read("is_active", static v => v.AsBool()),
                ModeratorId = data.Read("moderator_id", static v => v.AsString()),
                ModeratorLogin = data.Read("moderator_login", static v => v.AsString()),
                ModeratorName = data.Read("moderator_name", static v => v.AsString()),
                LastActivatedAt = data.Read("last_activated_at", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_update_shield_mode_status.gd", "ResponseData");
            request.SetValue("is_active", IsActive);
            if(ModeratorId != null) request.SetValue("moderator_id", ModeratorId);
            if(ModeratorLogin != null) request.SetValue("moderator_login", ModeratorLogin);
            if(ModeratorName != null) request.SetValue("moderator_name", ModeratorName);
            if(LastActivatedAt != null) request.SetValue("last_activated_at", LastActivatedAt);
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
