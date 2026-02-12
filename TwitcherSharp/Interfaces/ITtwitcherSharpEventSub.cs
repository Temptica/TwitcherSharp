using Godot.Collections;

namespace TwitcherSharp.Interfaces;

public interface ITwitcherSharpEventSub<out TSelf> where TSelf: ITwitcherSharpEventSub<TSelf>
{
    static abstract TSelf FromData(Dictionary data);
}