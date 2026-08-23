using Godot;

namespace TwitcherSharp.Extensions;

public static class RichTextLabelExtension
{
    private const string SpriteFrameEffectScriptPath = "res://addons/twitcher/sprite_frame_effect.gd";

    extension(RichTextLabel label)
    {
        /// <summary>
        /// Creates a new SpriteFrameEffect, installs it on this <see cref="RichTextLabel"/> and prepares
        /// the given message so any [sprite] tags get resolved into animated sprites.<br/>
        /// Requires <see cref="RichTextLabel.BbcodeEnabled"/> to be enabled on the label.
        /// </summary>
        /// <param name="message">The BBCode message to prepare, potentially containing [sprite] tags.</param>
        /// <returns>The prepared message, ready to be assigned to <see cref="RichTextLabel.Text"/>.</returns>
        public string PrepareSpriteFrameMessage(string message)
        {
            var script = GD.Load<GDScript>(SpriteFrameEffectScriptPath);
            var effect = script.New().AsGodotObject();
            label.Call("install_effect", effect);
            return effect.Call("prepare_message", message, label).AsString();
        }
    }
}
