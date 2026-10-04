using System;
using System.Threading.Tasks;
using Chickensoft.GoDotTest;
using Godot;
using Shouldly;
using TwitcherSharp.Api.Generated;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Chat;
using TwitcherSharp.EventSub;
using TwitcherSharp.EventSub.Generated.ChannelChatMessage;
using TwitcherSharp.Extensions;

namespace TwitcherSharp.GoDotTests.Tests;

/// <summary>
/// Maps a chat message, an API response and an EventSub event and keeps them until the engine shuts down, like a
/// consumer that holds on to the last message. Whatever handle the mapping leaks is released by Godot's disposables
/// tracker at shutdown; the run then crashes on exit (run-tests.ps1 fails on the exit code) or ends early (fewer tests
/// run than discovered).
/// </summary>
public class DisposalTest(Node testScene) : TestClass(testScene)
{
    private const string ChatFixturePath = "res://Tests/Fixtures/chat_message_fixture.gd";
    private const string ChatEventPath = "res://addons/twitcher/generated_eventsub/twitch_es_channel_chat_message.gd";

    // Kept until shutdown on purpose.
    private static TwitchChatMessage? _chatMessage;
    private static TwitchGetUsersResponse? _users;
    private static TwitchChannelChatMessageEvent? _chatEvent;

    [Test]
    public void ChatMessageSurvivesTheCallerDisposingItsWrapper()
    {
        using var gdMessage = NewChatMessage();
        TwitchChatMessage message;
        // The handle rule for callers: dispose the wrapper you made. Godot hands out one wrapper per object, so this
        // is also the wrapper FromObject received.
        using (var wrapper = gdMessage.AsGodotObject())
        {
            message = TwitchChatMessage.FromObject(wrapper)!;
        }

        message.Content.Fragments[1].Emote!.Id.ShouldBe("25");
        message.Badges.Length.ShouldBe(2);
    }

    [Test]
    public async Task ApiResponseSurvivesTheCallerDisposingItsWrapper()
    {
        using var gdResponse = await TwitchApi.Required.ToGodotObject().CallAsync("get_users", new Variant());
        TwitchGetUsersResponse response;
        using (var wrapper = gdResponse.AsGodotObject())
        {
            response = TwitchGetUsersResponse.FromObject(wrapper)!;
        }

        response.Data[0].Id.ShouldBe(Main.UserId);
    }

    [Test]
    public void EventSubEventSurvivesTheCallerDisposingItsWrapper()
    {
        using var gdEvent = NewChatEvent();
        TwitchChannelChatMessageEvent chatEvent;
        using (var wrapper = gdEvent.AsGodotObject())
        {
            chatEvent = TwitchChannelChatMessageEvent.FromObject(wrapper)!;
        }

        chatEvent.Message!.Fragments![0].Text.ShouldBe("Hello");
    }

    [Test]
    public void DisposingTheMappedObjectsReleasesTheTwitcherObjects()
    {
        AssertReleasedOnDispose(NewChatMessage(), data =>
        {
            var message = TwitchChatMessage.FromObject(data)!;
            message.Content.Fragments[1].Emote!.Id.ShouldBe("25");
            return message;
        });
        AssertReleasedOnDispose(NewChatEvent(), data =>
        {
            var chatEvent = TwitchChannelChatMessageEvent.FromObject(data)!;
            chatEvent.Message!.Text.ShouldBe("Hello");
            return chatEvent;
        });
    }

    [Test]
    public void EventSubDefinitionCreatesNoObject()
    {
        // twitcher's definitions are plain Objects, which nothing frees; ToGodotObject must hand out twitcher's own.
        // The first call may initialize the script's static definitions, so it is not counted.
        TwitchEventSubDefinition.ChannelFollow.ToGodotObject().Dispose();
        var before = Performance.GetMonitor(Performance.Monitor.ObjectCount);

        for (var i = 0; i < 10; i++)
        {
            using var definition = TwitchEventSubDefinition.ChannelFollow.ToGodotObject();
            definition.Get("value").AsString().ShouldBe("channel.follow");
        }

        (Performance.GetMonitor(Performance.Monitor.ObjectCount) - before).ShouldBe(0);
    }

    [Test]
    public async Task MappedObjectsAreKeptUntilExit()
    {
        using (var gdMessage = NewChatMessage())
        using (var wrapper = gdMessage.AsGodotObject())
        {
            _chatMessage = TwitchChatMessage.FromObject(wrapper);
        }

        _chatMessage.ShouldNotBeNull();
        _chatMessage.Content.Fragments[1].Emote!.Id.ShouldBe("25");
        _chatMessage.Content.Fragments[3].Mention!.UserName.ShouldBe("Friend");
        _chatMessage.Badges.Length.ShouldBe(2);

        _users = await TwitchApi.Required.GetUsers();
        _users.Data.ShouldNotBeEmpty();
        _users.Data[0].Id.ShouldBe(Main.UserId);

        using (var gdEvent = NewChatEvent())
        using (var wrapper = gdEvent.AsGodotObject())
        {
            _chatEvent = TwitchChannelChatMessageEvent.FromObject(wrapper);
        }

        _chatEvent.ShouldNotBeNull();
        _chatEvent.BroadcasterUserId.ShouldBe("1001");
        _chatEvent.Message!.Text.ShouldBe("Hello");
        _chatEvent.Message.Fragments![0].Text.ShouldBe("Hello");

        // Anything the mapping dropped is finalized now, on the finalizer thread, while the run continues.
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    private static Variant NewChatMessage()
    {
        using var fixture = GD.Load<GDScript>(ChatFixturePath);
        return fixture.Call("full_message");
    }

    /// <summary>
    /// A channel.chat.message event built by twitcher's own from_json, as the EventSub client does.
    /// </summary>
    private static Variant NewChatEvent()
    {
        using var script = GD.Load<GDScript>(ChatEventPath);
        using var eventClass = script.Get("Event");
        using var json = new Godot.Collections.Dictionary
        {
            ["broadcaster_user_id"] = "1001",
            ["chatter_user_name"] = "Chatter",
            ["message"] = new Godot.Collections.Dictionary
            {
                ["text"] = "Hello",
                ["fragments"] = new Godot.Collections.Array
                {
                    new Godot.Collections.Dictionary { ["type"] = "text", ["text"] = "Hello" },
                },
            },
        };
        using var eventClassObject = eventClass.AsGodotObject();
        return eventClassObject.Call("from_json", json);
    }

    /// <summary>
    /// Maps <paramref name="gdObject"/>, drops every other reference to it and checks that disposing the mapped object
    /// frees the twitcher object right away instead of whenever the GC finalizes a leftover wrapper.
    /// </summary>
    private static void AssertReleasedOnDispose(Variant gdObject, Func<GodotObject, GodotObject> map)
    {
        WeakRef weak;
        GodotObject mapped;
        using (gdObject)
        using (var wrapper = gdObject.AsGodotObject())
        {
            weak = GodotObject.WeakRef(wrapper)!;
            mapped = map(wrapper);
        }

        using (var alive = weak.GetRef())
        {
            alive.VariantType.ShouldBe(Variant.Type.Object, "the mapped object keeps the twitcher object");
        }

        mapped.Dispose();

        using var released = weak.GetRef();
        released.VariantType.ShouldBe(Variant.Type.Nil, $"{mapped.GetType().Name}.Dispose releases the twitcher object");
        weak.Dispose();
    }
}
