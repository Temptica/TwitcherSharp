using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetSharedChatSessionResponse : RefCounted, ITwitcherSharp<TwitchGetSharedChatSessionResponse>
{
    private Variant _data;
    public TwitchResponseData[] Data { get => field ??= _data.GetArray<TwitchResponseData>("data")!; set; } = null!;

    /// <summary> 
    /// Transforms the godot data into a TwitchGetSharedChatSessionResponse object.
    /// </summary> 
    public static TwitchGetSharedChatSessionResponse? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchGetSharedChatSessionResponse();
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_shared_chat_session.gd", "Response");
        if(Data != null) request.SetArray("data", Data);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private Variant _data;
        public string SessionId { get; set; } = null!;
        public string HostBroadcasterId { get; set; } = null!;
        public TwitchResponseParticipants[] Participants { get => field ??= _data.GetArray<TwitchResponseParticipants>("participants")!; set; } = null!;
        public string CreatedAt { get; set; } = null!;
        public string UpdatedAt { get; set; } = null!;
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                SessionId = data.Read("session_id", static v => v.AsString()),
                HostBroadcasterId = data.Read("host_broadcaster_id", static v => v.AsString()),
                CreatedAt = data.Read("created_at", static v => v.AsString()),
                UpdatedAt = data.Read("updated_at", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_shared_chat_session.gd", "ResponseData");
            if(SessionId != null) request.SetValue("session_id", SessionId);
            if(HostBroadcasterId != null) request.SetValue("host_broadcaster_id", HostBroadcasterId);
            if(Participants != null) request.SetArray("participants", Participants);
            if(CreatedAt != null) request.SetValue("created_at", CreatedAt);
            if(UpdatedAt != null) request.SetValue("updated_at", UpdatedAt);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
        
        /// <summary> 
        /// The list of participants in the session. 
        /// </summary>
        public partial class TwitchResponseParticipants : RefCounted, ITwitcherSharp<TwitchResponseParticipants>
        {
            private Variant _data;
            public string BroadcasterId { get; set; } = null!;
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseParticipants object.
            /// </summary> 
            public static TwitchResponseParticipants? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseParticipants
                {
                    BroadcasterId = data.Read("broadcaster_id", static v => v.AsString()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated/twitch_get_shared_chat_session.gd", "ResponseParticipants");
                if(BroadcasterId != null) request.SetValue("broadcaster_id", BroadcasterId);
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

}
