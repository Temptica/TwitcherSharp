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
            Content = new Message
            {
                Fragments = [],
                Text = "Test Message"
            },
            ChatMessageType = MessageType.Text,
            Badges =
            [
                new Badge
                {
                    SetId = "1.0",
                    Id = "123321",
                    Info = "Test Badge"
                }
            ],
            CheerMetadata = new Cheer
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