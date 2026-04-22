using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Godot;

namespace TwitcherSharp.Demo.Scenes;

public partial class Character : CharacterBody3D
{
    public Node3D CharacterNode { get; set; }

    public Label3D NameLabel { get; set; }

    public string Username { get; set; }
    public string TwitchId { get; set; }
    public Color Color { get; set; }
    private Node3D _explosion;
    private NavigationAgent3D _navAgent;
    private Node3D _target;

    private const float Speed = 4f;
    private const float Gravity = 100f;
    public bool Moving { get; private set; }

    private MeshInstance3D CharacterMesh => CharacterNode.Get("gobot_model").As<MeshInstance3D>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        CharacterNode = GetNode<Node3D>("GobotSkin");
        _explosion = GetNode<Node3D>("Explosion");
        NameLabel = GetNode<Label3D>("NameLabel3D");
        NameLabel.Text = Username;
        SetColor(Color);

        _navAgent = GetNode<NavigationAgent3D>("NavigationAgent3D");
        _navAgent.VelocityComputed += velocity =>
        {
            Velocity = velocity;
            MoveAndSlide();
        };

        _navAgent.TargetReached += () => { Moving = false; };
        CharacterNode.Set("blink", true);
    }

    public void SetColor(Color color)
    {
        Color = color;
        NameLabel.Modulate = Color;
        ((StandardMaterial3D)((ArrayMesh)CharacterMesh.Mesh).SurfaceGetMaterial(0)).Set("albedo_color", Color);
    }

    public static Character Create(string userName, string twitchId, Color color)
    {
        if (color == default)
        {
            color = Colors.White;
        }

        var scene = GD.Load<PackedScene>("res://Scenes/character.tscn");
        var character = scene.Instantiate<Character>();
        character.Username = userName;
        character.TwitchId = twitchId;
        character.Color = color;
        return character;
    }

    public void Jump(float force = 100)
    {
        if (!IsOnFloor())
        {
            GD.Print($"User {Username} is not on the floor");
            return;
        }

        SetVelocity(new Vector3(0, force, 0));
    }

    public override void _PhysicsProcess(double delta)
    {
        var deltaF = (float)delta;

        // Apply gravity without destroying horizontal movement.
        var velocity = Velocity;
        velocity.Y -= Gravity * deltaF;

        if (Moving)
        {
            if (_target != null) _navAgent.TargetPosition = _target.GlobalPosition;

            var currentPosition = GlobalPosition;
            var targetPosition = _navAgent.TargetPosition;
            var direction = (targetPosition - currentPosition).Normalized();

            // NavigationAgent3D expects velocity in units/second, not multiplied by delta.
            var desiredVelocity = direction * Speed;

            // Keep vertical velocity from gravity/jumping, but give the agent the movement it needs for avoidance.
            desiredVelocity.Y = velocity.Y;
            _navAgent.Velocity = desiredVelocity;
            velocity = desiredVelocity;
        }

        Velocity = velocity;
        MoveAndSlide();

        if (Velocity == Vector3.Zero)
        {
            IdleCharacter();
            return;
        }

        if (!IsOnFloor())
        {
            if (UpDirection.Length() > 0) JumpCharacter();
            else FallCharacter();
            return;
        }

        RunCharacter();
        if ((_target is Character && (Position - _navAgent.TargetPosition).Length() < 5)
            || (Position - _navAgent.TargetPosition).Length() < 3)
        {
            _target = null;
            return;
        }

        CharacterNode.LookAt(_navAgent.TargetPosition, Vector3.Up);
        CharacterNode.RotateY(Mathf.Pi);
    }

    private void JumpCharacter()
    {
        CharacterNode.Call("jump");
    }

    private void FallCharacter()
    {
        CharacterNode.Call("fall");
    }

    private void IdleCharacter()
    {
        CharacterNode.Call("idle");
    }

    private void RunCharacter()
    {
        CharacterNode.Call("run");
    }

    public void Explode()
    {
        Jump(200);

        foreach (var particle in _explosion.GetChildren().OfType<GpuParticles3D>())
        {
            particle.Emitting = true;
        }
    }

    public void MoveToTarget(Vector3 target)
    {
        _navAgent.AvoidanceEnabled = true;
        _navAgent.TargetPosition = target;
        Moving = true;
    }

    public void MoveToObject(Node3D target)
    {
        _navAgent.AvoidanceEnabled = true;
        _navAgent.TargetPosition = target.GlobalPosition;
        _target = target;
        Moving = true;
    }

    private static List<Color> _danceColors = new List<Color>
    {
        Colors.Red, Colors.Orange, Colors.Yellow, Colors.Green, Colors.Blue, Colors.Indigo, Colors.Violet
    };

    public async Task Dance()
    {
        var material = (StandardMaterial3D)((ArrayMesh)CharacterMesh.Mesh).SurfaceGetMaterial(0);
        var tween = CreateTween();

        const float duration = 5f / 6f;

        for (var i = 0; i < 2; i++)
        {
            foreach (var color in _danceColors)
            {
                tween.Chain().TweenProperty(material, "albedo_color", color, duration);
                tween.Parallel().TweenProperty(NameLabel, "modulate", color, duration);
            }
        }

        tween.Chain().TweenProperty(material, "albedo_color", Color, duration);
        tween.Parallel().TweenProperty(NameLabel, "modulate", Color, duration);
    }
}