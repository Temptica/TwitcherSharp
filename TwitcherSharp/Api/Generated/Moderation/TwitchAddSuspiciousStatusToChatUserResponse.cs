using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchAddSuspiciousStatusToChatUserResponse : RefCounted, ITwitcherSharp<TwitchAddSuspiciousStatusToChatUserResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchAddSuspiciousStatusToChatUserResponse object.
    /// </summary> 
    public static TwitchAddSuspiciousStatusToChatUserResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchAddSuspiciousStatusToChatUserResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_add_suspicious_status_to_chat_user.gd", "Response");
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
    /// An array with one object containing information about the suspicious user action. 
    /// </summary>
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public string UserId { get; set; } = null!;
        public string BroadcasterId { get; set; } = null!;
        public string ModeratorId { get; set; } = null!;
        public string UpdatedAt { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string[] Types { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                UserId = data.Read("user_id", static v => v.AsString()),
                BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
                ModeratorId = data.Read("moderator_id", static v => v.AsString()),
                UpdatedAt = data.Read("updated_at", static v => v.AsString()),
                Status = data.Read("status", static v => v.AsString()),
                Types = data.Read("types", static v => v.AsStringArray()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_add_suspicious_status_to_chat_user.gd", "ResponseData");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
            if(ModeratorId != null) request.SetValue("moderator_id", ModeratorId);
            if(UpdatedAt != null) request.SetValue("updated_at", UpdatedAt);
            if(Status != null) request.SetValue("status", Status);
            if(Types != null) request.SetValue("types", new Godot.Collections.Array<string>(Types));
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
