using Godot;

namespace TwitcherSharp.Interfaces;

/// <summary>
/// The typed variant of the base interface for all TwitcherSharp EventSub classes.
/// </summary>
/// <typeparam name="TSelf">A RefCounted class</typeparam>
public interface ITwitcherSharpEventSub<out TSelf> : ITwitcherSharpEventSub, ITwitcherSharp<TSelf>
    where TSelf : RefCounted, ITwitcherSharpEventSub<TSelf>;

/// <summary>
/// The base interface for all TwitcherSharp EventSub classes.
/// </summary>
public interface ITwitcherSharpEventSub : ITwitcherSharp;