using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelModerate;

public partial class TwitchChannelModerateEventV2 : RefCounted, ITwitcherSharpEventSub<TwitchChannelModerateEventV2>
{
    private GodotObject? _data;
    
    /// <summary> 
    /// The ID of the broadcaster.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The login of the broadcaster.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user name of the broadcaster.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The channel in which the action originally occurred. Is the same as the broadcaster_user_id if not in shared chat.
    /// </summary>
    public string? SourceBroadcasterUserId { get; set; }

    /// <summary> 
    /// The channel in which the action originally occurred. Is the same as the broadcaster_user_login if not in shared chat.
    /// </summary>
    public string? SourceBroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The channel in which the action originally occurred. Is **null** when the moderator action happens in the same channel as the broadcaster. Is not **null** when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public string? SourceBroadcasterUserName { get; set; }

    /// <summary> 
    /// The ID of the moderator who performed the action.
    /// </summary>
    public string? ModeratorUserId { get; set; }

    /// <summary> 
    /// The login of the moderator.
    /// </summary>
    public string? ModeratorUserLogin { get; set; }

    /// <summary> 
    /// The user name of the moderator.
    /// </summary>
    public string? ModeratorUserName { get; set; }

    /// <summary> 
    /// The action performed. Possible values:
    /// - `ban`
    /// - `timeout`
    /// - `unban`
    /// - `untimeout`
    /// - `clear`
    /// - `emoteonly`
    /// - `emoteonlyoff`
    /// - `followers`
    /// - `followersoff`
    /// - `uniquechat`
    /// - `uniquechatoff`
    /// - `slow`
    /// - `slowoff`
    /// - `subscribers`
    /// - `subscribersoff`
    /// - `unraid`
    /// - `delete`
    /// - `unvip`
    /// - `vip`
    /// - `raid`
    /// - `add_blocked_term`
    /// - `add_permitted_term`
    /// - `remove_blocked_term`
    /// - `remove_permitted_term`
    /// - `mod`
    /// - `unmod`
    /// - `approve_unban_request`
    /// - `deny_unban_request`
    /// - `warn`
    /// - `shared_chat_ban`
    /// - `shared_chat_timeout`
    /// - `shared_chat_unban`
    /// - `shared_chat_untimeout`
    /// - `shared_chat_delete`
    /// </summary>
    public string? Action { get; set; }

    /// <summary> 
    /// Metadata associated with the followers command.
    /// </summary>
    public TwitchFollowersV2? Followers { get => field ??= _data?.Get<TwitchFollowersV2>("followers"); set; }

    /// <summary> 
    /// Metadata associated with the slow command.
    /// </summary>
    public TwitchSlowV2? Slow { get => field ??= _data?.Get<TwitchSlowV2>("slow"); set; }

    /// <summary> 
    /// Metadata associated with the vip command.
    /// </summary>
    public TwitchVipV2? Vip { get => field ??= _data?.Get<TwitchVipV2>("vip"); set; }

    /// <summary> 
    /// Metadata associated with the unvip command.
    /// </summary>
    public TwitchUnvipV2? Unvip { get => field ??= _data?.Get<TwitchUnvipV2>("unvip"); set; }

    /// <summary> 
    /// Metadata associated with the mod command.
    /// </summary>
    public TwitchModV2? Mod { get => field ??= _data?.Get<TwitchModV2>("mod"); set; }

    /// <summary> 
    /// Metadata associated with the unmod command.
    /// </summary>
    public TwitchUnmodV2? Unmod { get => field ??= _data?.Get<TwitchUnmodV2>("unmod"); set; }

    /// <summary> 
    /// Metadata associated with the ban command.
    /// </summary>
    public TwitchBanV2? Ban { get => field ??= _data?.Get<TwitchBanV2>("ban"); set; }

    /// <summary> 
    /// Metadata associated with the unban command.
    /// </summary>
    public TwitchUnbanV2? Unban { get => field ??= _data?.Get<TwitchUnbanV2>("unban"); set; }

    /// <summary> 
    /// Metadata associated with the timeout command.
    /// </summary>
    public TwitchTimeoutV2? Timeout { get => field ??= _data?.Get<TwitchTimeoutV2>("timeout"); set; }

    /// <summary> 
    /// Metadata associated with the untimeout command.
    /// </summary>
    public TwitchUntimeoutV2? Untimeout { get => field ??= _data?.Get<TwitchUntimeoutV2>("untimeout"); set; }

    /// <summary> 
    /// Metadata associated with the raid command.
    /// </summary>
    public TwitchRaidV2? Raid { get => field ??= _data?.Get<TwitchRaidV2>("raid"); set; }

    /// <summary> 
    /// Metadata associated with the unraid command.
    /// </summary>
    public TwitchUnraidV2? Unraid { get => field ??= _data?.Get<TwitchUnraidV2>("unraid"); set; }

    /// <summary> 
    /// Metadata associated with the delete command.
    /// </summary>
    public TwitchDeleteV2? Delete { get => field ??= _data?.Get<TwitchDeleteV2>("delete"); set; }

    /// <summary> 
    /// Metadata associated with the automod terms changes.
    /// </summary>
    public TwitchAutomodTermsV2? AutomodTerms { get => field ??= _data?.Get<TwitchAutomodTermsV2>("automod_terms"); set; }

    /// <summary> 
    /// Metadata associated with an unban request.
    /// </summary>
    public TwitchUnbanRequestV2? UnbanRequest { get => field ??= _data?.Get<TwitchUnbanRequestV2>("unban_request"); set; }

    /// <summary> 
    /// Metadata associated with the warn command.
    /// </summary>
    public TwitchWarnV2? Warn { get => field ??= _data?.Get<TwitchWarnV2>("warn"); set; }

    /// <summary> 
    /// Information about the `shared_chat_ban` event. Is null if `action` is not `shared_chat_ban`. This field has the same information as the `ban` field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchBanV2? SharedChatBan { get => field ??= _data?.Get<TwitchBanV2>("shared_chat_ban"); set; }

    /// <summary> 
    /// Information about the `shared_chat_unban` event. Is null if `action` is not `shared_chat_unban`. This field has the same information as the `unban` field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchUnbanV2? SharedChatUnban { get => field ??= _data?.Get<TwitchUnbanV2>("shared_chat_unban"); set; }

    /// <summary> 
    /// Information about the `shared_chat_timeout` event. Is null if `action` is not `shared_chat_timeout`. This field has the same information as the `timeout` field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchTimeoutV2? SharedChatTimeout { get => field ??= _data?.Get<TwitchTimeoutV2>("shared_chat_timeout"); set; }

    /// <summary> 
    /// Information about the `shared_chat_untimeout` event. Is null if `action` is not `shared_chat_untimeout`. This field has the same information as the `untimeout` field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchUntimeoutV2? SharedChatUntimeout { get => field ??= _data?.Get<TwitchUntimeoutV2>("shared_chat_untimeout"); set; }

    /// <summary> 
    /// Information about the `shared_chat_delete` event. Is null if `action` is not `shared_chat_delete`. This field has the same information as the `delete` field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchDeleteV2? SharedChatDelete { get => field ??= _data?.Get<TwitchDeleteV2>("shared_chat_delete"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelModerateEventV2 object.
    /// </summary> 
    public static TwitchChannelModerateEventV2? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelModerateEventV2
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
        var eventV2Class = script.Get("EventV2").As<GDScript>();
        var request = eventV2Class.New().AsGodotObject();
        if(BroadcasterUserId != null) request.Set("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.Set("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.Set("broadcaster_user_name", BroadcasterUserName);
        if(SourceBroadcasterUserId != null) request.Set("source_broadcaster_user_id", SourceBroadcasterUserId);
        if(SourceBroadcasterUserLogin != null) request.Set("source_broadcaster_user_login", SourceBroadcasterUserLogin);
        if(SourceBroadcasterUserName != null) request.Set("source_broadcaster_user_name", SourceBroadcasterUserName);
        if(ModeratorUserId != null) request.Set("moderator_user_id", ModeratorUserId);
        if(ModeratorUserLogin != null) request.Set("moderator_user_login", ModeratorUserLogin);
        if(ModeratorUserName != null) request.Set("moderator_user_name", ModeratorUserName);
        if(Action != null) request.Set("action", Action);
        if(Followers != null) request.Set("followers", Followers.ToGodotObject());
        if(Slow != null) request.Set("slow", Slow.ToGodotObject());
        if(Vip != null) request.Set("vip", Vip.ToGodotObject());
        if(Unvip != null) request.Set("unvip", Unvip.ToGodotObject());
        if(Mod != null) request.Set("mod", Mod.ToGodotObject());
        if(Unmod != null) request.Set("unmod", Unmod.ToGodotObject());
        if(Ban != null) request.Set("ban", Ban.ToGodotObject());
        if(Unban != null) request.Set("unban", Unban.ToGodotObject());
        if(Timeout != null) request.Set("timeout", Timeout.ToGodotObject());
        if(Untimeout != null) request.Set("untimeout", Untimeout.ToGodotObject());
        if(Raid != null) request.Set("raid", Raid.ToGodotObject());
        if(Unraid != null) request.Set("unraid", Unraid.ToGodotObject());
        if(Delete != null) request.Set("delete", Delete.ToGodotObject());
        if(AutomodTerms != null) request.Set("automod_terms", AutomodTerms.ToGodotObject());
        if(UnbanRequest != null) request.Set("unban_request", UnbanRequest.ToGodotObject());
        if(Warn != null) request.Set("warn", Warn.ToGodotObject());
        if(SharedChatBan != null) request.Set("shared_chat_ban", SharedChatBan.ToGodotObject());
        if(SharedChatUnban != null) request.Set("shared_chat_unban", SharedChatUnban.ToGodotObject());
        if(SharedChatTimeout != null) request.Set("shared_chat_timeout", SharedChatTimeout.ToGodotObject());
        if(SharedChatUntimeout != null) request.Set("shared_chat_untimeout", SharedChatUntimeout.ToGodotObject());
        if(SharedChatDelete != null) request.Set("shared_chat_delete", SharedChatDelete.ToGodotObject());
        return request;
    }


    public partial class TwitchFollowersV2 : RefCounted, ITwitcherSharpEventSub<TwitchFollowersV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The length of time, in minutes, that the followers must have followed the broadcaster to participate in the chat room.
        /// </summary>
        public int FollowDurationMinutes { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchFollowersV2 object.
        /// </summary> 
        public static TwitchFollowersV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchFollowersV2
            {
                FollowDurationMinutes = data.Get("follow_duration_minutes").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var followersV2Class = script.Get("FollowersV2").As<GDScript>();
            var request = followersV2Class.New().AsGodotObject();
            request.Set("follow_duration_minutes", FollowDurationMinutes);
            return request;
        }
    }

    public partial class TwitchSlowV2 : RefCounted, ITwitcherSharpEventSub<TwitchSlowV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The amount of time, in seconds, that users need to wait between sending messages.
        /// </summary>
        public int WaitTimeSeconds { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSlowV2 object.
        /// </summary> 
        public static TwitchSlowV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchSlowV2
            {
                WaitTimeSeconds = data.Get("wait_time_seconds").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd");
            var slowV2Class = script.Get("SlowV2").As<GDScript>();
            var request = slowV2Class.New().AsGodotObject();
            request.Set("wait_time_seconds", WaitTimeSeconds);
            return request;
        }
    }

    public partial class TwitchVipV2 : RefCounted, ITwitcherSharpEventSub<TwitchVipV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The ID of the user gaining VIP status.
        /// </summary>
        public string? UserId { get; set; }
    
        /// <summary> 
        /// The login of the user gaining VIP status.
        /// </summary>
        public string? UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user gaining VIP status.
        /// </summary>
        public string? UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchVipV2 object.
        /// </summary> 
        public static TwitchVipV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchVipV2
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
            var vipV2Class = script.Get("VipV2").As<GDScript>();
            var request = vipV2Class.New().AsGodotObject();
            if(UserId != null) request.Set("user_id", UserId);
            if(UserLogin != null) request.Set("user_login", UserLogin);
            if(UserName != null) request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchUnvipV2 : RefCounted, ITwitcherSharpEventSub<TwitchUnvipV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The ID of the user losing VIP status.
        /// </summary>
        public string? UserId { get; set; }
    
        /// <summary> 
        /// The login of the user losing VIP status.
        /// </summary>
        public string? UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user losing VIP status.
        /// </summary>
        public string? UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchUnvipV2 object.
        /// </summary> 
        public static TwitchUnvipV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchUnvipV2
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
            var unvipV2Class = script.Get("UnvipV2").As<GDScript>();
            var request = unvipV2Class.New().AsGodotObject();
            if(UserId != null) request.Set("user_id", UserId);
            if(UserLogin != null) request.Set("user_login", UserLogin);
            if(UserName != null) request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchModV2 : RefCounted, ITwitcherSharpEventSub<TwitchModV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The ID of the user gaining mod status.
        /// </summary>
        public string? UserId { get; set; }
    
        /// <summary> 
        /// The login of the user gaining mod status.
        /// </summary>
        public string? UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user gaining mod status.
        /// </summary>
        public string? UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchModV2 object.
        /// </summary> 
        public static TwitchModV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchModV2
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
            var modV2Class = script.Get("ModV2").As<GDScript>();
            var request = modV2Class.New().AsGodotObject();
            if(UserId != null) request.Set("user_id", UserId);
            if(UserLogin != null) request.Set("user_login", UserLogin);
            if(UserName != null) request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchUnmodV2 : RefCounted, ITwitcherSharpEventSub<TwitchUnmodV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The ID of the user losing mod status.
        /// </summary>
        public string? UserId { get; set; }
    
        /// <summary> 
        /// The login of the user losing mod status.
        /// </summary>
        public string? UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user losing mod status.
        /// </summary>
        public string? UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchUnmodV2 object.
        /// </summary> 
        public static TwitchUnmodV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchUnmodV2
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
            var unmodV2Class = script.Get("UnmodV2").As<GDScript>();
            var request = unmodV2Class.New().AsGodotObject();
            if(UserId != null) request.Set("user_id", UserId);
            if(UserLogin != null) request.Set("user_login", UserLogin);
            if(UserName != null) request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchBanV2 : RefCounted, ITwitcherSharpEventSub<TwitchBanV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The ID of the user being banned.
        /// </summary>
        public string? UserId { get; set; }
    
        /// <summary> 
        /// The login of the user being banned.
        /// </summary>
        public string? UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user being banned.
        /// </summary>
        public string? UserName { get; set; }
    
        /// <summary> 
        /// Reason given for the ban.
        /// </summary>
        public string? Reason { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBanV2 object.
        /// </summary> 
        public static TwitchBanV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBanV2
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
            var banV2Class = script.Get("BanV2").As<GDScript>();
            var request = banV2Class.New().AsGodotObject();
            if(UserId != null) request.Set("user_id", UserId);
            if(UserLogin != null) request.Set("user_login", UserLogin);
            if(UserName != null) request.Set("user_name", UserName);
            if(Reason != null) request.Set("reason", Reason);
            return request;
        }
    }

    public partial class TwitchUnbanV2 : RefCounted, ITwitcherSharpEventSub<TwitchUnbanV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The ID of the user being unbanned.
        /// </summary>
        public string? UserId { get; set; }
    
        /// <summary> 
        /// The login of the user being unbanned.
        /// </summary>
        public string? UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user being unbanned.
        /// </summary>
        public string? UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchUnbanV2 object.
        /// </summary> 
        public static TwitchUnbanV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchUnbanV2
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
            var unbanV2Class = script.Get("UnbanV2").As<GDScript>();
            var request = unbanV2Class.New().AsGodotObject();
            if(UserId != null) request.Set("user_id", UserId);
            if(UserLogin != null) request.Set("user_login", UserLogin);
            if(UserName != null) request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchTimeoutV2 : RefCounted, ITwitcherSharpEventSub<TwitchTimeoutV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The ID of the user being timed out.
        /// </summary>
        public string? UserId { get; set; }
    
        /// <summary> 
        /// The login of the user being timed out.
        /// </summary>
        public string? UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user being timed out.
        /// </summary>
        public string? UserName { get; set; }
    
        /// <summary> 
        /// The reason given for the timeout.
        /// </summary>
        public string? Reason { get; set; }
    
        /// <summary> 
        /// The time at which the timeout ends.
        /// </summary>
        public string? ExpiresAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchTimeoutV2 object.
        /// </summary> 
        public static TwitchTimeoutV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchTimeoutV2
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
            var timeoutV2Class = script.Get("TimeoutV2").As<GDScript>();
            var request = timeoutV2Class.New().AsGodotObject();
            if(UserId != null) request.Set("user_id", UserId);
            if(UserLogin != null) request.Set("user_login", UserLogin);
            if(UserName != null) request.Set("user_name", UserName);
            if(Reason != null) request.Set("reason", Reason);
            if(ExpiresAt != null) request.Set("expires_at", ExpiresAt);
            return request;
        }
    }

    public partial class TwitchUntimeoutV2 : RefCounted, ITwitcherSharpEventSub<TwitchUntimeoutV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The ID of the user being untimed out.
        /// </summary>
        public string? UserId { get; set; }
    
        /// <summary> 
        /// The login of the user being untimed out.
        /// </summary>
        public string? UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user untimed out.
        /// </summary>
        public string? UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchUntimeoutV2 object.
        /// </summary> 
        public static TwitchUntimeoutV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchUntimeoutV2
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
            var untimeoutV2Class = script.Get("UntimeoutV2").As<GDScript>();
            var request = untimeoutV2Class.New().AsGodotObject();
            if(UserId != null) request.Set("user_id", UserId);
            if(UserLogin != null) request.Set("user_login", UserLogin);
            if(UserName != null) request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchRaidV2 : RefCounted, ITwitcherSharpEventSub<TwitchRaidV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The ID of the user being raided.
        /// </summary>
        public string? UserId { get; set; }
    
        /// <summary> 
        /// The login of the user being raided.
        /// </summary>
        public string? UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user raided.
        /// </summary>
        public string? UserName { get; set; }
    
        /// <summary> 
        /// The viewer count.
        /// </summary>
        public int ViewerCount { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchRaidV2 object.
        /// </summary> 
        public static TwitchRaidV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchRaidV2
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
            var raidV2Class = script.Get("RaidV2").As<GDScript>();
            var request = raidV2Class.New().AsGodotObject();
            if(UserId != null) request.Set("user_id", UserId);
            if(UserLogin != null) request.Set("user_login", UserLogin);
            if(UserName != null) request.Set("user_name", UserName);
            request.Set("viewer_count", ViewerCount);
            return request;
        }
    }

    public partial class TwitchUnraidV2 : RefCounted, ITwitcherSharpEventSub<TwitchUnraidV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The ID of the user no longer being raided.
        /// </summary>
        public string? UserId { get; set; }
    
        /// <summary> 
        /// The login of the user no longer being raided.
        /// </summary>
        public string? UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the no longer user raided.
        /// </summary>
        public string? UserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchUnraidV2 object.
        /// </summary> 
        public static TwitchUnraidV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchUnraidV2
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
            var unraidV2Class = script.Get("UnraidV2").As<GDScript>();
            var request = unraidV2Class.New().AsGodotObject();
            if(UserId != null) request.Set("user_id", UserId);
            if(UserLogin != null) request.Set("user_login", UserLogin);
            if(UserName != null) request.Set("user_name", UserName);
            return request;
        }
    }

    public partial class TwitchDeleteV2 : RefCounted, ITwitcherSharpEventSub<TwitchDeleteV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The ID of the user whose message is being deleted.
        /// </summary>
        public string? UserId { get; set; }
    
        /// <summary> 
        /// The login of the user.
        /// </summary>
        public string? UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user.
        /// </summary>
        public string? UserName { get; set; }
    
        /// <summary> 
        /// The ID of the message being deleted.
        /// </summary>
        public string? MessageId { get; set; }
    
        /// <summary> 
        /// The message body of the message being deleted.
        /// </summary>
        public string? MessageBody { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchDeleteV2 object.
        /// </summary> 
        public static TwitchDeleteV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchDeleteV2
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
            var deleteV2Class = script.Get("DeleteV2").As<GDScript>();
            var request = deleteV2Class.New().AsGodotObject();
            if(UserId != null) request.Set("user_id", UserId);
            if(UserLogin != null) request.Set("user_login", UserLogin);
            if(UserName != null) request.Set("user_name", UserName);
            if(MessageId != null) request.Set("message_id", MessageId);
            if(MessageBody != null) request.Set("message_body", MessageBody);
            return request;
        }
    }

    public partial class TwitchAutomodTermsV2 : RefCounted, ITwitcherSharpEventSub<TwitchAutomodTermsV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// Either “add” or “remove”.
        /// </summary>
        public string? Action { get; set; }
    
        /// <summary> 
        /// Either “blocked” or “permitted”.
        /// </summary>
        public string? List { get; set; }
    
        /// <summary> 
        /// Terms being added or removed.
        /// </summary>
        public string[]? Terms { get; set; }
    
        /// <summary> 
        /// Whether the terms were added due to an Automod message approve/deny action.
        /// </summary>
        public bool FromAutomod { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchAutomodTermsV2 object.
        /// </summary> 
        public static TwitchAutomodTermsV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchAutomodTermsV2
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
            var automodTermsV2Class = script.Get("AutomodTermsV2").As<GDScript>();
            var request = automodTermsV2Class.New().AsGodotObject();
            if(Action != null) request.Set("action", Action);
            if(List != null) request.Set("list", List);
            if(Terms != null) request.Set("terms", new Godot.Collections.Array<string>(Terms));
            request.Set("from_automod", FromAutomod);
            return request;
        }
    }

    public partial class TwitchUnbanRequestV2 : RefCounted, ITwitcherSharpEventSub<TwitchUnbanRequestV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// Whether or not the unban request was approved or denied.
        /// </summary>
        public bool IsApproved { get; set; }
    
        /// <summary> 
        /// The ID of the banned user.
        /// </summary>
        public string? UserId { get; set; }
    
        /// <summary> 
        /// The login of the user.
        /// </summary>
        public string? UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user.
        /// </summary>
        public string? UserName { get; set; }
    
        /// <summary> 
        /// The message included by the moderator explaining their approval or denial.
        /// </summary>
        public string? ModeratorMessage { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchUnbanRequestV2 object.
        /// </summary> 
        public static TwitchUnbanRequestV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchUnbanRequestV2
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
            var unbanRequestV2Class = script.Get("UnbanRequestV2").As<GDScript>();
            var request = unbanRequestV2Class.New().AsGodotObject();
            request.Set("is_approved", IsApproved);
            if(UserId != null) request.Set("user_id", UserId);
            if(UserLogin != null) request.Set("user_login", UserLogin);
            if(UserName != null) request.Set("user_name", UserName);
            if(ModeratorMessage != null) request.Set("moderator_message", ModeratorMessage);
            return request;
        }
    }

    public partial class TwitchWarnV2 : RefCounted, ITwitcherSharpEventSub<TwitchWarnV2>
    {
        private GodotObject? _data;
        
        /// <summary> 
        /// The ID of the user being warned.
        /// </summary>
        public string? UserId { get; set; }
    
        /// <summary> 
        /// The login of the user being warned.
        /// </summary>
        public string? UserLogin { get; set; }
    
        /// <summary> 
        /// The user name of the user being warned.
        /// </summary>
        public string? UserName { get; set; }
    
        /// <summary> 
        /// Reason given for the warning.
        /// </summary>
        public string? Reason { get; set; }
    
        /// <summary> 
        /// Chat rules cited for the warning.
        /// </summary>
        public string[]? ChatRulesCited { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchWarnV2 object.
        /// </summary> 
        public static TwitchWarnV2? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchWarnV2
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
            var warnV2Class = script.Get("WarnV2").As<GDScript>();
            var request = warnV2Class.New().AsGodotObject();
            if(UserId != null) request.Set("user_id", UserId);
            if(UserLogin != null) request.Set("user_login", UserLogin);
            if(UserName != null) request.Set("user_name", UserName);
            if(Reason != null) request.Set("reason", Reason);
            if(ChatRulesCited != null) request.Set("chat_rules_cited", new Godot.Collections.Array<string>(ChatRulesCited));
            return request;
        }
    }
}
