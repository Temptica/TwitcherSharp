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

    [Test]
    public void TestTwitchEventSubDefinitionMapping()
    {
        //this one is a bit weird

        // A copy without scopes: the static definitions are shared, so the test must not change them.
        var source = TwitchEventSubDefinition.AutomodMessageHold;
        var definition = new TwitchEventSubDefinition
        {
            Type = source.Type,
            Value = source.Value,
            Version = source.Version,
            Conditions = source.Conditions,
            Scopes = null,
            DocumentationLink = source.DocumentationLink,
            Script = source.Script,
        };
        var godotObject = definition.ToGodotObject();
        var parsedDefinition = TwitchEventSubDefinition.FromObject(godotObject);
        AssertHelper.AssertTwitcherSharpProperties(definition, parsedDefinition, _log);
    }
}