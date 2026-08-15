using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatNotification;

public partial class TwitchChannelChatNotificationEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelChatNotificationEvent>
{
    private GodotObject _data;
    
    /// <summary> 
    /// The broadcaster user ID.
    /// </summary>
    public string BroadcasterUserId { get; set; }

    /// <summary> 
    /// The broadcaster display name.
    /// </summary>
    public string BroadcasterUserName { get; set; }

    /// <summary> 
    /// The broadcaster login.
    /// </summary>
    public string BroadcasterUserLogin { get; set; }

    /// <summary> 
    /// The user ID of the user that sent the message.
    /// </summary>
    public string ChatterUserId { get; set; }

    /// <summary> 
    /// The user login of the user that sent the message.
    /// </summary>
    public string ChatterUserName { get; set; }

    /// <summary> 
    /// Whether or not the chatter is anonymous.
    /// </summary>
    public bool ChatterIsAnonymous { get; set; }

    /// <summary> 
    /// The color of the user’s name in the chat room.
    /// </summary>
    public string Color { get; set; }

    /// <summary> 
    /// The color of the user’s name in the chat room.
    /// </summary>
    public TwitchBadges[] Badges { get => field ??= _data?.GetArray<TwitchBadges>("badges"); set; }

    /// <summary> 
    /// The message Twitch shows in the chat room for this notice.
    /// </summary>
    public string SystemMessage { get; set; }

    /// <summary> 
    /// A UUID that identifies the message.
    /// </summary>
    public string MessageId { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMessage Message { get => field ??= _data?.Get<TwitchMessage>("message"); set; }

    /// <summary> 
    /// The type of notice. Possible values are: subresubsub_giftcommunity_sub_giftgift_paid_upgradeprime_paid_upgraderaidunraidpay_it_forwardannouncementbits_badge_tiercharity_donationwatch_streakshared_chat_subshared_chat_resubshared_chat_sub_giftshared_chat_community_sub_giftshared_chat_gift_paid_upgradeshared_chat_prime_paid_upgradeshared_chat_raidshared_chat_pay_it_forwardshared_chat_announcement
    /// </summary>
    public string NoticeType { get; set; }

    /// <summary> 
    /// Information about the sub event. Null if notice_type is not sub.
    /// </summary>
    public TwitchSub Sub { get => field ??= _data?.Get<TwitchSub>("sub"); set; }

    /// <summary> 
    /// Information about the resub event. Null if notice_type is not resub.
    /// </summary>
    public TwitchResub Resub { get => field ??= _data?.Get<TwitchResub>("resub"); set; }

    /// <summary> 
    /// Information about the gift sub event. Null if notice_type is not sub_gift.
    /// </summary>
    public TwitchSubGift SubGift { get => field ??= _data?.Get<TwitchSubGift>("sub_gift"); set; }

    /// <summary> 
    /// Information about the community gift sub event. Null if notice_type is not community_sub_gift.
    /// </summary>
    public TwitchCommunitySubGift CommunitySubGift { get => field ??= _data?.Get<TwitchCommunitySubGift>("community_sub_gift"); set; }

    /// <summary> 
    /// Information about the community gift paid upgrade event. Null if notice_type is not gift_paid_upgrade.
    /// </summary>
    public TwitchGiftPaidUpgrade GiftPaidUpgrade { get => field ??= _data?.Get<TwitchGiftPaidUpgrade>("gift_paid_upgrade"); set; }

    /// <summary> 
    /// Information about the Prime gift paid upgrade event. Null if notice_type is not prime_paid_upgrade
    /// </summary>
    public TwitchPrimePaidUpgrade PrimePaidUpgrade { get => field ??= _data?.Get<TwitchPrimePaidUpgrade>("prime_paid_upgrade"); set; }

    /// <summary> 
    /// Information about the pay it forward event. Null if notice_type is not pay_it_forward
    /// </summary>
    public TwitchPayItForward PayItForward { get => field ??= _data?.Get<TwitchPayItForward>("pay_it_forward"); set; }

    /// <summary> 
    /// Information about the raid event. Null if notice_type is not raid
    /// </summary>
    public TwitchRaid Raid { get => field ??= _data?.Get<TwitchRaid>("raid"); set; }

    /// <summary> 
    /// Returns an empty payload if  notice_type is not unraid, otherwise returns null.
    /// </summary>
    public Dictionary Unraid { get; set; }

    /// <summary> 
    /// Information about the announcement event. Null if notice_type is not announcement
    /// </summary>
    public TwitchAnnouncement Announcement { get => field ??= _data?.Get<TwitchAnnouncement>("announcement"); set; }

    /// <summary> 
    /// Information about the Bits badge tier event. Null if notice_type is not bits_badge_tier
    /// </summary>
    public TwitchBitsBadgeTier BitsBadgeTier { get => field ??= _data?.Get<TwitchBitsBadgeTier>("bits_badge_tier"); set; }

    /// <summary> 
    /// Information about the announcement event. Null if notice_type is not charity_donation
    /// </summary>
    public string CharityDonation { get; set; }

    /// <summary> 
    /// Name of the charity.
    /// </summary>
    public string CharityName { get; set; }

    /// <summary> 
    /// An object that contains the amount of money that the user paid.
    /// </summary>
    public TwitchAmount Amount { get => field ??= _data?.Get<TwitchAmount>("amount"); set; }

    /// <summary> 
    /// Information about the Watch Streak event. Null if notice_type is not watch_streak.
    /// </summary>
    public TwitchWatchStreak WatchStreak { get => field ??= _data?.Get<TwitchWatchStreak>("watch_streak"); set; }

    /// <summary> 
    /// Optional. The broadcaster user ID of the channel the message was sent from. Is null when the message notification happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public string SourceBroadcasterUserId { get; set; }

    /// <summary> 
    /// Optional. The user name of the broadcaster of the channel the message was sent from. Is null when the message notification happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public string SourceBroadcasterUserName { get; set; }

    /// <summary> 
    /// Optional. The login of the broadcaster of the channel the message was sent from. Is null when the message notification happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public string SourceBroadcasterUserLogin { get; set; }

    /// <summary> 
    /// Optional. The UUID that identifies the source message from the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public string SourceMessageId { get; set; }

    /// <summary> 
    /// Optional. The list of chat badges for the chatter in the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public TwitchSourceBadges[] SourceBadges { get => field ??= _data?.GetArray<TwitchSourceBadges>("source_badges"); set; }

    /// <summary> 
    /// Optional. Whether the notification is only sent to the source channel. Is null if the notification is not in a shared chat session.
    /// </summary>
    public bool IsSourceOnly { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_sub event. Is null if notice_type is not shared_chat_sub. This field has the same information as the sub field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchSub SharedChatSub { get => field ??= _data?.Get<TwitchSub>("shared_chat_sub"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_resub event. Is null if notice_type is not shared_chat_resub. This field has the same information as the resub field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchResub SharedChatResub { get => field ??= _data?.Get<TwitchResub>("shared_chat_resub"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_sub_gift event. Is null if notice_type is not shared_chat_sub_gift. This field has the same information as the chat_sub_gift field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchSubGift SharedChatSubGift { get => field ??= _data?.Get<TwitchSubGift>("shared_chat_sub_gift"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_community_sub_gift event. Is null if notice_type is not shared_chat_community_sub_gift. This field has the same information as the community_sub_gift field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchCommunitySubGift SharedChatCommunitySubGift { get => field ??= _data?.Get<TwitchCommunitySubGift>("shared_chat_community_sub_gift"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_gift_paid_upgrade event. Is null if notice_type is not shared_chat_gift_paid_upgrade. This field has the same information as the gift_paid_upgrade field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchGiftPaidUpgrade SharedChatGiftPaidUpgrade { get => field ??= _data?.Get<TwitchGiftPaidUpgrade>("shared_chat_gift_paid_upgrade"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_chat_prime_paid_upgrade event. Is null if notice_type is not shared_chat_prime_paid_upgrade. This field has the same information as the prime_paid_upgrade field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchPrimePaidUpgrade SharedChatPrimePaidUpgrade { get => field ??= _data?.Get<TwitchPrimePaidUpgrade>("shared_chat_prime_paid_upgrade"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_pay_it_forward event. Is null if notice_type is not shared_chat_pay_it_forward. This field has the same information as the pay_it_forward field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchPayItForward SharedChatPayItForward { get => field ??= _data?.Get<TwitchPayItForward>("shared_chat_pay_it_forward"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_raid event. Is null if notice_type is not shared_chat_raid. This field has the same information as the raid field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchRaid SharedChatRaid { get => field ??= _data?.Get<TwitchRaid>("shared_chat_raid"); set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_announcement event. Is null if notice_type is not shared_chat_announcement. This field has the same information as the announcement field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchAnnouncement SharedChatAnnouncement { get => field ??= _data?.Get<TwitchAnnouncement>("shared_chat_announcement"); set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatNotificationEvent object.
    /// </summary> 
    public static TwitchChannelChatNotificationEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelChatNotificationEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            ChatterUserId = data.Get("chatter_user_id").AsString(),
            ChatterUserName = data.Get("chatter_user_name").AsString(),
            ChatterIsAnonymous = data.Get("chatter_is_anonymous").AsBool(),
            Color = data.Get("color").AsString(),
            SystemMessage = data.Get("system_message").AsString(),
            MessageId = data.Get("message_id").AsString(),
            NoticeType = data.Get("notice_type").AsString(),
            Unraid = data.Get("unraid").AsGodotDictionary(),
            CharityDonation = data.Get("charity_donation").AsString(),
            CharityName = data.Get("charity_name").AsString(),
            SourceBroadcasterUserId = data.Get("source_broadcaster_user_id").AsString(),
            SourceBroadcasterUserName = data.Get("source_broadcaster_user_name").AsString(),
            SourceBroadcasterUserLogin = data.Get("source_broadcaster_user_login").AsString(),
            SourceMessageId = data.Get("source_message_id").AsString(),
            IsSourceOnly = data.Get("is_source_only").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("chatter_user_id", ChatterUserId);
        request.Set("chatter_user_name", ChatterUserName);
        request.Set("chatter_is_anonymous", ChatterIsAnonymous);
        request.Set("color", Color);
        if(Badges != null) request.SetArray("badges", Badges);
        request.Set("system_message", SystemMessage);
        request.Set("message_id", MessageId);
        request.Set("message", Message?.ToGodotObject());
        request.Set("notice_type", NoticeType);
        request.Set("sub", Sub?.ToGodotObject());
        request.Set("resub", Resub?.ToGodotObject());
        request.Set("sub_gift", SubGift?.ToGodotObject());
        request.Set("community_sub_gift", CommunitySubGift?.ToGodotObject());
        request.Set("gift_paid_upgrade", GiftPaidUpgrade?.ToGodotObject());
        request.Set("prime_paid_upgrade", PrimePaidUpgrade?.ToGodotObject());
        request.Set("pay_it_forward", PayItForward?.ToGodotObject());
        request.Set("raid", Raid?.ToGodotObject());
        request.Set("unraid", Unraid);
        request.Set("announcement", Announcement?.ToGodotObject());
        request.Set("bits_badge_tier", BitsBadgeTier?.ToGodotObject());
        request.Set("charity_donation", CharityDonation);
        request.Set("charity_name", CharityName);
        request.Set("amount", Amount?.ToGodotObject());
        request.Set("watch_streak", WatchStreak?.ToGodotObject());
        request.Set("source_broadcaster_user_id", SourceBroadcasterUserId);
        request.Set("source_broadcaster_user_name", SourceBroadcasterUserName);
        request.Set("source_broadcaster_user_login", SourceBroadcasterUserLogin);
        request.Set("source_message_id", SourceMessageId);
        if(SourceBadges != null) request.SetArray("source_badges", SourceBadges);
        request.Set("is_source_only", IsSourceOnly);
        request.Set("shared_chat_sub", SharedChatSub?.ToGodotObject());
        request.Set("shared_chat_resub", SharedChatResub?.ToGodotObject());
        request.Set("shared_chat_sub_gift", SharedChatSubGift?.ToGodotObject());
        request.Set("shared_chat_community_sub_gift", SharedChatCommunitySubGift?.ToGodotObject());
        request.Set("shared_chat_gift_paid_upgrade", SharedChatGiftPaidUpgrade?.ToGodotObject());
        request.Set("shared_chat_prime_paid_upgrade", SharedChatPrimePaidUpgrade?.ToGodotObject());
        request.Set("shared_chat_pay_it_forward", SharedChatPayItForward?.ToGodotObject());
        request.Set("shared_chat_raid", SharedChatRaid?.ToGodotObject());
        request.Set("shared_chat_announcement", SharedChatAnnouncement?.ToGodotObject());
        return request;
    }


    public partial class TwitchBadges : RefCounted, ITwitcherSharpEventSub<TwitchBadges>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// An ID that identifies this set of chat badges. For example, Bits or Subscriber.
        /// </summary>
        public string SetId { get; set; }
    
        /// <summary> 
        /// An ID that identifies this version of the badge. The ID can be any value. For example, for Bits, the ID is the Bits tier level, but for World of Warcraft, it could be Alliance or Horde.
        /// </summary>
        public string Id { get; set; }
    
        /// <summary> 
        /// Contains metadata related to the chat badges in the badges tag. Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
        /// </summary>
        public string Info { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBadges object.
        /// </summary> 
        public static TwitchBadges FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchBadges
            {
                SetId = data.Get("set_id").AsString(),
                Id = data.Get("id").AsString(),
                Info = data.Get("info").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var badgesClass = script.Get("Badges").As<GDScript>();
            var request = badgesClass.New().AsGodotObject();
            request.Set("set_id", SetId);
            request.Set("id", Id);
            request.Set("info", Info);
            return request;
        }
    }

    public partial class TwitchMessage : RefCounted, ITwitcherSharpEventSub<TwitchMessage>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The chat message in plain text.
        /// </summary>
        public Dictionary Text { get; set; }
    
        /// <summary> 
        /// Ordered list of chat message fragments.
        /// </summary>
        public TwitchFragments[] Fragments { get => field ??= _data?.GetArray<TwitchFragments>("fragments"); set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMessage object.
        /// </summary> 
        public static TwitchMessage FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchMessage
            {
                Text = data.Get("text").AsGodotDictionary(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var messageClass = script.Get("Message").As<GDScript>();
            var request = messageClass.New().AsGodotObject();
            request.Set("text", Text);
            if(Fragments != null) request.SetArray("fragments", Fragments);
            return request;
        }
    
    
        public partial class TwitchFragments : RefCounted, ITwitcherSharpEventSub<TwitchFragments>
        {
            private GodotObject _data;
            
            /// <summary> 
            /// The type of message fragment. Possible values: textcheermoteemotemention
            /// </summary>
            public string Type { get; set; }
        
            /// <summary> 
            /// Message text in fragment.
            /// </summary>
            public string Text { get; set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the cheermote.
            /// </summary>
            public TwitchCheermote Cheermote { get => field ??= _data?.Get<TwitchCheermote>("cheermote"); set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the emote.
            /// </summary>
            public TwitchEmote Emote { get => field ??= _data?.Get<TwitchEmote>("emote"); set; }
        
            /// <summary> 
            /// Optional.  Metadata pertaining to the mention.
            /// </summary>
            public TwitchMention Mention { get => field ??= _data?.Get<TwitchMention>("mention"); set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchFragments object.
            /// </summary> 
            public static TwitchFragments FromObject(GodotObject data)
            {
                if(data == null) return null;
                var instance = new TwitchFragments
                {
                    Type = data.Get("type").AsString(),
                    Text = data.Get("text").AsString(),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
                var fragmentsClass = script.Get("Fragments").As<GDScript>();
                var request = fragmentsClass.New().AsGodotObject();
                request.Set("type", Type);
                request.Set("text", Text);
                request.Set("cheermote", Cheermote?.ToGodotObject());
                request.Set("emote", Emote?.ToGodotObject());
                request.Set("mention", Mention?.ToGodotObject());
                return request;
            }
        
        
            public partial class TwitchCheermote : RefCounted, ITwitcherSharpEventSub<TwitchCheermote>
            {
                private GodotObject _data;
                
                /// <summary> 
                /// The name portion of the Cheermote string that you use in chat to cheer Bits. The full Cheermote string is the concatenation of {prefix} + {number of Bits}. For example, if the prefix is “Cheer” and you want to cheer 100 Bits, the full Cheermote string is Cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
                /// </summary>
                public Dictionary Prefix { get; set; }
            
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
                public static TwitchCheermote FromObject(GodotObject data)
                {
                    if(data == null) return null;
                    var instance = new TwitchCheermote
                    {
                        Prefix = data.Get("prefix").AsGodotDictionary(),
                        Bits = data.Get("bits").AsInt32(),
                        Tier = data.Get("tier").AsInt32(),
                    };
                    
                    instance._data = data;
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
                    var cheermoteClass = script.Get("Cheermote").As<GDScript>();
                    var request = cheermoteClass.New().AsGodotObject();
                    request.Set("prefix", Prefix);
                    request.Set("bits", Bits);
                    request.Set("tier", Tier);
                    return request;
                }
            }
        
            public partial class TwitchEmote : RefCounted, ITwitcherSharpEventSub<TwitchEmote>
            {
                private GodotObject _data;
                
                /// <summary> 
                /// An ID that uniquely identifies this emote.
                /// </summary>
                public string Id { get; set; }
            
                /// <summary> 
                /// An ID that identifies the emote set that the emote belongs to.
                /// </summary>
                public string EmoteSetId { get; set; }
            
                /// <summary> 
                /// The ID of the broadcaster who owns the emote.
                /// </summary>
                public string OwnerId { get; set; }
            
                /// <summary> 
                /// The formats that the emote is available in. For example, if the emote is available only as a static PNG, the array contains only static. But if the emote is available as a static PNG and an animated GIF, the array contains static and animated. The possible formats are: animated - An animated GIF is available for this emote.static - A static PNG file is available for this emote.
                /// </summary>
                public string[] Format { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchEmote object.
                /// </summary> 
                public static TwitchEmote FromObject(GodotObject data)
                {
                    if(data == null) return null;
                    var instance = new TwitchEmote
                    {
                        Id = data.Get("id").AsString(),
                        EmoteSetId = data.Get("emote_set_id").AsString(),
                        OwnerId = data.Get("owner_id").AsString(),
                    };
                    
                    instance._data = data;
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
                    var emoteClass = script.Get("Emote").As<GDScript>();
                    var request = emoteClass.New().AsGodotObject();
                    request.Set("id", Id);
                    request.Set("emote_set_id", EmoteSetId);
                    request.Set("owner_id", OwnerId);
                    if(Format != null) request.Set("format", new Godot.Collections.Array<string>(Format));
                    return request;
                }
            }
        
            public partial class TwitchMention : RefCounted, ITwitcherSharpEventSub<TwitchMention>
            {
                private GodotObject _data;
                
                /// <summary> 
                /// The user ID of the mentioned user.
                /// </summary>
                public string UserId { get; set; }
            
                /// <summary> 
                /// The user name of the mentioned user.
                /// </summary>
                public string UserName { get; set; }
            
                /// <summary> 
                /// The user login of the mentioned user.
                /// </summary>
                public string UserLogin { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchMention object.
                /// </summary> 
                public static TwitchMention FromObject(GodotObject data)
                {
                    if(data == null) return null;
                    var instance = new TwitchMention
                    {
                        UserId = data.Get("user_id").AsString(),
                        UserName = data.Get("user_name").AsString(),
                        UserLogin = data.Get("user_login").AsString(),
                    };
                    
                    instance._data = data;
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
                    var mentionClass = script.Get("Mention").As<GDScript>();
                    var request = mentionClass.New().AsGodotObject();
                    request.Set("user_id", UserId);
                    request.Set("user_name", UserName);
                    request.Set("user_login", UserLogin);
                    return request;
                }
            }
        }
    }

    public partial class TwitchSub : RefCounted, ITwitcherSharpEventSub<TwitchSub>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The type of subscription plan being used. Possible values are: 1000 - First level of paid or Prime subscription.2000 - Second level of paid subscription.3000 - Third level of paid subscription.
        /// </summary>
        public string SubTier { get; set; }
    
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
        public static TwitchSub FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchSub
            {
                SubTier = data.Get("sub_tier").AsString(),
                IsPrime = data.Get("is_prime").AsBool(),
                DurationMonths = data.Get("duration_months").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var subClass = script.Get("Sub").As<GDScript>();
            var request = subClass.New().AsGodotObject();
            request.Set("sub_tier", SubTier);
            request.Set("is_prime", IsPrime);
            request.Set("duration_months", DurationMonths);
            return request;
        }
    }

    public partial class TwitchResub : RefCounted, ITwitcherSharpEventSub<TwitchResub>
    {
        private GodotObject _data;
        
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
        public string SubTier { get; set; }
    
        /// <summary> 
        /// Optional. The number of consecutive months the user has subscribed.
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
        public string GifterUserId { get; set; }
    
        /// <summary> 
        /// The user name of the subscription gifter. Null if anonymous.
        /// </summary>
        public string GifterUserName { get; set; }
    
        /// <summary> 
        /// Optional. The user login of the subscription gifter. Null if anonymous.
        /// </summary>
        public string GifterUserLogin { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchResub object.
        /// </summary> 
        public static TwitchResub FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchResub
            {
                CumulativeMonths = data.Get("cumulative_months").AsInt32(),
                DurationMonths = data.Get("duration_months").AsInt32(),
                StreakMonths = data.Get("streak_months").AsInt32(),
                SubTier = data.Get("sub_tier").AsString(),
                IsPrime = data.Get("is_prime").AsBool(),
                IsGift = data.Get("is_gift").AsBool(),
                GifterIsAnonymous = data.Get("gifter_is_anonymous").AsBool(),
                GifterUserId = data.Get("gifter_user_id").AsString(),
                GifterUserName = data.Get("gifter_user_name").AsString(),
                GifterUserLogin = data.Get("gifter_user_login").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var resubClass = script.Get("Resub").As<GDScript>();
            var request = resubClass.New().AsGodotObject();
            request.Set("cumulative_months", CumulativeMonths);
            request.Set("duration_months", DurationMonths);
            request.Set("streak_months", StreakMonths);
            request.Set("sub_tier", SubTier);
            request.Set("is_prime", IsPrime);
            request.Set("is_gift", IsGift);
            request.Set("gifter_is_anonymous", GifterIsAnonymous);
            request.Set("gifter_user_id", GifterUserId);
            request.Set("gifter_user_name", GifterUserName);
            request.Set("gifter_user_login", GifterUserLogin);
            return request;
        }
    }

    public partial class TwitchSubGift : RefCounted, ITwitcherSharpEventSub<TwitchSubGift>
    {
        private GodotObject _data;
        
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
        public string RecipientUserId { get; set; }
    
        /// <summary> 
        /// The user name of the subscription gift recipient.
        /// </summary>
        public string RecipientUserName { get; set; }
    
        /// <summary> 
        /// The user login of the subscription gift recipient.
        /// </summary>
        public string RecipientUserLogin { get; set; }
    
        /// <summary> 
        /// The type of subscription plan being used. Possible values are: 1000 - First level of paid or Prime subscription.2000 - Second level of paid subscription.3000 - Third level of paid subscription.
        /// </summary>
        public string SubTier { get; set; }
    
        /// <summary> 
        /// Optional. The ID of the associated community gift. Null if not associated with a community gift.
        /// </summary>
        public string CommunityGiftId { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSubGift object.
        /// </summary> 
        public static TwitchSubGift FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchSubGift
            {
                DurationMonths = data.Get("duration_months").AsInt32(),
                CumulativeTotal = data.Get("cumulative_total").AsInt32(),
                RecipientUserId = data.Get("recipient_user_id").AsString(),
                RecipientUserName = data.Get("recipient_user_name").AsString(),
                RecipientUserLogin = data.Get("recipient_user_login").AsString(),
                SubTier = data.Get("sub_tier").AsString(),
                CommunityGiftId = data.Get("community_gift_id").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var subGiftClass = script.Get("SubGift").As<GDScript>();
            var request = subGiftClass.New().AsGodotObject();
            request.Set("duration_months", DurationMonths);
            request.Set("cumulative_total", CumulativeTotal);
            request.Set("recipient_user_id", RecipientUserId);
            request.Set("recipient_user_name", RecipientUserName);
            request.Set("recipient_user_login", RecipientUserLogin);
            request.Set("sub_tier", SubTier);
            request.Set("community_gift_id", CommunityGiftId);
            return request;
        }
    }

    public partial class TwitchCommunitySubGift : RefCounted, ITwitcherSharpEventSub<TwitchCommunitySubGift>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The ID of the associated community gift.
        /// </summary>
        public string Id { get; set; }
    
        /// <summary> 
        /// Number of subscriptions being gifted.
        /// </summary>
        public int Total { get; set; }
    
        /// <summary> 
        /// The type of subscription plan being used. Possible values are: 1000 - First level of paid or Prime subscription.2000 - Second level of paid subscription.3000 - Third level of paid subscription.
        /// </summary>
        public string SubTier { get; set; }
    
        /// <summary> 
        /// Optional. The amount of gifts the gifter has given in this channel. Null if anonymous.
        /// </summary>
        public int CumulativeTotal { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchCommunitySubGift object.
        /// </summary> 
        public static TwitchCommunitySubGift FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchCommunitySubGift
            {
                Id = data.Get("id").AsString(),
                Total = data.Get("total").AsInt32(),
                SubTier = data.Get("sub_tier").AsString(),
                CumulativeTotal = data.Get("cumulative_total").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var communitySubGiftClass = script.Get("CommunitySubGift").As<GDScript>();
            var request = communitySubGiftClass.New().AsGodotObject();
            request.Set("id", Id);
            request.Set("total", Total);
            request.Set("sub_tier", SubTier);
            request.Set("cumulative_total", CumulativeTotal);
            return request;
        }
    }

    public partial class TwitchGiftPaidUpgrade : RefCounted, ITwitcherSharpEventSub<TwitchGiftPaidUpgrade>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// Whether the gift was given anonymously.
        /// </summary>
        public bool GifterIsAnonymous { get; set; }
    
        /// <summary> 
        /// Optional. The user ID of the user who gifted the subscription. Null if anonymous.
        /// </summary>
        public string GifterUserId { get; set; }
    
        /// <summary> 
        /// Optional. The user name of the user who gifted the subscription. Null if anonymous.
        /// </summary>
        public string GifterUserName { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchGiftPaidUpgrade object.
        /// </summary> 
        public static TwitchGiftPaidUpgrade FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchGiftPaidUpgrade
            {
                GifterIsAnonymous = data.Get("gifter_is_anonymous").AsBool(),
                GifterUserId = data.Get("gifter_user_id").AsString(),
                GifterUserName = data.Get("gifter_user_name").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var giftPaidUpgradeClass = script.Get("GiftPaidUpgrade").As<GDScript>();
            var request = giftPaidUpgradeClass.New().AsGodotObject();
            request.Set("gifter_is_anonymous", GifterIsAnonymous);
            request.Set("gifter_user_id", GifterUserId);
            request.Set("gifter_user_name", GifterUserName);
            return request;
        }
    }

    public partial class TwitchPrimePaidUpgrade : RefCounted, ITwitcherSharpEventSub<TwitchPrimePaidUpgrade>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The type of subscription plan being used. Possible values are: 1000 - First level of paid or Prime subscription.2000 - Second level of paid subscription.3000 - Third level of paid subscription.
        /// </summary>
        public string SubTier { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchPrimePaidUpgrade object.
        /// </summary> 
        public static TwitchPrimePaidUpgrade FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchPrimePaidUpgrade
            {
                SubTier = data.Get("sub_tier").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var primePaidUpgradeClass = script.Get("PrimePaidUpgrade").As<GDScript>();
            var request = primePaidUpgradeClass.New().AsGodotObject();
            request.Set("sub_tier", SubTier);
            return request;
        }
    }

    public partial class TwitchPayItForward : RefCounted, ITwitcherSharpEventSub<TwitchPayItForward>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// Whether the gift was given anonymously.
        /// </summary>
        public bool GifterIsAnonymous { get; set; }
    
        /// <summary> 
        /// The user ID of the user who gifted the subscription. Null if anonymous.
        /// </summary>
        public string GifterUserId { get; set; }
    
        /// <summary> 
        /// Optional. The user name of the user who gifted the subscription. Null if anonymous.
        /// </summary>
        public string GifterUserName { get; set; }
    
        /// <summary> 
        /// The user login of the user who gifted the subscription. Null if anonymous.
        /// </summary>
        public string GifterUserLogin { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchPayItForward object.
        /// </summary> 
        public static TwitchPayItForward FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchPayItForward
            {
                GifterIsAnonymous = data.Get("gifter_is_anonymous").AsBool(),
                GifterUserId = data.Get("gifter_user_id").AsString(),
                GifterUserName = data.Get("gifter_user_name").AsString(),
                GifterUserLogin = data.Get("gifter_user_login").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var payItForwardClass = script.Get("PayItForward").As<GDScript>();
            var request = payItForwardClass.New().AsGodotObject();
            request.Set("gifter_is_anonymous", GifterIsAnonymous);
            request.Set("gifter_user_id", GifterUserId);
            request.Set("gifter_user_name", GifterUserName);
            request.Set("gifter_user_login", GifterUserLogin);
            return request;
        }
    }

    public partial class TwitchRaid : RefCounted, ITwitcherSharpEventSub<TwitchRaid>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The user ID of the broadcaster raiding this channel.
        /// </summary>
        public string UserId { get; set; }
    
        /// <summary> 
        /// The user name of the broadcaster raiding this channel.
        /// </summary>
        public string UserName { get; set; }
    
        /// <summary> 
        /// The login name of the broadcaster raiding this channel.
        /// </summary>
        public string UserLogin { get; set; }
    
        /// <summary> 
        /// The number of viewers raiding this channel from the broadcaster’s channel.
        /// </summary>
        public int ViewerCount { get; set; }
    
        /// <summary> 
        /// Profile image URL of the broadcaster raiding this channel.
        /// </summary>
        public string ProfileImageUrl { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchRaid object.
        /// </summary> 
        public static TwitchRaid FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchRaid
            {
                UserId = data.Get("user_id").AsString(),
                UserName = data.Get("user_name").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                ViewerCount = data.Get("viewer_count").AsInt32(),
                ProfileImageUrl = data.Get("profile_image_url").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var raidClass = script.Get("Raid").As<GDScript>();
            var request = raidClass.New().AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_name", UserName);
            request.Set("user_login", UserLogin);
            request.Set("viewer_count", ViewerCount);
            request.Set("profile_image_url", ProfileImageUrl);
            return request;
        }
    }

    public partial class TwitchAnnouncement : RefCounted, ITwitcherSharpEventSub<TwitchAnnouncement>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// Color of the announcement.
        /// </summary>
        public string Color { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchAnnouncement object.
        /// </summary> 
        public static TwitchAnnouncement FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchAnnouncement
            {
                Color = data.Get("color").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var announcementClass = script.Get("Announcement").As<GDScript>();
            var request = announcementClass.New().AsGodotObject();
            request.Set("color", Color);
            return request;
        }
    }

    public partial class TwitchBitsBadgeTier : RefCounted, ITwitcherSharpEventSub<TwitchBitsBadgeTier>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The tier of the Bits badge the user just earned. For example, 100, 1000, or 10000.
        /// </summary>
        public int Tier { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchBitsBadgeTier object.
        /// </summary> 
        public static TwitchBitsBadgeTier FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchBitsBadgeTier
            {
                Tier = data.Get("tier").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var bitsBadgeTierClass = script.Get("BitsBadgeTier").As<GDScript>();
            var request = bitsBadgeTierClass.New().AsGodotObject();
            request.Set("tier", Tier);
            return request;
        }
    }

    public partial class TwitchAmount : RefCounted, ITwitcherSharpEventSub<TwitchAmount>
    {
        private GodotObject _data;
        
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
        public string Currency { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchAmount object.
        /// </summary> 
        public static TwitchAmount FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchAmount
            {
                Value = data.Get("value").AsInt32(),
                DecimalPlace = data.Get("decimal_place").AsInt32(),
                Currency = data.Get("currency").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var amountClass = script.Get("Amount").As<GDScript>();
            var request = amountClass.New().AsGodotObject();
            request.Set("value", Value);
            request.Set("decimal_place", DecimalPlace);
            request.Set("currency", Currency);
            return request;
        }
    }

    public partial class TwitchWatchStreak : RefCounted, ITwitcherSharpEventSub<TwitchWatchStreak>
    {
        private GodotObject _data;
        
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
        public static TwitchWatchStreak FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchWatchStreak
            {
                StreakCount = data.Get("streak_count").AsInt32(),
                ChannelPointsAwarded = data.Get("channel_points_awarded").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var watchStreakClass = script.Get("WatchStreak").As<GDScript>();
            var request = watchStreakClass.New().AsGodotObject();
            request.Set("streak_count", StreakCount);
            request.Set("channel_points_awarded", ChannelPointsAwarded);
            return request;
        }
    }

    public partial class TwitchSourceBadges : RefCounted, ITwitcherSharpEventSub<TwitchSourceBadges>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The ID that identifies this set of chat badges. For example, Bits or Subscriber.
        /// </summary>
        public string SetId { get; set; }
    
        /// <summary> 
        /// The ID that identifies this version of the badge. The ID can be any value. For example, for Bits, the ID is the Bits tier level, but for World of Warcraft, it could be Alliance or Horde.
        /// </summary>
        public string Id { get; set; }
    
        /// <summary> 
        /// Contains metadata related to the chat badges in the badges tag. Currently, this tag contains metadata only for subscriber badges, to indicate the number of months the user has been a subscriber.
        /// </summary>
        public string Info { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchSourceBadges object.
        /// </summary> 
        public static TwitchSourceBadges FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchSourceBadges
            {
                SetId = data.Get("set_id").AsString(),
                Id = data.Get("id").AsString(),
                Info = data.Get("info").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var sourceBadgesClass = script.Get("SourceBadges").As<GDScript>();
            var request = sourceBadgesClass.New().AsGodotObject();
            request.Set("set_id", SetId);
            request.Set("id", Id);
            request.Set("info", Info);
            return request;
        }
    }
}
