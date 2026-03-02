namespace TwitcherSharp.Interfaces;

public interface ITwitcherSharpSingleton<out TSelf> : ITwitcherSharpSingleton, ITwitcherSharp<TSelf>
    where TSelf : ITwitcherSharpSingleton<TSelf>
{
    public static abstract TSelf Instance { get; }
    public static abstract TSelf Create();
}

public interface ITwitcherSharpSingleton : ITwitcherSharp;