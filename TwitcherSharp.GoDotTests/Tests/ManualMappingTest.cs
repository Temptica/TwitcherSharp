using System;
using Chickensoft.GoDotTest;
using Chickensoft.Log;
using Godot;
using TwitcherSharp.Chat;
using TwitcherSharp.EventSub;
using TwitcherSharp.GoDotTests.Helper;

namespace TwitcherSharp.GoDotTests.Tests;

public class ManualMappingTest(Node testScene) : TestClass(testScene)
{
    private readonly ILog _log = new Log(nameof(MappingTestComplex), new TraceWriter());

    [Test] //Just a small test to check if the mapping works
    public void TestTwitchChatMessageParsing()
    {
        var twitchChatMessage = new TwitchChatMessage
        {
            BroadcasterUserId = "123",
            BroadcasterUserLogin = "abc",
            BroadcasterUserName = "Abc",
            ChatterUserId = "321",
            ChatterUserLogin = "def",
            ChatterUserName = "Def",
            MessageId = "456",
            Content = new TwitchChatMessage.Message
            {
                Fragments = [],
                Text = "Test Message"
            },
            ChatMessageType = TwitchChatMessage.MessageType.Text,
            Badges =
            [
                new TwitchChatMessage.Badge
                {
                    SetId = "1.0",
                    Id = "123321",
                    Info = "Test Badge"
                }
            ],
            CheerMetadata = new TwitchChatMessage.Cheer
            {
                Bits = 500
            },
            Color = "FF00FF",
            ReplyMetadata = null,
            ChannelPointsCustomRewardId = null,
            SourceBroadcasterUserId = "123",
            SourceBroadcasterUserName = "Abc",
            SourceBroadcasterUserLogin = "abc",
            SourceMessageId = "123456",
            SourceBadges = []
        };

        var godotObject = twitchChatMessage.ToGodotObject();
        var parsedTwitchChatMessage = TwitchChatMessage.FromObject(godotObject);

        AssertHelper.AssertTwitcherSharpProperties(twitchChatMessage, parsedTwitchChatMessage, _log);
    }

    // Regression test. AssertTwitcherSharpProperties skips class and array properties, and the test above assigns
    // Fragments explicitly, so neither exercises the lazy getter. A non-null `= []` initializer on Fragments used to
    // leave the `field ??=` backing field non-null before first access, so the getter never read _data and the
    // property was permanently empty. This test goes through FromObject and reads Fragments without assigning it.
    [Test]
    public void TestTwitchChatMessageFragmentsAreLazyLoadedFromData()
    {
        var message = new TwitchChatMessage.Message
        {
            Text = "Hello world",
            Fragments =
            [
                new TwitchChatMessage.Fragment
                {
                    Type = TwitchChatMessage.FragmentType.Text,
                    Text = "Hello world"
                }
            ]
        };

        var parsed = TwitchChatMessage.Message.FromObject(message.ToGodotObject());

        if (parsed == null)
            throw new Exception("Message.FromObject returned null");

        if (parsed.Fragments.Length != 1)
            throw new Exception(
                $"Expected 1 fragment to be read back from _data but got {parsed.Fragments.Length}. " +
                "A non-null initializer on Fragments is short-circuiting the `field ??=` lazy getter.");

        if (parsed.Fragments[0].Text != "Hello world")
            throw new Exception($"Expected fragment text 'Hello world' but got '{parsed.Fragments[0].Text}'");

        if (parsed.Fragments[0].Type != TwitchChatMessage.FragmentType.Text)
            throw new Exception($"Expected fragment type Text but got {parsed.Fragments[0].Type}");

        _log.Print("Fragments were lazy-loaded from _data as expected");
    }

    [Test]
    public void TestTwitchEventSubDefinitionMapping()
    {
        //this one is a bit weird

        var definition = TwitchEventSubDefinition.AutomodMessageHold;
        definition.Scopes = null;
        var godotObject = definition.ToGodotObject();
        var parsedDefinition = TwitchEventSubDefinition.FromObject(godotObject);
        AssertHelper.AssertTwitcherSharpProperties(definition, parsedDefinition, _log);
    }
}