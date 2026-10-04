using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelModerate;

public partial class TwitchChannelModerateEventV2 : RefCounted, ITwitcherSharpEventSub<TwitchChannelModerateEventV2>
{
    private Variant _data;
    
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
    /// The channel in which the action originally occurred. Is null when the moderator action happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
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
    /// The action performed. Possible values are: bantimeoutunbanuntimeoutclearemoteonlyemoteonlyofffollowersfollowersoffuniquechatuniquechatoffslowslowoffsubscriberssubscribersoffunraiddeleteunvipvipraidadd_blocked_termadd_permitted_termremove_blocked_termremove_permitted_termmodunmodapprove_unban_requestdeny_unban_requestwarnshared_chat_banshared_chat_timeoutshared_chat_unbanshared_chat_untimeoutshared_chat_delete
    /// </summary>
    public string? Action { get; set; }

    /// <summary> 
    /// Optional. Metadata associated with the followers command.
    /// </summary>
    public TwitchFollowersV2? FollowersV2 { get => field ??= _data.Get<TwitchFollowersV2>("followers_v_2"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the slow command.
    /// </summary>
    public TwitchSlowV2? SlowV2 { get => field ??= _data.Get<TwitchSlowV2>("slow_v_2"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the vip command.
    /// </summary>
    public TwitchVipV2? VipV2 { get => field ??= _data.Get<TwitchVipV2>("vip_v_2"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the unvip command.
    /// </summary>
    public TwitchUnvipV2? UnvipV2 { get => field ??= _data.Get<TwitchUnvipV2>("unvip_v_2"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the mod command.
    /// </summary>
    public TwitchModV2? ModV2 { get => field ??= _data.Get<TwitchModV2>("mod_v_2"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the unmod command.
    /// </summary>
    public TwitchUnmodV2? UnmodV2 { get => field ??= _data.Get<TwitchUnmodV2>("unmod_v_2"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the ban command.
    /// </summary>
    public TwitchBanV2? BanV2 { get => field ??= _data.Get<TwitchBanV2>("ban_v_2"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the unban command.
    /// </summary>
    public TwitchUnbanV2? UnbanV2 { get => field ??= _data.Get<TwitchUnbanV2>("unban_v_2"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the timeout command.
    /// </summary>
    public TwitchTimeoutV2? TimeoutV2 { get => field ??= _data.Get<TwitchTimeoutV2>("timeout_v_2"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the untimeout command.
    /// </summary>
    public TwitchUntimeoutV2? UntimeoutV2 { get => field ??= _data.Get<TwitchUntimeoutV2>("untimeout_v_2"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the raid command.
    /// </summary>
    public TwitchRaidV2? RaidV2 { get => field ??= _data.Get<TwitchRaidV2>("raid_v_2"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the unraid command.
    /// </summary>
    public TwitchUnraidV2? UnraidV2 { get => field ??= _data.Get<TwitchUnraidV2>("unraid_v_2"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the delete command.
    /// </summary>
    public TwitchDeleteV2? DeleteV2 { get => field ??= _data.Get<TwitchDeleteV2>("delete_v_2"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the automod terms changes.
    /// </summary>
    public TwitchAutomodTermsV2? AutomodTermsV2 { get => field ??= _data.Get<TwitchAutomodTermsV2>("automod_terms_v_2"); set; }

    /// <summary> 
    /// Optional. Metadata associated with an unban request.
    /// </summary>
    public TwitchUnbanRequestV2? UnbanRequestV2 { get => field ??= _data.Get<TwitchUnbanRequestV2>("unban_request_v_2"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the warn command.
    /// </summary>
    public TwitchWarnV2? WarnV2 { get => field ??= _data.Get<TwitchWarnV2>("warn_v_2"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_ban event. Is null if action is not shared_chat_ban. This field has the same information as the ban field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchBanV2? SharedChatBan { get => field ??= _data.Get<TwitchBanV2>("shared_chat_ban"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_unban event. Is null if action is not shared_chat_unban. This field has the same information as the unban field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchUnbanV2? SharedChatUnban { get => field ??= _data.Get<TwitchUnbanV2>("shared_chat_unban"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_timeout event. Is null if action is not shared_chat_timeout. This field has the same information as the timeout field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchTimeoutV2? SharedChatTimeout { get => field ??= _data.Get<TwitchTimeoutV2>("shared_chat_timeout"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_untimeout event. Is null if action is not shared_chat_untimeout. This field has the same information as the untimeout field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchUntimeoutV2? SharedChatUntimeout { get => field ??= _data.Get<TwitchUntimeoutV2>("shared_chat_untimeout"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_delete event. Is null if action is not shared_chat_delete. This field has the same information as the delete field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchDeleteV2? SharedChatDelete { get => field ??= _data.Get<TwitchDeleteV2>("shared_chat_delete"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelModerateEventV2 object.
    /// </summary> 
    public static TwitchChannelModerateEventV2? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelModerateEventV2
        {
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            SourceBroadcasterUserId = data.Read("source_broadcaster_user_id", static v => v.AsString()),
            SourceBroadcasterUserLogin = data.Read("source_broadcaster_user_login", static v => v.AsString()),
            SourceBroadcasterUserName = data.Read("source_broadcaster_user_name", static v => v.AsString()),
            ModeratorUserId = data.Read("moderator_user_id", static v => v.AsString()),
            ModeratorUserLogin = data.Read("moderator_user_login", static v => v.AsString()),
            ModeratorUserName = data.Read("moderator_user_name", static v => v.AsString()),
            Action = data.Read("action", static v => v.AsString()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "EventV2");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(SourceBroadcasterUserId != null) request.SetValue("source_broadcaster_user_id", SourceBroadcasterUserId);
        if(SourceBroadcasterUserLogin != null) request.SetValue("source_broadcaster_user_login", SourceBroadcasterUserLogin);
        if(SourceBroadcasterUserName != null) request.SetValue("source_broadcaster_user_name", SourceBroadcasterUserName);
        if(ModeratorUserId != null) request.SetValue("moderator_user_id", ModeratorUserId);
        if(ModeratorUserLogin != null) request.SetValue("moderator_user_login", ModeratorUserLogin);
        if(ModeratorUserName != null) request.SetValue("moderator_user_name", ModeratorUserName);
        if(Action != null) request.SetValue("action", Action);
        if(FollowersV2 != null) request.SetObject("followers_v_2", FollowersV2);
        if(SlowV2 != null) request.SetObject("slow_v_2", SlowV2);
        if(VipV2 != null) request.SetObject("vip_v_2", VipV2);
        if(UnvipV2 != null) request.SetObject("unvip_v_2", UnvipV2);
        if(ModV2 != null) request.SetObject("mod_v_2", ModV2);
        if(UnmodV2 != null) request.SetObject("unmod_v_2", UnmodV2);
        if(BanV2 != null) request.SetObject("ban_v_2", BanV2);
        if(UnbanV2 != null) request.SetObject("unban_v_2", UnbanV2);
        if(TimeoutV2 != null) request.SetObject("timeout_v_2", TimeoutV2);
        if(UntimeoutV2 != null) request.SetObject("untimeout_v_2", UntimeoutV2);
        if(RaidV2 != null) request.SetObject("raid_v_2", RaidV2);
        if(UnraidV2 != null) request.SetObject("unraid_v_2", UnraidV2);
        if(DeleteV2 != null) request.SetObject("delete_v_2", DeleteV2);
        if(AutomodTermsV2 != null) request.SetObject("automod_terms_v_2", AutomodTermsV2);
        if(UnbanRequestV2 != null) request.SetObject("unban_request_v_2", UnbanRequestV2);
        if(WarnV2 != null) request.SetObject("warn_v_2", WarnV2);
        if(SharedChatBan != null) request.SetObject("shared_chat_ban", SharedChatBan);
        if(SharedChatUnban != null) request.SetObject("shared_chat_unban", SharedChatUnban);
        if(SharedChatTimeout != null) request.SetObject("shared_chat_timeout", SharedChatTimeout);
        if(SharedChatUntimeout != null) request.SetObject("shared_chat_untimeout", SharedChatUntimeout);
        if(SharedChatDelete != null) request.SetObject("shared_chat_delete", SharedChatDelete);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }


    public partial class TwitchFollowersV2 : RefCounted, ITwitcherSharpEventSub<TwitchFollowersV2>
    {
        private Variant _data;
        
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
                FollowDurationMinutes = data.Read("follow_duration_minutes", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "FollowersV2");
            request.SetValue("follow_duration_minutes", FollowDurationMinutes);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchSlowV2 : RefCounted, ITwitcherSharpEventSub<TwitchSlowV2>
    {
        private Variant _data;
        
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
                WaitTimeSeconds = data.Read("wait_time_seconds", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "SlowV2");
            request.SetValue("wait_time_seconds", WaitTimeSeconds);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchVipV2 : RefCounted, ITwitcherSharpEventSub<TwitchVipV2>
    {
        private Variant _data;
        
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
                UserId = data.Read("user_id", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "VipV2");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(UserName != null) request.SetValue("user_name", UserName);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchUnvipV2 : RefCounted, ITwitcherSharpEventSub<TwitchUnvipV2>
    {
        private Variant _data;
        
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
                UserId = data.Read("user_id", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "UnvipV2");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(UserName != null) request.SetValue("user_name", UserName);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchModV2 : RefCounted, ITwitcherSharpEventSub<TwitchModV2>
    {
        private Variant _data;
        
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
                UserId = data.Read("user_id", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "ModV2");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(UserName != null) request.SetValue("user_name", UserName);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchUnmodV2 : RefCounted, ITwitcherSharpEventSub<TwitchUnmodV2>
    {
        private Variant _data;
        
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
                UserId = data.Read("user_id", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "UnmodV2");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(UserName != null) request.SetValue("user_name", UserName);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchBanV2 : RefCounted, ITwitcherSharpEventSub<TwitchBanV2>
    {
        private Variant _data;
        
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
        /// Optional. Reason given for the ban.
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
                UserId = data.Read("user_id", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
                Reason = data.Read("reason", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "BanV2");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(UserName != null) request.SetValue("user_name", UserName);
            if(Reason != null) request.SetValue("reason", Reason);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchUnbanV2 : RefCounted, ITwitcherSharpEventSub<TwitchUnbanV2>
    {
        private Variant _data;
        
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
                UserId = data.Read("user_id", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "UnbanV2");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(UserName != null) request.SetValue("user_name", UserName);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchTimeoutV2 : RefCounted, ITwitcherSharpEventSub<TwitchTimeoutV2>
    {
        private Variant _data;
        
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
        /// Optional. The reason given for the timeout.
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
                UserId = data.Read("user_id", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
                Reason = data.Read("reason", static v => v.AsString()),
                ExpiresAt = data.Read("expires_at", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "TimeoutV2");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(UserName != null) request.SetValue("user_name", UserName);
            if(Reason != null) request.SetValue("reason", Reason);
            if(ExpiresAt != null) request.SetValue("expires_at", ExpiresAt);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchUntimeoutV2 : RefCounted, ITwitcherSharpEventSub<TwitchUntimeoutV2>
    {
        private Variant _data;
        
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
                UserId = data.Read("user_id", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "UntimeoutV2");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(UserName != null) request.SetValue("user_name", UserName);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchRaidV2 : RefCounted, ITwitcherSharpEventSub<TwitchRaidV2>
    {
        private Variant _data;
        
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
                UserId = data.Read("user_id", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
                ViewerCount = data.Read("viewer_count", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "RaidV2");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(UserName != null) request.SetValue("user_name", UserName);
            request.SetValue("viewer_count", ViewerCount);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchUnraidV2 : RefCounted, ITwitcherSharpEventSub<TwitchUnraidV2>
    {
        private Variant _data;
        
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
                UserId = data.Read("user_id", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "UnraidV2");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(UserName != null) request.SetValue("user_name", UserName);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchDeleteV2 : RefCounted, ITwitcherSharpEventSub<TwitchDeleteV2>
    {
        private Variant _data;
        
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
                UserId = data.Read("user_id", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
                MessageId = data.Read("message_id", static v => v.AsString()),
                MessageBody = data.Read("message_body", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "DeleteV2");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(UserName != null) request.SetValue("user_name", UserName);
            if(MessageId != null) request.SetValue("message_id", MessageId);
            if(MessageBody != null) request.SetValue("message_body", MessageBody);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchAutomodTermsV2 : RefCounted, ITwitcherSharpEventSub<TwitchAutomodTermsV2>
    {
        private Variant _data;
        
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
                Action = data.Read("action", static v => v.AsString()),
                List = data.Read("list", static v => v.AsString()),
                FromAutomod = data.Read("from_automod", static v => v.AsBool()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "AutomodTermsV2");
            if(Action != null) request.SetValue("action", Action);
            if(List != null) request.SetValue("list", List);
            if(Terms != null) request.SetValue("terms", new Godot.Collections.Array<string>(Terms));
            request.SetValue("from_automod", FromAutomod);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchUnbanRequestV2 : RefCounted, ITwitcherSharpEventSub<TwitchUnbanRequestV2>
    {
        private Variant _data;
        
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
                IsApproved = data.Read("is_approved", static v => v.AsBool()),
                UserId = data.Read("user_id", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
                ModeratorMessage = data.Read("moderator_message", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "UnbanRequestV2");
            request.SetValue("is_approved", IsApproved);
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(UserName != null) request.SetValue("user_name", UserName);
            if(ModeratorMessage != null) request.SetValue("moderator_message", ModeratorMessage);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchWarnV2 : RefCounted, ITwitcherSharpEventSub<TwitchWarnV2>
    {
        private Variant _data;
        
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
        /// Optional. Reason given for the warning.
        /// </summary>
        public string? Reason { get; set; }
    
        /// <summary> 
        /// Optional. Chat rules cited for the warning.
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
                UserId = data.Read("user_id", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
                Reason = data.Read("reason", static v => v.AsString()),
                ChatRulesCited = data.Read("chat_rules_cited", static v => v.AsStringArray()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "WarnV2");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            if(UserName != null) request.SetValue("user_name", UserName);
            if(Reason != null) request.SetValue("reason", Reason);
            if(ChatRulesCited != null) request.SetValue("chat_rules_cited", ChatRulesCited);
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
