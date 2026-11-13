using System;
using System.Linq;
using Chickensoft.GoDotTest;
using Godot;
using Shouldly;
using TwitcherSharp.Api.Generated.Ads;
using TwitcherSharp.EventSub.Generated.ConduitShardDisabled;
using TwitcherSharp.EventSub.Generated.HypeTrainBegin;
using TwitcherSharp.EventSub.Generated.Shared;

namespace TwitcherSharp.GoDotTests.Tests;

/// <summary>
/// Generated types whose shape has to match the Twitch API (and twitcher): the types are read through reflection, so
/// the tests compile against any shape and fail on the wrong one.
/// </summary>
public class GeneratedShapeTest(Node testScene) : TestClass(testScene)
{
    private const string EventSubPath = "res://addons/twitcher/generated_eventsub/";

    [Test]
    public void AdScheduleTimestampsKeepEverySecond()
    {
        // Unix timestamps (int64 in the API): a float has no room for the last seconds of 1700000001.
        using var gdData = FromJson("res://addons/twitcher/generated/twitch_get_ad_schedule.gd", "ResponseData",
            new Godot.Collections.Dictionary
            {
                ["snooze_refresh_at"] = 1700000001L,
                ["next_ad_at"] = 1700000003L,
                ["last_ad_at"] = 1700000005L,
            });
        using var wrapper = gdData.AsGodotObject();
        var data = TwitchGetAdScheduleResponse.TwitchResponseData.FromObject(wrapper)!;

        Convert.ToInt64(Property(data, "SnoozeRefreshAt")).ShouldBe(1700000001L);
        Convert.ToInt64(Property(data, "NextAdAt")).ShouldBe(1700000003L);
        Convert.ToInt64(Property(data, "LastAdAt")).ShouldBe(1700000005L);
    }

    [Test]
    public void HypeTrainTopContributionsIsAList()
    {
        using var gdEvent = FromJson(EventSubPath + "twitch_es_hype_train_begin.gd", "Event", new Godot.Collections.Dictionary
        {
            ["top_contributions"] = new Godot.Collections.Array
            {
                new Godot.Collections.Dictionary { ["user_id"] = "1", ["type"] = "bits", ["total"] = 100 },
                new Godot.Collections.Dictionary { ["user_id"] = "2", ["type"] = "subscription", ["total"] = 50 },
            },
        });
        using var wrapper = gdEvent.AsGodotObject();
        var hypeTrain = TwitchHypeTrainBeginEvent.FromObject(wrapper)!;

        var contributions = Property(hypeTrain, "TopContributions").ShouldBeAssignableTo<Array>()!;
        contributions.Length.ShouldBe(2);
        Property(contributions.GetValue(1)!, "UserId").ShouldBe("2");
    }

    [Test]
    public void PredictionTopPredictorsIsAList()
    {
        using var gdOutcome = FromJson(EventSubPath + "twitch_es_outcomes.gd", null, new Godot.Collections.Dictionary
        {
            ["id"] = "outcome-1",
            ["top_predictors"] = new Godot.Collections.Array
            {
                new Godot.Collections.Dictionary { ["user_id"] = "1", ["channel_points_used"] = 500 },
                new Godot.Collections.Dictionary { ["user_id"] = "2", ["channel_points_used"] = 300 },
            },
        });
        using var wrapper = gdOutcome.AsGodotObject();
        var outcome = TwitchOutcomes.FromObject(wrapper)!;

        var predictors = Property(outcome, "TopPredictors").ShouldBeAssignableTo<Array>()!;
        predictors.Length.ShouldBe(2);
        Property(predictors.GetValue(1)!, "UserId").ShouldBe("2");
    }

    [Test]
    public void ConduitShardDisabledKeepsTheTransportFieldsInTheTransport()
    {
        using var gdEvent = FromJson(EventSubPath + "twitch_es_conduit_shard_disabled.gd", "Event",
            new Godot.Collections.Dictionary
            {
                ["conduit_id"] = "conduit-1",
                ["transport"] = new Godot.Collections.Dictionary { ["method"] = "websocket", ["session_id"] = "session-1" },
            });
        using var wrapper = gdEvent.AsGodotObject();
        var disabled = TwitchConduitShardDisabledEvent.FromObject(wrapper)!;

        // The docs list the transport's fields unindented after it; they belong to the transport, not the event.
        string[] transportFields = ["Method", "Callback", "SessionId", "ConnectedAt", "DisconnectedAt"];
        typeof(TwitchConduitShardDisabledEvent).GetProperties().Select(p => p.Name).Intersect(transportFields)
            .ShouldBeEmpty();
        disabled.Transport.ShouldNotBeNull();
        Property(disabled.Transport, "Method").ShouldBe("websocket");
        Property(disabled.Transport, "SessionId").ShouldBe("session-1");
    }

    /// <summary>
    /// A twitcher object made by its own from_json, the way twitcher fills it from Twitch's JSON.
    /// </summary>
    private static Variant FromJson(string scriptPath, string? innerClass, Godot.Collections.Dictionary json)
    {
        using var script = GD.Load<GDScript>(scriptPath);
        using (json)
        {
            if (innerClass is null) return script.Call("from_json", json);
            using var inner = script.Get(innerClass);
            using var innerScript = inner.AsGodotObject();
            return innerScript.Call("from_json", json);
        }
    }

    private static object? Property(object target, string name) =>
        target.GetType().GetProperty(name).ShouldNotBeNull($"{target.GetType().Name}.{name}").GetValue(target);
}
