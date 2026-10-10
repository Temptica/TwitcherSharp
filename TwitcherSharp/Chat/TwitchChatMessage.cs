using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Media;

namespace TwitcherSharp.Chat;

public partial class TwitchChatMessage : RefCounted, ITwitcherSharp<TwitchChatMessage>
{
    private const string ScriptPath = "res://addons/twitcher/chat/twitch_chat_message.gd";

    private Variant _data;
    public string BroadcasterUserId { get; set; } = null!;
    public string BroadcasterUserName { get; set; } = null!;
    public string BroadcasterUserLogin { get; set; } = null!;
    public string ChatterUserId { get; set; } = null!;
    public string ChatterUserName { get; set; } = null!;
    public string ChatterUserLogin { get; set; } = null!;
    public string MessageId { get; set; } = null!;

    public Message Content
    {
        get => field ??= _data.Get<Message>("message")!;
        set;
    } = null!;

    public MessageType ChatMessageType { get; set; }

    public Badge[] Badges
    {
        get => field ??= _data.GetArray<Badge>("badges")!;
        set;
    } = null!;

    /// <summary>
    /// Present only for cheer messages.
    /// </summary>
    public Cheer? CheerMetadata
    {
        get => field ??= _data.Get<Cheer>("cheer");
        set;
    }

    public string Color { get; set; } = null!;

    /// <summary>
    /// Present only when the message is a reply to another message.
    /// </summary>
    public Reply? ReplyMetadata
    {
        get => field ??= _data.Get<Reply>("reply");
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

    /// <summary>
    /// True when this message should only be shown in the shared chat's source room, not fanned out to the other rooms.
    /// </summary>
    public bool IsSourceOnly { get; set; }

    public Badge[]? SourceBadges
    {
        get => field ??= _data.GetArray<Badge>("source_badges");
        set;
    }

    public async Task<Godot.Collections.Dictionary<TwitchBadgeDefinition, SpriteFrames>> GetBadges(
        TwitchMediaLoader mediaLoader, int scale = TwitchBadgeDefinition.Scale1)
        => await _data.CallDictionaryKeyAsync<TwitchBadgeDefinition, SpriteFrames>("get_badges", mediaLoader.ToGodotObject(), scale);

    public async Task<Godot.Collections.Dictionary<TwitchBadgeDefinition, SpriteFrames>> GetSourceBadges(
        TwitchMediaLoader mediaLoader, int scale = TwitchBadgeDefinition.Scale1)
        => await _data.CallDictionaryKeyAsync<TwitchBadgeDefinition, SpriteFrames>("get_source_badges", mediaLoader.ToGodotObject(), scale);

    public string GetColor(string defaultColor = "#AAAAAA") => string.IsNullOrEmpty(Color) ? defaultColor : Color;

    public async Task<Godot.Collections.Dictionary<TwitchEmoteDefinition, SpriteFrames>> LoadEmotesFromFragment(
        TwitchMediaLoader mediaLoader, int scale = TwitchEmoteDefinition.Scale1,
        string theme = TwitchEmoteDefinition.ThemeDark, string type = TwitchEmoteDefinition.TypeDefault)
        => await _data.CallDictionaryKeyAsync<TwitchEmoteDefinition, SpriteFrames>("load_emotes_from_fragment", mediaLoader.ToGodotObject(), scale,
            theme, type);

    public static TwitchChatMessage? FromObject(GodotObject? data)
    {
        if (data == null) return null;

        return new TwitchChatMessage
        {
            _data = Variant.CreateFrom(data),
            BroadcasterUserId = data.ReadAsString("broadcaster_user_id"),
            BroadcasterUserName = data.ReadAsString("broadcaster_user_name"),
            BroadcasterUserLogin = data.ReadAsString("broadcaster_user_login"),
            ChatterUserId = data.ReadAsString("chatter_user_id"),
            ChatterUserName = data.ReadAsString("chatter_user_name"),
            ChatterUserLogin = data.ReadAsString("chatter_user_login"),
            MessageId = data.ReadAsString("message_id"),
            ChatMessageType = data.Read("message_type", static v => (MessageType)v.AsInt32()),
            Color = data.ReadAsString("color"),
            ChannelPointsCustomRewardId = data.ReadAsString("channel_points_custom_reward_id"),
            SourceBroadcasterUserId = data.ReadAsString("source_broadcaster_user_id"),
            SourceBroadcasterUserName = data.ReadAsString("source_broadcaster_user_name"),
            SourceBroadcasterUserLogin = data.ReadAsString("source_broadcaster_user_login"),
            SourceMessageId = data.ReadAsString("source_message_id"),
            IsSourceOnly = data.ReadAsBool("is_source_only"),
        };
    }

    public GodotObject ToGodotObject()
    {
        var instance = InteropExtension.NewObject(ScriptPath);
        instance.SetValue("broadcaster_user_id", BroadcasterUserId);
        instance.SetValue("broadcaster_user_name", BroadcasterUserName);
        instance.SetValue("broadcaster_user_login", BroadcasterUserLogin);
        instance.SetValue("chatter_user_id", ChatterUserId);
        instance.SetValue("chatter_user_name", ChatterUserName);
        instance.SetValue("chatter_user_login", ChatterUserLogin);
        instance.SetValue("message_id", MessageId);
        if (Content != null) instance.SetObject("message", Content);
        instance.SetValue("message_type", (int)ChatMessageType);
        instance.SetObject("cheer", CheerMetadata);
        instance.SetValue("color", Color);
        instance.SetObject("reply", ReplyMetadata);
        if (ChannelPointsCustomRewardId != null) instance.SetValue("channel_points_custom_reward_id", ChannelPointsCustomRewardId);
        if (SourceBroadcasterUserId != null) instance.SetValue("source_broadcaster_user_id", SourceBroadcasterUserId);
        if (SourceBroadcasterUserName != null) instance.SetValue("source_broadcaster_user_name", SourceBroadcasterUserName);
        if (SourceBroadcasterUserLogin != null) instance.SetValue("source_broadcaster_user_login", SourceBroadcasterUserLogin);
        if (SourceMessageId != null) instance.SetValue("source_message_id", SourceMessageId);
        instance.SetArray("badges", Badges);
        instance.SetArray("source_badges", SourceBadges);
        instance.SetValue("is_source_only", IsSourceOnly);
        return instance;
    }

    /// <summary> Releases the twitcher object this message was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        // Only when disposed explicitly: when finalized, the Variant is finalized on its own, and disposing it again
        // throws on the finalizer thread, which ends the process.
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }


    public partial class Message : RefCounted, ITwitcherSharp<Message>
    {
        private Variant _data;
        public string Text { get; set; } = null!;
        public Fragment[] Fragments { get => field ??= _data.GetArray<Fragment>("fragments") ?? []; set; } = null!;

        public static Message? FromObject(GodotObject? data)
        {
            if (data == null) return null;
            return new Message
            {
                _data = Variant.CreateFrom(data),
                Text = data.ReadAsString("text"),
            };
        }

        public GodotObject ToGodotObject()
        {
            var message = InteropExtension.NewInner(ScriptPath, "Message");
            message.SetValue("text", Text);
            message.SetArray("fragments", Fragments);
            return message;
        }

        /// <summary> Releases the twitcher object this message was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
        }
    }

    public partial class Fragment : RefCounted, ITwitcherSharp<Fragment>
    {
        private Variant _data;
        public FragmentType Type { get; set; }
        public string Text { get; set; } = null!;

        /// <summary>
        /// Exactly one of Cheermote/Emote/Mention is present, matching Type.
        /// </summary>
        public Cheermote? Cheermote { get => field ??= _data.Get<Cheermote>("cheermote"); set; }
        public Emote? Emote { get => field ??= _data.Get<Emote>("emote"); set; }
        public Mention? Mention { get => field ??= _data.Get<Mention>("mention"); set; }

        public static Fragment? FromObject(GodotObject? data)
        {
            if (data == null) return null;
            return new Fragment
            {
                _data = Variant.CreateFrom(data),
                Type = data.Read("type", static v => (FragmentType)v.AsInt32()),
                Text = data.ReadAsString("text"),
            };
        }

        public GodotObject ToGodotObject()
        {
            var instance = InteropExtension.NewInner(ScriptPath, "Fragment");
            instance.SetValue("type", (int)Type);
            instance.SetValue("text", Text);
            instance.SetObject("cheermote", Cheermote);
            instance.SetObject("emote", Emote);
            instance.SetObject("mention", Mention);
            return instance;
        }

        /// <summary> Releases the twitcher object this fragment was mapped from. </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing) _data.Dispose();
            base.Dispose(disposing);
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
                UserId = data.ReadAsString("user_id"),
                UserName = data.ReadAsString("user_name"),
                UserLogin = data.ReadAsString("user_login")
            };
        }

        public GodotObject ToGodotObject()
        {
            var instance = InteropExtension.NewInner(ScriptPath, "Mention");
            instance.SetValue("user_id", UserId);
            instance.SetValue("user_name", UserName);
            instance.SetValue("user_login", UserLogin);
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
                Prefix = data.ReadAsString("prefix"),
                Bits = data.ReadAsInt32("bits"),
                Tier = data.ReadAsInt32("tier")
            };
        }

        public GodotObject ToGodotObject()
        {
            var instance = InteropExtension.NewInner(ScriptPath, "Cheermote");
            instance.SetValue("prefix", Prefix);
            instance.SetValue("bits", Bits);
            instance.SetValue("tier", Tier);
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
            return new Emote
            {
                Id = data.ReadAsString("id"),
                EmoteSetId = data.ReadAsString("emote_set_id"),
                OwnerId = data.ReadAsString("owner_id"),
                // Array[EmoteFormat] in twitcher: the enum values, not the "static"/"animated" strings of the API.
                Format = data.Read("format", static v => v.AsInt32Array().Select(f => (EmoteFormat)f).ToArray())
            };
        }

        public GodotObject ToGodotObject()
        {
            var instance = InteropExtension.NewInner(ScriptPath, "Emote");
            instance.SetValue("id", Id);
            instance.SetValue("emote_set_id", EmoteSetId);
            instance.SetValue("owner_id", OwnerId);
            instance.SetArray("format", Format.Select(f => Variant.From((int)f)));
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
                SetId = data.ReadAsString("set_id"),
                Id = data.ReadAsString("id"),
                Info = data.ReadAsString("info")
            };
        }

        public GodotObject ToGodotObject()
        {
            var instance = InteropExtension.NewInner(ScriptPath, "Badge");
            instance.SetValue("set_id", SetId);
            instance.SetValue("id", Id);
            if (Info != null) instance.SetValue("info", Info);
            return instance;
        }
    }

    public partial class Cheer : RefCounted, ITwitcherSharp<Cheer>
    {
        public int Bits { get; set; }

        public static Cheer? FromObject(GodotObject? data) =>
            data == null ? null : new Cheer { Bits = data.ReadAsInt32("bits") };

        public GodotObject ToGodotObject()
        {
            var instance = InteropExtension.NewInner(ScriptPath, "Cheer");
            instance.SetValue("bits", Bits);
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
                ParentMessageId = data.ReadAsString("parent_message_id"),
                ParentMessageBody = data.ReadAsString("parent_message_body"),
                ParentUserId = data.ReadAsString("parent_user_id"),
                ParentUserName = data.ReadAsString("parent_user_name"),
                ParentUserLogin = data.ReadAsString("parent_user_login"),
                ThreadMessageId = data.ReadAsString("thread_message_id"),
                ThreadUserId = data.ReadAsString("thread_user_id"),
                ThreadUserName = data.ReadAsString("thread_user_name"),
                ThreadUserLogin = data.ReadAsString("thread_user_login")
            };
        }

        public GodotObject ToGodotObject()
        {
            var instance = InteropExtension.NewInner(ScriptPath, "Reply");
            instance.SetValue("parent_message_id", ParentMessageId);
            instance.SetValue("parent_message_body", ParentMessageBody);
            instance.SetValue("parent_user_id", ParentUserId);
            instance.SetValue("parent_user_name", ParentUserName);
            instance.SetValue("parent_user_login", ParentUserLogin);
            instance.SetValue("thread_message_id", ThreadMessageId);
            instance.SetValue("thread_user_id", ThreadUserId);
            instance.SetValue("thread_user_name", ThreadUserName);
            instance.SetValue("thread_user_login", ThreadUserLogin);
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
