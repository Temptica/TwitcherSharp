using System;
using System.Linq;
using Chickensoft.Log;
using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.GoDotTests.Helper;

public static class AssertHelper
{
    public static void AssertTwitcherSharpProperties(ITwitcherSharp twitcherSharpObject,
        ITwitcherSharp twitcherSharpObject2, ILog log)
    {
        foreach (var property in twitcherSharpObject.GetType().GetProperties()
                     .Where(p => p.CanWrite)
                     .Where(p => !p.PropertyType.FullName?.Contains("Array") ?? false)
                     .Where(p => !p.PropertyType.IsClass)
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
                    if ((string)val1 == (string)val2) continue;
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

            if (property.PropertyType.IsClass)
            {
                // AssertTwitcherSharpProperties(property.GetValue(twitcherSharpObject) as ITwitcherSharp,
                //     property2.GetValue(twitcherSharpObject2) as ITwitcherSharp);
                continue;
            }

            if (val1 == val2) continue;

            throw new Exception(
                $"property {property.Name} values do not match for {twitcherSharpObject.GetType().Name}. Expecting {val1} but got {val2}");
        }
    }
}