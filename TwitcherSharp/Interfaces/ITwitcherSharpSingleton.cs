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
    /// Get the current Instance. Else it will try to find an existing GDScript instance.
    /// <p>This object will also be added to the metaData of the linked node. When that node is removed from the scene, it will also remove this refCounted object</p>
    /// </summary>
    /// <returns>The Instance when found, else returns null</returns>
    public static TSelf? Instance {
        get
        {
            if (field is not null)
                return field;

            var script = GD.Load<GDScript>(TSelf.ScriptPath);
            var gdObject = script.New().AsGodotObject();

            var instance = gdObject.Get("instance");
        
            field = instance.VariantType != Variant.Type.Object ? null : TSelf.FromObject(instance.AsGodotObject());
        
            return field;
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
        Instance = new TSelf();
        configure?.Invoke(Instance);

        var gdNode = Instance.ToGodotObject();

        var root = (Engine.GetMainLoop() as SceneTree)!.Root;
        root.AddChild(gdNode as Node);

        return Instance;
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