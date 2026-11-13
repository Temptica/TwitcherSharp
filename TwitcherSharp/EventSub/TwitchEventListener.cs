using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub;

public partial class TwitchEventListener<T> : RefCounted, ITwitcherSharp<TwitchEventListener<T>>
    where T : RefCounted, ITwitcherSharpEventSub<T>
{
    private GodotObject? _data;
    private readonly List<Action<T>> _receivedEvents = [];

    /// <summary>
    /// The subscription to listen for. Determines which conditions are needed.
    /// </summary>
    public TwitchEventSubDefinitionType Subscription
    {
        get;
        set
        {
            field = value;
            _data?.Set("subscription", (int)value);
        }
    }

    /// <summary>
    /// Conditions to subscribe with. Which conditions are available is defined by <see cref="Subscription"/>.
    /// Only used when the <see cref="TwitchEventSub"/> has no fitting subscription yet.
    /// </summary>
    public ITwitcherSharpCondition Condition
    {
        get;
        set
        {
            field = value;
            _data?.Set("condition", value.ToDictionary());
        }
    }

    /// <summary>
    /// Subscribes on ready when the <see cref="TwitchEventSub"/> has no fitting subscription and <see cref="Condition"/>
    /// is completely filled.
    /// </summary>
    public bool EnsureSubscriptionOnReady
    {
        get;
        set
        {
            field = value;
            _data?.Set("ensure_subscription_on_ready", value);
        }
    } = true;

    /// <summary>
    /// Definition of the currently selected <see cref="Subscription"/>
    /// </summary>
    public TwitchEventSubDefinition Definition => TwitchEventSubDefinition.All[Subscription];

    [Obsolete("Part of twitcher <2.5.2. Please use Definition instead")]
    public TwitchEventSubDefinition? SubscriptionDefinition => Definition;

    /// <summary>
    /// Triggers whenever the Event has been received
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
        _data!.Connect("typed_data_received", Callable.From<Variant>(data =>
        {
            // The event keeps its own reference; the Variant and the wrapper made for mapping are released here.
            T? eventData;
            using (data) eventData = GodotObjectExtension.Map<T>(data);
            foreach (var action in _receivedEvents) action(eventData!);
        }));
    }

    /// <summary>
    /// Will automatically start when adding to a scene tree. Expects that the signal was already configured in the eventsub or has been manually subscribed.
    /// </summary>
    public void StartListening() => _data!.Invoke("start_listening");

    public void StopListening() => _data!.Invoke("stop_listening");

    /// <summary>
    /// Ensures that the <see cref="TwitchEventSub"/> has a subscription that this listener can listen to.
    /// Subscribes on its own when the conditions are filled. Logs an error when there is no subscription
    /// and none could be created.
    /// </summary>
    public void EnsureSubscription() => _data!.Call("ensure_subscription");

    /// <summary>
    /// All conditions of <see cref="Subscription"/> that have no value yet.
    /// </summary>
    public List<StringName> GetMissingConditions() =>
        _data!.Call("get_missing_conditions").AsSystemArrayOfStringName().ToList();

    /// <summary>
    /// Conditions that are used to subscribe. Resolves the users that got selected within the editor.
    /// </summary>
    public Dictionary GetConditions() => _data!.Call("get_conditions").AsGodotDictionary();

    public static TwitchEventListener<T>? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var listener = new TwitchEventListener<T>
        {
            _data = data,
        };
        listener.ConnectSignals();

        return listener;
    }

    public GodotObject ToGodotObject()
    {
        var instance = InteropExtension.NewObject("res://addons/twitcher/eventsub/twitch_event_listener.gd");
        if (SubscriptionDefinition != null) instance.SetObject("subscription_definition", SubscriptionDefinition);
        instance.Set("subscription", (int)Subscription);
        if (Condition != null) instance.Set("condition", Condition.ToDictionary());
        instance.Set("ensure_subscription_on_ready", EnsureSubscriptionOnReady);

        _data = instance;
        ConnectSignals();
        
        return instance;
    }
}