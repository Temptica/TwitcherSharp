using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;


namespace TwitcherSharp.EventSub.Generated.ChannelChatMessage;

public partial class TwitchChannelChatMessageEvent : RefCounted, ITwitcherSharpEventSub<TwitchChannelChatMessageEvent>
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
    /// The user name of the user that sent the message.
    /// </summary>
    public string? ChatterUserName { get; set; }

    /// <summary> 
    /// The user login of the user that sent the message.
    /// </summary>
    public string? ChatterUserLogin { get; set; }

    /// <summary> 
    /// A UUID that identifies the message.
    /// </summary>
    public string? MessageId { get; set; }

    /// <summary> 
    /// 
    /// </summary>
    public TwitchMessage? Message { get => field ??= _data.Get<TwitchMessage>("message"); set; }

    /// <summary> 
    /// The type of message. Possible values: textchannel_points_highlightedchannel_points_sub_onlyuser_intropower_ups_message_effectpower_ups_gigantified_emote
    /// </summary>
    public string? MessageType { get; set; }

    /// <summary> 
    /// List of chat badges.
    /// </summary>
    public TwitchBadges[]? Badges { get => field ??= _data.GetArray<TwitchBadges>("badges"); set; }

    /// <summary> 
    /// Optional. Metadata if this message is a cheer.
    /// </summary>
    public TwitchCheer? Cheer { get => field ??= _data.Get<TwitchCheer>("cheer"); set; }

    /// <summary> 
    /// The color of the user’s name in the chat room. This is a hexadecimal RGB color code in the form, #&amp;lt;RGB&amp;gt;. This tag may be empty if it is never set.
    /// </summary>
    public string? Color { get; set; }

    /// <summary> 
    /// Optional. Metadata if this message is a reply.
    /// </summary>
    public TwitchReply? Reply { get => field ??= _data.Get<TwitchReply>("reply"); set; }

    /// <summary> 
    /// Optional. The ID of a channel points custom reward that was redeemed.
    /// </summary>
    public string? ChannelPointsCustomRewardId { get; set; }

    /// <summary> 
    /// Optional. The broadcaster user ID of the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public string? SourceBroadcasterUserId { get; set; }

    /// <summary> 
    /// Optional. The user name of the broadcaster of the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
    /// </summary>
    public string? SourceBroadcasterUserName { get; set; }

    /// <summary> 
    /// Optional. The login of the broadcaster of the channel the message was sent from. Is null when the message happens in the same channel as the broadcaster. Is not null when in a shared chat session, and the action happens in the channel of a participant other than the broadcaster.
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
    /// Optional. Determines if a message delivered during a shared chat session is only sent to the source channel. Has no effect if the message is not sent during a shared chat session.
    /// </summary>
    public bool IsSourceOnly { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchChannelChatMessageEvent object.
    /// </summary> 
    public static TwitchChannelChatMessageEvent? FromObject(GodotObject? data)
    {
        if(data == null) return null;
        var instance = new TwitchChannelChatMessageEvent
        {
            BroadcasterUserId = data.Read("broadcaster_user_id", static v => v.AsString()),
            BroadcasterUserName = data.Read("broadcaster_user_name", static v => v.AsString()),
            BroadcasterUserLogin = data.Read("broadcaster_user_login", static v => v.AsString()),
            ChatterUserId = data.Read("chatter_user_id", static v => v.AsString()),
            ChatterUserName = data.Read("chatter_user_name", static v => v.AsString()),
            ChatterUserLogin = data.Read("chatter_user_login", static v => v.AsString()),
            MessageId = data.Read("message_id", static v => v.AsString()),
            MessageType = data.Read("message_type", static v => v.AsString()),
            Color = data.Read("color", static v => v.AsString()),
            ChannelPointsCustomRewardId = data.Read("channel_points_custom_reward_id", static v => v.AsString()),
            SourceBroadcasterUserId = data.Read("source_broadcaster_user_id", static v => v.AsString()),
            SourceBroadcasterUserName = data.Read("source_broadcaster_user_name", static v => v.AsString()),
            SourceBroadcasterUserLogin = data.Read("source_broadcaster_user_login", static v => v.AsString()),
            SourceMessageId = data.Read("source_message_id", static v => v.AsString()),
            IsSourceOnly = data.Read("is_source_only", static v => v.AsBool()),
        };
        
        instance._data = Variant.CreateFrom(data);
        return instance;
    }

    public GodotObject ToGodotObject()
    {
        var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd", "Event");
        if(BroadcasterUserId != null) request.SetValue("broadcaster_user_id", BroadcasterUserId);
        if(BroadcasterUserName != null) request.SetValue("broadcaster_user_name", BroadcasterUserName);
        if(BroadcasterUserLogin != null) request.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        if(ChatterUserId != null) request.SetValue("chatter_user_id", ChatterUserId);
        if(ChatterUserName != null) request.SetValue("chatter_user_name", ChatterUserName);
        if(ChatterUserLogin != null) request.SetValue("chatter_user_login", ChatterUserLogin);
        if(MessageId != null) request.SetValue("message_id", MessageId);
        if(Message != null) request.SetObject("message", Message);
        if(MessageType != null) request.SetValue("message_type", MessageType);
        if(Badges != null) request.SetArray("badges", Badges);
        if(Cheer != null) request.SetObject("cheer", Cheer);
        if(Color != null) request.SetValue("color", Color);
        if(Reply != null) request.SetObject("reply", Reply);
        if(ChannelPointsCustomRewardId != null) request.SetValue("channel_points_custom_reward_id", ChannelPointsCustomRewardId);
        if(SourceBroadcasterUserId != null) request.SetValue("source_broadcaster_user_id", SourceBroadcasterUserId);
        if(SourceBroadcasterUserName != null) request.SetValue("source_broadcaster_user_name", SourceBroadcasterUserName);
        if(SourceBroadcasterUserLogin != null) request.SetValue("source_broadcaster_user_login", SourceBroadcasterUserLogin);
        if(SourceMessageId != null) request.SetValue("source_message_id", SourceMessageId);
        if(SourceBadges != null) request.SetArray("source_badges", SourceBadges);
        request.SetValue("is_source_only", IsSourceOnly);
        return request;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd", "Message");
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
            /// The type of message fragment. Possible values: textcheermoteemotementiongif
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
            /// Optional. Metadata pertaining to the mention.
            /// </summary>
            public TwitchMention? Mention { get => field ??= _data.Get<TwitchMention>("mention"); set; }
        
            /// <summary> 
            /// Optional. Metadata pertaining to the GIF.
            /// </summary>
            public TwitchGif? Gif { get => field ??= _data.Get<TwitchGif>("gif"); set; }
        
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
                var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd", "Fragments");
                if(Type != null) request.SetValue("type", Type);
                if(Text != null) request.SetValue("text", Text);
                if(Cheermote != null) request.SetObject("cheermote", Cheermote);
                if(Emote != null) request.SetObject("emote", Emote);
                if(Mention != null) request.SetObject("mention", Mention);
                if(Gif != null) request.SetObject("gif", Gif);
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
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd", "Cheermote");
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
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd", "Emote");
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
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd", "Mention");
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
        
            public partial class TwitchGif : RefCounted, ITwitcherSharpEventSub<TwitchGif>
            {
                private Variant _data;
                
                /// <summary> 
                /// An ID that uniquely identifies this GIF.
                /// </summary>
                public string? GifId { get; set; }
            
                /// <summary> 
                /// The URL of the GIF asset. Applications rendering the GIF must use the full URL provided; it must not be modified.
                /// </summary>
                public string? Url { get; set; }
            
                /// <summary> 
                /// Transforms the godot data into a TwitchGif object.
                /// </summary> 
                public static TwitchGif? FromObject(GodotObject? data)
                {
                    if(data == null) return null;
                    var instance = new TwitchGif
                    {
                        GifId = data.Read("gif_id", static v => v.AsString()),
                        Url = data.Read("url", static v => v.AsString()),
                    };
                    
                    instance._data = Variant.CreateFrom(data);
                    return instance;
                }
            
                public GodotObject ToGodotObject()
                {
                    var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd", "Gif");
                    if(GifId != null) request.SetValue("gif_id", GifId);
                    if(Url != null) request.SetValue("url", Url);
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd", "Badges");
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

    public partial class TwitchCheer : RefCounted, ITwitcherSharpEventSub<TwitchCheer>
    {
        private Variant _data;
        
        /// <summary> 
        /// The amount of Bits the user cheered.
        /// </summary>
        public int Bits { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchCheer object.
        /// </summary> 
        public static TwitchCheer? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchCheer
            {
                Bits = data.Read("bits", static v => v.AsInt32()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd", "Cheer");
            request.SetValue("bits", Bits);
            return request;
        }
    
        /// <summary> Releases the twitcher object this instance was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class TwitchReply : RefCounted, ITwitcherSharpEventSub<TwitchReply>
    {
        private Variant _data;
        
        /// <summary> 
        /// An ID that uniquely identifies the parent message that this message is replying to.
        /// </summary>
        public string? ParentMessageId { get; set; }
    
        /// <summary> 
        /// The message body of the parent message.
        /// </summary>
        public string? ParentMessageBody { get; set; }
    
        /// <summary> 
        /// User ID of the sender of the parent message.
        /// </summary>
        public string? ParentUserId { get; set; }
    
        /// <summary> 
        /// User name of the sender of the parent message.
        /// </summary>
        public string? ParentUserName { get; set; }
    
        /// <summary> 
        /// User login of the sender of the parent message.
        /// </summary>
        public string? ParentUserLogin { get; set; }
    
        /// <summary> 
        /// An ID that identifies the parent message of the reply thread.
        /// </summary>
        public string? ThreadMessageId { get; set; }
    
        /// <summary> 
        /// User ID of the sender of the thread’s parent message.
        /// </summary>
        public string? ThreadUserId { get; set; }
    
        /// <summary> 
        /// User name of the sender of the thread’s parent message.
        /// </summary>
        public string? ThreadUserName { get; set; }
    
        /// <summary> 
        /// User login of the sender of the thread’s parent message.
        /// </summary>
        public string? ThreadUserLogin { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchReply object.
        /// </summary> 
        public static TwitchReply? FromObject(GodotObject? data)
        {
            if(data == null) return null;
            var instance = new TwitchReply
            {
                ParentMessageId = data.Read("parent_message_id", static v => v.AsString()),
                ParentMessageBody = data.Read("parent_message_body", static v => v.AsString()),
                ParentUserId = data.Read("parent_user_id", static v => v.AsString()),
                ParentUserName = data.Read("parent_user_name", static v => v.AsString()),
                ParentUserLogin = data.Read("parent_user_login", static v => v.AsString()),
                ThreadMessageId = data.Read("thread_message_id", static v => v.AsString()),
                ThreadUserId = data.Read("thread_user_id", static v => v.AsString()),
                ThreadUserName = data.Read("thread_user_name", static v => v.AsString()),
                ThreadUserLogin = data.Read("thread_user_login", static v => v.AsString()),
            };
            
            instance._data = Variant.CreateFrom(data);
            return instance;
        }
    
        public GodotObject ToGodotObject()
        {
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd", "Reply");
            if(ParentMessageId != null) request.SetValue("parent_message_id", ParentMessageId);
            if(ParentMessageBody != null) request.SetValue("parent_message_body", ParentMessageBody);
            if(ParentUserId != null) request.SetValue("parent_user_id", ParentUserId);
            if(ParentUserName != null) request.SetValue("parent_user_name", ParentUserName);
            if(ParentUserLogin != null) request.SetValue("parent_user_login", ParentUserLogin);
            if(ThreadMessageId != null) request.SetValue("thread_message_id", ThreadMessageId);
            if(ThreadUserId != null) request.SetValue("thread_user_id", ThreadUserId);
            if(ThreadUserName != null) request.SetValue("thread_user_name", ThreadUserName);
            if(ThreadUserLogin != null) request.SetValue("thread_user_login", ThreadUserLogin);
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
            var request = InteropExtension.NewInner("res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd", "SourceBadges");
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
