using Godot;

namespace TwitcherSharp.Interfaces;

public interface ITwitcherSharp<out TSelf> where TSelf: ITwitcherSharp<TSelf>
{
    static abstract TSelf FromObject(GodotObject data);
}