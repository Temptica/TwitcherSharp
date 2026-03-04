using System.Runtime.CompilerServices;
using Godot;

namespace TwitcherSharp.Interfaces;

/// <summary>
/// The typed variant of the base interface for all TwitcherSharp singleton classes.
/// </summary>
/// <typeparam name="TSelf"></typeparam>
public interface ITwitcherSharpSingleton<out TSelf> : ITwitcherSharpSingleton, ITwitcherSharp<TSelf>
    where TSelf : ITwitcherSharpSingleton<TSelf>
{
    public static abstract TSelf Instance { get; }

    /// <summary>
    /// Creates a new instance. It will try to find an existing GDScript instance of this type in the SceneTree and bind to this one.
    /// <p>If none can be found, it will instead not connect and be it's own instance.</p>
    /// If you wish not to connect to an existing instance, use <see cref="Create"/> instead.
    /// </summary>
    /// <returns>The created instance</returns>
    public static abstract TSelf CreateFromInstance();
    
    /// <summary>
    /// Creates a new instance. Does not bind to an existing instance.
    /// </summary>
    /// <returns></returns>
    public static abstract TSelf Create();

    /// <summary>
    /// Returns the linked GodotObject. If there is no linked object, it will create a new one based on this instance <b>and link it</b>.
    /// </summary>
    /// <returns></returns>
    abstract GodotObject ITwitcherSharp.ToGodotObject();
}

/// <summary>
/// The base interface for all TwitcherSharp singleton classes.
/// These classes can be linked to a GodotObject.
/// </summary>
public interface ITwitcherSharpSingleton : ITwitcherSharp
{
    /// <summary>
    /// Returns whether this instance is linked to a GodotObject.
    /// </summary>
    bool IsLinked { get; }
}