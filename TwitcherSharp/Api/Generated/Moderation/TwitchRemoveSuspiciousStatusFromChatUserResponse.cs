using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Moderation;

public partial class TwitchRemoveSuspiciousStatusFromChatUserResponse : RefCounted, ITwitcherSharp<TwitchRemoveSuspiciousStatusFromChatUserResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchRemoveSuspiciousStatusFromChatUserResponse object.
    /// </summary> 
    public static TwitchRemoveSuspiciousStatusFromChatUserResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchRemoveSuspiciousStatusFromChatUserResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_remove_suspicious_status_from_chat_user.gd", "Response");
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
                UserId = data.ReadAsString("user_id"),
                BroadcasterId = data.ReadAsString("broadcaster_id"),
                ModeratorId = data.ReadAsString("moderator_id"),
                UpdatedAt = data.ReadAsString("updated_at"),
                Status = data.ReadAsString("status"),
                Types = data.ReadAsStringArray("types"),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_remove_suspicious_status_from_chat_user.gd", "ResponseData");
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
