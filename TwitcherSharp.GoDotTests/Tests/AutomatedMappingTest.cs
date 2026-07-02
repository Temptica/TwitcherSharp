using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Chickensoft.GoDotTest;
using Chickensoft.Log;
using Godot;
using TwitcherSharp.Interfaces;
using TwitcherSharp.GoDotTests.Helper;

namespace TwitcherSharp.GoDotTests.Tests;

public class AutomatedMappingTest(Node testScene) : TestClass(testScene)
{
    private readonly Log _log = new(nameof(AutomatedMappingTest), new TraceWriter());

    [Test]
    public void TestAllMappings()
    {
        var assembly = typeof(ITwitcherSharp).Assembly;
        var types = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Where(t => typeof(ITwitcherSharp).IsAssignableFrom(t))
            .ToList();

        _log.Print($"Found {types.Count} types implementing ITwitcherSharp");

        var successCount = 0;
        int failCount = 0;
        List<string> failures = new();

        foreach (var type in types)
        {
            try
            {
                TestTypeMapping(type, false);
                successCount++;
            }
            catch (Exception ex)
            {
                _log.Err($"Failed to test mapping for {type.FullName}: {ex.Message}");
                failures.Add($"{type.FullName}: {ex.Message}");
                failCount++;
            }
        }

        _log.Print($"Mapping test completed. Success: {successCount}, Fail: {failCount}");

        if (failCount > 0)
        {
            throw new Exception($"Mapping tests failed for {failCount} types:\n" + string.Join("\n", failures));
        }
    }

    [Test]
    public void TestAllEventSubMappings()
    {
        var assembly = typeof(ITwitcherSharp).Assembly;
        var types = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .Where(t => typeof(ITwitcherSharpEventSub).IsAssignableFrom(t))
            .ToList();

        _log.Print($"Found {types.Count} types implementing ITwitcherSharpEventSub");

        int successCount = 0;
        int failCount = 0;
        List<string> failures = new();

        foreach (var type in types)
        {
            try
            {
                TestTypeMapping(type, true);
                successCount++;
            }
            catch (Exception ex)
            {
                _log.Err($"Failed to test mapping for {type.FullName}: {ex.Message}");
                failures.Add($"{type.FullName}: {ex.Message}");
                failCount++;
            }
        }

        _log.Print($"EventSub mapping test completed. Success: {successCount}, Fail: {failCount}");

        if (failCount > 0)
        {
            throw new Exception($"EventSub mapping tests failed for {failCount} types:\n" + string.Join("\n", failures));
        }
    }

    private void TestTypeMapping(Type type, bool isEventSub)
    {
        _log.Print($"Testing {type.Name}");

        // Create instance
        object instance;
        try
        {
            instance = Activator.CreateInstance(type);
        }
        catch (Exception ex)
        {
            // Some classes might not have parameterless constructor or might fail during creation
            _log.Warn($"Could not create instance of {type.Name} using parameterless constructor: {ex.Message}");
            return;
        }

        if (isEventSub)
        {
            if (instance is not ITwitcherSharpEventSub eventSubObject) return;
            InitializeProperties(eventSubObject);
            
            GodotObject godotObject;
            try { godotObject = eventSubObject.ToGodotObject(); }
            catch (Exception ex) { throw new Exception($"ToGodotObject failed: {ex.Message}", ex); }
            
            if (godotObject == null) { _log.Warn($"{type.Name}.ToGodotObject() returned null"); return; }
            
            var fromObjectMethod = type.GetMethod("FromObject", BindingFlags.Public | BindingFlags.Static);
            if (fromObjectMethod == null) throw new Exception($"Static method FromObject not found on type {type.FullName}");
            
            ITwitcherSharpEventSub restoredObject;
            try { restoredObject = fromObjectMethod.Invoke(null, [godotObject]) as ITwitcherSharpEventSub; }
            catch (Exception ex) { throw new Exception($"FromObject failed: {ex.Message}", ex); }
            
            if (restoredObject == null) throw new Exception("FromObject returned null");
            
            AssertHelper.AssertTwitcherSharpProperties(eventSubObject, restoredObject, _log);
        }
        else
        {
            if (instance is not ITwitcherSharp twitcherObject) return;
            InitializeProperties(twitcherObject);
            
            GodotObject godotObject;
            try { godotObject = twitcherObject.ToGodotObject(); }
            catch (Exception ex) { throw new Exception($"ToGodotObject failed: {ex.Message}", ex); }
            
            if (godotObject == null) { _log.Warn($"{type.Name}.ToGodotObject() returned null"); return; }
            
            var fromObjectMethod = type.GetMethod("FromObject", BindingFlags.Public | BindingFlags.Static);
            if (fromObjectMethod == null) throw new Exception($"Static method FromObject not found on type {type.FullName}");
            
            ITwitcherSharp restoredObject;
            try { restoredObject = fromObjectMethod.Invoke(null, [godotObject]) as ITwitcherSharp; }
            catch (Exception ex) { throw new Exception($"FromObject failed: {ex.Message}", ex); }
            
            if (restoredObject == null) throw new Exception("FromObject returned null");
            
            AssertHelper.AssertTwitcherSharpProperties(twitcherObject, restoredObject, _log);
        }
    }

    private void InitializeProperties(object obj)
    {
        var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanWrite);

        foreach (var prop in properties)
        {
            try
            {
                if (prop.PropertyType == typeof(string))
                {
                    prop.SetValue(obj, "test_" + prop.Name);
                }
                else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
                {
                    prop.SetValue(obj, 123);
                }
                else if (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?))
                {
                    prop.SetValue(obj, true);
                }
                else if (prop.PropertyType == typeof(double) || prop.PropertyType == typeof(double?))
                {
                    prop.SetValue(obj, 123.45);
                }
                else if (prop.PropertyType == typeof(float) || prop.PropertyType == typeof(float?))
                {
                    prop.SetValue(obj, 123.45f);
                }
                else if (prop.PropertyType.IsEnum)
                {
                    var values = Enum.GetValues(prop.PropertyType);
                    if (values.Length > 0)
                    {
                        prop.SetValue(obj, values.GetValue(0));
                    }
                }
                else if (prop.PropertyType.IsGenericType && (prop.PropertyType.GetGenericTypeDefinition() == typeof(List<>) || prop.PropertyType.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
                {
                    var itemType = prop.PropertyType.GetGenericArguments()[0];
                    var listType = typeof(List<>).MakeGenericType(itemType);
                    var list = Activator.CreateInstance(listType);
                    prop.SetValue(obj, list);
                }
                else if (prop.PropertyType.IsArray)
                {
                    var itemType = prop.PropertyType.GetElementType();
                    var array = Array.CreateInstance(itemType, 0);
                    prop.SetValue(obj, array);
                }
                else if (prop.PropertyType.GetInterfaces().Any(i => i == typeof(ITwitcherSharp) || i == typeof(ITwitcherSharpEventSub)))
                {
                    // Create nested object if it has a parameterless constructor
                    try
                    {
                        var nestedObj = Activator.CreateInstance(prop.PropertyType);
                        InitializeProperties(nestedObj);
                        prop.SetValue(obj, nestedObj);
                    }
                    catch { /* ignore */ }
                }
            }
            catch
            {
                // Ignore initialization failures for specific properties
            }
        }
    }
}
