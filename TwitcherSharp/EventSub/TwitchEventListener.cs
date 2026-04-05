using Godot;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub;

public partial class TwitchEventListener<T> : RefCounted, ITwitcherSharp<TwitchEventListener<T>>
    where T : RefCounted, ITwitcherSharpEventSub<T>
{
    private GodotObject _data;
    private readonly List<Action<T>> _receivedEvents = [];
    
    public TwitchEventSubDefinition SubscriptionDefinition { get; set; }

    /// <summary>
    /// Triggers whenever the Event has been recieved
    /// </summary>
    public event Action<T> Received
    {
        add => _receivedEvents.Add(value);
        remove => _receivedEvents.Remove(value);
    }

    public void ConnectReceived(Action<T> action) => _receivedEvents.Add(action);
    public void DisconnectReceived(Action<T> action) => _receivedEvents.Remove(action);

    private void ConnectSignals()
    {
        _data.Connect("typed_data_received", Callable.From<Variant>(data =>
        {
            var eventData = T.FromObject(data.AsGodotObject());
            foreach (var action in _receivedEvents) action(eventData);
        }));
    }

    /// <summary>
    /// Will automatically start when adding to a scene tree. Expects that the signal was already configured in the eventsub or has been manually subscribed.
    /// </summary>
    public void StartListening() => _data.Call("start_listening");

    public void StopListening() => _data.Call("stop_listening");

    public static TwitchEventListener<T> FromObject(GodotObject data)
    {
        var listener = new TwitchEventListener<T>
        {
            _data = data,
        };
        listener.ConnectSignals();

        return listener;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/eventsub/twitch_event_listener.gd");
        var instance = script.New().AsGodotObject();
        instance.Set("subscription_definition", SubscriptionDefinition.ToGodotObject());
        
        _data = instance;
        ConnectSignals();
        
        return instance;
    }
}