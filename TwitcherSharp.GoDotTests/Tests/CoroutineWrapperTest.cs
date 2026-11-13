using System;
using System.Linq;
using System.Threading.Tasks;
using Chickensoft.GoDotTest;
using Godot;
using Shouldly;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Auth;
using TwitcherSharp.Chat;
using TwitcherSharp.EventSub;
using TwitcherSharp.EventSub.Generated.ChannelFollow;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Media;
using TwitcherSharp.Poll;
using TwitcherSharp.Reward;

namespace TwitcherSharp.GoDotTests.Tests;

/// <summary>
/// Wrappers over twitcher functions that await. Called from C#, such a function returns a function state at its
/// first await, and its value arrives later; the wrappers must await it. The fakes (Fixtures/coroutine_fakes.gd)
/// await a frame before they answer.
/// </summary>
public class CoroutineWrapperTest(Node testScene) : TestClass(testScene)
{
    private const string FakesPath = "res://Tests/Fixtures/coroutine_fakes.gd";
    private const string ChatFixturePath = "res://Tests/Fixtures/chat_message_fixture.gd";

    [Test]
    public async Task GetEmotesByDefinitionReturnsTheSpriteFrames()
    {
        await WithFake("FakeMediaLoader", TwitchMediaLoader.FromObject, async loader =>
        {
            var result = await loader.GetEmotesByDefinition([new TwitchEmoteDefinition("25"), new TwitchEmoteDefinition("42")]);

            result.Count.ShouldBe(2);
            result.Keys.Select(definition => definition.Id).Order().ShouldBe(["25", "42"]);
            foreach (var (definition, frames) in result)
            {
                frames.GetMeta("emote_id").AsString().ShouldBe(definition.Id);
            }
        });
    }

    [Test]
    public async Task GetBadgesReturnsTheSpriteFrames()
    {
        await WithFake("FakeMediaLoader", TwitchMediaLoader.FromObject, async loader =>
        {
            var result = await loader.GetBadges([new TwitchBadgeDefinition("subscriber", "12", TwitchBadgeDefinition.Scale2, "1001")]);

            var (badge, frames) = result.ShouldHaveSingleItem();
            badge.BadgeSet.ShouldBe("subscriber");
            badge.BadgeId.ShouldBe("12");
            badge.Scale.ShouldBe(TwitchBadgeDefinition.Scale2);
            badge.Channel.ShouldBe("1001");
            frames.GetMeta("badge").AsString().ShouldBe("1001_subscriber_12_2");
        });
    }

    [Test]
    public async Task GetEmotesReturnsTheSpriteFrames()
    {
        await WithFake("FakeMediaLoader", TwitchMediaLoader.FromObject, async loader =>
        {
            var result = await loader.GetEmotes(["25"]);

            result.Keys.ShouldBe(["25"]);
            result["25"].GetMeta("emote_id").AsString().ShouldBe("25");
        });
    }

    [Test]
    public async Task PreloadEmotesCompletes()
    {
        await WithFake("FakeMediaLoader", TwitchMediaLoader.FromObject, async loader =>
        {
            await loader.PreloadEmotes("1001");

            loader.ToGodotObject().GetMeta("preloaded", "").AsString().ShouldBe("1001");
        });
    }

    [Test]
    public async Task LoadEmotesFromFragmentReturnsEmoteDefinitions()
    {
        using var fixture = GD.Load<GDScript>(ChatFixturePath);
        using var gdMessage = fixture.Call("full_message");
        var message = TwitchChatMessage.FromObject(gdMessage.AsGodotObject())!;

        await WithFake("FakeMediaLoader", TwitchMediaLoader.FromObject, async loader =>
        {
            var result = await message.LoadEmotesFromFragment(loader);

            result.Keys.Select(definition => definition.Id).ShouldBe(["25"]);
        });
    }

    [Test]
    public async Task SubscribeEventReturnsTheConfig()
    {
        await WithFake("FakeService", TwitchService.FromObject, async service =>
        {
            var config = await service.SubscribeEvent(TwitchEventSubDefinition.ChannelFollow,
                new TwitchChannelFollowCondition("1001", "1001"));

            config.ShouldNotBeNull();
            config.Type.ShouldBe(TwitchEventSubDefinitionType.ChannelFollow);
        });
    }

    [Test]
    public async Task ShoutoutAnnouncementAndWhisperComplete()
    {
        await WithFake("FakeService", TwitchService.FromObject, async service =>
        {
            await service.Shoutout(new TwitchUser { Id = "4004", Login = "friend" });
            await service.Announcement("Hello chat");
            await service.Whisper("psst", "4004");

            var node = service.ToGodotObject();
            node.GetMeta("shoutout", "").AsString().ShouldBe("friend");
            node.GetMeta("announcement", "").AsString().ShouldBe("Hello chat");
            node.GetMeta("whisper", "").AsString().ShouldBe("4004:psst");
        });
    }

    [Test]
    public async Task ChatSubscribeCompletes()
    {
        await WithFake("FakeChat", TwitchChat.FromObject, async chat =>
        {
            await chat.Subscribe();

            chat.ToGodotObject().GetMeta("subscribed", false).AsBool().ShouldBeTrue();
        });
    }

    [Test]
    public async Task AuthorizeAwaitsTheLogin()
    {
        using var fakes = GD.Load<GDScript>(FakesPath);
        using var fakeClass = fakes.Get("FakeAuth");
        var node = fakeClass.AsGodotObject().Call("new").AsGodotObject();
        try
        {
            // Blocking on the result instead would wait on the main thread for a frame that never comes.
            (await TwitchAuth.FromObject(node)!.Authorize(force: true)).ShouldBeTrue();
        }
        finally
        {
            node.Free();
        }
    }

    [Test]
    public void PollListenerReadsTheBroadcasterTwitcherResolves()
    {
        using var script = GD.Load<GDScript>("res://addons/twitcher/poll/twitch_poll_listener.gd");
        var node = script.New().AsGodotObject();
        try
        {
            // twitcher looks the broadcaster up in _ready; FromObject must not block on an API call for it.
            var listener = TwitchPollListener.FromObject(node)!;
            listener.Broadcaster.ShouldBeNull();

            node.Set("broadcaster", new TwitchUser { Id = "1001", Login = "broadcaster" }.ToGodotObject());
            listener.Broadcaster.ShouldNotBeNull();
            listener.Broadcaster.Id.ShouldBe("1001");
        }
        finally
        {
            node.Free();
        }
    }

    [Test]
    public async Task RewardServiceReturnsTheResults()
    {
        using var fakes = GD.Load<GDScript>(FakesPath);
        using var fakeClass = fakes.Get("FakeRewardService");
        using var gdService = fakeClass.AsGodotObject().Call("new");
        var service = TwitchRewardService.FromObject(gdService.AsGodotObject())!;
        var reward = new TwitchReward { Title = "Before", BroadcasterUser = new TwitchUser { Id = "1001" } };

        (await service.LoadReward(reward)).ShouldBe(TwitchRewardService.LoadError.NoRewardFound);
        reward.Title.ShouldBe("Loaded");
        (await service.SaveReward(reward)).ShouldBe(TwitchRewardService.SaveError.RewardNotOwned);
        (await service.DeleteReward(reward)).ShouldBe(TwitchRewardService.DeleteError.NoBroadcasterUser);
    }

    /// <summary>
    /// Wraps a fake node from coroutine_fakes.gd, runs the test and frees the node again. FromObject of the
    /// singleton wrappers replaces their static Instance, so the previous one is restored afterwards.
    /// </summary>
    private static async Task WithFake<T>(string fakeName, Func<GodotObject?, T?> fromObject, Func<T, Task> test)
        where T : RefCounted, ITwitcherSharpSingleton<T>, new()
    {
        var previous = ITwitcherSharpSingleton<T>.Instance;
        using var fakes = GD.Load<GDScript>(FakesPath);
        using var fakeClass = fakes.Get(fakeName);
        var node = fakeClass.AsGodotObject().Call("new").AsGodotObject();
        try
        {
            await test(fromObject(node)!);
        }
        finally
        {
            ITwitcherSharpSingleton<T>.Instance = previous;
            node.Free();
        }
    }
}
