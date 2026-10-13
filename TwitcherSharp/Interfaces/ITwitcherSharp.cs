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
    /// <remarks>
    /// The mapped object keeps its own reference to <paramref name="data"/> (as a Variant, not as the wrapper), so the
    /// caller still owns the wrapper it passed and disposes it as usual. Disposing the mapped object releases that
    /// reference.
    /// </remarks>
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
    /// <remarks>
    /// For a data object (a twitcher RefCounted such as a chat message or an API response) the caller owns the returned
    /// wrapper and disposes it once twitcher holds the object (for example after setting it on a property or passing it
    /// to a call). Singletons and other nodes return their node instead, which the caller must not dispose.
    /// </remarks>
    /// <returns></returns>
    public GodotObject ToGodotObject();
}