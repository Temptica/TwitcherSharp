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

        public T Call<T>(string method, params Variant[] args) where T : RefCounted, ITwitcherSharp<T>
        {
            return T.FromObject(obj.Call(method, args).AsGodotObject())!;
        }

        public async Task<T> CallAsync<T>(string method, params Variant[] args) where T : RefCounted, ITwitcherSharp<T>
        {
            var task = obj.Call(method, args).AsGodotObject();

            if (task.HasSignal("completed"))
            {
                var result = await obj.ToSignal(task, "completed");
                return T.FromObject(result[0].AsGodotObject())!;
            }

            return T.FromObject(task)!;
        }

        public async Task<Variant> CallAsync(string methode, params Variant[] args)
        {
            var task = obj.Call(methode, args);
            if (task.AsGodotObject().HasSignal("completed"))
            {
                return (await obj.ToSignal(task.AsGodotObject(), "completed"))[0];
            }

            return task;
        }

        /// <summary>
        /// Calls a godot method and returns a typed dictionary. Expects the TwitcherSharp object to be the key
        /// </summary>
        /// <param name="method">method to call (snake-cased)</param>
        /// <param name="args">parameters for the method to call</param>
        /// <typeparam name="T">An implementation of <see cref="ITwitcherSharp{T}"/></typeparam>
        /// <typeparam name="TVariant">A <see cref="Variant"/></typeparam>
        /// <returns>Returns a <see cref="Godot.Collections.Dictionary{Tkey, TValue}"/> with the result data</returns>
        public async Task<Godot.Collections.Dictionary<T, TVariant>> CallDictionaryKeyAsync<[MustBeVariant] T,
            [MustBeVariant] TVariant>(string method, params Variant[] args)
            where T : RefCounted, ITwitcherSharp<T>
        {
            var dictionary = new Godot.Collections.Dictionary<T, TVariant>();
            var result = await obj.CallAsync(method, args);
            var resultDictionary = result.AsGodotDictionary<GodotObject, TVariant>()
                .Select(x => (T.FromObject(x.Key)!, x.Value));

            foreach (var (key, value) in resultDictionary)
            {
                dictionary.Add(key, value);
            }

            return dictionary;
        }

        /// <summary>
        /// Calls a godot method and returns a typed dictionary. Expects the TwitcherSharp object to be the value
        /// </summary>
        /// <param name="method">method to call (snake-cased)</param>
        /// <param name="args">parameters for the method to call</param>
        /// <typeparam name="T">A <see cref="Variant"/></typeparam>
        /// <typeparam name="TVariant">An implementation of <see cref="ITwitcherSharp{TVariant}"/></typeparam>
        /// <returns>Returns a <see cref="Godot.Collections.Dictionary{Tkey, TValue}"/> with the result data</returns>
        public async Task<Godot.Collections.Dictionary<TVariant, T>> CallDictionaryValueAsync<[MustBeVariant] TVariant,
            [MustBeVariant] T>(string method, params Variant[] args)
            where T : RefCounted, ITwitcherSharp<T>
        {
            var dictionary = new Godot.Collections.Dictionary<TVariant, T>();
            var result = await obj.CallAsync(method, args);
            var resultDictionary = result.AsGodotDictionary<TVariant, GodotObject>()
                .Select(x => (x.Key, T.FromObject(x.Value)!));

            foreach (var (key, value) in resultDictionary)
            {
                dictionary.Add(key, value);
            }

            return dictionary;
        }

        /// <summary>
        /// Calls a godot method and returns a typed dictionary.
        /// </summary>
        /// <param name="method">method to call (snake-cased)</param>
        /// <param name="args">parameters for the method to call</param>
        /// <typeparam name="T">An implementation of <see cref="ITwitcherSharp{T}"/></typeparam>
        /// <typeparam name="TVariant">A <see cref="Variant"/></typeparam>
        /// <returns>Returns a <see cref="Godot.Collections.Dictionary{Tkey, TValue}"/> with the result data</returns>
        public Godot.Collections.Dictionary<T, TVariant> CallDictionaryKey<[MustBeVariant] T, [MustBeVariant] TVariant>(
            string method, params Variant[] args)
            where T : RefCounted, ITwitcherSharp<T>
        {
            var dictionary = new Godot.Collections.Dictionary<T, TVariant>();
            var result = obj.Call(method, args);
            var resultDictionary = result.AsGodotDictionary<GodotObject, TVariant>()
                .Select(x => (T.FromObject(x.Key)!, x.Value));

            foreach (var (key, value) in resultDictionary)
            {
                dictionary.Add(key, value);
            }

            return dictionary;
        }

        /// <summary>
        /// Calls a godot method and returns a typed dictionary. Expects the TwitcherSharp object to be the value
        /// </summary>
        /// <param name="method">method to call (snake-cased)</param>
        /// <param name="args">parameters for the method to call</param>
        /// <typeparam name="T">A <see cref="Variant"/></typeparam>
        /// <typeparam name="TVariant">An implementation of <see cref="ITwitcherSharp{TVariant}"/></typeparam>
        /// <returns>Returns a <see cref="Godot.Collections.Dictionary{Tkey, TValue}"/> with the result data</returns>
        public Godot.Collections.Dictionary<TVariant, T> CallDictionaryValue<[MustBeVariant] TVariant,
            [MustBeVariant] T>(string method, params Variant[] args)
            where T : RefCounted, ITwitcherSharp<T>
        {
            var dictionary = new Godot.Collections.Dictionary<TVariant, T>();
            var result = obj.Call(method, args);
            var resultDictionary = result.AsGodotDictionary<TVariant, GodotObject>()
                .Select(x => (x.Key, T.FromObject(x.Value)!));

            foreach (var (key, value) in resultDictionary)
            {
                dictionary.Add(key, value);
            }

            return dictionary;
        }

        /// <summary>
        /// Calls a godot method and returns a list of typed objects.
        /// </summary>
        /// <param name="method">method to call (snake-cased)</param>
        /// <param name="args">parameters for the method to call</param>
        /// <typeparam name="T">An implementation of <see cref="ITwitcherSharp{T}"/></typeparam>
        /// <returns>Returns a <see cref="List{T}"/> with the result data</returns>
        public List<T> CallList<[MustBeVariant] T>(string method, params Variant[] args)
            where T : RefCounted, ITwitcherSharp<T>
        {
            var result = obj.Call(method, args);
            return result.AsGodotArray<GodotObject>()
                .Select(T.FromObject)
                .OfType<T>()
                .ToList();
        }

        /// <summary>
        /// Calls a godot method and returns a list of typed objects.
        /// </summary>
        /// <param name="method">method to call (snake-cased)</param>
        /// <param name="args">parameters for the method to call</param>
        /// <typeparam name="T">An implementation of <see cref="ITwitcherSharp{T}"/></typeparam>
        /// <returns>Returns a <see cref="List{T}"/> with the result data</returns>
        public async Task<List<T>> CallListAsync<T>(string method, params Variant[] args)
            where T : RefCounted, ITwitcherSharp<T>
        {
            var result = await obj.CallAsync(method, args);
            return result.AsGodotArray<GodotObject>()
                .Select(T.FromObject)
                .OfType<T>()
                .ToList();
        }

        internal List<T> GetList<T>(string propertyName) where T : RefCounted, ITwitcherSharp<T>
        {
            return obj.Get(propertyName).AsGodotObjectArray<GodotObject>().Select(T.FromObject).OfType<T>().ToList();
        }

        internal T[] GetArray<T>(string propertyName) where T : RefCounted, ITwitcherSharp<T>
        {
            return obj.Get(propertyName).AsGodotObjectArray<GodotObject>().Select(T.FromObject).OfType<T>().ToArray();
        }

        internal T? Get<T>(string propertyName) where T : RefCounted, ITwitcherSharp<T>
        {
            return T.FromObject(obj.Get(propertyName).AsGodotObject());
        }
    }
}