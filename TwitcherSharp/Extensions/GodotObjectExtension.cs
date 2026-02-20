using Godot;
using Godot.Collections;
using TwitcherSharp.Chat;
using TwitcherSharp.Interfaces;
using TwitcherSharp.Reward;

namespace TwitcherSharp.Extensions;

public static class GodotObjectExtension
{
    extension(GodotObject obj)
    {
        private static StringName RedeemedSignal => "redeemed";
        private static StringName CommandReceived => "command_received";
        private static StringName Cooldown => "cooldown";
        private static StringName ReceivedInvalidCommand => "received_invalid_command";

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
            obj.Connect(GodotObject.CommandReceived, Callable.From<string, GodotObject, string[]>((_,_,_) => action.Invoke()));
        }
        
        public void ConnectReceivedInvalidCommand(Action<string, TwitchCommandInfo, string[]> action)
        {
            obj.Connect(GodotObject.ReceivedInvalidCommand, Callable.FromTwitcherSharp(action));
        }

        public void ConnectReceivedInvalidCommand(Action action)
        {
            obj.Connect(GodotObject.ReceivedInvalidCommand, Callable.From<string, GodotObject, string[]>((_,_,_) => action.Invoke()));
        }
        
        //string fromUsername, TwitchCommandInfo info, string[] args,
        // float cooldownRemainingInS
        public void ConnectCooldown(Action<string, TwitchCommandInfo, string[], float> action)
        {
            obj.Connect(GodotObject.Cooldown, Callable.FromTwitcherSharp(action));
        }

        public void ConnectCooldown(Action action)
        {
            obj.Connect(GodotObject.Cooldown, Callable.From<string, GodotObject, string[], float>((_,_,_,_) => action.Invoke()));
        }

        public async Task<T> CallAsync<T>(string methode, params Variant[] args) where T : ITwitcherSharp<T>
        {
            var task = obj.Call(methode, args);
            var result = await obj.ToSignal(task.AsGodotObject(), "completed");
            return T.FromObject(result[0].AsGodotObject());
        }
        
        public async Task CallAsync(string methode, params Variant[] args)
        {
            var task = obj.Call(methode, args);
            await obj.ToSignal(task.AsGodotObject(), "completed");
        }
    }
}