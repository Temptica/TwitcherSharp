using Chickensoft.GoDotTest;
using Godot;
using Shouldly;
using TwitcherSharp.EventSub;
using TwitcherSharp.EventSub.Generated.ChannelFollow;

namespace TwitcherSharp.GoDotTests.Tests;

/// <summary>
/// EventSub definitions and configs between twitcher and C#. twitcher numbers its event types in another order than
/// TwitchEventSubDefinitionType, so a type only maps through the event it stands for (value and version).
/// </summary>
public class EventSubMappingTest(Node testScene) : TestClass(testScene)
{
    private const string DefinitionPath = "res://addons/twitcher/eventsub/twitch_eventsub_definition.gd";
    private const string ConfigPath = "res://addons/twitcher/eventsub/twitch_eventsub_config.gd";

    [Test]
    public void DefinitionFromTwitcherHasItsType()
    {
        using var script = GD.Load<GDScript>(DefinitionPath);
        using var follow = script.Get("CHANNEL_FOLLOW");
        using var followObject = follow.AsGodotObject();

        TwitchEventSubDefinition.FromObject(followObject)!.Type.ShouldBe(TwitchEventSubDefinitionType.ChannelFollow);
    }

    [Test]
    public void ConfigFromTwitcherHasItsType()
    {
        using var definitions = GD.Load<GDScript>(DefinitionPath);
        using var follow = definitions.Get("CHANNEL_FOLLOW");
        using var configs = GD.Load<GDScript>(ConfigPath);
        using var conditions = new Godot.Collections.Dictionary { ["broadcaster_user_id"] = "1001" };
        using var config = configs.Call("create", follow, conditions);
        using var configObject = config.AsGodotObject();
        configObject.Set("id", "subscription-1");

        var mapped = TwitchEventSubConfig.FromObject(configObject)!;

        mapped.Type.ShouldBe(TwitchEventSubDefinitionType.ChannelFollow);
        mapped.Id.ShouldBe("subscription-1");
    }

    [Test]
    public void ConfigToTwitcherKeepsTypeAndConditions()
    {
        var config = new TwitchEventSubConfig(TwitchEventSubDefinition.ChannelFollow,
            [new TwitchChannelFollowCondition("1001", "2002")]);

        using var configObject = config.ToGodotObject();

        using var definition = configObject.Get("definition");
        using var definitionObject = definition.AsGodotObject();
        definitionObject.Get("value").AsString().ShouldBe("channel.follow");
        using var condition = configObject.Get("condition");
        using var conditionDictionary = condition.AsGodotDictionary();
        conditionDictionary["broadcaster_user_id"].AsString().ShouldBe("1001");
        conditionDictionary["moderator_user_id"].AsString().ShouldBe("2002");
    }
}
