using Godot;

namespace TwitcherSharp.Interfaces;

public interface ITwitcherSharp<out TSelf> : ITwitcherSharp where TSelf: ITwitcherSharp<TSelf>
{
    static abstract TSelf FromObject(GodotObject data);
}

public interface ITwitcherSharp
{
    public GodotObject ToGodotObject();
}