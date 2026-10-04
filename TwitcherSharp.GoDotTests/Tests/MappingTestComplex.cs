using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Chickensoft.GoDotTest;
using Chickensoft.Log;
using Godot;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.EventSub;
using TwitcherSharp.EventSub.Generated.ChannelBitsUse;
using TwitcherSharp.EventSub.Generated.ChannelChatNotification;
using TwitcherSharp.EventSub.Generated.Shared;
using TwitcherSharp.GoDotTests.Helper;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Lib.Http;
using TwitcherSharp.Poll;

namespace TwitcherSharp.GoDotTests.Tests;

public class MappingTestComplex(Node testScene) : TestClass(testScene)
{
    private readonly ILog _log = new Log(nameof(MappingTestComplex), new TraceWriter());
    public List<ITwitcherSharp> TwitcherSharpObjects { get; set; }
    public static int TestCounter { get; set; } = 0;

    private const string TestString = "TestString";
    private const int TestInt = 42;
    private const bool TestBool = true;
    private const float TestFloat = 3.14f;

    public readonly List<string> TypesToSkip =
    [
        nameof(RequestData), //Ignoring this for tests 
        nameof(ResponseData), //Ignoring this for tests
        nameof(TwitchPollListener), //Doesn't want to work during test due to authentication stuff
        nameof(TwitchEventSubDefinition), //Special one tested manually in ManualMappingTest.cs
        nameof(TwitchGetAuthorizationByUserResponse), // Broken on Twitcher's side. Awaiting Kani's implementation.
        nameof(TwitchChannelChatNotificationCondition), // Broken on Twitcher's side. Awaiting Kani's implementation.
        nameof(TwitchChannelChatNotificationEvent), // Broken on Twitcher's side. Awaiting Kani's implementation.
        nameof(TwitchReward), // Broken on Twitcher's side. Awaiting Kani's implementation.
        nameof(TwitchChannelChatNotificationEvent), // Broken on Twitcher's side. Awaiting Kani's implementation.
        nameof(TwitchChannelBitsUseEvent), // Broken on Twitcher's side. Awaiting Kani's implementation.
    ];

    /// <summary>
    /// Generated types that do not map against the twitcher the tests run against, because the two generators read
    /// different sources: the drop.entitlement.grant data is untyped in twitcher's EventSub swagger, and the ad
    /// schedule timestamps are int in twitcher but float here. They are listed so that any other failing type still
    /// fails this test, and a listed type that starts to map fails it too.
    /// </summary>
    private static readonly HashSet<string> KnownTwitcherMismatches =
    [
        "TwitcherSharp.Api.Generated.Ads.TwitchGetAdScheduleResponse+TwitchResponseData",
        "TwitcherSharp.EventSub.Generated.DropEntitlementGrant.TwitchDropEntitlementGrantEvent+TwitchData",
    ];

    [Test]
    public void TestParsing()
    {
        var assembly = typeof(ITwitcherSharpSingleton).Assembly;

        TwitcherSharpObjects = assembly.GetTypes()
            .Where(t => typeof(ITwitcherSharp).IsAssignableFrom(t) &&
                        !typeof(ITwitcherSharpSingleton).IsAssignableFrom(t)
                        && t.IsClass
                        && !t.IsAbstract
                        && t.GetConstructor(Type.EmptyTypes) != null
                        && !TypesToSkip.Contains(t.Name)
                        && !IsNestedUnderSkippedType(t)
                        && !t.ContainsGenericParameters)
            .Select(t => (ITwitcherSharp)Activator.CreateInstance(t)!)
            .ToList();

        // Collect every failing type instead of stopping at the first one.
        var failures = new List<string>();
        foreach (var twitcherSharpObject in TwitcherSharpObjects)
        {
            foreach (var property in twitcherSharpObject.GetType().GetProperties().Where(p => p.CanWrite))
            {
                SetDefaultTestProperty(property, twitcherSharpObject);
            }

            _log.Print("testing " + twitcherSharpObject.GetType().Name);
            try
            {
                var godotObject = twitcherSharpObject.ToGodotObject();
                var parsedTwitcherSharpObject = FromGodotObject(twitcherSharpObject.GetType(), godotObject);
                AssertHelper.AssertTwitcherSharpProperties(twitcherSharpObject, parsedTwitcherSharpObject, _log);
            }
            catch (Exception e)
            {
                failures.Add($"{twitcherSharpObject.GetType().FullName}: {e.GetType().Name}: {e.Message}");
                continue;
            }
            TestCounter++;
            _log.Print($"test {TestCounter} successful {twitcherSharpObject.GetType().Name}");
        }

        var unexpected = failures.Where(f => !KnownTwitcherMismatches.Contains(f[..f.IndexOf(':')])).ToList();
        var mapsNow = KnownTwitcherMismatches
            .Where(name => !failures.Any(f => f.StartsWith(name + ":", StringComparison.Ordinal))).ToList();
        _log.Print($"{TestCounter} of {TwitcherSharpObjects.Count} types mapped, "
                   + $"{failures.Count - unexpected.Count} known twitcher mismatches");

        if (unexpected.Count > 0 || mapsNow.Count > 0)
        {
            throw new Exception($"{unexpected.Count} of {TwitcherSharpObjects.Count} types failed to map:\n"
                                + string.Join("\n", unexpected)
                                + (mapsNow.Count > 0
                                    ? "\nThese map now; remove them from KnownTwitcherMismatches:\n"
                                      + string.Join("\n", mapsNow)
                                    : ""));
        }
    }

    private bool IsNestedUnderSkippedType(Type type)
    {
        var current = type.DeclaringType;

        while (current != null)
        {
            if (TypesToSkip.Contains(current.Name))
            {
                return true;
            }

            current = current.DeclaringType;
        }

        return false;
    }

    private static void SetDefaultTestProperty(PropertyInfo property, ITwitcherSharp twitcherSharpObject)
    {
        switch (property.PropertyType.Name)
        {
            case nameof(String):
                property.SetValue(twitcherSharpObject, TestString);
                return;
            case nameof(Int32):
                property.SetValue(twitcherSharpObject, TestInt);
                return;
            case nameof(Boolean):
                property.SetValue(twitcherSharpObject, TestBool);
                return;
            case nameof(Single):
                property.SetValue(twitcherSharpObject, TestFloat);
                return;
            case nameof(DateTime):
                property.SetValue(twitcherSharpObject, DateTime.Now);
                return;
        }

        if (property.PropertyType.IsEnum)
        {
            property.SetValue(twitcherSharpObject, property.PropertyType.GetEnumValues().GetValue(0));
            return;
        }
    }

    private static ITwitcherSharp FromGodotObject(Type concreteType, GodotObject godotObject)
    {
        var fromObjectMethod = concreteType.GetMethod(
            "FromObject",
            BindingFlags.Public | BindingFlags.Static,
            binder: null,
            types: [typeof(GodotObject)],
            modifiers: null);

        if (fromObjectMethod == null)
        {
            throw new InvalidOperationException(
                $"Type {concreteType.FullName} does not expose a public static FromObject(GodotObject) method.");
        }

        return (ITwitcherSharp)fromObjectMethod.Invoke(null, [godotObject]);
    }
}