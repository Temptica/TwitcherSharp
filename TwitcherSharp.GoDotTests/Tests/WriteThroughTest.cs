using System;
using Chickensoft.GoDotTest;
using Godot;
using Shouldly;
using TwitcherSharp.Api.Generated;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Chat;
using TwitcherSharp.EventSub;
using TwitcherSharp.Poll;
using TwitcherSharp.Reward;

namespace TwitcherSharp.GoDotTests.Tests;

/// <summary>
/// Setting a property of a wrapper linked to a twitcher node changes the node, and reading it reads the node.
/// </summary>
public class WriteThroughTest(Node testScene) : TestClass(testScene)
{
    private const string CommandScript = "res://addons/twitcher/chat/twitch_command.gd";
    private const string ContainsScript = "res://addons/twitcher/chat/twitch_command_contains.gd";
    private const string RegexScript = "res://addons/twitcher/chat/twitch_command_regex.gd";
    private const string HelpScript = "res://addons/twitcher/chat/twitch_command_help.gd";
    private const string AutoMessageScript = "res://addons/twitcher/chat/twitch_auto_message.gd";
    private const string PollListenerScript = "res://addons/twitcher/poll/twitch_poll_listener.gd";
    private const string RedeemListenerScript = "res://addons/twitcher/reward/twitch_redeem_listener.gd";

    [Test]
    public void CommandAllowedUsersReachTheNode()
    {
        WithNode(CommandScript, node =>
        {
            var command = TwitchCommand.FromObject(node)!;

            command.AllowedUsers = ["kani"];

            using var allowed = node.Get("allowed_users");
            allowed.AsStringArray().ShouldBe(["kani"]);
        });
    }

    [Test]
    public void CommandBasePropertiesReachTheNode()
    {
        WithNode(CommandScript, node =>
        {
            var command = TwitchCommand.FromObject(node)!;

            command.Command = "camera";
            command.Description = "moves the camera";
            command.PermissionLevel = TwitchCommandBase.PermissionFlag.Mod;
            command.Where = TwitchCommandBase.WhereFlag.Anywhere;
            command.ListenToChatrooms = ["room"];
            command.CaseInsensitive = false;
            command.UserCooldown = 2.5;
            command.GlobalCooldown = 1.5;

            Read(node, "command", v => v.AsString()).ShouldBe("camera");
            Read(node, "description", v => v.AsString()).ShouldBe("moves the camera");
            Read(node, "permission_level", v => v.AsInt32()).ShouldBe(4);
            Read(node, "where", v => v.AsInt32()).ShouldBe(3);
            Read(node, "listen_to_chatrooms", v => v.AsStringArray()).ShouldBe(["room"]);
            Read(node, "case_insensitive", v => v.AsBool()).ShouldBeFalse();
            Read(node, "user_cooldown", v => v.AsDouble()).ShouldBe(2.5);
            Read(node, "global_cooldown", v => v.AsDouble()).ShouldBe(1.5);
        });
    }

    [Test]
    public void CommandPropertiesReachTheNode()
    {
        WithNode(CommandScript, node =>
        {
            var command = TwitchCommand.FromObject(node)!;

            command.CommandPrefixes = ["?"];
            command.Aliases = ["cam", "c"];
            command.ArgsMin = 1;
            command.ArgsMax = 3;

            Read(node, "command_prefixes", v => v.AsStringArray()).ShouldBe(["?"]);
            Read(node, "aliases", v => v.AsStringArray()).ShouldBe(["cam", "c"]);
            Read(node, "args_min", v => v.AsInt32()).ShouldBe(1);
            Read(node, "args_max", v => v.AsInt32()).ShouldBe(3);
        });
    }

    [Test]
    public void CommandReadsWhatTheNodeHolds()
    {
        WithNode(CommandScript, node =>
        {
            var command = TwitchCommand.FromObject(node)!;

            using (var users = Variant.CreateFrom(new Godot.Collections.Array<string> { "kani" })) node.Set("allowed_users", users);
            node.Set("command", "later");
            node.Set("args_max", 7);

            command.AllowedUsers.ShouldBe(["kani"]);
            command.Command.ShouldBe("later");
            command.ArgsMax.ShouldBe(7);
        });
    }

    [Test]
    public void UnlinkedCommandKeepsItsValues()
    {
        var command = new TwitchCommand { Command = "hello", AllowedUsers = ["kani"], ArgsMin = 2 };

        command.Command.ShouldBe("hello");
        command.AllowedUsers.ShouldBe(["kani"]);
        command.ArgsMin.ShouldBe(2);

        var node = (Node)command.ToGodotObject();
        try
        {
            Read(node, "allowed_users", v => v.AsStringArray()).ShouldBe(["kani"]);
            command.AllowedUsers = ["other"];
            Read(node, "allowed_users", v => v.AsStringArray()).ShouldBe(["other"]);
        }
        finally
        {
            node.Free();
        }
    }

    [Test]
    public void ContainsAndRegexPropertiesReachTheNode()
    {
        WithNode(ContainsScript, node =>
        {
            var command = TwitchCommandContains.FromObject(node)!;

            command.Contains = ["hello", "hi"];
            command.MatchAll = true;
            command.MatchWord = true;
            command.AllowedUsers = ["kani"];

            Read(node, "contains", v => v.AsStringArray()).ShouldBe(["hello", "hi"]);
            Read(node, "match_all", v => v.AsBool()).ShouldBeTrue();
            Read(node, "match_word", v => v.AsBool()).ShouldBeTrue();
            Read(node, "allowed_users", v => v.AsStringArray()).ShouldBe(["kani"]);
        });

        WithNode(RegexScript, node =>
        {
            var command = TwitchCommandRegex.FromObject(node)!;

            command.RegexToListen = "^hi$";

            Read(node, "regex_to_listen", v => v.AsString()).ShouldBe("^hi$");
        });
    }

    [Test]
    public void HelpSenderUserReachesTheNode()
    {
        WithNode(HelpScript, node =>
        {
            var help = TwitchCommandHelp.FromObject(node)!;

            help.SenderUser = new TwitchUser { Id = "4711", Login = "kani" };
            help.Aliases = ["h"];

            using var sender = node.Get("sender_user");
            using var user = sender.AsGodotObject();
            using var login = user.Get("login");
            login.AsString().ShouldBe("kani");
            help.SenderUser!.Login.ShouldBe("kani");
            Read(node, "aliases", v => v.AsStringArray()).ShouldBe(["h"]);
        });
    }

    [Test]
    public void AutoMessagePropertiesReachTheNode()
    {
        WithNode(AutoMessageScript, node =>
        {
            var message = TwitchAutoMessage.FromObject(node)!;

            message.UseBot = true;
            message.Announcement = true;
            message.AnnouncementColor = TwitchAnnouncementColor.Purple;
            message.Message = "follow!";
            message.SourceOnly = false;
            message.Weight = 3;
            message.Broadcaster = new TwitchUser { Id = "1", Login = "broadcaster" };
            message.Sender = new TwitchUser { Id = "2", Login = "sender" };

            Read(node, "use_bot", v => v.AsBool()).ShouldBeTrue();
            Read(node, "announcement", v => v.AsBool()).ShouldBeTrue();
            Read(node, "announcement_color", v => v.AsInt32()).ShouldBe(3); // TwitchAnnouncementColor.Enum.PURPLE
            Read(node, "message", v => v.AsString()).ShouldBe("follow!");
            Read(node, "source_only", v => v.AsBool()).ShouldBeFalse();
            Read(node, "weight", v => v.AsInt32()).ShouldBe(3);
            ReadLogin(node, "broadcaster").ShouldBe("broadcaster");
            ReadLogin(node, "sender").ShouldBe("sender");

            message.AnnouncementColor.Value.ShouldBe("purple");
            message.Broadcaster!.Login.ShouldBe("broadcaster");
        });
    }

    [Test]
    public void ListenerSettingsReachTheNode()
    {
        var eventSub = TwitchEventSub.Instance.ShouldNotBeNull();
        var api = TwitchApi.Instance.ShouldNotBeNull();

        WithNode(PollListenerScript, node =>
        {
            var listener = TwitchPollListener.FromObject(node)!;

            listener.EnsureSubscriptionsOnReady = false;
            listener.TwitchEventSub = eventSub;
            listener.TwitchApi = api;

            Read(node, "ensure_subscriptions_on_ready", v => v.AsBool()).ShouldBeFalse();
            ReadNode(node, "eventsub").ShouldBe(eventSub.ToGodotObject().GetInstanceId());
            ReadNode(node, "api").ShouldBe(api.ToGodotObject().GetInstanceId());
        });

        WithNode(RedeemListenerScript, node =>
        {
            var listener = TwitchRedeemListener.FromObject(node)!;

            listener.EnsureSubscriptionsOnReady = false;
            listener.TwitchEventSub = eventSub;
            listener.TwitchApi = api;

            Read(node, "ensure_subscriptions_on_ready", v => v.AsBool()).ShouldBeFalse();
            ReadNode(node, "eventsub").ShouldBe(eventSub.ToGodotObject().GetInstanceId());
            ReadNode(node, "api").ShouldBe(api.ToGodotObject().GetInstanceId());
        });
    }

    [Test]
    public void RewardServiceApiReachesTheTwitcherObject()
    {
        var api = TwitchApi.Instance.ShouldNotBeNull();
        using var script = GD.Load<GDScript>("res://addons/twitcher/reward/twitch_reward_service.gd");
        using var instance = script.New(default, default);
        TwitchRewardService service;
        // Godot shares one wrapper per object and the service disposes the ones it takes: never hold one across.
        using (var gdService = instance.AsGodotObject()) service = TwitchRewardService.FromObject(gdService)!;
        using var _ = service;

        service.TwitchApi = api;

        using var after = instance.AsGodotObject();
        ReadNode(after, "api").ShouldBe(api.ToGodotObject().GetInstanceId());
    }

    /// <summary>
    /// Creates a node of a twitcher script outside the tree and frees it afterwards.
    /// </summary>
    private static void WithNode(string scriptPath, Action<Node> test)
    {
        Node node;
        using (var script = GD.Load<GDScript>(scriptPath))
        using (var instance = script.New())
        {
            node = (Node)instance.AsGodotObject();
        }

        try
        {
            test(node);
        }
        finally
        {
            node.Free();
        }
    }

    private static T Read<T>(GodotObject node, string property, Func<Variant, T> read)
    {
        using var value = node.Get(property);
        return read(value);
    }

    private static string ReadLogin(GodotObject node, string property)
    {
        using var value = node.Get(property);
        using var user = value.AsGodotObject();
        if (user is null) return null;
        using var login = user.Get("login");
        return login.AsString();
    }

    private static ulong ReadNode(GodotObject node, string property)
    {
        using var value = node.Get(property);
        return value.AsGodotObject()?.GetInstanceId() ?? 0;
    }
}
