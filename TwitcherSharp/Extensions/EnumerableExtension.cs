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
}