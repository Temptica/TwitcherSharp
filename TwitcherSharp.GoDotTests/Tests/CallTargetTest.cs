using Chickensoft.GoDotTest;
using Godot;
using Shouldly;
using TwitcherSharp.Chat;

namespace TwitcherSharp.GoDotTests.Tests;

/// <summary>
/// Wrappers whose Call targets a function twitcher 2.5.1 does not have.
/// </summary>
public class CallTargetTest(Node testScene) : TestClass(testScene)
{
    [Test]
    public void TokenIsValidCallsIsTokenValid()
    {
        // Main updated the scene's token handler with a fresh mock token before the run.
        ((Main)TestScene).OAuthToken.TokenIsValid().ShouldBeTrue();
    }

    [Test]
    public void RemoveAliasRemovesTheAlias()
    {
        var command = new TwitchCommand { Command = "hello" };
        var node = (Node)command.ToGodotObject();
        try
        {
            command.AddAlias("hi");
            command.AddAlias("hey");

            command.RemoveAlias("hi");

            command.Aliases.ShouldBe(["hey"]);
            using var aliases = node.Get("aliases");
            aliases.AsStringArray().ShouldBe(["hey"]);
        }
        finally
        {
            node.Free();
        }
    }
}
