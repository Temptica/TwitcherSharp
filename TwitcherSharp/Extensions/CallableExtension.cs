using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Extensions;

public static class CallableExtension
{
    extension(Callable)
    {
        /// <summary>
        /// Makes it easier to create a <see cref="Callable"/> while assuring type safety on TwitcherSharp objects.<br/>
        /// </summary>
        /// <param name="action">The action to be executed when the <see cref="Callable"/> gets called.</param>
        /// <typeparam name="T">The type of the TwitcherSharp object (must implement ITwitcherSharp).</typeparam>
        /// <returns>A Godot <see cref="Callable"/> that handles the type conversion automatically.</returns>
        public static Callable FromTwitcherSharp<T>(Action<T> action) where T : ITwitcherSharp<T>
        {
            return Callable.From<GodotObject>(data => action.Invoke(T.FromObject(data)));
        }

        /// <summary>
        /// Makes it easier to create a <see cref="Callable"/> while assuring type safety on TwitcherSharp objects.<br/>
        /// Best way to do this is by using <see cref="Node.GetNode{GodotObject}(NodePath)"/> from the scene's tree (usually a direct child).<br/>
        /// Example usage:
        /// <code>
        /// var redeem = GetNode&lt;GodotObject&gt;("RedeemListener");
        /// redeem.ConnectRedeemed(FromTwitcherSharp&lt;RedeemType&gt;(data => MethodToExecute(data)));
        /// </code>
        /// </summary>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Callable FromTwitcherSharp<T>(Action<string, T, string[]> action) where T : ITwitcherSharp<T>
        {
            return Callable.From<string, GodotObject, string[]>((userName, info, args) =>
                action.Invoke(userName, T.FromObject(info), args));
        }

        public static Callable FromTwitcherSharp<T>(Action<string, T, string[], float> action)
            where T : ITwitcherSharp<T>
        {
            return Callable.From<string, GodotObject, string[], float>((userName, info, args, cooldown) =>
                action.Invoke(userName, T.FromObject(info), args, cooldown));
        }
    }
}