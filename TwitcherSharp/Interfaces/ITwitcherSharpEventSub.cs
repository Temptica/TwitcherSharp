namespace TwitcherSharp.Interfaces;
/// <summary>
/// The typed variant of the base interface for all TwitcherSharp EventSub classes.
/// </summary>
/// <typeparam name="TSelf"></typeparam>
public interface ITwitcherSharpEventSub<out TSelf> : ITwitcherSharpEventSub, ITwitcherSharp<TSelf> where TSelf: ITwitcherSharpEventSub<TSelf>;

/// <summary>
/// The base interface for all TwitcherSharp EventSub classes.
/// </summary>
public interface ITwitcherSharpEventSub: ITwitcherSharp;