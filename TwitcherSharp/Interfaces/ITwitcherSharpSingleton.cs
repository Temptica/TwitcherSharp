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
    /// <summary>
    /// Returns whether it is linked to a None and the node has not been freed.
    /// </summary>
    public static abstract TSelf Instance { get; }

    /// <summary>
    /// Get the current Instance. Else it will try to find an existing GDScript instance of this type and bind to this one.
    /// <p>If none can be found, it will instead create a new Node and add it to the root of the SceneTree.</p>
    /// <p>This object will also be added to the metaData of the linked node. When that node is removed from the scene, it will also remove this refCounted object</p>
    /// </summary>
    /// <returns>The created instance</returns>
    public static abstract TSelf GetOrCreateInstance();
}

/// <summary>
/// The base interface for all TwitcherSharp singleton classes.
/// These classes can be linked to a GodotObject.
/// </summary>
public interface ITwitcherSharpSingleton : ITwitcherSharp
{
    /// <summary>
    /// Returns whether this instance is linked to an existing GodotObject.
    /// </summary>
    bool IsLinked { get; }
    
    /// <summary>
    /// Returns the linked GodotObject. If there is no linked object, it will create a new one based on this instance <b>link it</b> and return it.
    /// </summary>
    /// <returns></returns>
    abstract GodotObject ITwitcherSharp.ToGodotObject();
    
    /// <summary>
    /// Removes the singleton instance. This will unlink the GodotObject if it exists.
    /// </summary>
    void FreeInstance();
}