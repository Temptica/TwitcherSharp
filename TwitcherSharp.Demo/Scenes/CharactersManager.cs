using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Godot;
using Godot.NativeInterop;
using TwitcherSharp.Api.Generated;
using TwitcherSharp.Chat;
using TwitcherSharp.EventSub;
using TwitcherSharp.EventSub.Generated.ChannelBitsUse;
using TwitcherSharp.EventSub.Generated.ChannelFollow;
using TwitcherSharp.Extensions;
using TwitcherSharp.Media;
using TwitcherSharp.Reward;

namespace TwitcherSharp.Demo.Scenes;

public partial class CharactersManager : Node3D
{
    // Called when the node enters the scene tree for the first time.
    private readonly List<Character> _characters = [];

    public override void _Ready()
    {
        ListenToEvents();
        ListenToCommands();
    }

    private void ListenToCommands()
    {
        //Listen example
        this.GetTwitcherNode<TwitchCommand>("TwitchCommands/JoinCommand").CommandReceived += OnJoinReceived;
        this.GetTwitcherNode<TwitchCommand>("TwitchCommands/LeaveCommand").CommandReceived += OnLeaveReceived;
        this.GetTwitcherNode<TwitchCommand>("TwitchCommands/ColorCommand").CommandReceived += OnColorReceived;
        this.GetTwitcherNode<TwitchCommand>("TwitchCommands/JumpCommand").CommandReceived += OnJumpReceived;
        this.GetTwitcherNode<TwitchCommand>("TwitchCommands/ExplodeCommand").CommandReceived += OnExplodeReceived;
        this.GetTwitcherNode<TwitchCommand>("TwitchCommands/MoveCommand").CommandReceived += OnMoveReceived;
        this.GetTwitcherNode<TwitchCommand>("TwitchCommands/DanceCommand").CommandReceived += OnDanceReceived;

        //Create command example
        var moveToCommand = new TwitchCommand()
        {
            Command = "moveto",
            Aliases =
            [
                "mt", "m", "hug"
            ], //Due to the Args, even if alias is same as Move command, it will look at args count!!
            ArgsMin = 1,
            ArgsMax = 1,
            Description = "Move to an object within the scene.",
            PermissionLevel = TwitchCommandBase.PermissionFlag.Everyone
        };

        GetNode("TwitchCommands").AddChild(moveToCommand.ToGodotObject() as Node);
        //OR use TwitchService.Instance.AddCommand(moveToCommand); But this adds the command to the TwitcherService instead

        moveToCommand.CommandReceived += OnMoveToReceived;
    }

    private Character GetCharacter(string userName)
    {
        return _characters.FirstOrDefault(c =>
            c.Username.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
    }

    private void OnJoinReceived(string userName, TwitchCommandInfo info, string[] args)
    {
        if (GetCharacter(userName) != null)
        {
            GD.Print($"User {userName} already exists");
            return;
        }

        GD.Print($"User {userName} joined");

        var msg = info.ChatMessage;
        var character = Character.Create(msg.ChatterUserName, msg.ChatterUserId, Color.FromHtml(msg.Color));

        AddChild(character);
        _characters.Add(character);

        character.Position = new Vector3(Random.Shared.Next(-14, 15), 0, Random.Shared.Next(-14, 15));
    }

    private void OnLeaveReceived(string userName, TwitchCommandInfo info, string[] args)
    {
        var character = GetCharacter(userName);
        if (character == null)
        {
            GD.Print($"User {userName} not found");
            return;
        }

        GD.Print($"User {userName} left");

        _characters.Remove(character);
        character.QueueFree();
    }

    private void OnColorReceived(string userName, TwitchCommandInfo info, string[] args)
    {
        var character = GetCharacter(userName);
        if (character == null)
        {
            GD.Print($"User {userName} not found");
            return;
        }

        GD.Print($"User {userName} changed color to {args[0]}");

        character.SetColor(Color.FromHtml(args[0]));
    }

    private void OnJumpReceived(string userName, TwitchCommandInfo info, string[] args)
    {
        var character = GetCharacter(userName);
        if (character == null)
        {
            GD.Print($"User {userName} not found");
            return;
        }

        GD.Print($"User {userName} jumped");

        character.Jump();
    }

    private void OnExplodeReceived(string userName, TwitchCommandInfo info, string[] args)
    {
        var character = args.Length > 0 ? GetCharacter(args[0]) : GetCharacter(userName);

        if (character == null)
        {
            GD.Print("User not found");
            return;
        }

        GD.Print($"User {character.Username} exploded");

        character.Explode();
    }

    private void OnMoveReceived(string fromUsername, TwitchCommandInfo info, string[] args)
    {
        if (!int.TryParse(args[0], out var x) || !int.TryParse(args[1], out var y)) return;
        var character = GetCharacter(fromUsername);
        if (character == null)
        {
            GD.Print($"User {args[0]} not found");
            return;
        }

        var position = Map.Instance.GetGridPosition(x, y);
        character.MoveToTarget(position);
    }

    private async void OnDanceReceived(string fromUsername, TwitchCommandInfo info, string[] args)
    {
        var character = GetCharacter(fromUsername);
        if (character == null)
        {
            GD.Print($"User {args[0]} not found");
            return;
        }

        await character.Dance();
    }

    private void OnMoveToReceived(string fromUsername, TwitchCommandInfo info, string[] args)
    {
        var itemName = args[0];
        var item = Map.Instance.PhysicsManager.GetItem(itemName);
        item ??= GetCharacter(itemName);
        if (item == null)
        {
            _ = TwitchBot.SendMessage("Item not found.", info.ChatMessage.MessageId);
            return;
        }

        var character = GetCharacter(fromUsername);
        if (character == null)
        {
            GD.Print($"User {args[0]} not found");
            return;
        }

        character.MoveToObject(item);
    }

    private void ListenToEvents()
    {
        this.GetTwitcherNode<TwitchEventListener<TwitchChannelFollowEvent>>("EventSub/FollowListener").Received +=
            OnFollowReceived;
    }

    private void OnFollowReceived(TwitchChannelFollowEvent obj)
    {
        foreach (var character in _characters)
        {
            _ = character.Dance();
        }
    }
}