using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Chickensoft.GoDotTest;
using Chickensoft.Log;
using Godot;
using TwitcherSharp.Api.Generated.EventSub;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.EventSub;
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
                        && !t.ContainsGenericParameters)
            .Select(t => (ITwitcherSharp)Activator.CreateInstance(t)!)
            .ToList();

        foreach (var twitcherSharpObject in TwitcherSharpObjects)
        {
            foreach (var property in twitcherSharpObject.GetType().GetProperties().Where(p => p.CanWrite))
            {
                SetDefaultTestProperty(property, twitcherSharpObject);
            }

            _log.Print("testing " + twitcherSharpObject.GetType().Name);
            var godotObject = twitcherSharpObject.ToGodotObject();
            var parsedTwitcherSharpObject = FromGodotObject(twitcherSharpObject.GetType(), godotObject);
            AssertHelper.AssertTwitcherSharpProperties(twitcherSharpObject, parsedTwitcherSharpObject, _log);
            TestCounter++;
            _log.Print($"test {TestCounter} successful {twitcherSharpObject.GetType().Name}");
        }
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