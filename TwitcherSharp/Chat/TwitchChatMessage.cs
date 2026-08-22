using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public partial class TwitchChatMessage : RefCounted, ITwitcherSharp<TwitchChatMessage>
{
    private GodotObject? _data;
    public string BroadcasterUserId { get; set; } = null!;
    public string BroadcasterUserName { get; set; } = null!;
    public string BroadcasterUserLogin { get; set; } = null!;
    public string ChatterUserId { get; set; } = null!;
    public string ChatterUserName { get; set; } = null!;
    public string ChatterUserLogin { get; set; } = null!;
    public string MessageId { get; set; } = null!;

    public Message Content
    {
        get => field ??= Message.FromObject(_data?.Get("message").AsGodotObject())!;
        set;
    } = null!;

    public MessageType ChatMessageType { get; set; }

    public Badge[] Badges
    {
        get => field ??= _data?.Get("badges").AsGodotArray<GodotObject>().Select(Badge.FromObject).OfType<Badge>().ToArray()!;
        set;
    } = null!;

    /// <summary>
    /// Present only for cheer messages.
    /// </summary>
    public Cheer? CheerMetadata
    {
        get => field ??= Cheer.FromObject(_data?.Get("cheer").AsGodotObject());
        set;
    }

    public string Color { get; set; } = null!;

    /// <summary>
    /// Present only when the message is a reply to another message.
    /// </summary>
    public Reply? ReplyMetadata
    {
        get => field ??= Reply.FromObject(_data?.Get("reply").AsGodotObject());
        set;
    }

    /// <summary>
    /// Present only when the message was sent alongside a channel points reward redemption.
    /// </summary>
    public string? ChannelPointsCustomRewardId { get; set; }

    /// <summary>
    /// The following Source* fields are present only for messages sent to a shared chat.
    /// </summary>
    public string? SourceBroadcasterUserId { get; set; }
    public string? SourceBroadcasterUserName { get; set; }
    public string? SourceBroadcasterUserLogin { get; set; }
    public string? SourceMessageId { get; set; }

    public Badge[]? SourceBadges
    {
        get => field ??= _data?.Get("source_badges").AsGodotArray<GodotObject>().Select(Badge.FromObject).OfType<Badge>().ToArray();
        set;
    }

    public static TwitchChatMessage? FromObject(GodotObject? data)
    {
        if (data == null) return null;

        var result = new TwitchChatMessage
        {
            BroadcasterUserId = data.Get("broadcaster_user_id").AsString(),
            BroadcasterUserName = data.Get("broadcaster_user_name").AsString(),
            BroadcasterUserLogin = data.Get("broadcaster_user_login").AsString(),
            ChatterUserId = data.Get("chatter_user_id").AsString(),
            ChatterUserName = data.Get("chatter_user_name").AsString(),
            ChatterUserLogin = data.Get("chatter_user_login").AsString(),
            MessageId = data.Get("message_id").AsString(),
            ChatMessageType = (MessageType)data.Get("message_type").AsInt32(),
            Color = data.Get("color").AsString(),
            ChannelPointsCustomRewardId = data.Get("channel_points_custom_reward_id").AsString(),
            SourceBroadcasterUserId = data.Get("source_broadcaster_user_id").AsString(),
            SourceBroadcasterUserName = data.Get("source_broadcaster_user_name").AsString(),
            SourceBroadcasterUserLogin = data.Get("source_broadcaster_user_login").AsString(),
            SourceMessageId = data.Get("source_message_id").AsString(),
        };

        result._data = data;

        return result;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_chat_message.gd");
        var instance = script.New().AsGodotObject();
        instance.Set("broadcaster_user_id", BroadcasterUserId);
        instance.Set("broadcaster_user_name", BroadcasterUserName);
        instance.Set("broadcaster_user_login", BroadcasterUserLogin);
        instance.Set("chatter_user_id", ChatterUserId);
        instance.Set("chatter_user_name", ChatterUserName);
        instance.Set("chatter_user_login", ChatterUserLogin);
        instance.Set("message_id", MessageId);
        instance.Set("message", Content.ToGodotObject());
        instance.Set("message_type", (int)ChatMessageType);
        instance.Set("cheer", CheerMetadata?.ToGodotObject() ?? new Variant());
        instance.Set("color", Color);
        instance.Set("reply", ReplyMetadata?.ToGodotObject() ?? new Variant());
        if (ChannelPointsCustomRewardId != null) instance.Set("channel_points_custom_reward_id", ChannelPointsCustomRewardId);
        if (SourceBroadcasterUserId != null) instance.Set("source_broadcaster_user_id", SourceBroadcasterUserId);
        if (SourceBroadcasterUserName != null) instance.Set("source_broadcaster_user_name", SourceBroadcasterUserName);
        if (SourceBroadcasterUserLogin != null) instance.Set("source_broadcaster_user_login", SourceBroadcasterUserLogin);
        if (SourceMessageId != null) instance.Set("source_message_id", SourceMessageId);
        instance.Set("badges", Badges.ToGodotArray());
        if (SourceBadges != null) instance.Set("source_badges", SourceBadges.ToGodotArray());
        return instance;
    }

    private string GetColor(string defaultColor = "#AAAAAA") => string.IsNullOrEmpty(Color) ? defaultColor : Color;

    public partial class Message : RefCounted, ITwitcherSharp<Message>
    {
        private GodotObject? _data;
        public string Text { get; set; } = null!;
        public Fragment[] Fragments { get => field ??= _data?.GetArray<Fragment>("fragments") ?? []; set; } = [];

        public static Message? FromObject(GodotObject? data)
        {
            if (data == null) return null;
            var result = new Message
            {
                Text = data.Get("text").AsString()
            };

            result._data = data;

            return result;
        }

        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_chat_message.gd");
            var message = script.Get("Message").AsGodotObject().Call("new").AsGodotObject();
            message.Set("text", Text);
            message.Set("fragments", Fragments.ToGodotArray());
            return message;
        }
    }

    public partial class Fragment : RefCounted, ITwitcherSharp<Fragment>
    {
        private GodotObject? _data;
        public FragmentType Type { get; set; }
        public string Text { get; set; } = null!;

        /// <summary>
        /// Exactly one of Cheermote/Emote/Mention is present, matching Type.
        /// </summary>
        public Cheermote? Cheermote { get => field ??= _data?.Call<Cheermote>("cheermote"); set; }
        public Emote? Emote { get => field ??= _data?.Call<Emote>("emote"); set; }
        public Mention? Mention { get => field ??= _data?.Call<Mention>("mention"); set; }

        public static Fragment? FromObject(GodotObject? data)
        {
            if (data == null) return null;
            var result = new Fragment
            {
                Type = (FragmentType)data.Get("type").AsInt32(),
                Text = data.Get("text").AsString()
            };
            result._data = data;
            return result;
        }

        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_chat_message.gd");
            var instance = script.Get("Fragment").AsGodotObject().Call("new").AsGodotObject();
            instance.Set("type", (int)Type);
            instance.Set("text", Text);
            instance.Set("cheermote", Cheermote?.ToGodotObject() ?? new Variant());
            instance.Set("emote", Emote?.ToGodotObject() ?? new Variant());
            instance.Set("mention", Mention?.ToGodotObject() ?? new Variant());
            return instance;
        }
    }

    public partial class Mention : RefCounted, ITwitcherSharp<Mention>
    {
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string UserLogin { get; set; } = null!;

        public static Mention? FromObject(GodotObject? data)
        {
            if (data == null) return null;
            return new Mention
            {
                UserId = data.Get("user_id").AsString(),
                UserName = data.Get("user_name").AsString(),
                UserLogin = data.Get("user_login").AsString()
            };
        }

        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_chat_message.gd");
            var instance = script.Get("Mention").AsGodotObject().Call("new").AsGodotObject();
            instance.Set("user_id", UserId);
            instance.Set("user_name", UserName);
            instance.Set("user_login", UserLogin);
            return instance;
        }
    }

    public partial class Cheermote : RefCounted, ITwitcherSharp<Cheermote>
    {
        public string Prefix { get; set; } = null!;
        public int Bits { get; set; }
        public int Tier { get; set; }

        public static Cheermote? FromObject(GodotObject? data)
        {
            if (data == null) return null;
            return new Cheermote
            {
                Prefix = data.Get("prefix").AsString(),
                Bits = data.Get("bits").AsInt32(),
                Tier = data.Get("tier").AsInt32()
            };
        }

        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_chat_message.gd");
            var instance = script.Get("Cheermote").AsGodotObject().Call("new").AsGodotObject();
            instance.Set("prefix", Prefix);
            instance.Set("bits", Bits);
            instance.Set("tier", Tier);
            return instance;
        }
    }

    public partial class Emote : RefCounted, ITwitcherSharp<Emote>
    {
        public string Id { get; set; } = null!;
        public string EmoteSetId { get; set; } = null!;
        public string OwnerId { get; set; } = null!;
        public EmoteFormat[] Format { get; set; } = [];

        public static Emote? FromObject(GodotObject? data)
        {
            if (data == null) return null;
            var result = new Emote
            {
                Id = data.Get("id").AsString(),
                EmoteSetId = data.Get("emote_set_id").AsString(),
                OwnerId = data.Get("owner_id").AsString(),
                Format = data.Get("format").AsGodotArray<string>()
                    .Select(f => f == "static" ? EmoteFormat.Static : EmoteFormat.Animated).ToArray()
            };

            return result;
        }

        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_chat_message.gd");
            var instance = script.Get("Emote").AsGodotObject().Call("new").AsGodotObject();
            instance.Set("id", Id);
            instance.Set("emote_set_id", EmoteSetId);
            instance.Set("owner_id", OwnerId);
            instance.Set("format",
                Format.Select(f => f == EmoteFormat.Static ? "static" : "animated").ToVariantArray());
            return instance;
        }
    }

    public partial class Badge : RefCounted, ITwitcherSharp<Badge>
    {
        public string SetId { get; set; } = null!;
        public string Id { get; set; } = null!;

        /// <summary>
        /// Only present for subscriber and bits badges.
        /// </summary>
        public string? Info { get; set; }

        public static Badge? FromObject(GodotObject? data)
        {
            if (data == null) return null;
            return new Badge
            {
                SetId = data.Get("set_id").AsString(),
                Id = data.Get("id").AsString(),
                Info = data.Get("info").AsString()
            };
        }

        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_chat_message.gd");
            var instance = script.Get("Badge").AsGodotObject().Call("new").AsGodotObject();
            instance.Set("set_id", SetId);
            instance.Set("id", Id);
            if (Info != null) instance.Set("info", Info);
            return instance;
        }
    }

    public partial class Cheer : RefCounted, ITwitcherSharp<Cheer>
    {
        public int Bits { get; set; }

        public static Cheer? FromObject(GodotObject? data) =>
            data == null ? null : new Cheer { Bits = data.Get("bits").AsInt32() };

        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_chat_message.gd");
            var instance = script.Get("Cheer").AsGodotObject().Call("new").AsGodotObject();
            instance.Set("bits", Bits);
            return instance;
        }
    }

    public partial class Reply : RefCounted, ITwitcherSharp<Reply>
    {
        public string ParentMessageId { get; set; } = null!;
        public string ParentMessageBody { get; set; } = null!;
        public string ParentUserId { get; set; } = null!;
        public string ParentUserName { get; set; } = null!;
        public string ParentUserLogin { get; set; } = null!;
        public string ThreadMessageId { get; set; } = null!;
        public string ThreadUserId { get; set; } = null!;
        public string ThreadUserName { get; set; } = null!;
        public string ThreadUserLogin { get; set; } = null!;

        public static Reply? FromObject(GodotObject? data)
        {
            if (data == null) return null;
            return new Reply
            {
                ParentMessageId = data.Get("parent_message_id").AsString(),
                ParentMessageBody = data.Get("parent_message_body").AsString(),
                ParentUserId = data.Get("parent_user_id").AsString(),
                ParentUserName = data.Get("parent_user_name").AsString(),
                ParentUserLogin = data.Get("parent_user_login").AsString(),
                ThreadMessageId = data.Get("thread_message_id").AsString(),
                ThreadUserId = data.Get("thread_user_id").AsString(),
                ThreadUserName = data.Get("thread_user_name").AsString(),
                ThreadUserLogin = data.Get("thread_user_login").AsString()
            };
        }

        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_chat_message.gd");
            var instance = script.Get("Reply").AsGodotObject().Call("new").AsGodotObject();
            instance.Set("parent_message_id", ParentMessageId);
            instance.Set("parent_message_body", ParentMessageBody);
            instance.Set("parent_user_id", ParentUserId);
            instance.Set("parent_user_name", ParentUserName);
            instance.Set("parent_user_login", ParentUserLogin);
            instance.Set("thread_message_id", ThreadMessageId);
            instance.Set("thread_user_id", ThreadUserId);
            instance.Set("thread_user_name", ThreadUserName);
            instance.Set("thread_user_login", ThreadUserLogin);
            return instance;
        }
    }

    public enum FragmentType
    {
        Text = 0,
        Cheermote = 1,
        Emote = 2,
        Mention = 3
    }

    public enum EmoteFormat
    {
        Animated = 0,
        Static = 1
    }

    public enum MessageType
    {
        Text = 0,
        ChannelPointsHighlighted = 1,
        ChannelPointsSubOnly = 2,
        UserIntro = 3,
        PowerUpsMessageEffect = 4,
        PowerUpsGigantifiedEmote = 5
    }
}
