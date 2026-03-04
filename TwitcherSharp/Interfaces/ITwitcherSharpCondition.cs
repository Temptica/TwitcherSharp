namespace TwitcherSharp.Interfaces;

/// <summary>
/// The type variant of the base interface for all TwitcherSharp Conditions.
/// </summary>
/// <typeparam name="TSelf"></typeparam>
public interface ITwitcherSharpCondition<out TSelf> :ITwitcherSharpCondition, ITwitcherSharp<TSelf> where TSelf: ITwitcherSharpCondition<TSelf>;

/// <summary>
/// The base interface for all TwitcherSharp Conditions.
/// </summary>
public interface ITwitcherSharpCondition : ITwitcherSharp
{
    string Name { get; }
}