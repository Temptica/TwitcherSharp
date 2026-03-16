using Godot;
using TwitcherSharp.Chat;
using TwitcherSharp.Reward;

namespace TwitcherSharp.Extensions;

public static class NodeExtension
{
    extension(Node node)
    {
        public TwitchCommand GetTwitchCommandNode(NodePath path)
        {
            var commandNode = node.GetNode<GodotObject>(path);
            return commandNode == null ? null : TwitchCommand.FromObject(commandNode);
        }

        public TwitchCommand GetTwitchCommandNodeOrNull(NodePath path)
        {
            var commandNode = node.GetNodeOrNull<GodotObject>(path);
            return commandNode == null ? null : TwitchCommand.FromObject(commandNode);
        }

        public TwitchRedeemListener GetTwitchRedeemListenerNode(NodePath path)
        {
            var rewardNode = node.GetNode<GodotObject>(path);
            return rewardNode == null ? null : TwitchRedeemListener.FromObject(rewardNode);
        }

        public TwitchRedeemListener GetTwitchRedeemListenerNodeOrNull(NodePath path)
        {
            var rewardNode = node.GetNodeOrNull<GodotObject>(path);
            return rewardNode == null ? null : TwitchRedeemListener.FromObject(rewardNode);
        }
    }
}