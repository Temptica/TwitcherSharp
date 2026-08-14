using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSharedChatSessionUpdate;

public partial class TwitchChannelSharedChatSessionUpdateEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelSharedChatSessionUpdateEvent>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The unique identifier for the shared chat session.
    /// </summary>
    public string? SessionId { get; set; }

    /// <summary> 
    /// The User ID of the channel in the subscription condition.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The display name of the channel in the subscription condition.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The user login of the channel in the subscription condition.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The User ID of the host channel.
    /// </summary>
    public string? HostBroadcasterUserId { get; set; }

    /// <summary> 
    /// The display name of the host channel.
    /// </summary>
    public string? HostBroadcasterUserName { get; set; }

    /// <summary> 
    /// The user login of the host channel.
    /// </summary>
    public string? HostBroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The list of participants in the session.
    /// </summary>
    public TwitchParticipants[]? Participants { get => field ??= _data?.GetArray<TwitchParticipants>("participants"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSharedChatSessionUpdateEvent object.
    /// </summary> 
    public static TwitchChannelSharedChatSessionUpdateEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelSharedChatSessionUpdateEvent
        {
            SessionId = data.Get("session_id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            HostBroadcasterUserId = data.Get("host_broadcaster_user_id").AsString(),
            HostBroadcasterUserName = data.Get("host_broadcaster_user_name").AsString(),
            HostBroadcasterUserLogin = data.Get("host_broadcaster_user_login").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_shared_chat_session_update.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        if(SessionId != null) request.Set("session_id", SessionId);
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(HostBroadcasterUserId != null) request.Set("host_broadcaster_user_id", HostBroadcasterUserId);
        if(HostBroadcasterUserName != null) request.Set("host_broadcaster_user_name", HostBroadcasterUserName);
        if(HostBroadcasterUserLogin != null) request.Set("host_broadcaster_user_login", HostBroadcasterUserLogin);
        if(Participants != null) request.Set("participants", Participants.ToGodotArray());
        return request;
    }


    public partial class TwitchParticipants : RefCounted, ITwitcherSharpEventSub<TwitchParticipants>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The User ID of the participant channel.
        /// </summary>
        public string? BroadcasterUserId { get; set; }
    
        /// <summary> 
        /// The display name of the participant channel.
        /// </summary>
        public string? BroadcasterUserName { get; set; }
    
        /// <summary> 
        /// The user login of the participant channel.
        /// </summary>
        public string? BroadcasterUserLogin { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchParticipants object.
        /// </summary> 
        public static TwitchParticipants? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchParticipants
            {
                BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
                BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
                BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_shared_chat_session_update.gd");
            var participantsClass = script.Get("Participants").As<GDScript>();
            var request = participantsClass.New().AsGodotObject();
            if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
            if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
            if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
            return request;
        }
    }
}
