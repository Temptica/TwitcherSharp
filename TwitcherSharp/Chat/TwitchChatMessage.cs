using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public partial class TwitchChatMessage : RefCounted, ITwitcherSharp<TwitchChatMessage>
{
    private GodotObject _data;
    public string BroadcasterUserId { get; set; }
    public string BroadcasterUserName { get; set; }
    public string BroadcasterUserLogin { get; set; }
    public string ChatterUserId { get; set; }
    public string ChatterUserName { get; set; }
    public string ChatterUserLogin { get; set; }
    public string MessageId { get; set; }

    public Message Content
    {
        get => field ??= Message.FromObject(_data?.Get("message").AsGodotObject());
        set;
    }

    public MessageType ChatMessageType { get; set; }

    public Badge[] Badges
    {
        get => field ??= _data?.Get("badges").AsGodotArray<GodotObject>().Select(Badge.FromObject).ToArray();
        set;
    }

    public Cheer CheerMetadata
    {
        get => field ??= Cheer.FromObject(_data?.Get("cheer").AsGodotObject());
        set;
    }

    public string Color { get; set; }

    public Reply ReplyMetadata
    {
        get => field ??= Reply.FromObject(_data?.Get("reply").AsGodotObject());
        set;
    }

    public string ChannelPointsCustomRewardId { get; set; }
    public string SourceBroadcasterUserId { get; set; }
    public string SourceBroadcasterUserName { get; set; }
    public string SourceBroadcasterUserLogin { get; set; }
    public string SourceMessageId { get; set; }

    public Badge[] SourceBadges
    {
        get => field ??= _data?.Get("source_badges").AsGodotArray<GodotObject>().Select(Badge.FromObject).ToArray();
        set;
    }

    public static TwitchChatMessage FromObject(GodotObject data)
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
        instance.Set("message", Content?.ToGodotObject());
        instance.Set("message_type", (int)ChatMessageType);
        instance.Set("cheer", CheerMetadata?.ToGodotObject());
        instance.Set("color", Color);
        instance.Set("reply", ReplyMetadata?.ToGodotObject());
        instance.Set("channel_points_custom_reward_id", ChannelPointsCustomRewardId);
        instance.Set("source_broadcaster_user_id", SourceBroadcasterUserId);
        instance.Set("source_broadcaster_user_name", SourceBroadcasterUserName);
        instance.Set("source_broadcaster_user_login", SourceBroadcasterUserLogin);
        instance.Set("source_message_id", SourceMessageId);
        instance.SetArray("badges", Badges ?? []);
        instance.SetArray("source_badges", SourceBadges ?? []);
        return instance;
    }

    private string GetColor(string defaultColor = "#AAAAAA") => string.IsNullOrEmpty(Color) ? defaultColor : Color;

    public partial class Message : RefCounted, ITwitcherSharp<Message>
    {
        private GodotObject _data;
        public string Text { get; set; }
        public Fragment[] Fragments { get => field ??= _data?.GetArray<Fragment>("fragments"); set; }

        public static Message FromObject(GodotObject data)
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
            message.SetArray("fragments", Fragments ?? []);
            return message;
        }
    }

    public partial class Fragment : RefCounted, ITwitcherSharp<Fragment>
    {
        private GodotObject _data;
        public FragmentType Type { get; set; }
        public string Text { get; set; }
        public Cheermote Cheermote { get => field ??= _data?.Get<Cheermote>("cheermote"); set; }
        public Emote Emote { get => field ??= _data?.Get<Emote>("emote"); set; }
        public Mention Mention { get => field ??= _data?.Get<Mention>("mention"); set; }

        public static Fragment FromObject(GodotObject data)
        {
            if (data == null) return null;
            var result = new Fragment();
            result.Type = (FragmentType)data.Get("type").AsInt32();
            result.Text = data.Get("text").AsString();
            result._data = data;
            return result;
        }

        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/chat/twitch_chat_message.gd");
            var instance = script.Get("Fragment").AsGodotObject().Call("new").AsGodotObject();
            instance.Set("type", (int)Type);
            instance.Set("text", Text);
            instance.Set("cheermote", Cheermote?.ToGodotObject());
            instance.Set("emote", Emote?.ToGodotObject());
            instance.Set("mention", Mention?.ToGodotObject());
            return instance;
        }
    }

    public partial class Mention : RefCounted, ITwitcherSharp<Mention>
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserLogin { get; set; }

        public static Mention FromObject(GodotObject data)
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
        public string Prefix { get; set; }
        public int Bits { get; set; }
        public int Tier { get; set; }

        public static Cheermote FromObject(GodotObject data)
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
        public string Id { get; set; }
        public string EmoteSetId { get; set; }
        public string OwnerId { get; set; }
        public EmoteFormat[] Format { get; set; } = [];

        public static Emote FromObject(GodotObject data)
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
        public string SetId { get; set; }
        public string Id { get; set; }
        public string Info { get; set; }

        public static Badge FromObject(GodotObject data)
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
            instance.Set("info", Info);
            return instance;
        }
    }

    public partial class Cheer : RefCounted, ITwitcherSharp<Cheer>
    {
        public int Bits { get; set; }

        public static Cheer FromObject(GodotObject data) =>
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
        public string ParentMessageId { get; set; }
        public string ParentMessageBody { get; set; }
        public string ParentUserId { get; set; }
        public string ParentUserName { get; set; }
        public string ParentUserLogin { get; set; }
        public string ThreadMessageId { get; set; }
        public string ThreadUserId { get; set; }
        public string ThreadUserName { get; set; }
        public string ThreadUserLogin { get; set; }

        public static Reply FromObject(GodotObject data)
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