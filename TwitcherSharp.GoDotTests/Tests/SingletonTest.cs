using Chickensoft.GoDotTest;
using Godot;
using Shouldly;
using TwitcherSharp.Api.Generated;
using TwitcherSharp.Chat;
using TwitcherSharp.Media;

namespace TwitcherSharp.GoDotTests.Tests;

/// <summary>
/// ITwitcherSharpSingleton.Instance follows twitcher's static <c>instance</c>, which a twitcher node sets when it
/// enters the tree and clears when it leaves.
/// </summary>
public class SingletonTest(Node testScene) : TestClass(testScene)
{
    private const string MediaLoaderPath = "res://addons/twitcher/media/twitch_media_loader.gd";

    private static double OrphanNodes => Performance.GetMonitor(Performance.Monitor.ObjectOrphanNodeCount);

    [Test]
    public void InstanceCreatesNoNode()
    {
        var before = OrphanNodes;

        for (var i = 0; i < 3; i++)
        {
            // Neither has a node in the test scene.
            TwitchMediaLoader.Instance.ShouldBeNull();
            TwitchBot.Instance.ShouldBeNull();
        }

        (OrphanNodes - before).ShouldBe(0);
    }

    [Test]
    public void InstanceFollowsTheTreeNode()
    {
        using var script = GD.Load<GDScript>(MediaLoaderPath);
        var first = (Node)script.New().AsGodotObject();
        var second = (Node)script.New().AsGodotObject();
        try
        {
            TestScene.AddChild(first);
            TwitchMediaLoader.Instance.ShouldNotBeNull();
            TwitchMediaLoader.Instance.ToGodotObject().ShouldBeSameAs(first);

            TestScene.RemoveChild(first);
            TwitchMediaLoader.Instance.ShouldBeNull();

            first.Free();
            TestScene.AddChild(second);
            TwitchMediaLoader.Instance.ShouldNotBeNull();
            TwitchMediaLoader.Instance.ToGodotObject().ShouldBeSameAs(second);
        }
        finally
        {
            if (GodotObject.IsInstanceValid(first)) first.Free();
            second.Free();
        }
    }

    [Test]
    public void TouchingTwitchChatCreatesNoNode()
    {
        var api = TestScene.GetNode("Twitcher/TwitchService/TwitchAPI");
        var parent = api.GetParent();
        var index = api.GetIndex();
        var root = TestScene.GetTree().Root;
        var rootChildren = root.GetChildCount();

        parent.RemoveChild(api);
        try
        {
            // Without a TwitchAPI in the tree there is none to use; TwitchChat must not add one to the root.
            TwitchChat.Api.ShouldBeNull();
            TwitchApi.Instance.ShouldBeNull();
            root.GetChildCount().ShouldBe(rootChildren);
        }
        finally
        {
            parent.AddChild(api);
            parent.MoveChild(api, index);
        }

        TwitchChat.Api.ShouldNotBeNull();
        TwitchChat.Api.ToGodotObject().ShouldBeSameAs(api);
    }
}
