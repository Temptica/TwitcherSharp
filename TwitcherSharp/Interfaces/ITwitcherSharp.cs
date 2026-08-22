using Godot;

namespace TwitcherSharp.Interfaces;

/// <summary>
/// The typed variant of the base interface for all TwitcherSharp classes.
/// </summary>
/// <typeparam name="TSelf">A RefCounted class</typeparam>
public interface ITwitcherSharp<out TSelf> : ITwitcherSharp where TSelf: RefCounted, ITwitcherSharp<TSelf>
{
    /// <summary>
    /// Creates a new instance of the class from a GodotObject instance.
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    static abstract TSelf? FromObject(GodotObject? data);
}

/// <summary>
/// The base interface for all TwitcherSharp classes.
/// </summary>
public interface ITwitcherSharp
{
    /// <summary>
    /// Creates a new GodotObject instance from this class to be used in GDScript or to be added to the SceneTree.
    /// </summary>
    /// <returns></returns>
    public GodotObject ToGodotObject();
}