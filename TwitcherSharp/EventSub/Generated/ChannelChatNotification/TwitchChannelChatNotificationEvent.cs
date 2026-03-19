using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatNotification;

public partial class TwitchChannelChatNotificationEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelChatNotificationEvent>
{
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
    public TwitchBadges[] Badges { get; set; }

    /// <summary> 
    /// The message Twitch shows in the chat room for this notice.
    /// </summary>
    public string SystemMessage { get; set; }

    /// <summary> 
    /// A UUID that identifies the message.
    /// </summary>
    public string MessageId { get; set; }

    /// <summary> 
    /// The structured chat message.
    /// </summary>
    public TwitchMessage Message { get; set; }

    /// <summary> 
    /// The type of notice. Possible values are: subresubsub_giftcommunity_sub_giftgift_paid_upgradeprime_paid_upgraderaidunraidpay_it_forwardannouncementbits_badge_tiercharity_donationshared_chat_subshared_chat_resubshared_chat_sub_giftshared_chat_community_sub_giftshared_chat_gift_paid_upgradeshared_chat_prime_paid_upgradeshared_chat_raidshared_chat_pay_it_forwardshared_chat_announcement
    /// </summary>
    public string NoticeType { get; set; }

    /// <summary> 
    /// Information about the sub event. Null if notice_type is not sub.
    /// </summary>
    public TwitchSub Sub { get; set; }

    /// <summary> 
    /// Information about the resub event. Null if notice_type is not resub.
    /// </summary>
    public TwitchResub Resub { get; set; }

    /// <summary> 
    /// Information about the gift sub event. Null if notice_type is not sub_gift.
    /// </summary>
    public TwitchSubGift SubGift { get; set; }

    /// <summary> 
    /// Information about the community gift sub event. Null if notice_type is not community_sub_gift.
    /// </summary>
    public TwitchCommunitySubGift CommunitySubGift { get; set; }

    /// <summary> 
    /// Information about the community gift paid upgrade event. Null if notice_type is not gift_paid_upgrade.
    /// </summary>
    public TwitchGiftPaidUpgrade GiftPaidUpgrade { get; set; }

    /// <summary> 
    /// Information about the Prime gift paid upgrade event. Null if notice_type is not prime_paid_upgrade
    /// </summary>
    public TwitchPrimePaidUpgrade PrimePaidUpgrade { get; set; }

    /// <summary> 
    /// Information about the pay it forward event. Null if notice_type is not pay_it_forward
    /// </summary>
    public TwitchPayItForward PayItForward { get; set; }

    /// <summary> 
    /// Information about the raid event. Null if notice_type is not raid
    /// </summary>
    public TwitchRaid Raid { get; set; }

    /// <summary> 
    /// Returns an empty payload if  notice_type is not unraid, otherwise returns null.
    /// </summary>
    public TwitchUnraid Unraid { get; set; }

    /// <summary> 
    /// Information about the announcement event. Null if notice_type is not {::nomarkdown}announcement
    /// </summary>
    public TwitchAnnouncement Announcement { get; set; }

    /// <summary> 
    /// Information about the Bits badge tier event. Null if notice_type is not bits_badge_tier
    /// </summary>
    public TwitchBitsBadgeTier BitsBadgeTier { get; set; }

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
    public TwitchAmount Amount { get; set; }

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
    public TwitchSourceBadges[] SourceBadges { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_sub event. Is null if notice_type is not shared_chat_sub. This field has the same information as the sub field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchSub SharedChatSub { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_resub event. Is null if notice_type is not shared_chat_resub. This field has the same information as the resub field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchResub SharedChatResub { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_sub_gift event. Is null if notice_type is not shared_chat_sub_gift. This field has the same information as the chat_sub_gift field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchSubGift SharedChatSubGift { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_community_sub_gift event. Is null if notice_type is not shared_chat_community_sub_gift. This field has the same information as the community_sub_gift field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchCommunitySubGift SharedChatCommunitySubGift { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_gift_paid_upgrade event. Is null if notice_type is not shared_chat_gift_paid_upgrade. This field has the same information as the gift_paid_upgrade field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchGiftPaidUpgrade SharedChatGiftPaidUpgrade { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_chat_prime_paid_upgrade event. Is null if notice_type is not shared_chat_prime_paid_upgrade. This field has the same information as the prime_paid_upgrade field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchPrimePaidUpgrade SharedChatPrimePaidUpgrade { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_pay_it_forward event. Is null if notice_type is not shared_chat_pay_it_forward. This field has the same information as the pay_it_forward field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchPayItForward SharedChatPayItForward { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_raid event. Is null if notice_type is not shared_chat_raid. This field has the same information as the raid field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchRaid SharedChatRaid { get; set; }

    /// <summary> 
    /// Optional. Information about the shared_chat_announcement event. Is null if notice_type is not shared_chat_announcement. This field has the same information as the announcement field but for a notice that happened for a channel in a shared chat session other than the broadcaster in the subscription condition.
    /// </summary>
    public TwitchAnnouncement SharedChatAnnouncement { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatNotificationEvent object.
    /// </summary> 
    public static TwitchChannelChatNotificationEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        var badgesArray = data.Get("badges").AsGodotArray<GodotObject>();
        var sourceBadgesArray = data.Get("source_badges").AsGodotArray<GodotObject>();
        return new TwitchChannelChatNotificationEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            ChatterUserId = data.Get("chatter_user_id").AsString(),
            ChatterUserName = data.Get("chatter_user_name").AsString(),
            ChatterIsAnonymous = data.Get("chatter_is_anonymous").AsBool(),
            Color = data.Get("color").AsString(),
            Badges = badgesArray.Select(TwitchBadges.FromObject).ToArray(),
            SystemMessage = data.Get("system_message").AsString(),
            MessageId = data.Get("message_id").AsString(),
            Message = data.Get("message").As<TwitchMessage>(),
            NoticeType = data.Get("notice_type").AsString(),
            Sub = data.Get("sub").As<TwitchSub>(),
            Resub = data.Get("resub").As<TwitchResub>(),
            SubGift = data.Get("sub_gift").As<TwitchSubGift>(),
            CommunitySubGift = data.Get("community_sub_gift").As<TwitchCommunitySubGift>(),
            GiftPaidUpgrade = data.Get("gift_paid_upgrade").As<TwitchGiftPaidUpgrade>(),
            PrimePaidUpgrade = data.Get("prime_paid_upgrade").As<TwitchPrimePaidUpgrade>(),
            PayItForward = data.Get("pay_it_forward").As<TwitchPayItForward>(),
            Raid = data.Get("raid").As<TwitchRaid>(),
            Unraid = data.Get("unraid").As<TwitchUnraid>(),
            Announcement = data.Get("announcement").As<TwitchAnnouncement>(),
            BitsBadgeTier = data.Get("bits_badge_tier").As<TwitchBitsBadgeTier>(),
            CharityDonation = data.Get("charity_donation").AsString(),
            CharityName = data.Get("charity_name").AsString(),
            Amount = data.Get("amount").As<TwitchAmount>(),
            SourceBroadcasterUserId = data.Get("source_broadcaster_user_id").AsString(),
            SourceBroadcasterUserName = data.Get("source_broadcaster_user_name").AsString(),
            SourceBroadcasterUserLogin = data.Get("source_broadcaster_user_login").AsString(),
            SourceMessageId = data.Get("source_message_id").AsString(),
            SourceBadges = sourceBadgesArray.Select(TwitchSourceBadges.FromObject).ToArray(),
            SharedChatSub = data.Get("shared_chat_sub").As<TwitchSub>(),
            SharedChatResub = data.Get("shared_chat_resub").As<TwitchResub>(),
            SharedChatSubGift = data.Get("shared_chat_sub_gift").As<TwitchSubGift>(),
            SharedChatCommunitySubGift = data.Get("shared_chat_community_sub_gift").As<TwitchCommunitySubGift>(),
            SharedChatGiftPaidUpgrade = data.Get("shared_chat_gift_paid_upgrade").As<TwitchGiftPaidUpgrade>(),
            SharedChatPrimePaidUpgrade = data.Get("shared_chat_prime_paid_upgrade").As<TwitchPrimePaidUpgrade>(),
            SharedChatPayItForward = data.Get("shared_chat_pay_it_forward").As<TwitchPayItForward>(),
            SharedChatRaid = data.Get("shared_chat_raid").As<TwitchRaid>(),
            SharedChatAnnouncement = data.Get("shared_chat_announcement").As<TwitchAnnouncement>(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
        var eventClass = script.Get("Event").AsGodotObject();
        var request = eventClass.Call("new").AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("chatter_user_id", ChatterUserId);
        request.Set("chatter_user_name", ChatterUserName);
        request.Set("chatter_is_anonymous", ChatterIsAnonymous);
        request.Set("color", Color);
        request.Set("badges", Badges);
        request.Set("system_message", SystemMessage);
        request.Set("message_id", MessageId);
        request.Set("message", Message);
        request.Set("notice_type", NoticeType);
        request.Set("sub", Sub);
        request.Set("resub", Resub);
        request.Set("sub_gift", SubGift);
        request.Set("community_sub_gift", CommunitySubGift);
        request.Set("gift_paid_upgrade", GiftPaidUpgrade);
        request.Set("prime_paid_upgrade", PrimePaidUpgrade);
        request.Set("pay_it_forward", PayItForward);
        request.Set("raid", Raid);
        request.Set("unraid", Unraid);
        request.Set("announcement", Announcement);
        request.Set("bits_badge_tier", BitsBadgeTier);
        request.Set("charity_donation", CharityDonation);
        request.Set("charity_name", CharityName);
        request.Set("amount", Amount);
        request.Set("source_broadcaster_user_id", SourceBroadcasterUserId);
        request.Set("source_broadcaster_user_name", SourceBroadcasterUserName);
        request.Set("source_broadcaster_user_login", SourceBroadcasterUserLogin);
        request.Set("source_message_id", SourceMessageId);
        request.Set("source_badges", SourceBadges);
        request.Set("shared_chat_sub", SharedChatSub);
        request.Set("shared_chat_resub", SharedChatResub);
        request.Set("shared_chat_sub_gift", SharedChatSubGift);
        request.Set("shared_chat_community_sub_gift", SharedChatCommunitySubGift);
        request.Set("shared_chat_gift_paid_upgrade", SharedChatGiftPaidUpgrade);
        request.Set("shared_chat_prime_paid_upgrade", SharedChatPrimePaidUpgrade);
        request.Set("shared_chat_pay_it_forward", SharedChatPayItForward);
        request.Set("shared_chat_raid", SharedChatRaid);
        request.Set("shared_chat_announcement", SharedChatAnnouncement);
        return request;
    }


    public partial class TwitchBadges : RefCounted, ITwitcherSharpEventSub<TwitchBadges>
    {
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
            return new TwitchBadges
            {
                SetId = data.Get("set_id").AsString(),
                Id = data.Get("id").AsString(),
                Info = data.Get("info").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var badgesClass = script.Get("Badges").AsGodotObject();
            var request = badgesClass.Call("new").AsGodotObject();
            request.Set("set_id", SetId);
            request.Set("id", Id);
            request.Set("info", Info);
            return request;
        }
    }

    public partial class TwitchMessage : RefCounted, ITwitcherSharpEventSub<TwitchMessage>
    {
        /// <summary> 
        /// The chat message in plain text.
        /// </summary>
        public TwitchText Text { get; set; }
    
        /// <summary> 
        /// Ordered list of chat message fragments.
        /// </summary>
        public TwitchFragments[] Fragments { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchMessage object.
        /// </summary> 
        public static TwitchMessage FromObject(GodotObject data)
        {
            if(data == null) return null;
            var fragmentsArray = data.Get("fragments").AsGodotArray<GodotObject>();
            return new TwitchMessage
            {
                Text = data.Get("text").As<TwitchText>(),
                Fragments = fragmentsArray.Select(TwitchFragments.FromObject).ToArray(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var messageClass = script.Get("Message").AsGodotObject();
            var request = messageClass.Call("new").AsGodotObject();
            request.Set("text", Text);
            request.Set("fragments", Fragments);
            return request;
        }
    
    
        public partial class TwitchText : RefCounted, ITwitcherSharpEventSub<TwitchText>
        {
        
            /// <summary> 
            /// Transforms the godot data into a TwitchText object.
            /// </summary> 
            public static TwitchText FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchText
                {
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
                var textClass = script.Get("Text").AsGodotObject();
                var request = textClass.Call("new").AsGodotObject();
                return request;
            }
        }
    
        public partial class TwitchFragments : RefCounted, ITwitcherSharpEventSub<TwitchFragments>
        {
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
            public TwitchCheermote Cheermote { get; set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the emote.
            /// </summary>
            public TwitchEmote Emote { get; set; }
        
            /// <summary> 
            /// Optional.  Metadata pertaining to the mention.
            /// </summary>
            public TwitchMention Mention { get; set; }
        
            /// <summary> 
            /// Transforms the godot data into a TwitchFragments object.
            /// </summary> 
            public static TwitchFragments FromObject(GodotObject data)
            {
                if(data == null) return null;
                return new TwitchFragments
                {
                    Type = data.Get("type").AsString(),
                    Text = data.Get("text").AsString(),
                    Cheermote = data.Get("cheermote").As<TwitchCheermote>(),
                    Emote = data.Get("emote").As<TwitchEmote>(),
                    Mention = data.Get("mention").As<TwitchMention>(),
                };
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
                var fragmentsClass = script.Get("Fragments").AsGodotObject();
                var request = fragmentsClass.Call("new").AsGodotObject();
                request.Set("type", Type);
                request.Set("text", Text);
                request.Set("cheermote", Cheermote);
                request.Set("emote", Emote);
                request.Set("mention", Mention);
                return request;
            }
        
        
            public partial class TwitchCheermote : RefCounted, ITwitcherSharpEventSub<TwitchCheermote>
            {
                /// <summary> 
                /// The name portion of the Cheermote string that you use in chat to cheer Bits. The full Cheermote string is the concatenation of {prefix} + {number of Bits}. For example, if the prefix is “Cheer” and you want to cheer 100 Bits, the full Cheermote string is Cheer100. When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
                /// </summary>
                public TwitchPrefix Prefix { get; set; }
            
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
                    return new TwitchCheermote
                    {
                        Prefix = data.Get("prefix").As<TwitchPrefix>(),
                        Bits = data.Get("bits").AsInt32(),
                        Tier = data.Get("tier").AsInt32(),
                    };
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
                    var cheermoteClass = script.Get("Cheermote").AsGodotObject();
                    var request = cheermoteClass.Call("new").AsGodotObject();
                    request.Set("prefix", Prefix);
                    request.Set("bits", Bits);
                    request.Set("tier", Tier);
                    return request;
                }
            
            
                public partial class TwitchPrefix : RefCounted, ITwitcherSharpEventSub<TwitchPrefix>
                {
                
                    /// <summary> 
                    /// Transforms the godot data into a TwitchPrefix object.
                    /// </summary> 
                    public static TwitchPrefix FromObject(GodotObject data)
                    {
                        if(data == null) return null;
                        return new TwitchPrefix
                        {
                        };
                    }
                
                    public GodotObject ToGodotObject()
                    {
                        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
                        var prefixClass = script.Get("Prefix").AsGodotObject();
                        var request = prefixClass.Call("new").AsGodotObject();
                        return request;
                    }
                }
            }
        
            public partial class TwitchEmote : RefCounted, ITwitcherSharpEventSub<TwitchEmote>
            {
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
                    return new TwitchEmote
                    {
                        Id = data.Get("id").AsString(),
                        EmoteSetId = data.Get("emote_set_id").AsString(),
                        OwnerId = data.Get("owner_id").AsString(),
                        Format = data.Get("format").AsStringArray(),
                    };
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
                    var emoteClass = script.Get("Emote").AsGodotObject();
                    var request = emoteClass.Call("new").AsGodotObject();
                    request.Set("id", Id);
                    request.Set("emote_set_id", EmoteSetId);
                    request.Set("owner_id", OwnerId);
                    request.Set("format", Format);
                    return request;
                }
            }
        
            public partial class TwitchMention : RefCounted, ITwitcherSharpEventSub<TwitchMention>
            {
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
                    return new TwitchMention
                    {
                        UserId = data.Get("user_id").AsString(),
                        UserName = data.Get("user_name").AsString(),
                        UserLogin = data.Get("user_login").AsString(),
                    };
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
                    var mentionClass = script.Get("Mention").AsGodotObject();
                    var request = mentionClass.Call("new").AsGodotObject();
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
            return new TwitchSub
            {
                SubTier = data.Get("sub_tier").AsString(),
                IsPrime = data.Get("is_prime").AsBool(),
                DurationMonths = data.Get("duration_months").AsInt32(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var subClass = script.Get("Sub").AsGodotObject();
            var request = subClass.Call("new").AsGodotObject();
            request.Set("sub_tier", SubTier);
            request.Set("is_prime", IsPrime);
            request.Set("duration_months", DurationMonths);
            return request;
        }
    }

    public partial class TwitchResub : RefCounted, ITwitcherSharpEventSub<TwitchResub>
    {
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
            return new TwitchResub
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
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var resubClass = script.Get("Resub").AsGodotObject();
            var request = resubClass.Call("new").AsGodotObject();
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
            return new TwitchSubGift
            {
                DurationMonths = data.Get("duration_months").AsInt32(),
                CumulativeTotal = data.Get("cumulative_total").AsInt32(),
                RecipientUserId = data.Get("recipient_user_id").AsString(),
                RecipientUserName = data.Get("recipient_user_name").AsString(),
                RecipientUserLogin = data.Get("recipient_user_login").AsString(),
                SubTier = data.Get("sub_tier").AsString(),
                CommunityGiftId = data.Get("community_gift_id").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var subGiftClass = script.Get("SubGift").AsGodotObject();
            var request = subGiftClass.Call("new").AsGodotObject();
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
        /// <summary> 
        /// The ID of the associated community gift.
        /// </summary>
        public string Id { get; set; }
    
        /// <summary> 
        /// Number of subscriptions being gifted.
        /// </summary>
        public int Total { get; set; }
    
        /// <summary> 
        /// The type of subscription plan being used. Possible values are: &lt;ul&gt;&lt;li&gt;1000 - First level of paid or Prime subscription.&lt;/li&gt;&lt;li&gt;2000 - Second level of paid subscription.&lt;/li&gt;&lt;li&gt;3000 - Third level of paid subscription.&lt;/li&gt;&lt;/ul&gt;
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
            return new TwitchCommunitySubGift
            {
                Id = data.Get("id").AsString(),
                Total = data.Get("total").AsInt32(),
                SubTier = data.Get("sub_tier").AsString(),
                CumulativeTotal = data.Get("cumulative_total").AsInt32(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var communitySubGiftClass = script.Get("CommunitySubGift").AsGodotObject();
            var request = communitySubGiftClass.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("total", Total);
            request.Set("sub_tier", SubTier);
            request.Set("cumulative_total", CumulativeTotal);
            return request;
        }
    }

    public partial class TwitchGiftPaidUpgrade : RefCounted, ITwitcherSharpEventSub<TwitchGiftPaidUpgrade>
    {
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
            return new TwitchGiftPaidUpgrade
            {
                GifterIsAnonymous = data.Get("gifter_is_anonymous").AsBool(),
                GifterUserId = data.Get("gifter_user_id").AsString(),
                GifterUserName = data.Get("gifter_user_name").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var giftPaidUpgradeClass = script.Get("GiftPaidUpgrade").AsGodotObject();
            var request = giftPaidUpgradeClass.Call("new").AsGodotObject();
            request.Set("gifter_is_anonymous", GifterIsAnonymous);
            request.Set("gifter_user_id", GifterUserId);
            request.Set("gifter_user_name", GifterUserName);
            return request;
        }
    }

    public partial class TwitchPrimePaidUpgrade : RefCounted, ITwitcherSharpEventSub<TwitchPrimePaidUpgrade>
    {
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
            return new TwitchPrimePaidUpgrade
            {
                SubTier = data.Get("sub_tier").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var primePaidUpgradeClass = script.Get("PrimePaidUpgrade").AsGodotObject();
            var request = primePaidUpgradeClass.Call("new").AsGodotObject();
            request.Set("sub_tier", SubTier);
            return request;
        }
    }

    public partial class TwitchPayItForward : RefCounted, ITwitcherSharpEventSub<TwitchPayItForward>
    {
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
            return new TwitchPayItForward
            {
                GifterIsAnonymous = data.Get("gifter_is_anonymous").AsBool(),
                GifterUserId = data.Get("gifter_user_id").AsString(),
                GifterUserName = data.Get("gifter_user_name").AsString(),
                GifterUserLogin = data.Get("gifter_user_login").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var payItForwardClass = script.Get("PayItForward").AsGodotObject();
            var request = payItForwardClass.Call("new").AsGodotObject();
            request.Set("gifter_is_anonymous", GifterIsAnonymous);
            request.Set("gifter_user_id", GifterUserId);
            request.Set("gifter_user_name", GifterUserName);
            request.Set("gifter_user_login", GifterUserLogin);
            return request;
        }
    }

    public partial class TwitchRaid : RefCounted, ITwitcherSharpEventSub<TwitchRaid>
    {
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
            return new TwitchRaid
            {
                UserId = data.Get("user_id").AsString(),
                UserName = data.Get("user_name").AsString(),
                UserLogin = data.Get("user_login").AsString(),
                ViewerCount = data.Get("viewer_count").AsInt32(),
                ProfileImageUrl = data.Get("profile_image_url").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var raidClass = script.Get("Raid").AsGodotObject();
            var request = raidClass.Call("new").AsGodotObject();
            request.Set("user_id", UserId);
            request.Set("user_name", UserName);
            request.Set("user_login", UserLogin);
            request.Set("viewer_count", ViewerCount);
            request.Set("profile_image_url", ProfileImageUrl);
            return request;
        }
    }

    public partial class TwitchUnraid : RefCounted, ITwitcherSharpEventSub<TwitchUnraid>
    {
    
        /// <summary> 
        /// Transforms the godot data into a TwitchUnraid object.
        /// </summary> 
        public static TwitchUnraid FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchUnraid
            {
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var unraidClass = script.Get("Unraid").AsGodotObject();
            var request = unraidClass.Call("new").AsGodotObject();
            return request;
        }
    }

    public partial class TwitchAnnouncement : RefCounted, ITwitcherSharpEventSub<TwitchAnnouncement>
    {
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
            return new TwitchAnnouncement
            {
                Color = data.Get("color").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var announcementClass = script.Get("Announcement").AsGodotObject();
            var request = announcementClass.Call("new").AsGodotObject();
            request.Set("color", Color);
            return request;
        }
    }

    public partial class TwitchBitsBadgeTier : RefCounted, ITwitcherSharpEventSub<TwitchBitsBadgeTier>
    {
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
            return new TwitchBitsBadgeTier
            {
                Tier = data.Get("tier").AsInt32(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var bitsBadgeTierClass = script.Get("BitsBadgeTier").AsGodotObject();
            var request = bitsBadgeTierClass.Call("new").AsGodotObject();
            request.Set("tier", Tier);
            return request;
        }
    }

    public partial class TwitchAmount : RefCounted, ITwitcherSharpEventSub<TwitchAmount>
    {
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
            return new TwitchAmount
            {
                Value = data.Get("value").AsInt32(),
                DecimalPlace = data.Get("decimal_place").AsInt32(),
                Currency = data.Get("currency").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var amountClass = script.Get("Amount").AsGodotObject();
            var request = amountClass.Call("new").AsGodotObject();
            request.Set("value", Value);
            request.Set("decimal_place", DecimalPlace);
            request.Set("currency", Currency);
            return request;
        }
    }

    public partial class TwitchSourceBadges : RefCounted, ITwitcherSharpEventSub<TwitchSourceBadges>
    {
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
            return new TwitchSourceBadges
            {
                SetId = data.Get("set_id").AsString(),
                Id = data.Get("id").AsString(),
                Info = data.Get("info").AsString(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_notification.gd");
            var sourceBadgesClass = script.Get("SourceBadges").AsGodotObject();
            var request = sourceBadgesClass.Call("new").AsGodotObject();
            request.Set("set_id", SetId);
            request.Set("id", Id);
            request.Set("info", Info);
            return request;
        }
    }
}
