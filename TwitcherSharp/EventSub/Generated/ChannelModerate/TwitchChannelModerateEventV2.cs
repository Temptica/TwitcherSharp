using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelModerate;

public partial class TwitchChannelModerateEventV2 : Resource, ITwitcherSharpEventSub<TwitchChannelModerateEventV2>
{
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
    /// The action performed. Possible values are: bantimeoutunbanuntimeoutclearemoteonlyemoteonlyofffollowersfollowersoffuniquechatuniquechatoffslowslowoffsubscriberssubscribersoffunraiddeleteunvipvipraidadd_blocked_termadd_permitted_termremove_blocked_termremove_permitted_termmodunmodapprove_unban_requestdeny_unban_requestwarnshared_chat_banshared_chat_timeoutshared_chat_unbanshared_chat_untimeoutshared_chat_delete
    /// </summary>
    public string Action { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the followers command.
    /// </summary>
    public TwitchFollowers Followers { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the slow command.
    /// </summary>
    public TwitchSlow Slow { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the vip command.
    /// </summary>
    public TwitchVip Vip { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the unvip command.
    /// </summary>
    public TwitchUnvip Unvip { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the mod command.
    /// </summary>
    public TwitchMod Mod { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the unmod command.
    /// </summary>
    public TwitchUnmod Unmod { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the ban command.
    /// </summary>
    public TwitchBan Ban { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the unban command.
    /// </summary>
    public TwitchUnban Unban { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the timeout command.
    /// </summary>
    public TwitchTimeout Timeout { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the untimeout command.
    /// </summary>
    public TwitchUntimeout Untimeout { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the raid command.
    /// </summary>
    public TwitchRaid Raid { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the unraid command.
    /// </summary>
    public TwitchUnraid Unraid { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the delete command.
    /// </summary>
    public TwitchDelete Delete { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the automod terms changes.
    /// </summary>
    public TwitchAutomodTerms AutomodTerms { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with an unban request.
    /// </summary>
    public TwitchUnbanRequest UnbanRequest { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the warn command.
    /// </summary>
    public TwitchWarn Warn { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_ban event. Is null if action is not shared_chat_ban. This field has the same information as the ban field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchSharedChatBan SharedChatBan { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_unban event. Is null if action is not shared_chat_unban. This field has the same information as the unban field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchSharedChatUnban SharedChatUnban { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_timeout event. Is null if action is not shared_chat_timeout. This field has the same information as the timeout field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchSharedChatTimeout SharedChatTimeout { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_untimeout event. Is null if action is not shared_chat_untimeout. This field has the same information as the untimeout field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchSharedChatUntimeout SharedChatUntimeout { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_delete event. Is null if action is not shared_chat_delete. This field has the same information as the delete field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchSharedChatDelete SharedChatDelete { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelModerateEventV2 object.
    /// </summary> 
    public static TwitchChannelModerateEventV2 FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchChannelModerateEventV2
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
            Followers = data.Get("followers").As<TwitchFollowers>(),
            Slow = data.Get("slow").As<TwitchSlow>(),
            Vip = data.Get("vip").As<TwitchVip>(),
            Unvip = data.Get("unvip").As<TwitchUnvip>(),
            Mod = data.Get("mod").As<TwitchMod>(),
            Unmod = data.Get("unmod").As<TwitchUnmod>(),
            Ban = data.Get("ban").As<TwitchBan>(),
            Unban = data.Get("unban").As<TwitchUnban>(),
            Timeout = data.Get("timeout").As<TwitchTimeout>(),
            Untimeout = data.Get("untimeout").As<TwitchUntimeout>(),
            Raid = data.Get("raid").As<TwitchRaid>(),
            Unraid = data.Get("unraid").As<TwitchUnraid>(),
            Delete = data.Get("delete").As<TwitchDelete>(),
            AutomodTerms = data.Get("automod_terms").As<TwitchAutomodTerms>(),
            UnbanRequest = data.Get("unban_request").As<TwitchUnbanRequest>(),
            Warn = data.Get("warn").As<TwitchWarn>(),
            SharedChatBan = data.Get("shared_chat_ban").As<TwitchSharedChatBan>(),
            SharedChatUnban = data.Get("shared_chat_unban").As<TwitchSharedChatUnban>(),
            SharedChatTimeout = data.Get("shared_chat_timeout").As<TwitchSharedChatTimeout>(),
            SharedChatUntimeout = data.Get("shared_chat_untimeout").As<TwitchSharedChatUntimeout>(),
            SharedChatDelete = data.Get("shared_chat_delete").As<TwitchSharedChatDelete>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
        var channelModerateEventV2V2Class = script.Get("ChannelModerateEventV2V2").AsGodotObject();
        var request = channelModerateEventV2V2Class.Call("new").AsGodotObject();
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
        request.Set("followers", Followers);
        request.Set("slow", Slow);
        request.Set("vip", Vip);
        request.Set("unvip", Unvip);
        request.Set("mod", Mod);
        request.Set("unmod", Unmod);
        request.Set("ban", Ban);
        request.Set("unban", Unban);
        request.Set("timeout", Timeout);
        request.Set("untimeout", Untimeout);
        request.Set("raid", Raid);
        request.Set("unraid", Unraid);
        request.Set("delete", Delete);
        request.Set("automod_terms", AutomodTerms);
        request.Set("unban_request", UnbanRequest);
        request.Set("warn", Warn);
        request.Set("shared_chat_ban", SharedChatBan);
        request.Set("shared_chat_unban", SharedChatUnban);
        request.Set("shared_chat_timeout", SharedChatTimeout);
        request.Set("shared_chat_untimeout", SharedChatUntimeout);
        request.Set("shared_chat_delete", SharedChatDelete);
        return request;
    }

    public partial class TwitchFollowers : Resource, ITwitcherSharpEventSub<TwitchFollowers>
    {
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
            return new TwitchFollowers
            {
                FollowDurationMinutes = data.Get("follow_duration_minutes").AsInt32(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var followersClass = script.Get("Followers").AsGodotObject();
            var request = followersClass.Call("new").AsGodotObject();
            request.Set("follow_duration_minutes", FollowDurationMinutes);
            return request;
        }
    }

    public partial class TwitchSlow : Resource, ITwitcherSharpEventSub<TwitchSlow>
    {
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
            return new TwitchSlow
            {
                WaitTimeSeconds = data.Get("wait_time_seconds").AsInt32(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var slowClass = script.Get("Slow").AsGodotObject();
            var request = slowClass.Call("new").AsGodotObject();
            request.Set("wait_time_seconds", WaitTimeSeconds);
            return request;
        }
    }

    public partial class TwitchVip : Resource, ITwitcherSharpEventSub<TwitchVip>
    {
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
            return new TwitchVip
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var vipClass = script.Get("Vip").AsGodotObject();
            var request = vipClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchUnvip : Resource, ITwitcherSharpEventSub<TwitchUnvip>
    {
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
            return new TwitchUnvip
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var unvipClass = script.Get("Unvip").AsGodotObject();
            var request = unvipClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchMod : Resource, ITwitcherSharpEventSub<TwitchMod>
    {
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
            return new TwitchMod
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var modClass = script.Get("Mod").AsGodotObject();
            var request = modClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchUnmod : Resource, ITwitcherSharpEventSub<TwitchUnmod>
    {
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
            return new TwitchUnmod
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var unmodClass = script.Get("Unmod").AsGodotObject();
            var request = unmodClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchBan : Resource, ITwitcherSharpEventSub<TwitchBan>
    {
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
            return new TwitchBan
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                Reason = data.Get("reason").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var banClass = script.Get("Ban").AsGodotObject();
            var request = banClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("reason", Reason);
            return request;
        }
    }

    public partial class TwitchUnban : Resource, ITwitcherSharpEventSub<TwitchUnban>
    {
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
            return new TwitchUnban
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var unbanClass = script.Get("Unban").AsGodotObject();
            var request = unbanClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchTimeout : Resource, ITwitcherSharpEventSub<TwitchTimeout>
    {
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
        /// Optional. The reason given for the timeout.
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
            return new TwitchTimeout
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                Reason = data.Get("reason").AsString(),
                ExpiresAt = data.Get("expires_at").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var timeoutClass = script.Get("Timeout").AsGodotObject();
            var request = timeoutClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("reason", Reason);
            request.Set("expires_at", ExpiresAt);
            return request;
        }
    }

    public partial class TwitchUntimeout : Resource, ITwitcherSharpEventSub<TwitchUntimeout>
    {
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
            return new TwitchUntimeout
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var untimeoutClass = script.Get("Untimeout").AsGodotObject();
            var request = untimeoutClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchRaid : Resource, ITwitcherSharpEventSub<TwitchRaid>
    {
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
            return new TwitchRaid
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                ViewerCount = data.Get("viewer_count").AsInt32(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var raidClass = script.Get("Raid").AsGodotObject();
            var request = raidClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("viewer_count", ViewerCount);
            return request;
        }
    }

    public partial class TwitchUnraid : Resource, ITwitcherSharpEventSub<TwitchUnraid>
    {
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
            return new TwitchUnraid
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var unraidClass = script.Get("Unraid").AsGodotObject();
            var request = unraidClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchDelete : Resource, ITwitcherSharpEventSub<TwitchDelete>
    {
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
            return new TwitchDelete
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                MessageId = data.Get("message_id").AsString(),
                MessageBody = data.Get("message_body").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var deleteClass = script.Get("Delete").AsGodotObject();
            var request = deleteClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("message_id", MessageId);
            request.Set("message_body", MessageBody);
            return request;
        }
    }

    public partial class TwitchAutomodTerms : Resource, ITwitcherSharpEventSub<TwitchAutomodTerms>
    {
        /// <summary> 
        /// Either “add” or “remove”.
        /// </summary>
        public string Action { get; set; }
    
        /// <summary> 
        /// Either “blocked” or “permitted”.
        /// </summary>
        public string List { get; set; }
    
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
            return new TwitchAutomodTerms
            {
                Action = data.Get("action").AsString(),
                List = data.Get("list").AsString(),
                FromAutomod = data.Get("from_automod").AsBool(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var automodTermsClass = script.Get("AutomodTerms").AsGodotObject();
            var request = automodTermsClass.Call("new").AsGodotObject();
            request.Set("action", Action);
            request.Set("list", List);
            request.Set("from_automod", FromAutomod);
            return request;
        }
    }

    public partial class TwitchUnbanRequest : Resource, ITwitcherSharpEventSub<TwitchUnbanRequest>
    {
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
            return new TwitchUnbanRequest
            {
                IsApproved = data.Get("is_approved").AsBool(),
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                ModeratorMessage = data.Get("moderator_message").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var unbanRequestClass = script.Get("UnbanRequest").AsGodotObject();
            var request = unbanRequestClass.Call("new").AsGodotObject();
            request.Set("is_approved", IsApproved);
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("moderator_message", ModeratorMessage);
            return request;
        }
    }

    public partial class TwitchWarn : Resource, ITwitcherSharpEventSub<TwitchWarn>
    {
        /// <summary> 
        /// The ID of the user being warned.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The login of the user being warned.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user being warned.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// Optional. Reason given for the warning.
        /// </summary>
        public string Reason { get; set; }
    
        /// <summary> 
        /// Optional. Chat rules cited for the warning.
        /// </summary>
        public string[] ChatRulesCited { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchWarn object.
        /// </summary> 
        public static TwitchWarn FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchWarn
            {
                UserId = data.Get("user_id").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                UserName = data.Get("user_name").AsString(),
                Reason = data.Get("reason").AsString(),
                ChatRulesCited = data.Get("chat_rules_cited").AsStringArray(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var warnClass = script.Get("Warn").AsGodotObject();
            var request = warnClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_login", UserLogin);
            request.Set("user_name", UserName);
            request.Set("reason", Reason);
            request.Set("chat_rules_cited", ChatRulesCited);
            return request;
        }
    }

    public partial class TwitchSharedChatBan : Resource, ITwitcherSharpEventSub<TwitchSharedChatBan>
    {
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSharedChatBan object.
        /// </summary> 
        public static TwitchSharedChatBan FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchSharedChatBan
            {
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var sharedChatBanClass = script.Get("SharedChatBan").AsGodotObject();
            var request = sharedChatBanClass.Call("new").AsGodotObject();
            return request;
        }
    }

    public partial class TwitchSharedChatUnban : Resource, ITwitcherSharpEventSub<TwitchSharedChatUnban>
    {
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSharedChatUnban object.
        /// </summary> 
        public static TwitchSharedChatUnban FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchSharedChatUnban
            {
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var sharedChatUnbanClass = script.Get("SharedChatUnban").AsGodotObject();
            var request = sharedChatUnbanClass.Call("new").AsGodotObject();
            return request;
        }
    }

    public partial class TwitchSharedChatTimeout : Resource, ITwitcherSharpEventSub<TwitchSharedChatTimeout>
    {
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSharedChatTimeout object.
        /// </summary> 
        public static TwitchSharedChatTimeout FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchSharedChatTimeout
            {
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var sharedChatTimeoutClass = script.Get("SharedChatTimeout").AsGodotObject();
            var request = sharedChatTimeoutClass.Call("new").AsGodotObject();
            return request;
        }
    }

    public partial class TwitchSharedChatUntimeout : Resource, ITwitcherSharpEventSub<TwitchSharedChatUntimeout>
    {
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSharedChatUntimeout object.
        /// </summary> 
        public static TwitchSharedChatUntimeout FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchSharedChatUntimeout
            {
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var sharedChatUntimeoutClass = script.Get("SharedChatUntimeout").AsGodotObject();
            var request = sharedChatUntimeoutClass.Call("new").AsGodotObject();
            return request;
        }
    }

    public partial class TwitchSharedChatDelete : Resource, ITwitcherSharpEventSub<TwitchSharedChatDelete>
    {
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSharedChatDelete object.
        /// </summary> 
        public static TwitchSharedChatDelete FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchSharedChatDelete
            {
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var sharedChatDeleteClass = script.Get("SharedChatDelete").AsGodotObject();
            var request = sharedChatDeleteClass.Call("new").AsGodotObject();
            return request;
        }
    }
}
