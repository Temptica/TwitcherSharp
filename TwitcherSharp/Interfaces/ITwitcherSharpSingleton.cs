using Godot;

namespace TwitcherSharp.Interfaces;

/// <summary>
/// The typed variant of the base interface for all TwitcherSharp singleton classes.
/// </summary>
/// <typeparam name="TSelf">A RefCounted class</typeparam>
public interface ITwitcherSharpSingleton<out TSelf> : ITwitcherSharpSingleton, ITwitcherSharp<TSelf>
    where TSelf : RefCounted, ITwitcherSharpSingleton<TSelf>, new()
{
    /// <summary>
    /// Script path of the Twitcher node.
    /// </summary>
    static abstract string ScriptPath { get; }

    /// <summary>
    /// The wrapper of twitcher's current node of this type: the one in the script's static <c>instance</c>, which a
    /// twitcher node sets when it enters the tree and clears when it leaves. Never creates a node.
    /// <p>The wrapper is cached while it is linked to that node; once the node left the tree this returns null, or the
    /// wrapper of the node that took its place.</p>
    /// </summary>
    /// <returns>The Instance when found, else returns null</returns>
    public static TSelf? Instance {
        get
        {
            // The static is read from the script itself; instantiating the script to read it would create a node.
            using var script = GD.Load<GDScript>(TSelf.ScriptPath);
            using var current = script.Get("instance");
            var node = current.AsGodotObject();
            if (node is null || !GodotObject.IsInstanceValid(node)) return field = null;

            if (field is { IsLinked: true } && field.ToGodotObject().GetInstanceId() == node.GetInstanceId())
                return field;

            return field = TSelf.FromObject(node);
        } 
        set;
    }

    /// <summary>
    /// Gets the current <see cref="Instance"/>, or throws if it hasn't been initialized yet.
    /// <p>Use this instead of <see cref="Instance"/> when your code only ever runs after setup
    /// (e.g., the Twitcher autoload always initializes before your game code does) and you want a
    /// non-nullable reference back.</p>
    /// </summary>
    /// <exception cref="InvalidOperationException">The singleton has not been initialized yet.</exception>
    public static TSelf Required => Instance ?? throw new InvalidOperationException(
        $"{typeof(TSelf).Name}.Instance is not initialized. Make sure the Twitcher addon is enabled and set up " +
        $"before accessing it, or call {typeof(TSelf).Name}.CreateInstance() first.");

    /// <summary>
    /// Create a new instance of the TwitcherSharp singleton. This will also add a new Twitcher (gdscript) to the root of the scene.
    /// </summary>
    /// <param name="configure">optional configuration for the new instance</param>
    /// <returns>The newly created instance</returns>
    // public static abstract TSelf CreateInstance(Action<TSelf> configure = null);
    public static TSelf CreateInstance(Action<TSelf>? configure = null)
    {
        var instance = new TSelf();
        configure?.Invoke(instance);
        Instance = instance;

        var gdNode = instance.ToGodotObject();

        var root = (Engine.GetMainLoop() as SceneTree)!.Root;
        root.AddChild(gdNode as Node);

        return instance;
    }
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