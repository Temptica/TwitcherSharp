using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using TwitcherSharp.Chat;
using TwitcherSharp.Extensions;

namespace TwitcherSharp.Demo.Scenes;

public partial class PhysicItemsManager : Node3D
{
    public readonly List<Node3D> Items = [];

    public override async void _Ready()
    {
        foreach (var node in GetChildren().OfType<Node3D>())
        {
            Items.Add(node);
        }
        
        await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
        
        TwitchService.Instance.AddCommand(new TwitchCommand
        {
            Command = "items",
            Aliases = ["i"],
            Description = "List all items in the scene.",
            PermissionLevel = TwitchCommandBase.PermissionFlag.Everyone,
        }).CommandReceived += OnItemsCommandReceived;
    }

    private async void OnItemsCommandReceived(string fromUsername, TwitchCommandInfo info, string[] args)
    {
        var items = string.Join(", ", Items.Select(i => i.Name));
        await TwitchBot.SendMessage($"Items: {items}", info.ChatMessage.MessageId);
    }


    public Node3D GetItem(string name) =>
        Items.Find(i => string.Equals(i.Name, name, StringComparison.CurrentCultureIgnoreCase));
}