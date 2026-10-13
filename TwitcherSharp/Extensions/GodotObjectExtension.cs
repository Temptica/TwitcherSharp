using Godot;
using TwitcherSharp.Chat;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Reward;

namespace TwitcherSharp.Extensions;

public static class GodotObjectExtension
{
    extension(GodotObject obj)
    {
        internal static StringName RedeemedSignal => "redeemed";
        internal static StringName CommandReceived => "command_received";
        internal static StringName Cooldown => "cooldown";
        internal static StringName ReceivedInvalidCommand => "received_invalid_command";
        internal static StringName InvalidPermission => "invalid_permission";

        /// <summary>
        /// A Type-safe way to listen to Twitcher redeems.
        /// Best way to do this is by using <see cref="Node.GetNode(NodePath)"/> to get the Twitcher node and listen to the event.<br/>
        /// Example usage:
        /// <code>
        /// var redeem = GetNode("RedeemListener");
        /// redeem.ConnectRedeemed(MethodToExecute);
        /// </code>
        /// <param name="action">The action that should be executed when the redeem signal has been emitted</param>
        /// </summary>
        public void ConnectRedeemed(Action<TwitchRedemption> action)
        {
            obj.Connect(GodotObject.RedeemedSignal, Callable.FromTwitcherSharp(action));
        }

        /// <summary>
        /// A Type-safe way to listen to Twitcher redeems.
        /// Best way to do this is by using <see cref="Node.GetNode(NodePath)"/> to get the Twitcher node and listen to the event.<br/>
        /// Example usage:
        /// <code>
        /// var redeem = GetNode("RedeemListener");
        /// redeem.ConnectRedeemed(MethodToExecute);
        /// </code>
        /// <param name="action">The action that should be executed when the redeem signal has been emitted</param>
        /// </summary>
        public void ConnectRedeemed(Action action)
        {
            obj.Connect(GodotObject.RedeemedSignal, Callable.From<GodotObject>(_ => action.Invoke()));
        }

        public void ConnectCommandReceived(Action<string, TwitchCommandInfo, string[]> action)
        {
            obj.Connect(GodotObject.CommandReceived, Callable.FromTwitcherSharp(action));
        }

        public void ConnectCommandReceived(Action action)
        {
            obj.Connect(GodotObject.CommandReceived,
                Callable.From<string, GodotObject, string[]>((_, _, _) => action.Invoke()));
        }

        public void ConnectReceivedInvalidCommand(Action<string, TwitchCommandInfo, string[]> action)
        {
            obj.Connect(GodotObject.ReceivedInvalidCommand, Callable.FromTwitcherSharp(action));
        }

        public void ConnectReceivedInvalidCommand(Action action)
        {
            obj.Connect(GodotObject.ReceivedInvalidCommand,
                Callable.From<string, GodotObject, string[]>((_, _, _) => action.Invoke()));
        }

        //string fromUsername, TwitchCommandInfo info, string[] args,
        // float cooldownRemainingInS
        public void ConnectCooldown(Action<string, TwitchCommandInfo, string[], float> action)
        {
            obj.Connect(GodotObject.Cooldown, Callable.FromTwitcherSharp(action));
        }

        public void ConnectCooldown(Action action)
        {
            obj.Connect(GodotObject.Cooldown,
                Callable.From<string, GodotObject, string[], float>((_, _, _, _) => action.Invoke()));
        }

        internal List<T> GetList<T>(string propertyName) where T : RefCounted, ITwitcherSharp<T>
        {
            using var value = obj.Get(propertyName);
            return MapArray<T>(value);
        }

        internal T[] GetArray<T>(string propertyName) where T : RefCounted, ITwitcherSharp<T>
        {
            using var value = obj.Get(propertyName);
            return MapArray<T>(value).ToArray();
        }

        internal T? Get<T>(string propertyName) where T : RefCounted, ITwitcherSharp<T>
        {
            using var value = obj.Get(propertyName);
            return Map<T>(value);
        }

        /// <summary>
        /// Fills the array a GDScript property holds with the given items, disposing each of them.
        /// Assigning a new untyped Array to a typed property such as <c>Array[Badge]</c> fails silently, so the
        /// items go into the (typed) array the property already holds.
        /// </summary>
        internal void SetArray(string propertyName, IEnumerable<Variant> items)
        {
            using var property = obj.Get(propertyName);
            using var array = property.AsGodotArray();
            array.Clear();
            foreach (var item in items)
            {
                using (item) array.Add(item);
            }
        }

        /// <inheritdoc cref="SetArray(GodotObject, string, IEnumerable{Variant})"/>
        internal void SetArray<T>(string propertyName, IEnumerable<T>? items) where T : ITwitcherSharp
        {
            obj.SetArray(propertyName, (items ?? []).Select(item => ToVariant(item)));
        }
    }

    /// <summary>
    /// Maps the twitcher object a Variant holds, disposing the wrapper it takes for that.
    /// </summary>
    internal static T? Map<T>(Variant value) where T : RefCounted, ITwitcherSharp<T>
    {
        if (value.VariantType != Variant.Type.Object) return null;
        var gdObject = value.AsGodotObject();
        try
        {
            return T.FromObject(gdObject);
        }
        finally
        {
            gdObject.Release();
        }
    }

    /// <summary>
    /// Maps the twitcher objects of an Array Variant, disposing every entry and wrapper it takes for that.
    /// </summary>
    internal static List<T> MapArray<T>(Variant value) where T : RefCounted, ITwitcherSharp<T>
    {
        if (value.VariantType != Variant.Type.Array) return [];
        using var array = value.AsGodotArray();
        var result = new List<T>(array.Count);
        foreach (var item in array)
        {
            using (item)
            {
                if (Map<T>(item) is { } mapped) result.Add(mapped);
            }
        }

        return result;
    }

    /// <summary>
    /// A Variant holding the twitcher object of <paramref name="item"/> (or null), to pass it to twitcher; the caller
    /// disposes it.
    /// </summary>
    internal static Variant ToVariant(ITwitcherSharp? item)
    {
        if (item is null) return default;
        var gdObject = item.ToGodotObject();
        var variant = Variant.CreateFrom(gdObject);
        gdObject.Release();
        return variant;
    }

    // The `params Variant[]` members below are kept as classic `this`-parameter extension methods rather than
    // extension-block members: the Roslyn compiler emits spurious CS8620 nullability warnings for every argument
    // passed to a generic extension-block method with a `params` array parameter under <Nullable>enable</Nullable>
    // (confirmed as a compiler quirk, not a real nullability issue).

    public static T Call<T>(this GodotObject obj, string method, params Variant[] args) where T : RefCounted, ITwitcherSharp<T>
    {
        using var result = obj.Call(method, args);
        return Map<T>(result)!;
    }

    private static readonly StringName Completed = "completed";

    /// <summary>
    /// Calls a GDScript function that may await and returns its result, waiting for it when it is a coroutine.
    /// </summary>
    /// <remarks>
    /// A GDScript function that awaits returns a function state at its first await when called from C#; its value
    /// arrives through the state's <c>completed</c> signal. A function that returns without awaiting returns its value
    /// directly. Both end up as the result here.
    /// <para>
    /// The caller owns the returned <see cref="Variant"/> and disposes it. The function state and any wrapper made here
    /// are released before returning: a leftover handle to a GDScript RefCounted is released by Godot's disposables
    /// tracker at shutdown, after GDScript freed the object, which crashes the process on exit.
    /// </para>
    /// </remarks>
    public static Task<Variant> CallAsync(this GodotObject obj, string method, params Variant[] args) =>
        AwaitResult(obj.Call(method, args));

    /// <summary>
    /// Calls a function of the twitcher object the Variant holds, see <see cref="CallAsync(GodotObject, string, Variant[])"/>.
    /// The wrapper of the object is only taken for the call itself, not across the await.
    /// </summary>
    internal static Task<Variant> CallAsync(this Variant data, string method, params Variant[] args)
    {
        var obj = data.AsGodotObject();
        var result = obj.Call(method, args);
        obj.Release();
        return AwaitResult(result);
    }

    /// <inheritdoc cref="CallAsync{T}(GodotObject, string, Variant[])"/>
    internal static async Task<T?> CallAsync<T>(this Variant data, string method, params Variant[] args)
        where T : RefCounted, ITwitcherSharp<T>
    {
        using var result = await data.CallAsync(method, args);
        return Map<T>(result);
    }

    /// <inheritdoc cref="CallDictionaryKeyAsync{T, TVariant}(GodotObject, string, Variant[])"/>
    internal static async Task<Godot.Collections.Dictionary<T, TVariant>> CallDictionaryKeyAsync<[MustBeVariant] T,
        [MustBeVariant] TVariant>(this Variant data, string method, params Variant[] args)
        where T : RefCounted, ITwitcherSharp<T>
    {
        using var result = await data.CallAsync(method, args);
        return MapKeys<T, TVariant>(result);
    }

    /// <inheritdoc cref="CallListAsync{T}(GodotObject, string, Variant[])"/>
    internal static async Task<List<T>> CallListAsync<T>(this Variant data, string method, params Variant[] args)
        where T : RefCounted, ITwitcherSharp<T>
    {
        using var result = await data.CallAsync(method, args);
        return MapArray<T>(result);
    }

    /// <summary>
    /// The result of a call: the value itself, or what a function state delivers through <c>completed</c>.
    /// </summary>
    private static async Task<Variant> AwaitResult(Variant result)
    {
        if (result.VariantType != Variant.Type.Object) return result;

        using (result)
        {
            var state = result.AsGodotObject();
            if (state is null || !GodotObject.IsInstanceValid(state) || !state.HasSignal(Completed))
            {
                // A plain object result, which may be a node someone else holds the wrapper of.
                var value = Variant.CreateFrom(state);
                state.Release();
                return value;
            }

            using var _ = state;

            // The state is its own signal target, so nothing but the state is held across the await.
            var completed = await state.ToSignal(state, Completed);
            for (var i = 1; i < completed.Length; i++)
            {
                completed[i].Dispose();
            }

            return completed.Length > 0 ? completed[0] : default;
        }
    }

    public static async Task<T?> CallAsync<T>(this GodotObject obj, string method, params Variant[] args) where T : RefCounted, ITwitcherSharp<T>
    {
        using var result = await obj.CallAsync(method, args);
        return Map<T>(result);
    }

    /// <summary>
    /// Calls a godot method and returns a typed dictionary. Expects the TwitcherSharp object to be the key
    /// </summary>
    /// <param name="obj">the object to call the method on</param>
    /// <param name="method">method to call (snake-cased)</param>
    /// <param name="args">parameters for the method to call</param>
    /// <typeparam name="T">An implementation of <see cref="ITwitcherSharp{T}"/></typeparam>
    /// <typeparam name="TVariant">A <see cref="Variant"/></typeparam>
    /// <returns>Returns a <see cref="Godot.Collections.Dictionary{Tkey, TValue}"/> with the result data</returns>
    public static async Task<Godot.Collections.Dictionary<T, TVariant>> CallDictionaryKeyAsync<[MustBeVariant] T,
        [MustBeVariant] TVariant>(this GodotObject obj, string method, params Variant[] args)
        where T : RefCounted, ITwitcherSharp<T>
    {
        using var result = await obj.CallAsync(method, args);
        return MapKeys<T, TVariant>(result);
    }

    /// <summary>
    /// Calls a godot method and returns a typed dictionary. Expects the TwitcherSharp object to be the value
    /// </summary>
    /// <param name="obj">the object to call the method on</param>
    /// <param name="method">method to call (snake-cased)</param>
    /// <param name="args">parameters for the method to call</param>
    /// <typeparam name="T">A <see cref="Variant"/></typeparam>
    /// <typeparam name="TVariant">An implementation of <see cref="ITwitcherSharp{TVariant}"/></typeparam>
    /// <returns>Returns a <see cref="Godot.Collections.Dictionary{Tkey, TValue}"/> with the result data</returns>
    public static async Task<Godot.Collections.Dictionary<TVariant, T>> CallDictionaryValueAsync<[MustBeVariant] TVariant,
        [MustBeVariant] T>(this GodotObject obj, string method, params Variant[] args)
        where T : RefCounted, ITwitcherSharp<T>
    {
        using var result = await obj.CallAsync(method, args);
        return MapValues<TVariant, T>(result);
    }

    /// <summary>
    /// Calls a godot method and returns a typed dictionary.
    /// </summary>
    /// <param name="obj">the object to call the method on</param>
    /// <param name="method">method to call (snake-cased)</param>
    /// <param name="args">parameters for the method to call</param>
    /// <typeparam name="T">An implementation of <see cref="ITwitcherSharp{T}"/></typeparam>
    /// <typeparam name="TVariant">A <see cref="Variant"/></typeparam>
    /// <returns>Returns a <see cref="Godot.Collections.Dictionary{Tkey, TValue}"/> with the result data</returns>
    public static Godot.Collections.Dictionary<T, TVariant> CallDictionaryKey<[MustBeVariant] T, [MustBeVariant] TVariant>(
        this GodotObject obj, string method, params Variant[] args)
        where T : RefCounted, ITwitcherSharp<T>
    {
        using var result = obj.Call(method, args);
        return MapKeys<T, TVariant>(result);
    }

    /// <summary>
    /// Calls a godot method and returns a typed dictionary. Expects the TwitcherSharp object to be the value
    /// </summary>
    /// <param name="obj">the object to call the method on</param>
    /// <param name="method">method to call (snake-cased)</param>
    /// <param name="args">parameters for the method to call</param>
    /// <typeparam name="T">A <see cref="Variant"/></typeparam>
    /// <typeparam name="TVariant">An implementation of <see cref="ITwitcherSharp{TVariant}"/></typeparam>
    /// <returns>Returns a <see cref="Godot.Collections.Dictionary{Tkey, TValue}"/> with the result data</returns>
    public static Godot.Collections.Dictionary<TVariant, T> CallDictionaryValue<[MustBeVariant] TVariant,
        [MustBeVariant] T>(this GodotObject obj, string method, params Variant[] args)
        where T : RefCounted, ITwitcherSharp<T>
    {
        using var result = obj.Call(method, args);
        return MapValues<TVariant, T>(result);
    }

    /// <summary>
    /// Calls a godot method and returns a list of typed objects.
    /// </summary>
    /// <param name="obj">the object to call the method on</param>
    /// <param name="method">method to call (snake-cased)</param>
    /// <param name="args">parameters for the method to call</param>
    /// <typeparam name="T">An implementation of <see cref="ITwitcherSharp{T}"/></typeparam>
    /// <returns>Returns a <see cref="List{T}"/> with the result data</returns>
    public static List<T> CallList<[MustBeVariant] T>(this GodotObject obj, string method, params Variant[] args)
        where T : RefCounted, ITwitcherSharp<T>
    {
        using var result = obj.Call(method, args);
        return MapArray<T>(result);
    }

    /// <summary>
    /// Calls a godot method and returns a list of typed objects.
    /// </summary>
    /// <param name="obj">the object to call the method on</param>
    /// <param name="method">method to call (snake-cased)</param>
    /// <param name="args">parameters for the method to call</param>
    /// <typeparam name="T">An implementation of <see cref="ITwitcherSharp{T}"/></typeparam>
    /// <returns>Returns a <see cref="List{T}"/> with the result data</returns>
    public static async Task<List<T>> CallListAsync<T>(this GodotObject obj, string method, params Variant[] args)
        where T : RefCounted, ITwitcherSharp<T>
    {
        using var result = await obj.CallAsync(method, args);
        return MapArray<T>(result);
    }

    /// <summary>
    /// Maps the twitcher object keys of a Dictionary Variant, disposing every entry and wrapper it takes for that.
    /// </summary>
    private static Godot.Collections.Dictionary<T, TVariant> MapKeys<[MustBeVariant] T, [MustBeVariant] TVariant>(
        Variant value) where T : RefCounted, ITwitcherSharp<T>
    {
        var dictionary = new Godot.Collections.Dictionary<T, TVariant>();
        if (value.VariantType != Variant.Type.Dictionary) return dictionary;
        using var source = value.AsGodotDictionary();
        foreach (var (key, entry) in source)
        {
            using (key)
            using (entry)
            {
                if (Map<T>(key) is { } mapped) dictionary.Add(mapped, entry.As<TVariant>());
            }
        }

        return dictionary;
    }

    /// <summary>
    /// Maps the twitcher object values of a Dictionary Variant, disposing every entry and wrapper it takes for that.
    /// </summary>
    private static Godot.Collections.Dictionary<TVariant, T> MapValues<[MustBeVariant] TVariant, [MustBeVariant] T>(
        Variant value) where T : RefCounted, ITwitcherSharp<T>
    {
        var dictionary = new Godot.Collections.Dictionary<TVariant, T>();
        if (value.VariantType != Variant.Type.Dictionary) return dictionary;
        using var source = value.AsGodotDictionary();
        foreach (var (key, entry) in source)
        {
            using (key)
            using (entry)
            {
                if (Map<T>(entry) is { } mapped) dictionary.Add(key.As<TVariant>(), mapped);
            }
        }

        return dictionary;
    }
}
