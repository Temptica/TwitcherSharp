using System.Linq;
using Chickensoft.GoDotTest;
using Godot;
using Shouldly;
using TwitcherSharp.Chat;

namespace TwitcherSharp.GoDotTests.Tests;

/// <summary>
/// <see cref="TwitchCommandBase.AllCommands"/> is twitcher's <c>ALL_COMMANDS</c>: the commands in the tree.
/// </summary>
public class AllCommandsTest(Node testScene) : TestClass(testScene)
{
    private const string CommandScript = "res://addons/twitcher/chat/twitch_command.gd";
    private const string HelpScript = "res://addons/twitcher/chat/twitch_command_help.gd";

    [Test]
    public void AllCommandsListsTheCommandsInTheTree()
    {
        var camera = NewNode(CommandScript);
        camera.Set("command", "camera");
        var help = NewNode(HelpScript);
        help.Set("command", "help");
        TestScene.AddChild(camera);
        TestScene.AddChild(help);
        try
        {
            // Mapping a command must not reset the list.
            TwitchCommand.FromObject(camera).ShouldNotBeNull();

            var commands = TwitchCommandBase.AllCommands;

            commands.OfType<TwitchCommand>().Single(c => c.Command == "camera").ShouldBeOfType<TwitchCommand>();
            commands.OfType<TwitchCommand>().Single(c => c.Command == "help").ShouldBeOfType<TwitchCommandHelp>();
        }
        finally
        {
            camera.Free();
            help.Free();
        }

        TwitchCommandBase.AllCommands.Select(c => c.Command).ShouldNotContain("camera");
        TwitchCommandBase.AllCommands.Select(c => c.Command).ShouldNotContain("help");
    }

    [Test]
    public void AllCommandsKeepsOneWrapperPerCommand()
    {
        var camera = NewNode(CommandScript);
        camera.Set("command", "camera");
        TestScene.AddChild(camera);
        try
        {
            var first = TwitchCommandBase.AllCommands.Single(c => c.Command == "camera");
            var second = TwitchCommandBase.AllCommands.Single(c => c.Command == "camera");

            // A new wrapper per read would connect the command's signals once more each time.
            second.ShouldBeSameAs(first);
        }
        finally
        {
            camera.Free();
        }
    }

    [Test]
    public void ToGodotObjectCreatesOnlyItsOwnNode()
    {
        var camera = NewNode(CommandScript);
        camera.Set("command", "camera");
        TestScene.AddChild(camera);
        var before = (int)Performance.GetMonitor(Performance.Monitor.ObjectOrphanNodeCount);
        Node created = null;
        try
        {
            TwitchCommandBase.AllCommands.Count.ShouldBeGreaterThan(0);

            created = (Node)new TwitchCommand { Command = "new" }.ToGodotObject();

            ((int)Performance.GetMonitor(Performance.Monitor.ObjectOrphanNodeCount)).ShouldBe(before + 1);
        }
        finally
        {
            created?.Free();
            camera.Free();
        }
    }

    private static Node NewNode(string scriptPath)
    {
        using var script = GD.Load<GDScript>(scriptPath);
        using var instance = script.New();
        return (Node)instance.AsGodotObject();
    }
}
