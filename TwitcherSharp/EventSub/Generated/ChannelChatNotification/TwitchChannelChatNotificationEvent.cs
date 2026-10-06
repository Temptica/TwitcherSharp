using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatNotification;

public partial class TwitchChannelChatNotificationEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelChatNotificationEvent>
{
    private Variant _data;
    
    /// <summary> 
    /// The broadcaster user ID.
    /// </summary>
    public string? BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster display name.
    /// </summary>
    public string? BroadcasterUserName { get; set; }

    /// <summary> 
    /// The broadcaster login.
    /// </summary>
    public string? BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user ID of the user that sent the message.
    /// </summary>
    public string? ChatterUserId { get; set; }

    /// <summary> 
    /// The user login of the user that sent the message.
    /// </summary>
    public string? ChatterUserName { get; set; }

    /// <summary> 
    /// The chatter's login name.
    /// </summary>
    public string? ChatterUserLogin { get; set; }

    /// <summary> 
    /// Whether or not the chatter is anonymous.
    /// </summary>
    public bool ChatterIsAnonymous { get; set; }

    /// <summary> 
    /// The color of the user’s name in the chat room.
    /// </summary>
    public string? Color { get; set; }

    /// <summary> 
    /// The color of the user’s name in the chat room.
    /// </summary>
    public TwitchBadges[]? Badges { get => field ??= _data.GetArray<TwitchBadges>("badges"); set; }

    /// <summary> 
    /// The message Twitch shows in the chat room for this notice.
    /// </summary>
    public string? SystemMessage { get; set; }

    /// <summary> 
    /// A UUID that identifies the message.
    /// </summary>
    public string? MessageId { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMessage? Message { get => field ??= _data.Get<TwitchMessage>("message"); set; }

    /// <summary> 
    /// The type of notice. Possible values are: subresubsub_giftcommunity_sub_giftgift_paid_upgradeprime_paid_upgraderaidunraidpay_it_forwardannouncementbits_badge_tiercharity_donationwatch_streakmodiversaryshared_chat_subshared_chat_resubshared_chat_sub_giftshared_chat_community_sub_giftshared_chat_gift_paid_upgradeshared_chat_prime_paid_upgradeshared_chat_raidshared_chat_pay_it_forwardshared_chat_announcementshared_chat_modiversaryunknown
    /// </summary>
    public string? NoticeType { get; set; }

    /// <summary> 
    /// Information about the sub event. Null if notice_type is not sub.
    /// </summary>
    public TwitchSub? Sub { get => field ??= _data.Get<TwitchSub>("sub"); set; }

    /// <summary> 
    /// Information about the resub event. Null if notice_type is not resub.
    /// </summary>
    public TwitchResub? Resub { get => field ??= _data.Get<TwitchResub>("resub"); set; }

    /// <summary> 
    /// Information about the gift sub event. Null if notice_type is not sub_gift.
    /// </summary>
    public TwitchSubGift? SubGift { get => field ??= _data.Get<TwitchSubGift>("sub_gift"); set; }

    /// <summary> 
    /// Information about the community gift sub event. Null if notice_type is not community_sub_gift.
    /// </summary>
    public TwitchCommunitySubGift? CommunitySubGift { get => field ??= _data.Get<TwitchCommunitySubGift>("community_sub_gift"); set; }

    /// <summary> 
    /// Information about the community gift paid upgrade event. Null if notice_type is not gift_paid_upgrade.
    /// </summary>
    public TwitchGiftPaidUpgrade? GiftPaidUpgrade { get => field ??= _data.Get<TwitchGiftPaidUpgrade>("gift_paid_upgrade"); set; }

    /// <summary> 
    /// Information about the Prime gift paid upgrade event. Null if notice_type is not prime_paid_upgrade
    /// </summary>
    public TwitchPrimePaidUpgrade? PrimePaidUpgrade { get => field ??= _data.Get<TwitchPrimePaidUpgrade>("prime_paid_upgrade"); set; }

    /// <summary> 
    /// Information about the pay it forward event. Null if notice_type is not pay_it_forward
    /// </summary>
    public TwitchPayItForward? PayItForward { get => field ??= _data.Get<TwitchPayItForward>("pay_it_forward"); set; }

    /// <summary> 
    /// Information about the raid event. Null if notice_type is not raid
    /// </summary>
    public TwitchRaid? Raid { get => field ??= _data.Get<TwitchRaid>("raid"); set; }

    /// <summary> 
    /// Returns an empty payload if  notice_type is not unraid, otherwise returns null.
    /// </summary>
    public Dictionary? Unraid { get; set; }

    /// <summary> 
    /// Information about the announcement event. Null if notice_type is not announcement
    /// </summary>
    public TwitchAnnouncement? Announcement { get => field ??= _data.Get<TwitchAnnouncement>("announcement"); set; }

    /// <summary> 
    /// Information about the Bits badge tier event. Null if notice_type is not bits_badge_tier
    /// </summary>
    public TwitchBitsBadgeTier? BitsBadgeTier { get => field ??= _data.Get<TwitchBitsBadgeTier>("bits_badge_tier"); set; }

    /// <summary> 
    /// Information about the announcement event. Null if notice_type is not charity_donation
    /// </summary>
    public TwitchCharityDonation? CharityDonation { get => field ??= _data.Get<TwitchCharityDonation>("charity_donation"); set; }

    /// <summary> 
    /// Information about the Watch Streak event. Null if notice_type is not watch_streak.
    /// </summary>
    public TwitchWatchStreak? WatchStreak { get => field ??= _data.Get<TwitchWatchStreak>("watch_streak"); set; }

    /// <summary> 
    /// Information about the modiversary event. Null if notice_type is not modiversary.
    /// </summary>
    public TwitchModiversary? Modiversary { get => field ??= _data.Get<TwitchModiversary>("modiversary"); set; }

    /// <summary> 
    /// Optional. The broadcaster user ID of the channel the message was sent from. Is null when the message notification happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public string? SourceBroadcasterUserId { get; set; }

    /// <summary> 
    /// Optional. The user name of the broadcaster of the channel the message was sent from. Is null when the message notification happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public string? SourceBroadcasterUserName { get; set; }

    /// <summary> 
    /// Optional. The login of the broadcaster of the channel the message was sent from. Is null when the message notification happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public string? SourceBroadcasterUserLogin { get; set; }

    /// <summary> 
    /// Optional. The UUID that identifies the source message from the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public string? SourceMessageId { get; set; }

    /// <summary> 
    /// Optional. The list of chat badges for the chatter in the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public TwitchSourceBadges[]? SourceBadges { get => field ??= _data.GetArray<TwitchSourceBadges>("source_badges"); set; }

    /// <summary> 
    /// Optional. Whether the notification is only sent to the source channel. Is null if the notification is not in a shared chat session.
    /// </summary>
    public bool IsSourceOnly { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_sub event. Is null if notice_type is not shared_chat_sub. This field has the same information as the sub field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchSub? SharedChatSub { get => field ??= _data.Get<TwitchSub>("shared_chat_sub"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_resub event. Is null if notice_type is not shared_chat_resub. This field has the same information as the resub field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchResub? SharedChatResub { get => field ??= _data.Get<TwitchResub>("shared_chat_resub"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_sub_gift event. Is null if notice_type is not shared_chat_sub_gift. This field has the same information as the chat_sub_gift field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchSubGift? SharedChatSubGift { get => field ??= _data.Get<TwitchSubGift>("shared_chat_sub_gift"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_community_sub_gift event. Is null if notice_type is not shared_chat_community_sub_gift. This field has the same information as the community_sub_gift field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchCommunitySubGift? SharedChatCommunitySubGift { get => field ??= _data.Get<TwitchCommunitySubGift>("shared_chat_community_sub_gift"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_gift_paid_upgrade event. Is null if notice_type is not shared_chat_gift_paid_upgrade. This field has the same information as the gift_paid_upgrade field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchGiftPaidUpgrade? SharedChatGiftPaidUpgrade { get => field ??= _data.Get<TwitchGiftPaidUpgrade>("shared_chat_gift_paid_upgrade"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_chat_prime_paid_upgrade event. Is null if notice_type is not shared_chat_prime_paid_upgrade. This field has the same information as the prime_paid_upgrade field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchPrimePaidUpgrade? SharedChatPrimePaidUpgrade { get => field ??= _data.Get<TwitchPrimePaidUpgrade>("shared_chat_prime_paid_upgrade"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_pay_it_forward event. Is null if notice_type is not shared_chat_pay_it_forward. This field has the same information as the pay_it_forward field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchPayItForward? SharedChatPayItForward { get => field ??= _data.Get<TwitchPayItForward>("shared_chat_pay_it_forward"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_raid event. Is null if notice_type is not shared_chat_raid. This field has the same information as the raid field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchRaid? SharedChatRaid { get => field ??= _data.Get<TwitchRaid>("shared_chat_raid"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_announcement event. Is null if notice_type is not shared_chat_announcement. This field has the same information as the announcement field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchAnnouncement? SharedChatAnnouncement { get => field ??= _data.Get<TwitchAnnouncement>("shared_chat_announcement"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_modiversary event. Is null if notice_type is not shared_chat_modiversary. This field has the same information as the modiversary field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchModiversary? SharedChatModiversary { get => field ??= _data.Get<TwitchModiversary>("shared_chat_modiversary"); set; }

    /// <summary> 
    /// This field has the same information as the unraid field but for a notification that happened in a channel in the shared chat session.
    /// </summary>
    public Dictionary? SharedChatUnraid { get; set; }

    /// <summary> 
    /// This field has the same information as the bits_badge_tier field but for a notification that happened in a channel in the shared chat session.
    /// </summary>
    public TwitchBitsBadgeTier? SharedChatBitsBadgeTier { get => field ??= _data.Get<TwitchBitsBadgeTier>("shared_chat_bits_badge_tier"); set; }

    /// <summary> 
    /// This field has the same information as the charity_donation field but for a notification that happened in a channel in the shared chat session.
    /// </summary>
    public TwitchCharityDonation? SharedChatCharityDonation { get => field ??= _data.Get<TwitchCharityDonation>("shared_chat_charity_donation"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatNotificationEvent object.
    /// </summary> 
    public static TwitchChannelChatNotificationEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelChatNotificationEvent
        {
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            ChatterUserId = data.Read("chatter_user_id", static v => v.AsString()),
            ChatterUserName = data.Read("chatter_user_name", static v => v.AsString()),
            ChatterUserLogin = data.Read("chatter_user_login", static v => v.AsString()),
            ChatterIsAnonymous = data.Read("chatter_is_anonymous", static v => v.AsBool()),
            Color = data.Read("color", static v => v.AsString()),
            SystemMessage = data.Read("system_message", static v => v.AsString()),
            MessageId = data.Read("message_id", static v => v.AsString()),
            NoticeType = data.Read("notice_type", static v => v.AsString()),
            Unraid = data.Read("unraid", static v => v.AsGodotDictionary()),
            SourceBroadcasterUserId = data.Read("source_broadcaster_user_id", static v => v.AsString()),
            SourceBroadcasterUserName = data.Read("source_broadcaster_user_name", static v => v.AsString()),
            SourceBroadcasterUserLogin = data.Read("source_broadcaster_user_login", static v => v.AsString()),
            SourceMessageId = data.Read("source_message_id", static v => v.AsString()),
            IsSourceOnly = data.Read("is_source_only", static v => v.AsBool()),
            SharedChatUnraid = data.Read("shared_chat_unraid", static v => v.AsGodotDictionary()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(ChatterUserId != null) request.SetValue("chatter_user_id", ChatterUserId);
        if(ChatterUserName != null) request.SetValue("chatter_user_name", ChatterUserName);
        if(ChatterUserLogin != null) request.SetValue("chatter_user_login", ChatterUserLogin);
        request.SetValue("chatter_is_anonymous", ChatterIsAnonymous);
        if(Color != null) request.SetValue("color", Color);
        if(Badges != null) request.SetArray("badges", Badges);
        if(SystemMessage != null) request.SetValue("system_message", SystemMessage);
        if(MessageId != null) request.SetValue("message_id", MessageId);
        if(Message != null) request.SetObject("message", Message);
        if(NoticeType != null) request.SetValue("notice_type", NoticeType);
        if(Sub != null) request.SetObject("sub", Sub);
        if(Resub != null) request.SetObject("resub", Resub);
        if(SubGift != null) request.SetObject("sub_gift", SubGift);
        if(CommunitySubGift != null) request.SetObject("community_sub_gift", CommunitySubGift);
        if(GiftPaidUpgrade != null) request.SetObject("gift_paid_upgrade", GiftPaidUpgrade);
        if(PrimePaidUpgrade != null) request.SetObject("prime_paid_upgrade", PrimePaidUpgrade);
        if(PayItForward != null) request.SetObject("pay_it_forward", PayItForward);
        if(Raid != null) request.SetObject("raid", Raid);
        if(Unraid != null) request.SetValue("unraid", Unraid);
        if(Announcement != null) request.SetObject("announcement", Announcement);
        if(BitsBadgeTier != null) request.SetObject("bits_badge_tier", BitsBadgeTier);
        if(CharityDonation != null) request.SetObject("charity_donation", CharityDonation);
        if(WatchStreak != null) request.SetObject("watch_streak", WatchStreak);
        if(Modiversary != null) request.SetObject("modiversary", Modiversary);
        if(SourceBroadcasterUserId != null) request.SetValue("source_broadcaster_user_id", SourceBroadcasterUserId);
        if(SourceBroadcasterUserName != null) request.SetValue("source_broadcaster_user_name", SourceBroadcasterUserName);
        if(SourceBroadcasterUserLogin != null) request.SetValue("source_broadcaster_user_login", SourceBroadcasterUserLogin);
        if(SourceMessageId != null) request.SetValue("source_message_id", SourceMessageId);
        if(SourceBadges != null) request.SetArray("source_badges", SourceBadges);
        request.SetValue("is_source_only", IsSourceOnly);
        if(SharedChatSub != null) request.SetObject("shared_chat_sub", SharedChatSub);
        if(SharedChatResub != null) request.SetObject("shared_chat_resub", SharedChatResub);
        if(SharedChatSubGift != null) request.SetObject("shared_chat_sub_gift", SharedChatSubGift);
        if(SharedChatCommunitySubGift != null) request.SetObject("shared_chat_community_sub_gift", SharedChatCommunitySubGift);
        if(SharedChatGiftPaidUpgrade != null) request.SetObject("shared_chat_gift_paid_upgrade", SharedChatGiftPaidUpgrade);
        if(SharedChatPrimePaidUpgrade != null) request.SetObject("shared_chat_prime_paid_upgrade", SharedChatPrimePaidUpgrade);
        if(SharedChatPayItForward != null) request.SetObject("shared_chat_pay_it_forward", SharedChatPayItForward);
        if(SharedChatRaid != null) request.SetObject("shared_chat_raid", SharedChatRaid);
        if(SharedChatAnnouncement != null) request.SetObject("shared_chat_announcement", SharedChatAnnouncement);
        if(SharedChatModiversary != null) request.SetObject("shared_chat_modiversary", SharedChatModiversary);
        if(SharedChatUnraid != null) request.SetValue("shared_chat_unraid", SharedChatUnraid);
        if(SharedChatBitsBadgeTier != null) request.SetObject("shared_chat_bits_badge_tier", SharedChatBitsBadgeTier);
        if(SharedChatCharityDonation != null) request.SetObject("shared_chat_charity_donation", SharedChatCharityDonation);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }


    public partial class TwitchBadges : RefCounted, ITwitcherSharpEventSub<TwitchBadges>
    {
        private Variant _data;
        
        /// <summary> 
        /// An ID that identifies this set of chat badges. For example, Bits or Subscriber.
        /// </summary>
        public string? SetId { get; set; }
    
        /// <summary> 
        /// An ID that identifies this version of the badge. The ID can be any value. For example, for Bits, the ID is the Bits tier level, but for World of Warcraft, it could be Alliance or Horde.
        /// </summary>
        public string? Id { get; set; }
    
        /// <summary> 
        /// Contains metadata related to the chat badges in the badges tag. Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
        /// </summary>
        public string? Info { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBadges object.
        /// </summary> 
        public static TwitchBadges? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBadges
            {
                SetId = data.Read("set_id", static v => v.AsString()),
                Id = data.Read("id", static v => v.AsString()),
                Info = data.Read("info", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "Badges");
            if(SetId != null) request.SetValue("set_id", SetId);
            if(Id != null) request.SetValue("id", Id);
            if(Info != null) request.SetValue("info", Info);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchMessage : RefCounted, ITwitcherSharpEventSub<TwitchMessage>
    {
        private Variant _data;
        
        /// <summary> 
        /// The chat message in plain text.
        /// </summary>
        public string? Text { get; set; }
    
        /// <summary> 
        /// Ordered list of chat message fragments.
        /// </summary>
        public TwitchFragments[]? Fragments { get => field ??= _data.GetArray<TwitchFragments>("fragments"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMessage object.
        /// </summary> 
        public static TwitchMessage? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchMessage
            {
                Text = data.Read("text", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "Message");
            if(Text != null) request.SetValue("text", Text);
            if(Fragments != null) request.SetArray("fragments", Fragments);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    
        public partial class TwitchFragments : RefCounted, ITwitcherSharpEventSub<TwitchFragments>
        {
            private Variant _data;
            
            /// <summary> 
            /// The type of message fragment. Possible values: textcheermoteemotemention
            /// </summary>
            public string? Type { get; set; }
        
            /// <summary> 
            /// Message text in fragment.
            /// </summary>
            public string? Text { get; set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the cheermote.
            /// </summary>
            public TwitchCheermote? Cheermote { get => field ??= _data.Get<TwitchCheermote>("cheermote"); set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the emote.
            /// </summary>
            public TwitchEmote? Emote { get => field ??= _data.Get<TwitchEmote>("emote"); set; }
        
            /// <summary> 
            /// Optional.  Metadata pertaining to the mention.
            /// </summary>
            public TwitchMention? Mention { get => field ??= _data.Get<TwitchMention>("mention"); set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchFragments object.
            /// </summary> 
            public static TwitchFragments? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchFragments
                {
                    Type = data.Read("type", static v => v.AsString()),
                    Text = data.Read("text", static v => v.AsString()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "Fragments");
                if(Type != null) request.SetValue("type", Type);
                if(Text != null) request.SetValue("text", Text);
                if(Cheermote != null) request.SetObject("cheermote", Cheermote);
                if(Emote != null) request.SetObject("emote", Emote);
                if(Mention != null) request.SetObject("mention", Mention);
                return request;
            }
        
            /// <summary> Releases the twitcher object this instance was mapped from. </summary>
            protected override void Dispose(bool disposing)
            {
                if (disposing) _data.Dispose();
                base.Dispose(disposing);
            }
        
        
            public partial class TwitchCheermote : RefCounted, ITwitcherSharpEventSub<TwitchCheermote>
            {
                private Variant _data;
                
                /// <summary> 
                /// The name portion of the Cheermote string that you use in chat to cheer Bits, converted to lowercase. The full Cheermote string is the concatenation of {prefix} + {number of Bits}.For example, if the prefix is “cheer” and you want to cheer 100 Bits, the full Cheermote string is cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
                /// </summary>
                public string? Prefix { get; set; }
            
                /// <summary> 
                /// The amount of Bits cheered.
                /// </summary>
                public int Bits { get; set; }
            
                /// <summary> 
                /// The tier level of the cheermote.
                /// </summary>
                public int Tier { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchCheermote object.
                /// </summary> 
                public static TwitchCheermote? FromObject(GodotObject? data)
                {
                    if(data == null) return null;
                    var instance = new TwitchCheermote
                    {
                        Prefix = data.Read("prefix", static v => v.AsString()),
                        Bits = data.Read("bits", static v => v.AsInt32()),
                        Tier = data.Read("tier", static v => v.AsInt32()),
                    };
                    
                    instance._data = Variant.CreateFrom(data);
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "Cheermote");
                    if(Prefix != null) request.SetValue("prefix", Prefix);
                    request.SetValue("bits", Bits);
                    request.SetValue("tier", Tier);
                    return request;
                }
            
                /// <summary> Releases the twitcher object this instance was mapped from. </summary>
                protected override void Dispose(bool disposing)
                {
                    if (disposing) _data.Dispose();
                    base.Dispose(disposing);
                }
            }
        
            public partial class TwitchEmote : RefCounted, ITwitcherSharpEventSub<TwitchEmote>
            {
                private Variant _data;
                
                /// <summary> 
                /// An ID that uniquely identifies this emote.
                /// </summary>
                public string? Id { get; set; }
            
                /// <summary> 
                /// An ID that identifies the emote set that the emote belongs to.
                /// </summary>
                public string? EmoteSetId { get; set; }
            
                /// <summary> 
                /// The ID of the broadcaster who owns the emote.
                /// </summary>
                public string? OwnerId { get; set; }
            
                /// <summary> 
                /// The formats that the emote is available in. For example, if the emote is available only as a static PNG, the array contains only static. But if the emote is available as a static PNG and an animated GIF, the array contains static and animated. The possible formats are: animated - An animated GIF is available for this emote.static - A static PNG file is available for this emote.
                /// </summary>
                public string[]? Format { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchEmote object.
                /// </summary> 
                public static TwitchEmote? FromObject(GodotObject? data)
                {
                    if(data == null) return null;
                    var instance = new TwitchEmote
                    {
                        Id = data.Read("id", static v => v.AsString()),
                        EmoteSetId = data.Read("emote_set_id", static v => v.AsString()),
                        OwnerId = data.Read("owner_id", static v => v.AsString()),
                    };
                    
                    instance._data = Variant.CreateFrom(data);
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "Emote");
                    if(Id != null) request.SetValue("id", Id);
                    if(EmoteSetId != null) request.SetValue("emote_set_id", EmoteSetId);
                    if(OwnerId != null) request.SetValue("owner_id", OwnerId);
                    if(Format != null) request.SetValue("format", new Godot.Collections.Array<string>(Format));
                    return request;
                }
            
                /// <summary> Releases the twitcher object this instance was mapped from. </summary>
                protected override void Dispose(bool disposing)
                {
                    if (disposing) _data.Dispose();
                    base.Dispose(disposing);
                }
            }
        
            public partial class TwitchMention : RefCounted, ITwitcherSharpEventSub<TwitchMention>
            {
                private Variant _data;
                
                /// <summary> 
                /// The user ID of the mentioned user.
                /// </summary>
                public string? UserId { get; set; }
            
                /// <summary> 
                /// The user name of the mentioned user.
                /// </summary>
                public string? UserName { get; set; }
            
                /// <summary> 
                /// The user login of the mentioned user.
                /// </summary>
                public string? UserLogin { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchMention object.
                /// </summary> 
                public static TwitchMention? FromObject(GodotObject? data)
                {
                    if(data == null) return null;
                    var instance = new TwitchMention
                    {
                        UserId = data.Read("user_id", static v => v.AsString()),
                        UserName = data.Read("user_name", static v => v.AsString()),
                        UserLogin = data.Read("user_login", static v => v.AsString()),
                    };
                    
                    instance._data = Variant.CreateFrom(data);
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "Mention");
                    if(UserId != null) request.SetValue("user_id", UserId);
                    if(UserName != null) request.SetValue("user_name", UserName);
                    if(UserLogin != null) request.SetValue("user_login", UserLogin);
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

    public partial class TwitchSub : RefCounted, ITwitcherSharpEventSub<TwitchSub>
    {
        private Variant _data;
        
        /// <summary> 
        /// The type of subscription plan being used. Possible values are: 1000 - First level of paid or Prime subscription.2000 - Second level of paid subscription.3000 - Third level of paid subscription.
        /// </summary>
        public string? SubTier { get; set; }
    
        /// <summary> 
        /// Indicates if the subscription was obtained through Amazon Prime.
        /// </summary>
        public bool IsPrime { get; set; }
    
        /// <summary> 
        /// The number of months the subscription is for.
        /// </summary>
        public int DurationMonths { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSub object.
        /// </summary> 
        public static TwitchSub? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchSub
            {
                SubTier = data.Read("sub_tier", static v => v.AsString()),
                IsPrime = data.Read("is_prime", static v => v.AsBool()),
                DurationMonths = data.Read("duration_months", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "Sub");
            if(SubTier != null) request.SetValue("sub_tier", SubTier);
            request.SetValue("is_prime", IsPrime);
            request.SetValue("duration_months", DurationMonths);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchResub : RefCounted, ITwitcherSharpEventSub<TwitchResub>
    {
        private Variant _data;
        
        /// <summary> 
        /// The total number of months the user has subscribed.
        /// </summary>
        public int CumulativeMonths { get; set; }
    
        /// <summary> 
        /// The number of months the subscription is for.
        /// </summary>
        public int DurationMonths { get; set; }
    
        /// <summary> 
        /// The total number of months the user has subscribed.
        /// </summary>
        public int StreakMonths { get; set; }
    
        /// <summary> 
        /// The type of subscription plan being used. Possible values are: 1000 - First level of paid or Prime subscription.2000 - Second level of paid subscription.3000 - Third level of paid subscription.
        /// </summary>
        public string? SubTier { get; set; }
    
        /// <summary> 
        /// Optional. Whether or not this subscription is a Prime subscription.
        /// </summary>
        public bool IsPrime { get; set; }
    
        /// <summary> 
        /// Whether or not the resub was a result of a gift.
        /// </summary>
        public bool IsGift { get; set; }
    
        /// <summary> 
        /// Optional. Whether or not the gift was anonymous.
        /// </summary>
        public bool GifterIsAnonymous { get; set; }
    
        /// <summary> 
        /// The user ID of the subscription gifter. Null if anonymous.
        /// </summary>
        public string? GifterUserId { get; set; }
    
        /// <summary> 
        /// The user name of the subscription gifter. Null if anonymous.
        /// </summary>
        public string? GifterUserName { get; set; }
    
        /// <summary> 
        /// Optional. The user login of the subscription gifter. Null if anonymous.
        /// </summary>
        public string? GifterUserLogin { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResub object.
        /// </summary> 
        public static TwitchResub? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchResub
            {
                CumulativeMonths = data.Read("cumulative_months", static v => v.AsInt32()),
                DurationMonths = data.Read("duration_months", static v => v.AsInt32()),
                StreakMonths = data.Read("streak_months", static v => v.AsInt32()),
                SubTier = data.Read("sub_tier", static v => v.AsString()),
                IsPrime = data.Read("is_prime", static v => v.AsBool()),
                IsGift = data.Read("is_gift", static v => v.AsBool()),
                GifterIsAnonymous = data.Read("gifter_is_anonymous", static v => v.AsBool()),
                GifterUserId = data.Read("gifter_user_id", static v => v.AsString()),
                GifterUserName = data.Read("gifter_user_name", static v => v.AsString()),
                GifterUserLogin = data.Read("gifter_user_login", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "Resub");
            request.SetValue("cumulative_months", CumulativeMonths);
            request.SetValue("duration_months", DurationMonths);
            request.SetValue("streak_months", StreakMonths);
            if(SubTier != null) request.SetValue("sub_tier", SubTier);
            request.SetValue("is_prime", IsPrime);
            request.SetValue("is_gift", IsGift);
            request.SetValue("gifter_is_anonymous", GifterIsAnonymous);
            if(GifterUserId != null) request.SetValue("gifter_user_id", GifterUserId);
            if(GifterUserName != null) request.SetValue("gifter_user_name", GifterUserName);
            if(GifterUserLogin != null) request.SetValue("gifter_user_login", GifterUserLogin);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchSubGift : RefCounted, ITwitcherSharpEventSub<TwitchSubGift>
    {
        private Variant _data;
        
        /// <summary> 
        /// The number of months the subscription is for.
        /// </summary>
        public int DurationMonths { get; set; }
    
        /// <summary> 
        /// Optional. The amount of gifts the gifter has given in this channel. Null if anonymous.
        /// </summary>
        public int CumulativeTotal { get; set; }
    
        /// <summary> 
        /// The user ID of the subscription gift recipient.
        /// </summary>
        public string? RecipientUserId { get; set; }
    
        /// <summary> 
        /// The user name of the subscription gift recipient.
        /// </summary>
        public string? RecipientUserName { get; set; }
    
        /// <summary> 
        /// The user login of the subscription gift recipient.
        /// </summary>
        public string? RecipientUserLogin { get; set; }
    
        /// <summary> 
        /// The type of subscription plan being used. Possible values are: 1000 - First level of paid or Prime subscription.2000 - Second level of paid subscription.3000 - Third level of paid subscription.
        /// </summary>
        public string? SubTier { get; set; }
    
        /// <summary> 
        /// Optional. The ID of the associated community gift. Null if not associated with a community gift.
        /// </summary>
        public string? CommunityGiftId { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSubGift object.
        /// </summary> 
        public static TwitchSubGift? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchSubGift
            {
                DurationMonths = data.Read("duration_months", static v => v.AsInt32()),
                CumulativeTotal = data.Read("cumulative_total", static v => v.AsInt32()),
                RecipientUserId = data.Read("recipient_user_id", static v => v.AsString()),
                RecipientUserName = data.Read("recipient_user_name", static v => v.AsString()),
                RecipientUserLogin = data.Read("recipient_user_login", static v => v.AsString()),
                SubTier = data.Read("sub_tier", static v => v.AsString()),
                CommunityGiftId = data.Read("community_gift_id", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "SubGift");
            request.SetValue("duration_months", DurationMonths);
            request.SetValue("cumulative_total", CumulativeTotal);
            if(RecipientUserId != null) request.SetValue("recipient_user_id", RecipientUserId);
            if(RecipientUserName != null) request.SetValue("recipient_user_name", RecipientUserName);
            if(RecipientUserLogin != null) request.SetValue("recipient_user_login", RecipientUserLogin);
            if(SubTier != null) request.SetValue("sub_tier", SubTier);
            if(CommunityGiftId != null) request.SetValue("community_gift_id", CommunityGiftId);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchCommunitySubGift : RefCounted, ITwitcherSharpEventSub<TwitchCommunitySubGift>
    {
        private Variant _data;
        
        /// <summary> 
        /// The ID of the associated community gift.
        /// </summary>
        public string? Id { get; set; }
    
        /// <summary> 
        /// Number of subscriptions being gifted.
        /// </summary>
        public int Total { get; set; }
    
        /// <summary> 
        /// The type of subscription plan being used. Possible values are: 1000 - First level of paid or Prime subscription.2000 - Second level of paid subscription.3000 - Third level of paid subscription.
        /// </summary>
        public string? SubTier { get; set; }
    
        /// <summary> 
        /// Optional. The amount of gifts the gifter has given in this channel. Null if anonymous.
        /// </summary>
        public int CumulativeTotal { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchCommunitySubGift object.
        /// </summary> 
        public static TwitchCommunitySubGift? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchCommunitySubGift
            {
                Id = data.Read("id", static v => v.AsString()),
                Total = data.Read("total", static v => v.AsInt32()),
                SubTier = data.Read("sub_tier", static v => v.AsString()),
                CumulativeTotal = data.Read("cumulative_total", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "CommunitySubGift");
            if(Id != null) request.SetValue("id", Id);
            request.SetValue("total", Total);
            if(SubTier != null) request.SetValue("sub_tier", SubTier);
            request.SetValue("cumulative_total", CumulativeTotal);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchGiftPaidUpgrade : RefCounted, ITwitcherSharpEventSub<TwitchGiftPaidUpgrade>
    {
        private Variant _data;
        
        /// <summary> 
        /// Whether the gift was given anonymously.
        /// </summary>
        public bool GifterIsAnonymous { get; set; }
    
        /// <summary> 
        /// Optional. The user ID of the user who gifted the subscription. Null if anonymous.
        /// </summary>
        public string? GifterUserId { get; set; }
    
        /// <summary> 
        /// Optional. The user name of the user who gifted the subscription. Null if anonymous.
        /// </summary>
        public string? GifterUserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchGiftPaidUpgrade object.
        /// </summary> 
        public static TwitchGiftPaidUpgrade? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchGiftPaidUpgrade
            {
                GifterIsAnonymous = data.Read("gifter_is_anonymous", static v => v.AsBool()),
                GifterUserId = data.Read("gifter_user_id", static v => v.AsString()),
                GifterUserName = data.Read("gifter_user_name", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "GiftPaidUpgrade");
            request.SetValue("gifter_is_anonymous", GifterIsAnonymous);
            if(GifterUserId != null) request.SetValue("gifter_user_id", GifterUserId);
            if(GifterUserName != null) request.SetValue("gifter_user_name", GifterUserName);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchPrimePaidUpgrade : RefCounted, ITwitcherSharpEventSub<TwitchPrimePaidUpgrade>
    {
        private Variant _data;
        
        /// <summary> 
        /// The type of subscription plan being used. Possible values are: 1000 - First level of paid or Prime subscription.2000 - Second level of paid subscription.3000 - Third level of paid subscription.
        /// </summary>
        public string? SubTier { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchPrimePaidUpgrade object.
        /// </summary> 
        public static TwitchPrimePaidUpgrade? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchPrimePaidUpgrade
            {
                SubTier = data.Read("sub_tier", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "PrimePaidUpgrade");
            if(SubTier != null) request.SetValue("sub_tier", SubTier);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchPayItForward : RefCounted, ITwitcherSharpEventSub<TwitchPayItForward>
    {
        private Variant _data;
        
        /// <summary> 
        /// Whether the gift was given anonymously.
        /// </summary>
        public bool GifterIsAnonymous { get; set; }
    
        /// <summary> 
        /// The user ID of the user who gifted the subscription. Null if anonymous.
        /// </summary>
        public string? GifterUserId { get; set; }
    
        /// <summary> 
        /// Optional. The user name of the user who gifted the subscription. Null if anonymous.
        /// </summary>
        public string? GifterUserName { get; set; }
    
        /// <summary> 
        /// The user login of the user who gifted the subscription. Null if anonymous.
        /// </summary>
        public string? GifterUserLogin { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchPayItForward object.
        /// </summary> 
        public static TwitchPayItForward? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchPayItForward
            {
                GifterIsAnonymous = data.Read("gifter_is_anonymous", static v => v.AsBool()),
                GifterUserId = data.Read("gifter_user_id", static v => v.AsString()),
                GifterUserName = data.Read("gifter_user_name", static v => v.AsString()),
                GifterUserLogin = data.Read("gifter_user_login", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "PayItForward");
            request.SetValue("gifter_is_anonymous", GifterIsAnonymous);
            if(GifterUserId != null) request.SetValue("gifter_user_id", GifterUserId);
            if(GifterUserName != null) request.SetValue("gifter_user_name", GifterUserName);
            if(GifterUserLogin != null) request.SetValue("gifter_user_login", GifterUserLogin);
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
        /// The user ID of the broadcaster raiding this channel.
        /// </summary>
        public string? UserId { get; set; }
    
        /// <summary> 
        /// The user name of the broadcaster raiding this channel.
        /// </summary>
        public string? UserName { get; set; }
    
        /// <summary> 
        /// The login name of the broadcaster raiding this channel.
        /// </summary>
        public string? UserLogin { get; set; }
    
        /// <summary> 
        /// The number of viewers raiding this channel from the broadcaster’s channel.
        /// </summary>
        public int ViewerCount { get; set; }
    
        /// <summary> 
        /// Profile image URL of the broadcaster raiding this channel.
        /// </summary>
        public string? ProfileImageUrl { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchRaid object.
        /// </summary> 
        public static TwitchRaid? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchRaid
            {
                UserId = data.Read("user_id", static v => v.AsString()),
                UserName = data.Read("user_name", static v => v.AsString()),
                UserLogin = data.Read("user_login", static v => v.AsString()),
                ViewerCount = data.Read("viewer_count", static v => v.AsInt32()),
                ProfileImageUrl = data.Read("profile_image_url", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "Raid");
            if(UserId != null) request.SetValue("user_id", UserId);
            if(UserName != null) request.SetValue("user_name", UserName);
            if(UserLogin != null) request.SetValue("user_login", UserLogin);
            request.SetValue("viewer_count", ViewerCount);
            if(ProfileImageUrl != null) request.SetValue("profile_image_url", ProfileImageUrl);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchAnnouncement : RefCounted, ITwitcherSharpEventSub<TwitchAnnouncement>
    {
        private Variant _data;
        
        /// <summary> 
        /// Color of the announcement.
        /// </summary>
        public string? Color { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchAnnouncement object.
        /// </summary> 
        public static TwitchAnnouncement? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchAnnouncement
            {
                Color = data.Read("color", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "Announcement");
            if(Color != null) request.SetValue("color", Color);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchBitsBadgeTier : RefCounted, ITwitcherSharpEventSub<TwitchBitsBadgeTier>
    {
        private Variant _data;
        
        /// <summary> 
        /// The tier of the Bits badge the user just earned. For example, 100, 1000, or 10000.
        /// </summary>
        public int Tier { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBitsBadgeTier object.
        /// </summary> 
        public static TwitchBitsBadgeTier? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchBitsBadgeTier
            {
                Tier = data.Read("tier", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "BitsBadgeTier");
            request.SetValue("tier", Tier);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchCharityDonation : RefCounted, ITwitcherSharpEventSub<TwitchCharityDonation>
    {
        private Variant _data;
        
        /// <summary> 
        /// Name of the charity.
        /// </summary>
        public string? CharityName { get; set; }
    
        /// <summary> 
        /// An object that contains the amount of money that the user paid.
        /// </summary>
        public TwitchAmount? Amount { get => field ??= _data.Get<TwitchAmount>("amount"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchCharityDonation object.
        /// </summary> 
        public static TwitchCharityDonation? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchCharityDonation
            {
                CharityName = data.Read("charity_name", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "CharityDonation");
            if(CharityName != null) request.SetValue("charity_name", CharityName);
            if(Amount != null) request.SetObject("amount", Amount);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    
    
        public partial class TwitchAmount : RefCounted, ITwitcherSharpEventSub<TwitchAmount>
        {
            private Variant _data;
            
            /// <summary> 
            /// The monetary amount. The amount is specified in the currency’s minor unit. For example, the minor units for USD is cents, so if the amount is $5.50 USD, value is set to 550.
            /// </summary>
            public int Value { get; set; }
        
            /// <summary> 
            /// The number of decimal places used by the currency. For example, USD uses two decimal places.
            /// </summary>
            public int DecimalPlace { get; set; }
        
            /// <summary> 
            /// The ISO-4217 three-letter currency code that identifies the type of currency in value.
            /// </summary>
            public string? Currency { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchAmount object.
            /// </summary> 
            public static TwitchAmount? FromObject(GodotObject? data)
            {
                if(data == null) return null;
                var instance = new TwitchAmount
                {
                    Value = data.Read("value", static v => v.AsInt32()),
                    DecimalPlace = data.Read("decimal_place", static v => v.AsInt32()),
                    Currency = data.Read("currency", static v => v.AsString()),
                };
                
                instance._data = Variant.CreateFrom(data);
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "Amount");
                request.SetValue("value", Value);
                request.SetValue("decimal_place", DecimalPlace);
                if(Currency != null) request.SetValue("currency", Currency);
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

    public partial class TwitchWatchStreak : RefCounted, ITwitcherSharpEventSub<TwitchWatchStreak>
    {
        private Variant _data;
        
        /// <summary> 
        /// The number of consecutive broadcasts for which the user has been watching.
        /// </summary>
        public int StreakCount { get; set; }
    
        /// <summary> 
        /// The number of channel points awarded for the Watch Streak milestone.
        /// </summary>
        public int ChannelPointsAwarded { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchWatchStreak object.
        /// </summary> 
        public static TwitchWatchStreak? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchWatchStreak
            {
                StreakCount = data.Read("streak_count", static v => v.AsInt32()),
                ChannelPointsAwarded = data.Read("channel_points_awarded", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "WatchStreak");
            request.SetValue("streak_count", StreakCount);
            request.SetValue("channel_points_awarded", ChannelPointsAwarded);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchModiversary : RefCounted, ITwitcherSharpEventSub<TwitchModiversary>
    {
        private Variant _data;
        
        /// <summary> 
        /// The number of months the user has been a moderator in this channel.
        /// </summary>
        public int Months { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchModiversary object.
        /// </summary> 
        public static TwitchModiversary? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchModiversary
            {
                Months = data.Read("months", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "Modiversary");
            request.SetValue("months", Months);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchSourceBadges : RefCounted, ITwitcherSharpEventSub<TwitchSourceBadges>
    {
        private Variant _data;
        
        /// <summary> 
        /// The ID that identifies this set of chat badges. For example, Bits or Subscriber.
        /// </summary>
        public string? SetId { get; set; }
    
        /// <summary> 
        /// The ID that identifies this version of the badge. The ID can be any value. For example, for Bits, the ID is the Bits tier level, but for World of Warcraft, it could be Alliance or Horde.
        /// </summary>
        public string? Id { get; set; }
    
        /// <summary> 
        /// Contains metadata related to the chat badges in the badges tag. Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
        /// </summary>
        public string? Info { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSourceBadges object.
        /// </summary> 
        public static TwitchSourceBadges? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchSourceBadges
            {
                SetId = data.Read("set_id", static v => v.AsString()),
                Id = data.Read("id", static v => v.AsString()),
                Info = data.Read("info", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd", "SourceBadges");
            if(SetId != null) request.SetValue("set_id", SetId);
            if(Id != null) request.SetValue("id", Id);
            if(Info != null) request.SetValue("info", Info);
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
