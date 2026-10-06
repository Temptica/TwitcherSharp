using Chickensoft.GoDotTest;
using Godot;
using Shouldly;
using TwitcherSharp.Chat;

namespace TwitcherSharp.GoDotTests.Tests;

/// <summary>
/// Maps a TwitchChatMessage built in GDScript (Fixtures/chat_message_fixture.gd) and reads every field back.
/// </summary>
public class ChatMessageMappingTest(Node testScene) : TestClass(testScene)
{
    private const string FixturePath = "res://Tests/Fixtures/chat_message_fixture.gd";

    [Test]
    public void FromObjectReadsEveryField()
    {
        using var fixture = GD.Load<GDScript>(FixturePath);
        using var gdMessage = fixture.Call("full_message");

        AssertFullMessage(TwitchChatMessage.FromObject(gdMessage.AsGodotObject()));
    }

    [Test]
    public void ToGodotObjectWritesEveryField()
    {
        using var fixture = GD.Load<GDScript>(FixturePath);
        using var gdMessage = fixture.Call("full_message");
        var message = TwitchChatMessage.FromObject(gdMessage.AsGodotObject())!;

        // Through a plain copy, so ToGodotObject writes what C# holds instead of what the lazy members read.
        var copy = new TwitchChatMessage
        {
            BroadcasterUserId = message.BroadcasterUserId,
            BroadcasterUserName = message.BroadcasterUserName,
            BroadcasterUserLogin = message.BroadcasterUserLogin,
            ChatterUserId = message.ChatterUserId,
            ChatterUserName = message.ChatterUserName,
            ChatterUserLogin = message.ChatterUserLogin,
            MessageId = message.MessageId,
            Content = message.Content,
            ChatMessageType = message.ChatMessageType,
            Badges = message.Badges,
            CheerMetadata = message.CheerMetadata,
            Color = message.Color,
            ReplyMetadata = message.ReplyMetadata,
            ChannelPointsCustomRewardId = message.ChannelPointsCustomRewardId,
            SourceBroadcasterUserId = message.SourceBroadcasterUserId,
            SourceBroadcasterUserName = message.SourceBroadcasterUserName,
            SourceBroadcasterUserLogin = message.SourceBroadcasterUserLogin,
            SourceMessageId = message.SourceMessageId,
            IsSourceOnly = message.IsSourceOnly,
            SourceBadges = message.SourceBadges,
        };

        AssertFullMessage(TwitchChatMessage.FromObject(copy.ToGodotObject()));
    }

    [Test]
    public void ToGodotObjectWithoutOptionalParts()
    {
        var message = new TwitchChatMessage { MessageId = "message-1" };

        var parsed = TwitchChatMessage.FromObject(message.ToGodotObject())!;

        parsed.MessageId.ShouldBe("message-1");
        parsed.Badges.ShouldBeEmpty();
        parsed.CheerMetadata.ShouldBeNull();
        parsed.ReplyMetadata.ShouldBeNull();
    }

    [Test]
    public void CommandInfoRoundTripsTheChatMessage()
    {
        using var fixture = GD.Load<GDScript>(FixturePath);
        using var gdMessage = fixture.Call("full_message");
        var info = new TwitchCommandInfo
        {
            ChannelName = "broadcaster",
            Username = "chatter",
            UserId = "2002",
            Arguments = ["one", "two"],
            TextMessage = "!hello one two",
            ChatMessage = TwitchChatMessage.FromObject(gdMessage.AsGodotObject()),
        };

        var parsed = TwitchCommandInfo.FromObject(info.ToGodotObject())!;

        parsed.ChannelName.ShouldBe("broadcaster");
        parsed.Username.ShouldBe("chatter");
        parsed.UserId.ShouldBe("2002");
        parsed.Arguments.ShouldBe(["one", "two"]);
        parsed.TextMessage.ShouldBe("!hello one two");
        parsed.MessageType.ShouldBe(TwitchChatMessageType.ChatMessage);
        AssertFullMessage(parsed.ChatMessage);
    }

    private static void AssertFullMessage(TwitchChatMessage? message)
    {
        message.ShouldNotBeNull();
        message.BroadcasterUserId.ShouldBe("1001");
        message.BroadcasterUserName.ShouldBe("Broadcaster");
        message.BroadcasterUserLogin.ShouldBe("broadcaster");
        message.ChatterUserId.ShouldBe("2002");
        message.ChatterUserName.ShouldBe("Chatter");
        message.ChatterUserLogin.ShouldBe("chatter");
        message.MessageId.ShouldBe("message-1");
        message.ChatMessageType.ShouldBe(TwitchChatMessage.MessageType.ChannelPointsHighlighted);
        message.Color.ShouldBe("#FF00FF");
        message.ChannelPointsCustomRewardId.ShouldBe("reward-1");
        message.SourceBroadcasterUserId.ShouldBe("3003");
        message.SourceBroadcasterUserName.ShouldBe("Source");
        message.SourceBroadcasterUserLogin.ShouldBe("source");
        message.SourceMessageId.ShouldBe("source-message-1");
        message.IsSourceOnly.ShouldBeTrue();

        message.Badges.Length.ShouldBe(2);
        message.Badges[0].SetId.ShouldBe("subscriber");
        message.Badges[0].Id.ShouldBe("12");
        message.Badges[0].Info.ShouldBe("14");
        message.Badges[1].SetId.ShouldBe("moderator");
        message.SourceBadges.ShouldNotBeNull();
        message.SourceBadges.Length.ShouldBe(1);
        message.SourceBadges[0].SetId.ShouldBe("vip");

        message.CheerMetadata.ShouldNotBeNull();
        message.CheerMetadata.Bits.ShouldBe(100);

        var reply = message.ReplyMetadata;
        reply.ShouldNotBeNull();
        reply.ParentMessageId.ShouldBe("parent-1");
        reply.ParentMessageBody.ShouldBe("Parent body");
        reply.ParentUserId.ShouldBe("5005");
        reply.ParentUserName.ShouldBe("Parent");
        reply.ParentUserLogin.ShouldBe("parent");
        reply.ThreadMessageId.ShouldBe("thread-1");
        reply.ThreadUserId.ShouldBe("6006");
        reply.ThreadUserName.ShouldBe("Thread");
        reply.ThreadUserLogin.ShouldBe("thread");

        message.Content.ShouldNotBeNull();
        message.Content.Text.ShouldBe("Hello Kappa cheer100 @friend");
        var fragments = message.Content.Fragments;
        fragments.Length.ShouldBe(4);

        fragments[0].Type.ShouldBe(TwitchChatMessage.FragmentType.Text);
        fragments[0].Text.ShouldBe("Hello ");
        fragments[0].Emote.ShouldBeNull();
        fragments[0].Cheermote.ShouldBeNull();
        fragments[0].Mention.ShouldBeNull();

        fragments[1].Type.ShouldBe(TwitchChatMessage.FragmentType.Emote);
        fragments[1].Text.ShouldBe("Kappa");
        fragments[1].Emote.ShouldNotBeNull();
        fragments[1].Emote!.Id.ShouldBe("25");
        fragments[1].Emote!.EmoteSetId.ShouldBe("0");
        fragments[1].Emote!.OwnerId.ShouldBe("7007");
        fragments[1].Emote!.Format.ShouldBe([TwitchChatMessage.EmoteFormat.Static, TwitchChatMessage.EmoteFormat.Animated]);

        fragments[2].Type.ShouldBe(TwitchChatMessage.FragmentType.Cheermote);
        fragments[2].Cheermote.ShouldNotBeNull();
        fragments[2].Cheermote!.Prefix.ShouldBe("cheer");
        fragments[2].Cheermote!.Bits.ShouldBe(100);
        fragments[2].Cheermote!.Tier.ShouldBe(2);

        fragments[3].Type.ShouldBe(TwitchChatMessage.FragmentType.Mention);
        fragments[3].Mention.ShouldNotBeNull();
        fragments[3].Mention!.UserId.ShouldBe("4004");
        fragments[3].Mention!.UserName.ShouldBe("Friend");
        fragments[3].Mention!.UserLogin.ShouldBe("friend");
    }
}
