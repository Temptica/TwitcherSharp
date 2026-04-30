using Godot;
using System;
using TwitcherSharp.Api.Generated;
using TwitcherSharp.Chat;

namespace TwitcherSharp.Demo.Scenes;

public partial class Main : Node3D
{
    // Called when the node enters the scene tree for the first time.
    public override async void _Ready()
    {
        await TwitchService.GetInstance().Setup();
        TwitchApi.GetInstance();
        TwitchChat.GetInstance();
        TwitchBot.GetInstance();
    }
}