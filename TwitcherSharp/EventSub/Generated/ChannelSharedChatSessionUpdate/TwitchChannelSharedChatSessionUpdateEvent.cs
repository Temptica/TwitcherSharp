using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSharedChatSessionUpdate;

public partial class TwitchChannelSharedChatSessionUpdateEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelSharedChatSessionUpdateEvent>
{
    private Variant _data;
    
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
    public TwitchParticipants[]? Participants { get => field ??= _data.GetArray<TwitchParticipants>("participants"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSharedChatSessionUpdateEvent object.
    /// </summary> 
    public static TwitchChannelSharedChatSessionUpdateEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelSharedChatSessionUpdateEvent
        {
            SessionId = data.Read("session_id", static v => v.AsString()),
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            HostBroadcasterUserId = data.Read("host_broadcaster_user_id", static v => v.AsString()),
            HostBroadcasterUserName = data.Read("host_broadcaster_user_name", static v => v.AsString()),
            HostBroadcasterUserLogin = data.Read("host_broadcaster_user_login", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_shared_chat_session_update.gd", "Event");
        if(SessionId != null) request.SetValue("session_id", SessionId);
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(HostBroadcasterUserId != null) request.SetValue("host_broadcaster_user_id", HostBroadcasterUserId);
        if(HostBroadcasterUserName != null) request.SetValue("host_broadcaster_user_name", HostBroadcasterUserName);
        if(HostBroadcasterUserLogin != null) request.SetValue("host_broadcaster_user_login", HostBroadcasterUserLogin);
        if(Participants != null) request.SetArray("participants", Participants);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }


    public partial class TwitchParticipants : RefCounted, ITwitcherSharpEventSub<TwitchParticipants>
    {
        private Variant _data;
        
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
                BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
                BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
                BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_shared_chat_session_update.gd", "Participants");
            if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
            if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
            if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
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
