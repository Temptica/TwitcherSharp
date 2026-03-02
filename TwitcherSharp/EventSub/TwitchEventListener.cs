using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub;

public class TwitchEventListener<T> where T : ITwitcherSharpEventSub<T>
{
    private GodotObject _data;
    private readonly List<Action<T>> _receivedEvents = [];
    public event Action<T> Redeemed
    {
        add => _receivedEvents.Add(value);
        remove => _receivedEvents.Remove(value);
    }
    
    public void ConnectRedeemed(Action<T> action) => _receivedEvents.Add(action);
    public void DisconnectRedeemed(Action<T> action) => _receivedEvents.Remove(action);

    private void ConnectSignals()
    {
        _data.Connect("received", Callable.From<GodotObject>(d =>
        {
            var eventData = T.FromObject(d);
            foreach(var action in _receivedEvents) action(eventData);
        }));
    }
    
    public static TwitchEventListener<T> FromObject(GodotObject data)
    {
        var listener = new TwitchEventListener<T>
        {
            _data = data,
        };
        listener.ConnectSignals();
        
        return listener;
    }
}