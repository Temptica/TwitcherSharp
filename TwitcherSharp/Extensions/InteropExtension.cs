using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Extensions;

/// <summary>
/// Reads and writes twitcher objects without leaving Godot handles behind.
/// </summary>
/// <remarks>
/// Every <see cref="Variant"/> and every managed wrapper of a GDScript RefCounted that C# creates (from Get, Call, New
/// or AsGodotObject) has to be disposed: what is left over is released by Godot's disposables tracker at shutdown,
/// after GDScript freed the object. Godot hands out one managed wrapper per object, so disposing a wrapper disposes it
/// for every C# holder. Hence the conventions of TwitcherSharp:
/// <list type="bullet">
/// <item>A mapped twitcher object keeps its data as a <see cref="Variant"/>, never as a wrapper, and takes a
/// short-lived wrapper per access. Disposing the mapped object releases the Variant.</item>
/// <item><c>FromObject</c> does not take over the wrapper it gets; the caller still owns (and disposes) it.</item>
/// <item><c>ToGodotObject</c> of a data object returns a new twitcher object the caller owns: dispose the wrapper once
/// twitcher holds the object. Singletons return their linked node instead, which the caller must not dispose.</item>
/// </list>
/// </remarks>
internal static class InteropExtension
{
    /// <summary>
    /// Disposes a wrapper made here when it wraps a RefCounted. Wrappers of nodes and other objects stay: they hold
    /// no reference, and singletons keep the wrapper of their node, which Godot shares with every other holder.
    /// </summary>
    internal static void Release(this GodotObject? obj)
    {
        if (obj is RefCounted) obj.Dispose();
    }

    extension(GodotObject obj)
    {
        /// <summary>
        /// Reads a property and disposes the Variant it came in.
        /// </summary>
        internal T Read<T>(string propertyName, Func<Variant, T> read)
        {
            using var value = obj.Get(propertyName);
            return read(value);
        }

        /// <summary>
        /// Sets a property and disposes the Variant afterwards, also one created by an implicit conversion.
        /// </summary>
        internal void SetValue(string propertyName, Variant value)
        {
            using (value) obj.Set(propertyName, value);
        }

        /// <summary>
        /// Sets a property to the twitcher object of <paramref name="value"/> (or null), disposing what it creates.
        /// </summary>
        internal void SetObject<T>(string propertyName, T? value) where T : ITwitcherSharp
        {
            if (value is null)
            {
                obj.Set(propertyName, default);
                return;
            }

            var gdObject = value.ToGodotObject();
            using var variant = Variant.CreateFrom(gdObject);
            obj.Set(propertyName, variant);
            gdObject.Release();
        }
    }

    extension(Variant data)
    {
        /// <summary>
        /// Whether the Variant holds nothing (a mapped object made in C# instead of read from twitcher).
        /// </summary>
        internal bool IsNil => data.VariantType == Variant.Type.Nil;

        /// <summary>
        /// Runs <paramref name="access"/> with a short-lived wrapper of the object the Variant holds.
        /// </summary>
        internal T? With<T>(Func<GodotObject, T> access)
        {
            if (data.VariantType != Variant.Type.Object) return default;
            var obj = data.AsGodotObject();
            try
            {
                return obj is null ? default : access(obj);
            }
            finally
            {
                obj.Release();
            }
        }

        /// <inheritdoc cref="Read{T}(GodotObject, string, Func{Variant, T})"/>
        internal T? Read<T>(string propertyName, Func<Variant, T> read) =>
            data.With(obj => obj.Read(propertyName, read));

        /// <summary>
        /// Maps the twitcher object a property of the held object holds.
        /// </summary>
        internal T? Get<T>(string propertyName) where T : RefCounted, ITwitcherSharp<T> =>
            data.With(obj => obj.Get<T>(propertyName));

        /// <summary>
        /// Maps the twitcher objects an array property of the held object holds.
        /// </summary>
        internal T[]? GetArray<T>(string propertyName) where T : RefCounted, ITwitcherSharp<T> =>
            data.With(obj => obj.GetArray<T>(propertyName));

        /// <inheritdoc cref="GetArray{T}(Variant, string)"/>
        internal List<T>? GetList<T>(string propertyName) where T : RefCounted, ITwitcherSharp<T> =>
            data.With(obj => obj.GetList<T>(propertyName));
    }

    // The `params Variant[]` members are classic extension methods: extension-block members with a params array get
    // spurious nullability warnings (see GodotObjectExtension).

    /// <summary>
    /// Calls a function that does not await and disposes its result.
    /// </summary>
    internal static void Invoke(this GodotObject obj, string method, params Variant[] args)
    {
        using var result = obj.Call(method, args);
    }

    /// <summary>
    /// Calls a function that does not await, reads its result and disposes it.
    /// </summary>
    internal static T Invoke<T>(this GodotObject obj, string method, Func<Variant, T> read, params Variant[] args)
    {
        using var result = obj.Call(method, args);
        return read(result);
    }

    /// <summary>
    /// Calls a function that may await, waits for it and disposes its result.
    /// </summary>
    internal static async Task InvokeAsync(this GodotObject obj, string method, params Variant[] args)
    {
        using var result = await obj.CallAsync(method, args);
    }

    /// <summary>
    /// Calls a function that may await, waits for it, reads its result and disposes it.
    /// </summary>
    internal static async Task<T> InvokeAsync<T>(this GodotObject obj, string method, Func<Variant, T> read,
        params Variant[] args)
    {
        using var result = await obj.CallAsync(method, args);
        return read(result);
    }

    /// <inheritdoc cref="Invoke(GodotObject, string, Variant[])"/>
    internal static void Invoke(this Variant data, string method, params Variant[] args) =>
        data.With(obj =>
        {
            obj.Invoke(method, args);
            return true;
        });

    /// <inheritdoc cref="Invoke{T}(GodotObject, string, Func{Variant, T}, Variant[])"/>
    internal static T? Invoke<T>(this Variant data, string method, Func<Variant, T> read, params Variant[] args) =>
        data.With(obj => obj.Invoke(method, read, args));

    /// <summary>
    /// Creates an object of a twitcher script. The caller owns the returned wrapper.
    /// </summary>
    internal static GodotObject NewObject(string scriptPath, params Variant[] args)
    {
        using var script = GD.Load<GDScript>(scriptPath);
        using var instance = script.New(args);
        return instance.AsGodotObject();
    }

    /// <summary>
    /// Creates an object of an inner class of a twitcher script, such as <c>TwitchChatMessage.Badge</c>.
    /// The caller owns the returned wrapper.
    /// </summary>
    internal static GodotObject NewInner(string scriptPath, string className, params Variant[] args)
    {
        using var script = GD.Load<GDScript>(scriptPath);
        using var innerClass = script.Get(className);
        using var innerScript = innerClass.AsGodotObject();
        using var instance = innerScript.Call("new", args);
        return instance.AsGodotObject();
    }
}
