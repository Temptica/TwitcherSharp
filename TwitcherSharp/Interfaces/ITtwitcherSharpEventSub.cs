using Godot;
using Godot.Collections;

namespace TwitcherSharp.Interfaces;

//V1
// public interface ITwitcherSharpEventSub<out TSelf> where TSelf : ITwitcherSharpEventSub<TSelf>
// {
//     static abstract TSelf FromData(Dictionary data);
// }

//V2
public interface ITwitcherSharpEventSub<out TSelf> : ITwitcherSharp<TSelf> where TSelf: ITwitcherSharpEventSub<TSelf>;