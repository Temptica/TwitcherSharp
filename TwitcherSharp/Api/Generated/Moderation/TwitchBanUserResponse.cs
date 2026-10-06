using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchBanUserResponse : RefCounted, ITwitcherSharp<TwitchBanUserResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchBanUserResponse object.
    /// </summary> 
    public static TwitchBanUserResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchBanUserResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_ban_user.gd", "Response");
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
    /// A list that contains the user you successfully banned or put in a timeout. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public string BroadcasterId { get; set; } = null!;
        public string ModeratorId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string CreatedAt { get; set; } = null!;
        public string EndTime { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
                ModeratorId = data.Read("moderator_id", static v => v.AsString()),
                UserId = data.Read("user_id", static v => v.AsString()),
                CreatedAt = data.Read("created_at", static v => v.AsString()),
                EndTime = data.Read("end_time", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_ban_user.gd", "ResponseData");
            if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
            if(ModeratorId != null) request.SetValue("moderator_id", ModeratorId);
            if(UserId != null) request.SetValue("user_id", UserId);
            if(CreatedAt != null) request.SetValue("created_at", CreatedAt);
            if(EndTime != null) request.SetValue("end_time", EndTime);
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
