using System;
using System.Collections;
using System.Linq;
using Chickensoft.Log;
using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.GoDotTests.Helper;

public static class AssertHelper
{
    private const int MaxRecursionDepth = 10;

    public static void AssertTwitcherSharpProperties(ITwitcherSharp twitcherSharpObject,
        ITwitcherSharp twitcherSharpObject2, ILog log, int depth = 0)
    {
        if (depth > MaxRecursionDepth)
        {
            throw new Exception(
                $"Max recursion depth exceeded while comparing {twitcherSharpObject.GetType().Name} - possible self-referencing type");
        }

        foreach (var property in twitcherSharpObject.GetType().GetProperties()
                     .Where(p => p.CanWrite && p.GetMethod?.IsStatic != true)
                     .Where(p => p.DeclaringType == twitcherSharpObject.GetType())
                )
        {
            log.Print($"Asserting {property.Name} ({property.PropertyType.Name})");
            var property2 = twitcherSharpObject2.GetType().GetProperties().FirstOrDefault(p => p.Name == property.Name);

            if (property2 == null)
            {
                throw new ArgumentException($"Property {property.Name} not found in twitcherSharpObject2");
            }

            var val1 = property.GetValue(twitcherSharpObject);
            var val2 = property2.GetValue(twitcherSharpObject2);
            switch (property.PropertyType.Name)
            {
                case nameof(String):
                    if ((string)val1 == (string)val2 || (val1 == null && (string)val2 == "")) continue;
                    throw new Exception(
                        $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
                case nameof(Int32):
                case "Nullable`1" when property.PropertyType.GetGenericArguments()[0].Name == nameof(Int32):
                    if ((int?)val1 == (int?)val2 || (val1 == null && (int?)val2 == 0)) continue;
                    throw new Exception(
                        $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
                case nameof(Boolean):
                case "Nullable`1" when property.PropertyType.GetGenericArguments()[0].Name == nameof(Boolean):
                    if ((bool?)val1 == (bool?)val2 || (val1 == null && (bool?)val2 == false)) continue;
                    throw new Exception(
                        $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
                case "Nullable`1" when property.PropertyType.GetGenericArguments()[0].Name == nameof(Double):
                case nameof(Double):
                    if ((val1 == null && (double?)val2 == 0) || (double?)val1 == (double?)val2) continue;
                    throw new Exception(
                        $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
                case nameof(DateTime):
                    if ((DateTime?)val1 == (DateTime?)val2) continue;
                    throw new Exception(
                        $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
                case nameof(Color):
                    if ((Color?)val1 == (Color?)val2) continue;
                    throw new Exception(
                        $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
                case nameof(Variant):
                case "Nullable`1" when property.PropertyType.GetGenericArguments()[0].Name == "Variant":
                    continue;

                default: break;
            }

            if (property.PropertyType.IsEnum)
            {
                if ((int)val1 == (int)val2) continue;
                throw new Exception(
                    $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
            }

            if (val1 is ITwitcherSharp nested1)
            {
                if (val2 is not ITwitcherSharp nested2)
                {
                    throw new Exception(
                        $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting an {nested1.GetType().Name} but got {val2 ?? "null"}");
                }

                AssertTwitcherSharpProperties(nested1, nested2, log, depth + 1);
                continue;
            }

            if (val1 is IEnumerable enumerable1 && val1 is not string)
            {
                AssertSequence(property.Name, twitcherSharpObject.GetType().Name, enumerable1,
                    val2 as IEnumerable, log, depth);
                continue;
            }

            if (property.PropertyType.IsClass)
            {
                continue;
            }

            if (val1 == val2) continue;

            throw new Exception(
                $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
        }
    }

    private static void AssertSequence(string propertyName, string ownerTypeName, IEnumerable enumerable1,
        IEnumerable enumerable2, ILog log, int depth)
    {
        var list1 = enumerable1.Cast<object>().ToList();

        if (enumerable2 == null)
        {
            throw new Exception($"property {propertyName} values do not match for {ownerTypeName}. Expecting {list1.Count} elements but got null");
        }

        var list2 = enumerable2.Cast<object>().ToList();

        if (list1.Count != list2.Count)
        {
            throw new Exception(
                $"property {propertyName} array/list length does not match for {ownerTypeName}. Expecting {list1.Count} elements but got {list2.Count}");
        }

        for (var i = 0; i < list1.Count; i++)
        {
            var item1 = list1[i];
            var item2 = list2[i];

            if (item1 is ITwitcherSharp itemNested1)
            {
                if (item2 is not ITwitcherSharp itemNested2)
                {
                    throw new Exception(
                        $"property {propertyName}[{i}] values do not match for {ownerTypeName}. Expecting an {itemNested1.GetType().Name} but got {item2 ?? "null"}");
                }

                AssertTwitcherSharpProperties(itemNested1, itemNested2, log, depth + 1);
                continue;
            }

            if (Equals(item1, item2)) continue;

            throw new Exception(
                $"property {propertyName}[{i}] values do not match for {ownerTypeName}. Expecting {item1} but got {item2}");
        }
    }
}