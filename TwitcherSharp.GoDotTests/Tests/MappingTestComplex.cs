using System;
using System.Collections;
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
using TwitcherSharp.GoDotTests.Helper;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Lib.Http;
using TwitcherSharp.Lib.OOuch;
using TwitcherSharp.Poll;
using TwitcherSharp.Reward;

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
    private const int MaxPopulateDepth = 10;

    public readonly List<string> TypesToSkip =
    [
        nameof(RequestData), //Ignoring this for tests 
        nameof(ResponseData), //Ignoring this for tests
        nameof(TwitchPollListener), //Doesn't want to work during test due to authentication stuff
        nameof(OAuthTokenHandler), //Token setter proxies straight to the linked GodotObject; unusable without a real linked instance
        nameof(TwitchEventSubDefinition), //Special one tested manually in ManualMappingTest.cs
        nameof(TwitchGetAuthorizationByUserResponse), // Broken on Twitcher's side. Awaiting Kani's implementation.
        nameof(TwitchChannelChatNotificationCondition), // Broken on Twitcher's side. Awaiting Kani's implementation.
        nameof(TwitchChannelChatNotificationEvent), // Broken on Twitcher's side. Awaiting Kani's implementation.
        nameof(TwitchReward), // Broken on Twitcher's side. Awaiting Kani's implementation.
        nameof(TwitchChannelChatNotificationEvent), // Broken on Twitcher's side. Awaiting Kani's implementation.
        nameof(TwitchChannelBitsUseEvent), // Broken on Twitcher's side. Awaiting Kani's implementation.
        // NOTE: as of the recursive/array assertion work, TestParsing() now aggregates every per-type failure
        // into a single report instead of throwing on the first one (see the try/catch in TestParsing below).
        // That surfaced ~200 generated types with real, previously-invisible mapping bugs, in two known
        // buckets: (1) array-of-wrapper properties written via `.Set(key, x.ToGodotArray())`, which Godot
        // silently empties because the array isn't typed to the GDScript-declared inner script (fixed by hand
        // for TwitchChatMessage's Badges/SourceBadges/Fragments using the new GodotObjectExtension.SetArray;
        // TwitchMessage.Emotes is one of many still-broken generated instances of the same bug), and
        // (2) generator cardinality bugs where GDScript declares an `Array[X]` field but the generated C#
        // property is a single X, not an array (e.g. TwitchOutcomes.TopPredictors, TwitchHypeTrainProgressEvent
        // .TopContributions). Both are generated-code issues requiring a TwitcherSharp.ClassGenerator template
        // fix + regeneration, not one-off skip-list entries or hand-edits to Generated/ files. Given the scale
        // (~200 types), see the run's aggregated failure report rather than skip-listing them individually.
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

        var failures = new List<string>();

        foreach (var twitcherSharpObject in TwitcherSharpObjects)
        {
            try
            {
                PopulateProperties(twitcherSharpObject, 0);

                _log.Print("testing " + twitcherSharpObject.GetType().Name);
                var godotObject = twitcherSharpObject.ToGodotObject();
                var parsedTwitcherSharpObject = FromGodotObject(twitcherSharpObject.GetType(), godotObject);
                AssertHelper.AssertTwitcherSharpProperties(twitcherSharpObject, parsedTwitcherSharpObject, _log);
                TestCounter++;
                _log.Print($"test {TestCounter} successful {twitcherSharpObject.GetType().Name}");
            }
            catch (Exception ex)
            {
                failures.Add($"{twitcherSharpObject.GetType().FullName}: {ex.Message}");
            }
        }

        if (failures.Count > 0)
        {
            throw new Exception(
                $"Mapping tests failed for {failures.Count} of {TwitcherSharpObjects.Count} types:\n" +
                string.Join("\n", failures));
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

    private void PopulateProperties(object obj, int depth)
    {
        if (depth > MaxPopulateDepth) return;

        foreach (var property in obj.GetType().GetProperties()
                     .Where(p => p.CanWrite && p.GetMethod?.IsStatic != true))
        {
            SetDefaultTestProperty(property, obj, depth);
        }
    }

    private void SetDefaultTestProperty(PropertyInfo property, object twitcherSharpObject, int depth)
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

        if (typeof(ITwitcherSharp).IsAssignableFrom(property.PropertyType))
        {
            var nested = CreateNested(property.PropertyType, depth);
            if (nested != null)
            {
                property.SetValue(twitcherSharpObject, nested);
            }

            return;
        }

        if (property.PropertyType.IsArray)
        {
            var elementType = property.PropertyType.GetElementType()!;
            var array = CreateSequence(elementType, depth);
            if (array == null) return;

            var typedArray = Array.CreateInstance(elementType, array.Count);
            for (var i = 0; i < array.Count; i++) typedArray.SetValue(array[i], i);
            property.SetValue(twitcherSharpObject, typedArray);
            return;
        }

        if (property.PropertyType.IsGenericType &&
            property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
        {
            var elementType = property.PropertyType.GetGenericArguments()[0];
            var items = CreateSequence(elementType, depth);
            if (items == null) return;

            var listType = typeof(List<>).MakeGenericType(elementType);
            var typedList = (IList)Activator.CreateInstance(listType)!;
            foreach (var item in items) typedList.Add(item);
            property.SetValue(twitcherSharpObject, typedList);
        }
    }

    private object CreateNested(Type type, int depth)
    {
        if (depth >= MaxPopulateDepth) return null;
        if (type.IsAbstract || type.IsInterface) return null;
        if (type.GetConstructor(Type.EmptyTypes) == null) return null;

        var instance = Activator.CreateInstance(type)!;
        PopulateProperties(instance, depth + 1);
        return instance;
    }

    private List<object> CreateSequence(Type elementType, int depth)
    {
        if (elementType == typeof(string))
        {
            return [TestString + "_1", TestString + "_2"];
        }

        if (!typeof(ITwitcherSharp).IsAssignableFrom(elementType)) return null;
        if (depth >= MaxPopulateDepth) return [];

        var item = CreateNested(elementType, depth);
        return item == null ? [] : [item];
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