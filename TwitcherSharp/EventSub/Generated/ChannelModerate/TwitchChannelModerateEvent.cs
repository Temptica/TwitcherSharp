using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelModerate;

public partial class TwitchChannelModerateEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelModerateEvent>
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
    /// The type of action: Possible values are: bantimeoutunbanuntimeoutclearemoteonlyemoteonlyofffollowersfollowersoffuniquechatuniquechatoffslowslowoffsubscriberssubscribersoffunraiddeleteunvipvipraidadd_blocked_termadd_permitted_termremove_blocked_termremove_permitted_termmodunmodapprove_unban_requestdeny_unban_requestshared_chat_banshared_chat_timeoutshared_chat_untimeoutshared_chat_unbanshared_chat_delete
    /// </summary>
    public string? Action { get; set; }

    /// <summary> 
    /// Optional.. Metadata associated with the followers command.
    /// </summary>
    public TwitchFollowers? Followers { get => field ??= _data.Get<TwitchFollowers>("followers"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the slow command.
    /// </summary>
    public TwitchSlow? Slow { get => field ??= _data.Get<TwitchSlow>("slow"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the vip command.
    /// </summary>
    public TwitchVip? Vip { get => field ??= _data.Get<TwitchVip>("vip"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the unvip command.
    /// </summary>
    public TwitchUnvip? Unvip { get => field ??= _data.Get<TwitchUnvip>("unvip"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the mod command.
    /// </summary>
    public TwitchMod? Mod { get => field ??= _data.Get<TwitchMod>("mod"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the unmod command.
    /// </summary>
    public TwitchUnmod? Unmod { get => field ??= _data.Get<TwitchUnmod>("unmod"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the ban command.
    /// </summary>
    public TwitchBan? Ban { get => field ??= _data.Get<TwitchBan>("ban"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the unban command.
    /// </summary>
    public TwitchUnban? Unban { get => field ??= _data.Get<TwitchUnban>("unban"); set; }

    /// <summary> 
    /// Optional.. Metadata associated with the timeout command.
    /// </summary>
    public TwitchTimeout? Timeout { get => field ??= _data.Get<TwitchTimeout>("timeout"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the untimeout command.
    /// </summary>
    public TwitchUntimeout? Untimeout { get => field ??= _data.Get<TwitchUntimeout>("untimeout"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the raid command.
    /// </summary>
    public TwitchRaid? Raid { get => field ??= _data.Get<TwitchRaid>("raid"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the unraid command.
    /// </summary>
    public TwitchUnraid? Unraid { get => field ??= _data.Get<TwitchUnraid>("unraid"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the delete command.
    /// </summary>
    public TwitchDelete? Delete { get => field ??= _data.Get<TwitchDelete>("delete"); set; }

    /// <summary> 
    /// Optional. Metadata associated with the automod terms changes.
    /// </summary>
    public TwitchAutomodTerms? AutomodTerms { get => field ??= _data.Get<TwitchAutomodTerms>("automod_terms"); set; }

    /// <summary> 
    /// Optional. Metadata associated with an unban request.
    /// </summary>
    public TwitchUnbanRequest? UnbanRequest { get => field ??= _data.Get<TwitchUnbanRequest>("unban_request"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_ban event. Is null if action is not shared_chat_ban. This field has the same information as the ban field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchBan? SharedChatBan { get => field ??= _data.Get<TwitchBan>("shared_chat_ban"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_unban event. Is null if action is not shared_chat_unban. This field has the same information as the unban field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchUnban? SharedChatUnban { get => field ??= _data.Get<TwitchUnban>("shared_chat_unban"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_timeout event. Is null if action is not shared_chat_timeout. This field has the same information as the timeout field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchTimeout? SharedChatTimeout { get => field ??= _data.Get<TwitchTimeout>("shared_chat_timeout"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_untimeout event. Is null if action is not shared_chat_untimeout. This field has the same information as the untimeout field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchUntimeout? SharedChatUntimeout { get => field ??= _data.Get<TwitchUntimeout>("shared_chat_untimeout"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_delete event. Is null if action is not shared_chat_delete. This field has the same information as the delete field but for a action that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchDelete? SharedChatDelete { get => field ??= _data.Get<TwitchDelete>("shared_chat_delete"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelModerateEvent object.
    /// </summary> 
    public static TwitchChannelModerateEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelModerateEvent
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
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "Event");
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
        if(Followers != null) request.SetObject("followers", Followers);
        if(Slow != null) request.SetObject("slow", Slow);
        if(Vip != null) request.SetObject("vip", Vip);
        if(Unvip != null) request.SetObject("unvip", Unvip);
        if(Mod != null) request.SetObject("mod", Mod);
        if(Unmod != null) request.SetObject("unmod", Unmod);
        if(Ban != null) request.SetObject("ban", Ban);
        if(Unban != null) request.SetObject("unban", Unban);
        if(Timeout != null) request.SetObject("timeout", Timeout);
        if(Untimeout != null) request.SetObject("untimeout", Untimeout);
        if(Raid != null) request.SetObject("raid", Raid);
        if(Unraid != null) request.SetObject("unraid", Unraid);
        if(Delete != null) request.SetObject("delete", Delete);
        if(AutomodTerms != null) request.SetObject("automod_terms", AutomodTerms);
        if(UnbanRequest != null) request.SetObject("unban_request", UnbanRequest);
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


    public partial class TwitchFollowers : RefCounted, ITwitcherSharpEventSub<TwitchFollowers>
    {
        private Variant _data;
        
        /// <summary> 
        /// The length of time, in minutes, that the followers must have followed the broadcaster to participate in the chat room.
        /// </summary>
        public int FollowDurationMinutes { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchFollowers object.
        /// </summary> 
        public static TwitchFollowers? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchFollowers
            {
                FollowDurationMinutes = data.Read("follow_duration_minutes", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "Followers");
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

    public partial class TwitchSlow : RefCounted, ITwitcherSharpEventSub<TwitchSlow>
    {
        private Variant _data;
        
        /// <summary> 
        /// The amount of time, in seconds, that users need to wait between sending messages.
        /// </summary>
        public int WaitTimeSeconds { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSlow object.
        /// </summary> 
        public static TwitchSlow? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchSlow
            {
                WaitTimeSeconds = data.Read("wait_time_seconds", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "Slow");
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

    public partial class TwitchVip : RefCounted, ITwitcherSharpEventSub<TwitchVip>
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
        /// Transforms the godot data into a TwitchVip object.
        /// </summary> 
        public static TwitchVip? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchVip
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "Vip");
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

    public partial class TwitchUnvip : RefCounted, ITwitcherSharpEventSub<TwitchUnvip>
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
        /// Transforms the godot data into a TwitchUnvip object.
        /// </summary> 
        public static TwitchUnvip? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchUnvip
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "Unvip");
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

    public partial class TwitchMod : RefCounted, ITwitcherSharpEventSub<TwitchMod>
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
        /// Transforms the godot data into a TwitchMod object.
        /// </summary> 
        public static TwitchMod? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchMod
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "Mod");
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

    public partial class TwitchUnmod : RefCounted, ITwitcherSharpEventSub<TwitchUnmod>
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
        /// Transforms the godot data into a TwitchUnmod object.
        /// </summary> 
        public static TwitchUnmod? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchUnmod
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "Unmod");
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

    public partial class TwitchBan : RefCounted, ITwitcherSharpEventSub<TwitchBan>
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
        /// Transforms the godot data into a TwitchBan object.
        /// </summary> 
        public static TwitchBan? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBan
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "Ban");
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

    public partial class TwitchUnban : RefCounted, ITwitcherSharpEventSub<TwitchUnban>
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
        /// Transforms the godot data into a TwitchUnban object.
        /// </summary> 
        public static TwitchUnban? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchUnban
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "Unban");
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

    public partial class TwitchTimeout : RefCounted, ITwitcherSharpEventSub<TwitchTimeout>
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
        /// Optional.. The reason given for the timeout.
        /// </summary>
        public string? Reason { get; set; }
    
        /// <summary> 
        /// The time at which the timeout ends.
        /// </summary>
        public string? ExpiresAt { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchTimeout object.
        /// </summary> 
        public static TwitchTimeout? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchTimeout
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "Timeout");
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

    public partial class TwitchUntimeout : RefCounted, ITwitcherSharpEventSub<TwitchUntimeout>
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
        /// Transforms the godot data into a TwitchUntimeout object.
        /// </summary> 
        public static TwitchUntimeout? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchUntimeout
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "Untimeout");
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

    public partial class TwitchRaid : RefCounted, ITwitcherSharpEventSub<TwitchRaid>
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
        /// Transforms the godot data into a TwitchRaid object.
        /// </summary> 
        public static TwitchRaid? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchRaid
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "Raid");
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

    public partial class TwitchUnraid : RefCounted, ITwitcherSharpEventSub<TwitchUnraid>
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
        /// Transforms the godot data into a TwitchUnraid object.
        /// </summary> 
        public static TwitchUnraid? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchUnraid
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "Unraid");
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

    public partial class TwitchDelete : RefCounted, ITwitcherSharpEventSub<TwitchDelete>
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
        /// Transforms the godot data into a TwitchDelete object.
        /// </summary> 
        public static TwitchDelete? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchDelete
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "Delete");
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

    public partial class TwitchAutomodTerms : RefCounted, ITwitcherSharpEventSub<TwitchAutomodTerms>
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
        /// Transforms the godot data into a TwitchAutomodTerms object.
        /// </summary> 
        public static TwitchAutomodTerms? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchAutomodTerms
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "AutomodTerms");
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

    public partial class TwitchUnbanRequest : RefCounted, ITwitcherSharpEventSub<TwitchUnbanRequest>
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
        /// Transforms the godot data into a TwitchUnbanRequest object.
        /// </summary> 
        public static TwitchUnbanRequest? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchUnbanRequest
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_moderate.gd", "UnbanRequest");
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
}
