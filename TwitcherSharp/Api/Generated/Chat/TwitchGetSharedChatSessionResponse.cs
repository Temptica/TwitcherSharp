using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Chat;

public partial class TwitchGetSharedChatSessionResponse : RefCounted, ITwitcherSharp<TwitchGetSharedChatSessionResponse>
{
    private GodotObject _data;
    public TwitchResponseData[] Data { get => field ??= _data?.GetArray<TwitchResponseData>("data"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetSharedChatSessionResponse object.
    /// </summary> 
    public static TwitchGetSharedChatSessionResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchGetSharedChatSessionResponse();
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_shared_chat_session.gd");
        var responseClass = script.Get("Response").AsGodotObject();
        var request = responseClass.Call("new").AsGodotObject();
        if(Data != null) request.Set("data", Data?.ToGodotArray());
        return request;
    }
    public partial class TwitchResponseData : RefCounted, ITwitcherSharp<TwitchResponseData>
    {
        private GodotObject _data;
        public string SessionId { get; set; }
        public string HostBroadcasterId { get; set; }
        public TwitchResponseParticipants[] Participants { get => field ??= _data?.GetArray<TwitchResponseParticipants>("participants"); set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResponseData object.
        /// </summary> 
        public static TwitchResponseData FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchResponseData
            {
                SessionId = data.Get("session_id").AsString(),
                HostBroadcasterId = data.Get("host_broadcaster_id").AsString(),
                CreatedAt = data.Get("created_at").AsString(),
                UpdatedAt = data.Get("updated_at").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_shared_chat_session.gd");
            var twitchResponseDataClass = script.Get("ResponseData").AsGodotObject();
            var request = twitchResponseDataClass.Call("new").AsGodotObject();
            request.Set("session_id", SessionId);
            request.Set("host_broadcaster_id", HostBroadcasterId);
            if(Participants != null) request.Set("participants", Participants?.ToGodotArray());
            request.Set("created_at", CreatedAt);
            request.Set("updated_at", UpdatedAt);
            return request;
        }
        
        /// <summary> 
        /// The list of participants in the session. 
        /// </summary>
        public partial class TwitchResponseParticipants : RefCounted, ITwitcherSharp<TwitchResponseParticipants>
        {
            private GodotObject _data;
            public string BroadcasterId { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchResponseParticipants object.
            /// </summary> 
            public static TwitchResponseParticipants FromObject(GodotObject data)
            {
                if(data == null) return null;
                var instance = new TwitchResponseParticipants
                {
                    BroadcasterId = data.Get("broadcaster_id").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_shared_chat_session.gd");
                var twitchResponseParticipantsClass = script.Get("ResponseParticipants").AsGodotObject();
                var request = twitchResponseParticipantsClass.Call("new").AsGodotObject();
                request.Set("broadcaster_id", BroadcasterId);
                return request;
            }
        
        }
    
    }

}
