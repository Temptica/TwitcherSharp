using Godot;
using TwitcherSharp.Chat;

namespace TwitcherSharp.Extensions;

public static class NodeExtension
{
    extension(Node node)
    {
        public TwitchCommand GetTwitchCommand(NodePath path)
        {
            var commandNode = node.GetNode<GodotObject>(path);
            return commandNode == null ? null : TwitchCommand.FromObject(commandNode);
        }

        public TwitchCommand GetTwitchCommandOrNull(NodePath path)
        {
            var commandNode = node.GetNodeOrNull<GodotObject>(path);
            return commandNode == null ? null : TwitchCommand.FromObject(commandNode);
        }
    }
}