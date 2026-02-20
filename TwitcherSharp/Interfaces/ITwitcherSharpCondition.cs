namespace TwitcherSharp.Interfaces;

public interface ITwitcherSharpCondition<out TSelf> :ITwitcherSharpCondition, ITwitcherSharp<TSelf> where TSelf: ITwitcherSharpCondition<TSelf>;

public interface ITwitcherSharpCondition : ITwitcherSharp
{
    string Name { get; }
}