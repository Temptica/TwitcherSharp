using System;
using System.Linq;
using Chickensoft.GoDotTest;
using Godot;
using TwitcherSharp.Chat;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.GoDotTests;

public class MappingTestSimple(Node testScene) : TestClass(testScene)
{
    [Test]
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
            Badges = [new Badge
            {
                SetId = "1.0",
                Id = "123321",
                Info = "Test Badge"
            }],
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
        
        AssertTwitcherSharpProperties(twitchChatMessage, parsedTwitchChatMessage);
    }
    
    private static void AssertTwitcherSharpProperties(ITwitcherSharp twitcherSharpObject,
        ITwitcherSharp twitcherSharpObject2)
    {
        foreach (var property in twitcherSharpObject.GetType().GetProperties()
                     .Where(p => p.CanWrite)
                     .Where(p => !p.PropertyType.FullName?.Contains("Array") ?? false)
                     .Where(p => !p.PropertyType.IsClass)
                )
        {
            var property2 = twitcherSharpObject2.GetType().GetProperties().FirstOrDefault(p => p.Name == property.Name);

            if (property2 == null)
            {
                throw new ArgumentException($"Property {property.Name} not found in twitcherSharpObject2");
            }

            var val1 = property.GetValue(twitcherSharpObject);
            var val2 = property2.GetValue(twitcherSharpObject2);
            switch (property.PropertyType.Name)
            {
                case nameof(String):
                    if ((string)val1 == (string)val2) continue;
                    throw new Exception(
                        $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
                case nameof(Int32):
                    if((int?)val1 == (int?)val2) continue;
                    throw new Exception(
                        $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
                case nameof(Boolean):
                    if ((bool?)val1 == (bool?)val2) continue;
                    throw new Exception(
                        $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
                case nameof(Double):
                    if ((double?)val1 == (double?)val2) continue;
                    throw new Exception(
                        $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
                case nameof(Single):
                    if ((float?)val1 == (float?)val2) continue;
                    throw new Exception(
                        $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
                case nameof(DateTime):
                    if ((DateTime?)val1 == (DateTime?)val2) continue;
                    throw new Exception(
                        $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
                case nameof(Color):
                    if ((Color?)val1 == (Color?)val2) continue;
                    throw new Exception(
                        $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
                default: break;
            }

            if (property.PropertyType.IsEnum)
            {
                if((int)val1 == (int)val2) continue;
                throw new Exception(
                    $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
            }

            if (property.PropertyType.IsClass)
            {
                AssertTwitcherSharpProperties(property.GetValue(twitcherSharpObject) as ITwitcherSharp,
                    property2.GetValue(twitcherSharpObject2) as ITwitcherSharp);
                continue;
            }
            
            if (val1 == val2) continue;

            throw new Exception(
                $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
        }
    }
    
}