namespace TwitcherSharp.Interfaces;
public interface ITwitcherSharpEventSub<out TSelf> : ITwitcherSharpEventSub, ITwitcherSharp<TSelf> where TSelf: ITwitcherSharpEventSub<TSelf>;

public interface ITwitcherSharpEventSub: ITwitcherSharp;