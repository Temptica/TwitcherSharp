using Godot;
using TwitcherSharp.Extensions;
using TwitcherSharp.Reward;

namespace TwitcherSharp.Demo.Scenes.Fireworks;

public partial class Firework : Node3D
{
    [Export] private GpuParticles3D _rocketParticles;

    public void Start()
    {
        _rocketParticles.Emitting = true;
    }
}