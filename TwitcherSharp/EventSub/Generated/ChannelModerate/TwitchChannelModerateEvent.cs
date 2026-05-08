using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelModerate;

public partial class TwitchChannelModerateEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelModerateEvent>
{
    private GodotObject _data;
    
    /// <summary> 
    /// The ID of the broadcaster.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the broadcaster.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user name of the broadcaster.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The channel in which the action originally occurred. Is the same as the broadcaster_user_id if not in shared chat.
    /// </summary>
    public string SourceBroadcasterUserId { get; set; }

    /// <summary> 
    /// The channel in which the action originally occurred. Is the same as the broadcaster_user_login if not in shared chat.
    /// </summary>
    public string SourceBroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The channel in which the action originally occurred. Is null when the moderator action happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public string SourceBroadcasterUserName { get; set; }

    /// <summary> 
    /// The ID of the moderator who performed the action.
    /// </summary>
    public string ModeratorUserId { get; set; }

    /// <summary> 
    /// The login of the moderator.
    /// </summary>
    public string ModeratorUserLogin { get; set; }

    /// <summary> 
    /// The user name of the moderator.
    /// </summary>
    public string ModeratorUserName { get; set; }

    /// <summary> 
    /// The type of action: Possible values are: bantimeoutunbanuntimeoutclearemoteonlyemoteonlyofffollowersfollowersoffuniquechatuniquechatoffslowslowoffsubscriberssubscribersoffunraiddeleteunvipvipraidadd_blocked_termadd_permitted_termremove_blocked_termremove_permitted_termmodunmodapprove_unban_requestdeny_unban_requestshared_chat_banshared_chat_timeoutshared_chat_untimeoutshared_chat_unbanshared_chat_delete
    /// </summary>
    public string Action { get; set; }

    /// <summary> 
    /// Optional.. Metadata associated with the followers command.
    /// </summary>
    public TwitchFollowers Followers { get => field ??= _data?.Get<TwitchFollowers>("followers"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the slow command.
    /// </summary>
    public TwitchSlow Slow { get => field ??= _data?.Get<TwitchSlow>("slow"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the vip command.
    /// </summary>
    public TwitchVip Vip { get => field ??= _data?.Get<TwitchVip>("vip"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the unvip command.
    /// </summary>
    public TwitchUnvip Unvip { get => field ??= _data?.Get<TwitchUnvip>("unvip"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the mod command.
    /// </summary>
    public TwitchMod Mod { get => field ??= _data?.Get<TwitchMod>("mod"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the unmod command.
    /// </summary>
    public TwitchUnmod Unmod { get => field ??= _data?.Get<TwitchUnmod>("unmod"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the ban command.
    /// </summary>
    public TwitchBan Ban { get => field ??= _data?.Get<TwitchBan>("ban"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the unban command.
    /// </summary>
    public TwitchUnban Unban { get => field ??= _data?.Get<TwitchUnban>("unban"); set; }

    /// <summary> 
    /// Optional.. Metadata associated with the timeout command.
    /// </summary>
    public TwitchTimeout Timeout { get => field ??= _data?.Get<TwitchTimeout>("timeout"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the untimeout command.
    /// </summary>
    public TwitchUntimeout Untimeout { get => field ??= _data?.Get<TwitchUntimeout>("untimeout"); set; }

    /// <summary> 
    /// Optional.. Metadata associated with the raid command.
    /// </summary>
    public TwitchRaid Raid { get => field ??= _data?.Get<TwitchRaid>("raid"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the unraid command.
    /// </summary>
    public TwitchUnraid Unraid { get => field ??= _data?.Get<TwitchUnraid>("unraid"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the delete command.
    /// </summary>
    public TwitchDelete Delete { get => field ??= _data?.Get<TwitchDelete>("delete"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the automod terms changes.
    /// </summary>
    public TwitchAutomodTerms AutomodTerms { get => field ??= _data?.Get<TwitchAutomodTerms>("automod_terms"); set; }

    /// <summary> 
    /// Optional. Metadata associated with an unban request.
    /// </summary>
    public TwitchUnbanRequest UnbanRequest { get => field ??= _data?.Get<TwitchUnbanRequest>("unban_request"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_ban event. Is null if action is not shared_chat_ban. This field has the same information as the ban field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchBan SharedChatBan { get => field ??= _data?.Get<TwitchBan>("shared_chat_ban"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_unban event. Is null if action is not shared_chat_unban. This field has the same information as the unban field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchUnban SharedChatUnban { get => field ??= _data?.Get<TwitchUnban>("shared_chat_unban"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_timeout event. Is null if action is not shared_chat_timeout. This field has the same information as the timeout field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchTimeout SharedChatTimeout { get => field ??= _data?.Get<TwitchTimeout>("shared_chat_timeout"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_untimeout event. Is null if action is not shared_chat_untimeout. This field has the same information as the untimeout field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchUntimeout SharedChatUntimeout { get => field ??= _data?.Get<TwitchUntimeout>("shared_chat_untimeout"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_delete event. Is null if action is not shared_chat_delete. This field has the same information as the delete field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchDelete SharedChatDelete { get => field ??= _data?.Get<TwitchDelete>("shared_chat_delete"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelModerateEvent object.
    /// </summary> 
    public static TwitchChannelModerateEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelModerateEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            SourceBroadcasterUserId = data.Get("source_broadcaster_user_id").AsString(),
            SourceBroadcasterUserLogin = data.Get("source_broadcaster_user_login").AsString(),
            SourceBroadcasterUserName = data.Get("source_broadcaster_user_name").AsString(),
            ModeratorUserId = data.Get("moderator_user_id").AsString(),
            ModeratorUserLogin = data.Get("moderator_user_login").AsString(),
            ModeratorUserName = data.Get("moderator_user_name").AsString(),
            Action = data.Get("action").AsString(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("source_broadcaster_user_id", SourceBroadcasterUserId);
        request.Set("source_broadcaster_user_login", SourceBroadcasterUserLogin);
        request.Set("source_broadcaster_user_name", SourceBroadcasterUserName);
        request.Set("moderator_user_id", ModeratorUserId);
        request.Set("moderator_user_login", ModeratorUserLogin);
        request.Set("moderator_user_name", ModeratorUserName);
        request.Set("action", Action);
        request.Set("followers", Followers?.ToGodotObject());
        request.Set("slow", Slow?.ToGodotObject());
        request.Set("vip", Vip?.ToGodotObject());
        request.Set("unvip", Unvip?.ToGodotObject());
        request.Set("mod", Mod?.ToGodotObject());
        request.Set("unmod", Unmod?.ToGodotObject());
        request.Set("ban", Ban?.ToGodotObject());
        request.Set("unban", Unban?.ToGodotObject());
        request.Set("timeout", Timeout?.ToGodotObject());
        request.Set("untimeout", Untimeout?.ToGodotObject());
        request.Set("raid", Raid?.ToGodotObject());
        request.Set("unraid", Unraid?.ToGodotObject());
        request.Set("delete", Delete?.ToGodotObject());
        request.Set("automod_terms", AutomodTerms?.ToGodotObject());
        request.Set("unban_request", UnbanRequest?.ToGodotObject());
        request.Set("shared_chat_ban", SharedChatBan?.ToGodotObject());
        request.Set("shared_chat_unban", SharedChatUnban?.ToGodotObject());
        request.Set("shared_chat_timeout", SharedChatTimeout?.ToGodotObject());
        request.Set("shared_chat_untimeout", SharedChatUntimeout?.ToGodotObject());
        request.Set("shared_chat_delete", SharedChatDelete?.ToGodotObject());
        return request;
    }


    public partial class TwitchFollowers : RefCounted, ITwitcherSharpEventSub<TwitchFollowers>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The length of time, in minutes, that the followers must have followed the broadcaster to participate in the chat room.
        /// </summary>
        public int FollowDurationMinutes { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchFollowers object.
        /// </summary> 
        public static TwitchFollowers FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchFollowers
            {
                FollowDurationMinutes = data.Get("follow_duration_minutes").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var followersClass = script.Get("Followers").As<GDScript>();
            var request = followersClass.New().AsGodotObject();
            request.Set("follow_duration_minutes", FollowDurationMinutes);
            return request;
        }
    }

    public partial class TwitchSlow : RefCounted, ITwitcherSharpEventSub<TwitchSlow>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The amount of time, in seconds, that users need to wait between sending messages.
        /// </summary>
        public int WaitTimeSeconds { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSlow object.
        /// </summary> 
        public static TwitchSlow FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchSlow
            {
                WaitTimeSeconds = data.Get("wait_time_seconds").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var slowClass = script.Get("Slow").As<GDScript>();
            var request = slowClass.New().AsGodotObject();
            request.Set("wait_time_seconds", WaitTimeSeconds);
            return request;
        }
    }

    public partial class TwitchVip : RefCounted, ITwitcherSharpEventSub<TwitchVip>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The ID of the user gaining VIP status.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The login of the user gaining VIP status.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user gaining VIP status.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchVip object.
        /// </summary> 
        public static TwitchVip FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchVip
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var vipClass = script.Get("Vip").As<GDScript>();
            var request = vipClass.New().AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchUnvip : RefCounted, ITwitcherSharpEventSub<TwitchUnvip>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The ID of the user losing VIP status.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The login of the user losing VIP status.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user losing VIP status.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchUnvip object.
        /// </summary> 
        public static TwitchUnvip FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchUnvip
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var unvipClass = script.Get("Unvip").As<GDScript>();
            var request = unvipClass.New().AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchMod : RefCounted, ITwitcherSharpEventSub<TwitchMod>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The ID of the user gaining mod status.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The login of the user gaining mod status.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user gaining mod status.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMod object.
        /// </summary> 
        public static TwitchMod FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchMod
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var modClass = script.Get("Mod").As<GDScript>();
            var request = modClass.New().AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchUnmod : RefCounted, ITwitcherSharpEventSub<TwitchUnmod>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The ID of the user losing mod status.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The login of the user losing mod status.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user losing mod status.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchUnmod object.
        /// </summary> 
        public static TwitchUnmod FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchUnmod
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var unmodClass = script.Get("Unmod").As<GDScript>();
            var request = unmodClass.New().AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchBan : RefCounted, ITwitcherSharpEventSub<TwitchBan>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The ID of the user being banned.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The login of the user being banned.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user being banned.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// Optional. Reason given for the ban.
        /// </summary>
        public string Reason { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBan object.
        /// </summary> 
        public static TwitchBan FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchBan
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                Reason = data.Get("reason").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var banClass = script.Get("Ban").As<GDScript>();
            var request = banClass.New().AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("reason", Reason);
            return request;
        }
    }

    public partial class TwitchUnban : RefCounted, ITwitcherSharpEventSub<TwitchUnban>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The ID of the user being unbanned.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The login of the user being unbanned.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user being unbanned.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchUnban object.
        /// </summary> 
        public static TwitchUnban FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchUnban
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var unbanClass = script.Get("Unban").As<GDScript>();
            var request = unbanClass.New().AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchTimeout : RefCounted, ITwitcherSharpEventSub<TwitchTimeout>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The ID of the user being timed out.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The login of the user being timed out.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user being timed out.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// Optional.. The reason given for the timeout.
        /// </summary>
        public string Reason { get; set; }
    
        /// <summary> 
        /// The time at which the timeout ends.
        /// </summary>
        public string ExpiresAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchTimeout object.
        /// </summary> 
        public static TwitchTimeout FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchTimeout
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                Reason = data.Get("reason").AsString(),
                ExpiresAt = data.Get("expires_at").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var timeoutClass = script.Get("Timeout").As<GDScript>();
            var request = timeoutClass.New().AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("reason", Reason);
            request.Set("expires_at", ExpiresAt);
            return request;
        }
    }

    public partial class TwitchUntimeout : RefCounted, ITwitcherSharpEventSub<TwitchUntimeout>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The ID of the user being untimed out.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The login of the user being untimed out.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user untimed out.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchUntimeout object.
        /// </summary> 
        public static TwitchUntimeout FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchUntimeout
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var untimeoutClass = script.Get("Untimeout").As<GDScript>();
            var request = untimeoutClass.New().AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchRaid : RefCounted, ITwitcherSharpEventSub<TwitchRaid>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The ID of the user being raided.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The login of the user being raided.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user raided.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// The viewer count.
        /// </summary>
        public int ViewerCount { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchRaid object.
        /// </summary> 
        public static TwitchRaid FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchRaid
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                ViewerCount = data.Get("viewer_count").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var raidClass = script.Get("Raid").As<GDScript>();
            var request = raidClass.New().AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("viewer_count", ViewerCount);
            return request;
        }
    }

    public partial class TwitchUnraid : RefCounted, ITwitcherSharpEventSub<TwitchUnraid>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The ID of the user no longer being raided.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The login of the user no longer being raided.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the no longer user raided.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchUnraid object.
        /// </summary> 
        public static TwitchUnraid FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchUnraid
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var unraidClass = script.Get("Unraid").As<GDScript>();
            var request = unraidClass.New().AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchDelete : RefCounted, ITwitcherSharpEventSub<TwitchDelete>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The ID of the user whose message is being deleted.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The login of the user.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// The ID of the message being deleted.
        /// </summary>
        public string MessageId { get; set; }
    
        /// <summary> 
        /// The message body of the message being deleted.
        /// </summary>
        public string MessageBody { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchDelete object.
        /// </summary> 
        public static TwitchDelete FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchDelete
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                MessageId = data.Get("message_id").AsString(),
                MessageBody = data.Get("message_body").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var deleteClass = script.Get("Delete").As<GDScript>();
            var request = deleteClass.New().AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("message_id", MessageId);
            request.Set("message_body", MessageBody);
            return request;
        }
    }

    public partial class TwitchAutomodTerms : RefCounted, ITwitcherSharpEventSub<TwitchAutomodTerms>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// Either “add” or “remove”.
        /// </summary>
        public string Action { get; set; }
    
        /// <summary> 
        /// Either “blocked” or “permitted”.
        /// </summary>
        public string List { get; set; }
    
        /// <summary> 
        /// Terms being added or removed.
        /// </summary>
        public string[] Terms { get; set; }
    
        /// <summary> 
        /// Whether the terms were added due to an Automod message approve/deny action.
        /// </summary>
        public bool FromAutomod { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchAutomodTerms object.
        /// </summary> 
        public static TwitchAutomodTerms FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchAutomodTerms
            {
                Action = data.Get("action").AsString(),
                List = data.Get("list").AsString(),
                FromAutomod = data.Get("from_automod").AsBool(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var automodTermsClass = script.Get("AutomodTerms").As<GDScript>();
            var request = automodTermsClass.New().AsGodotObject();
            request.Set("action", Action);
            request.Set("list", List);
            if(Terms != null) request.Set("terms", new Godot.Collections.Array<string>(Terms));
            request.Set("from_automod", FromAutomod);
            return request;
        }
    }

    public partial class TwitchUnbanRequest : RefCounted, ITwitcherSharpEventSub<TwitchUnbanRequest>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// Whether or not the unban request was approved or denied.
        /// </summary>
        public bool IsApproved { get; set; }
    
        /// <summary> 
        /// The ID of the banned user.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The login of the user.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// The message included by the moderator explaining their approval or denial.
        /// </summary>
        public string ModeratorMessage { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchUnbanRequest object.
        /// </summary> 
        public static TwitchUnbanRequest FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchUnbanRequest
            {
                IsApproved = data.Get("is_approved").AsBool(),
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                ModeratorMessage = data.Get("moderator_message").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var unbanRequestClass = script.Get("UnbanRequest").As<GDScript>();
            var request = unbanRequestClass.New().AsGodotObject();
            request.Set("is_approved", IsApproved);
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("moderator_message", ModeratorMessage);
            return request;
        }
    }
}
