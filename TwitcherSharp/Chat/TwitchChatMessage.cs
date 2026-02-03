using System.Threading.Tasks;
using Godot;
using Godot.Collections;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Chat;

public partial class TwitchChatMessage : Resource, ITwitcherSharp<TwitchChatMessage>
{
    // Main class properties
    public string BroadcasterUserId { get; set; }
    public string BroadcasterUserName { get; set; }
    public string BroadcasterUserLogin { get; set; }
    public string ChatterUserId { get; set; }
    public string ChatterUserName { get; set; }
    public string ChatterUserLogin { get; set; }
    public string MessageId { get; set; }
    public Message Content { get; set; }
    public MessageType ChatMessageType { get; set; }
    public Array<Badge> Badges { get; set; } = [];
    public Cheer CheerMetadata { get; set; }
    public string Color { get; set; }
    public Reply ReplyMetadata { get; set; }
    public string ChannelPointsCustomRewardId { get; set; }
    public string SourceBroadcasterUserId { get; set; }
    public string SourceBroadcasterUserName { get; set; }
    public string SourceBroadcasterUserLogin { get; set; }
    public string SourceMessageId { get; set; }
    public Array<Badge> SourceBadges { get; set; } = [];

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
            Content = Message.FromObject(data.Get("message").AsGodotObject()),
            ChatMessageType = (MessageType)data.Get("message_type").AsInt32(),
            CheerMetadata = Cheer.FromObject(data.Get("cheer").AsGodotObject()),
            Color = data.Get("color").AsString(),
            ReplyMetadata = Reply.FromObject(data.Get("reply").AsGodotObject()),
            ChannelPointsCustomRewardId = data.Get("channel_points_custom_reward_id").AsString(),
            SourceBroadcasterUserId = data.Get("source_broadcaster_user_id").AsString(),
            SourceBroadcasterUserName = data.Get("source_broadcaster_user_name").AsString(),
            SourceBroadcasterUserLogin = data.Get("source_broadcaster_user_login").AsString(),
            SourceMessageId = data.Get("source_message_id").AsString()
        };

        var badgeArr = data.Get("badges").AsGodotArray<GodotObject>();
        if (badgeArr != null)
            foreach (var b in badgeArr)
                result.Badges.Add(Badge.FromObject(b));

        var sBadgeArr = data.Get("source_badges").AsGodotArray<GodotObject>();
        if (sBadgeArr != null)
            foreach (var b in sBadgeArr)
                result.SourceBadges.Add(Badge.FromObject(b));

        return result;
    }

    public GodotObject ToGodotObject()
    {
        throw new NotImplementedException();
    }

    public string GetColor(string defaultColor = "#AAAAAA")
        => string.IsNullOrEmpty(Color) ? defaultColor : Color;
}

public partial class Message : Resource, ITwitcherSharp<Message>
{
    public string Text { get; set; }
    public Array<Fragment> Fragments { get; set; } = [];

    public static Message FromObject(GodotObject data)
    {
        if (data == null) return null;
        var result = new Message();
        result.Text = data.Get("text").AsString();

        var fragments = data.Get("fragments").AsGodotArray<GodotObject>();
        if (fragments != null)
        {
            foreach (var fragObj in fragments)
            {
                result.Fragments.Add(Fragment.FromObject(fragObj));
            }
        }

        return result;
    }

    public GodotObject ToGodotObject()
    {
        throw new NotImplementedException();
    }
}

public partial class Fragment : Resource, ITwitcherSharp<Fragment>
{
    public FragmentType Type { get; set; }
    public string Text { get; set; }
    public Cheermote Cheermote { get; set; }
    public Emote Emote { get; set; }
    public Mention Mention { get; set; }

    public static Fragment FromObject(GodotObject data)
    {
        if (data == null) return null;
        var result = new Fragment();
        result.Type = (FragmentType)data.Get("type").AsInt32();
        result.Text = data.Get("text").AsString();
        result.Cheermote = Cheermote.FromObject(data.Get("cheermote").AsGodotObject());
        result.Emote = Emote.FromObject(data.Get("emote").AsGodotObject());
        result.Mention = Mention.FromObject(data.Get("mention").AsGodotObject());
        return result;
    }

    public GodotObject ToGodotObject()
    {
        throw new NotImplementedException();
    }
}

public partial class Mention : Resource, ITwitcherSharp<Mention>
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
        throw new NotImplementedException();
    }
}

public partial class Cheermote : Resource, ITwitcherSharp<Cheermote>
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
        throw new NotImplementedException();
    }
}

public partial class Emote : Resource, ITwitcherSharp<Emote>
{
    public string Id { get; set; }
    public string EmoteSetId { get; set; }
    public string OwnerId { get; set; }
    public Array<EmoteFormat> Format { get; set; } = new();

    public static Emote FromObject(GodotObject data)
    {
        if (data == null) return null;
        var result = new Emote
        {
            Id = data.Get("id").AsString(),
            EmoteSetId = data.Get("emote_set_id").AsString(),
            OwnerId = data.Get("owner_id").AsString()
        };

        var formats = data.Get("format").AsGodotArray<string>();
        if (formats != null)
        {
            foreach (var f in formats)
            {
                if (f == "static") result.Format.Add(EmoteFormat.Static);
                else if (f == "animated") result.Format.Add(EmoteFormat.Animated);
            }
        }

        return result;
    }

    public GodotObject ToGodotObject()
    {
        throw new NotImplementedException();
    }
}

public partial class Badge : Resource, ITwitcherSharp<Badge>
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
        throw new NotImplementedException();
    }
}

public partial class Cheer : Resource, ITwitcherSharp<Cheer>
{
    public int Bits { get; set; }

    public static Cheer FromObject(GodotObject data) =>
        data == null ? null : new Cheer { Bits = data.Get("bits").AsInt32() };

    public GodotObject ToGodotObject()
    {
        throw new NotImplementedException();
    }
}

public partial class Reply : Resource, ITwitcherSharp<Reply>
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
        throw new NotImplementedException();
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