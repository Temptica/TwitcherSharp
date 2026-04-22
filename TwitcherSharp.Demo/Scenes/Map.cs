using System.Collections.Generic;
using Godot;

namespace TwitcherSharp.Demo.Scenes;

public partial class Map : Node3D
{
    public static Map Instance { get; set; }
    public List<Tile> Tiles { get; } = [];

    public int Width { get; set; } = 30;
    public int Height { get; set; } = 30;

    public int TileSize { get; set; } = 1;
    
    public PhysicItemsManager PhysicsManager { get; private set; }

    public override void _Ready()
    {
        Instance = this;
        
        PhysicsManager = GetNode<PhysicItemsManager>("PhysicItemsManager");
        
        var offset = new Vector3(Width / 2f, 0, Height / 2f);
        for (var x = 0; x <= Width; x++)
        {
            for (var y = 0; y <= Height; y++)
            {
                var tile = new Tile { X = x, Y = y, Grid = this };
                Tiles.Add(tile);
                AddChild(tile);
                tile.Position = new Vector3(x * TileSize, 0, y * TileSize) - offset;
            }
        }
    }

    public Vector3 GetGridPosition(int x, int y) => Tiles.Find(g => g.X == x && g.Y == y)?.GridPosition ?? Vector3.Zero;
}