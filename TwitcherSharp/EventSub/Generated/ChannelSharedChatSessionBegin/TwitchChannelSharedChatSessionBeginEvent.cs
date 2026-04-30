using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelSharedChatSessionBegin;

public partial class TwitchChannelSharedChatSessionBeginEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelSharedChatSessionBeginEvent>
{
    /// <summary> 
    /// The unique identifier for the shared chat session.
    /// </summary>
    public string SessionId { get; set; }

    /// <summary> 
    /// The User ID of the channel in the subscription condition which is now active in the shared chat session.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The display name of the channel in the subscription condition which is now active in the shared chat session.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The user login of the channel in the subscription condition which is now active in the shared chat session.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The User ID of the host channel.
    /// </summary>
    public string HostBroadcasterUserId { get; set; }

    /// <summary> 
    /// The display name of the host channel.
    /// </summary>
    public string HostBroadcasterUserName { get; set; }

    /// <summary> 
    /// The user login of the host channel.
    /// </summary>
    public string HostBroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The list of participants in the session.
    /// </summary>
    public TwitchParticipants[] Participants { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelSharedChatSessionBeginEvent object.
    /// </summary> 
    public static TwitchChannelSharedChatSessionBeginEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        var participantsArray = data.Get("participants").AsGodotArray<GodotObject>();
        return new TwitchChannelSharedChatSessionBeginEvent
        {
            SessionId = data.Get("session_id").AsString(),
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            HostBroadcasterUserId = data.Get("host_broadcaster_user_id").AsString(),
            HostBroadcasterUserName = data.Get("host_broadcaster_user_name").AsString(),
            HostBroadcasterUserLogin = data.Get("host_broadcaster_user_login").AsString(),
            Participants = participantsArray.Select(TwitchParticipants.FromObject).ToArray(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_shared_chat_session_begin.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("session_id", SessionId);
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("host_broadcaster_user_id", HostBroadcasterUserId);
        request.Set("host_broadcaster_user_name", HostBroadcasterUserName);
        request.Set("host_broadcaster_user_login", HostBroadcasterUserLogin);
        if(Participants != null) request.Set("participants", Participants?.ToGodotArray());
        return request;
    }


    public partial class TwitchParticipants : RefCounted, ITwitcherSharpEventSub<TwitchParticipants>
    {
        /// <summary> 
        /// The User ID of the participant channel.
        /// </summary>
        public string BroadcasterUserId { get; set; }
    
        /// <summary> 
        /// The display name of the participant channel.
        /// </summary>
        public string BroadcasterUserName { get; set; }
    
        /// <summary> 
        /// The user login of the participant channel.
        /// </summary>
        public string BroadcasterUserLogin { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchParticipants object.
        /// </summary> 
        public static TwitchParticipants FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchParticipants
            {
                BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
                BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
                BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_shared_chat_session_begin.gd");
            var participantsClass = script.Get("Participants").As<GDScript>();
            var request = participantsClass.New().AsGodotObject();
            request.Set("broadcaster_user_id", BroadcasterUserId);
            request.Set("broadcaster_user_name", BroadcasterUserName);
            request.Set("broadcaster_user_login", BroadcasterUserLogin);
            return request;
        }
    }
}
