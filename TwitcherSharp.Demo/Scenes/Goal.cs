using System.Collections.Generic;
using System.Linq;
using Godot;
using TwitcherSharp.Demo.Scenes.Fireworks;

namespace TwitcherSharp.Demo.Scenes;

public partial class Goal : Node3D
{
    [Signal]
    public delegate void GoalScoredEventHandler();

    private List<Firework> _fireworks = [];

    public override void _Ready()
    {
        GetNode<Area3D>("Area3D").BodyEntered += OnBodyEntered;
        foreach (var firework in GetChildren().OfType<Fireworks.Firework>())
        {
            _fireworks.Add(firework);
        }
    }

    private void OnBodyEntered(Node body)
    {
        EmitSignal(nameof(GoalScored));
        GD.Print("GOAL");
        foreach (var firework in _fireworks)
        {
            firework.Start();
        }
    }
}