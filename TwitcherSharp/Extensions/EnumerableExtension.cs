using System.Collections;
using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Extensions;

public static class EnumerableExtension
{
    /// <summary>
    /// Parses an IEnumerable of TwitcherSharp objects into a Godot.Collections.Array of GodotObject.
    ///
    /// <seealso cref="ToVariantArray{T}">Parsing an IEnumerable of structs to variants</seealso>
    /// </summary>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Godot.Collections.Array<GodotObject> ToGodotArray<T>(this IEnumerable<T> enumerable) where T : RefCounted, ITwitcherSharp<T>
    {
        return new Godot.Collections.Array<GodotObject>(enumerable.Select(x => x.ToGodotObject()).ToArray());
    }
    
    /// <summary>
    /// Parses an IEnumerable of structs into a Godot.Collections.Array of GodotObject.
    /// </summary>
    ///
    /// <seealso cref="ToVariantArray{T}">Parses an IEnumerable of TwitcherSharp objects into a Godot.Collections.Array of GodotObject.</seealso>
    /// <param name="enumerable"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Godot.Collections.Array<T> ToVariantArray<[MustBeVariant]T>(this IEnumerable<T> enumerable)
    {
        return new Godot.Collections.Array<T>(enumerable.ToArray());
    }

    /// <summary>
    /// Builds an Array typed to a GDScript class, like <c>Array[TwitchEmoteDefinition]</c>, for a twitcher function
    /// with a typed array parameter: it receives an untyped Array as an empty one, without an error. GodotSharp can
    /// only type arrays to built-in types, so the typed array comes from Godot's own Array constructor.
    /// </summary>
    /// <param name="enumerable">The TwitcherSharp objects to put into the array</param>
    /// <param name="scriptPath">Path of the GDScript class the array is typed to</param>
    internal static Godot.Collections.Array ToTypedArray<T>(this IEnumerable<T> enumerable, string scriptPath)
        where T : RefCounted, ITwitcherSharp<T>
    {
        // The items first: creating them loads the same script, and Godot shares one wrapper per object, so a script
        // wrapper held across that would be disposed under our feet.
        var items = enumerable.Select(item => GodotObjectExtension.ToVariant(item)).ToList();
        using var script = GD.Load<GDScript>(scriptPath);
        using var nativeBase = new StringName(script.GetInstanceBaseType());
        try
        {
            using var untyped = new Godot.Collections.Array(items);
            using var expression = new Expression();
            expression.Parse("Array(items, type, native_base, script)", ["items", "type", "native_base", "script"]);
            using var inputs = new Godot.Collections.Array
                { untyped, (int)Variant.Type.Object, nativeBase, script };
            using var typed = expression.Execute(inputs);
            return typed.AsGodotArray();
        }
        finally
        {
            items.ForEach(item => item.Dispose());
        }
    }
}