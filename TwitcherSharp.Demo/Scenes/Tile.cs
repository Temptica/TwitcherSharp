using Godot;

namespace TwitcherSharp.Demo.Scenes;

public partial class Tile : Node3D
{
    public Map Grid { get; init; }
    public int X { get; init; }
    public int Y { get; init; }
    private int TileSize => Grid.TileSize;
    public Vector3 GridPosition => Position;

    public override void _Ready()
    {
        if (X % 5 != 0 || Y % 5 != 0) return;

        var label = new Label3D();
        label.Text = $"{X},{Y}";
        label.FontSize = 64;
        label.Billboard = BaseMaterial3D.BillboardModeEnum.Enabled;
        AddChild(label);
        label.Position = new Vector3(0, 0.25f, 0);
    }
}