using Godot;
using Godot.Collections;

namespace TwitcherSharp.Interfaces;

/// <summary>
/// The type variant of the base interface for all TwitcherSharp Conditions.
/// </summary>
/// <typeparam name="TSelf">A RefCounted class</typeparam>
public interface ITwitcherSharpCondition<out TSelf> : ITwitcherSharpCondition, ITwitcherSharp<TSelf>
    where TSelf : RefCounted, ITwitcherSharpCondition<TSelf>
{
    static abstract TSelf FromDictionary(Dictionary data);
}

/// <summary>
/// The base interface for all TwitcherSharp Conditions.
/// </summary>
public interface ITwitcherSharpCondition : ITwitcherSharp
{
    string Name { get; }
    public Dictionary ToDictionary();
    
}