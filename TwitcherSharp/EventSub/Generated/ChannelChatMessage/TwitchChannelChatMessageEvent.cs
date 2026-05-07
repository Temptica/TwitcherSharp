using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatMessage;

public partial class TwitchChannelChatMessageEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelChatMessageEvent>
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
    /// The user name of the user that sent the message.
    /// </summary>
    public string ChatterUserName { get; set; }

    /// <summary> 
    /// The user login of the user that sent the message.
    /// </summary>
    public string ChatterUserLogin { get; set; }

    /// <summary> 
    /// A UUID that identifies the message.
    /// </summary>
    public string MessageId { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMessage Message { get => field ??= _data?.Get<TwitchMessage>("message"); set; }

    /// <summary> 
    /// The type of message. Possible values: textchannel_points_highlightedchannel_points_sub_onlyuser_intropower_ups_message_effectpower_ups_gigantified_emote
    /// </summary>
    public string MessageType { get; set; }

    /// <summary> 
    /// List of chat badges.
    /// </summary>
    public TwitchBadges[] Badges { get => field ??= _data?.GetArray<TwitchBadges>("badges"); set; }

    /// <summary> 
    /// Optional. Metadata if this message is a cheer.
    /// </summary>
    public TwitchCheer Cheer { get => field ??= _data?.Get<TwitchCheer>("cheer"); set; }

    /// <summary> 
    /// The color of the user’s name in the chat room. This is a hexadecimal RGB color code in the form, #&amp;lt;RGB&amp;gt;. This tag may be empty if it is never set.
    /// </summary>
    public string Color { get; set; }

    /// <summary> 
    /// Optional. Metadata if this message is a reply.
    /// </summary>
    public TwitchReply Reply { get => field ??= _data?.Get<TwitchReply>("reply"); set; }

    /// <summary> 
    /// Optional. The ID of a channel points custom reward that was redeemed.
    /// </summary>
    public string ChannelPointsCustomRewardId { get; set; }

    /// <summary> 
    /// Optional. The broadcaster user ID of the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public string SourceBroadcasterUserId { get; set; }

    /// <summary> 
    /// Optional. The user name of the broadcaster of the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public string SourceBroadcasterUserName { get; set; }

    /// <summary> 
    /// Optional. The login of the broadcaster of the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
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
    /// Optional. Determines if a message delivered during a shared chat session is only sent to the source channel. Has no effect if the message is not sent during a shared chat session.
    /// </summary>
    public bool IsSourceOnly { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatMessageEvent object.
    /// </summary> 
    public static TwitchChannelChatMessageEvent FromObject(GodotObject data)
    {
        if(data == null) return null;
        var badgesArray = data.Get("badges").AsGodotArray<GodotObject>();
        var sourceBadgesArray = data.Get("source_badges").AsGodotArray<GodotObject>();
        var instance = new TwitchChannelChatMessageEvent
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            ChatterUserId = data.Get("chatter_user_id").AsString(),
            ChatterUserName = data.Get("chatter_user_name").AsString(),
            ChatterUserLogin = data.Get("chatter_user_login").AsString(),
            MessageId = data.Get("message_id").AsString(),
            Message = TwitchMessage.FromObject(data.Get("message").AsGodotObject()),
            MessageType = data.Get("message_type").AsString(),
            Badges = badgesArray.Select(TwitchBadges.FromObject).ToArray(),
            Cheer = TwitchCheer.FromObject(data.Get("cheer").AsGodotObject()),
            Color = data.Get("color").AsString(),
            Reply = TwitchReply.FromObject(data.Get("reply").AsGodotObject()),
            ChannelPointsCustomRewardId = data.Get("channel_points_custom_reward_id").AsString(),
            SourceBroadcasterUserId = data.Get("source_broadcaster_user_id").AsString(),
            SourceBroadcasterUserName = data.Get("source_broadcaster_user_name").AsString(),
            SourceBroadcasterUserLogin = data.Get("source_broadcaster_user_login").AsString(),
            SourceMessageId = data.Get("source_message_id").AsString(),
            SourceBadges = sourceBadgesArray.Select(TwitchSourceBadges.FromObject).ToArray(),
            IsSourceOnly = data.Get("is_source_only").AsBool(),
        };
        
        instance._data = data;
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd");
        var eventClass = script.Get("Event").As<GDScript>();
        var request = eventClass.New().AsGodotObject();
        request.Set("broadcaster_user_id", BroadcasterUserId);
        request.Set("broadcaster_user_name", BroadcasterUserName);
        request.Set("broadcaster_user_login", BroadcasterUserLogin);
        request.Set("chatter_user_id", ChatterUserId);
        request.Set("chatter_user_name", ChatterUserName);
        request.Set("chatter_user_login", ChatterUserLogin);
        request.Set("message_id", MessageId);
        request.Set("message", Message?.ToGodotObject());
        request.Set("message_type", MessageType);
        if(Badges != null) request.Set("badges", Badges?.ToGodotArray());
        request.Set("cheer", Cheer?.ToGodotObject());
        request.Set("color", Color);
        request.Set("reply", Reply?.ToGodotObject());
        request.Set("channel_points_custom_reward_id", ChannelPointsCustomRewardId);
        request.Set("source_broadcaster_user_id", SourceBroadcasterUserId);
        request.Set("source_broadcaster_user_name", SourceBroadcasterUserName);
        request.Set("source_broadcaster_user_login", SourceBroadcasterUserLogin);
        request.Set("source_message_id", SourceMessageId);
        if(SourceBadges != null) request.Set("source_badges", SourceBadges?.ToGodotArray());
        request.Set("is_source_only", IsSourceOnly);
        return request;
    }


    public partial class TwitchMessage : RefCounted, ITwitcherSharpEventSub<TwitchMessage>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The chat message in plain text.
        /// </summary>
        public string Text { get; set; }
    
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
            var fragmentsArray = data.Get("fragments").AsGodotArray<GodotObject>();
            var instance = new TwitchMessage
            {
                Text = data.Get("text").AsString(),
                Fragments = fragmentsArray.Select(TwitchFragments.FromObject).ToArray(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd");
            var messageClass = script.Get("Message").As<GDScript>();
            var request = messageClass.New().AsGodotObject();
            request.Set("text", Text);
            if(Fragments != null) request.Set("fragments", Fragments?.ToGodotArray());
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
            /// Optional. Metadata pertaining to the mention.
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
                    Cheermote = TwitchCheermote.FromObject(data.Get("cheermote").AsGodotObject()),
                    Emote = TwitchEmote.FromObject(data.Get("emote").AsGodotObject()),
                    Mention = TwitchMention.FromObject(data.Get("mention").AsGodotObject()),
                };
                
                instance._data = data;
                return instance;
            }
        
            public GodotObject ToGodotObject()
            {
                var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd");
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
                public string Prefix { get; set; }
            
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
                        Prefix = data.Get("prefix").AsString(),
                        Bits = data.Get("bits").AsInt32(),
                        Tier = data.Get("tier").AsInt32(),
                    };
                    
                    instance._data = data;
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd");
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
                        Format = data.Get("format").AsStringArray(),
                    };
                    
                    instance._data = data;
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd");
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
                    var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd");
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd");
            var badgesClass = script.Get("Badges").As<GDScript>();
            var request = badgesClass.New().AsGodotObject();
            request.Set("set_id", SetId);
            request.Set("id", Id);
            request.Set("info", Info);
            return request;
        }
    }

    public partial class TwitchCheer : RefCounted, ITwitcherSharpEventSub<TwitchCheer>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// The amount of Bits the user cheered.
        /// </summary>
        public int Bits { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchCheer object.
        /// </summary> 
        public static TwitchCheer FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchCheer
            {
                Bits = data.Get("bits").AsInt32(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd");
            var cheerClass = script.Get("Cheer").As<GDScript>();
            var request = cheerClass.New().AsGodotObject();
            request.Set("bits", Bits);
            return request;
        }
    }

    public partial class TwitchReply : RefCounted, ITwitcherSharpEventSub<TwitchReply>
    {
        private GodotObject _data;
        
        /// <summary> 
        /// An ID that uniquely identifies the parent message that this message is replying to.
        /// </summary>
        public string ParentMessageId { get; set; }
    
        /// <summary> 
        /// The message body of the parent message.
        /// </summary>
        public string ParentMessageBody { get; set; }
    
        /// <summary> 
        /// User ID of the sender of the parent message.
        /// </summary>
        public string ParentUserId { get; set; }
    
        /// <summary> 
        /// User name of the sender of the parent message.
        /// </summary>
        public string ParentUserName { get; set; }
    
        /// <summary> 
        /// User login of the sender of the parent message.
        /// </summary>
        public string ParentUserLogin { get; set; }
    
        /// <summary> 
        /// An ID that identifies the parent message of the reply thread.
        /// </summary>
        public string ThreadMessageId { get; set; }
    
        /// <summary> 
        /// User ID of the sender of the thread’s parent message.
        /// </summary>
        public string ThreadUserId { get; set; }
    
        /// <summary> 
        /// User name of the sender of the thread’s parent message.
        /// </summary>
        public string ThreadUserName { get; set; }
    
        /// <summary> 
        /// User login of the sender of the thread’s parent message.
        /// </summary>
        public string ThreadUserLogin { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchReply object.
        /// </summary> 
        public static TwitchReply FromObject(GodotObject data)
        {
            if(data == null) return null;
            var instance = new TwitchReply
            {
                ParentMessageId = data.Get("parent_message_id").AsString(),
                ParentMessageBody = data.Get("parent_message_body").AsString(),
                ParentUserId = data.Get("parent_user_id").AsString(),
                ParentUserName = data.Get("parent_user_name").AsString(),
                ParentUserLogin = data.Get("parent_user_login").AsString(),
                ThreadMessageId = data.Get("thread_message_id").AsString(),
                ThreadUserId = data.Get("thread_user_id").AsString(),
                ThreadUserName = data.Get("thread_user_name").AsString(),
                ThreadUserLogin = data.Get("thread_user_login").AsString(),
            };
            
            instance._data = data;
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd");
            var replyClass = script.Get("Reply").As<GDScript>();
            var request = replyClass.New().AsGodotObject();
            request.Set("parent_message_id", ParentMessageId);
            request.Set("parent_message_body", ParentMessageBody);
            request.Set("parent_user_id", ParentUserId);
            request.Set("parent_user_name", ParentUserName);
            request.Set("parent_user_login", ParentUserLogin);
            request.Set("thread_message_id", ThreadMessageId);
            request.Set("thread_user_id", ThreadUserId);
            request.Set("thread_user_name", ThreadUserName);
            request.Set("thread_user_login", ThreadUserLogin);
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
            var script = GD.Load<GDScript>("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd");
            var sourceBadgesClass = script.Get("SourceBadges").As<GDScript>();
            var request = sourceBadgesClass.New().AsGodotObject();
            request.Set("set_id", SetId);
            request.Set("id", Id);
            request.Set("info", Info);
            return request;
        }
    }
}
