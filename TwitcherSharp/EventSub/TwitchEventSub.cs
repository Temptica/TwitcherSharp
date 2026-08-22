using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.EventSub;

public partial class TwitchEventSub : RefCounted, ITwitcherSharpSingleton<TwitchEventSub>
{
    private GodotObject? _data;
    public static string ScriptPath => "res://addons/twitcher/eventsub/twitch_eventsub.gd";

    public static TwitchEventSub? Instance
    {
        get => ITwitcherSharpSingleton<TwitchEventSub>.Instance;
        private set => ITwitcherSharpSingleton<TwitchEventSub>.Instance = value;
    }

    public static TwitchEventSub CreateInstance(Action<TwitchEventSub>? configure = null) =>
        ITwitcherSharpSingleton<TwitchEventSub>.CreateInstance(configure);

    public bool IsLinked => _data != null;

    [Signal]
    public delegate void SessionIdReceivedEventHandler(string id);

    [Signal]
    public delegate void EventEventHandler(string type, Dictionary data);

    //[Signal] public delegate void EventReceivedEventHandler(Event event);

    [Signal]
    public delegate void EventsRevokedEventHandler(string type, string status);

    [Signal]
    public delegate void MessageReceivedEventHandler(Variant message);

    /// <summary>
    /// Propergated call from twitch service
    /// </summary>
    public async Task DoSetup() => await _data!.CallAsync("do_setup");

    /// <summary>
    /// Propergated call from twitch service
    /// </summary>
    public async Task DoUnSetup() => await _data!.CallAsync("do_unsetup");

    public async Task WaitSetup() => await _data!.CallAsync("wait_setup");

    /// <summary>
    /// Waits until the eventsub is fully established
    /// </summary>
    public async Task WaitForSessionEstablished() => await _data!.CallAsync("wait_for_session_established");

    public void OpenConnection() => _data!.Call("open_connection");

    public void CloseConnection() => _data!.Call("close_connection");

    /// <summary>
    /// Add a new subscription
    /// </summary>
    /// <param name="config"></param>
    public void Subscribe(TwitchEventSubConfig config) => _data!.Call("subscribe", config.ToGodotObject());

    public List<TwitchEventSubConfig> GetSubscriptionsByType(TwitchEventSubDefinitionType type)
        => _data!.Call("get_subscription_by_type", (int)type)
            .AsGodotArray<GodotObject>()
            .Select(TwitchEventSubConfig.FromObject)
            .OfType<TwitchEventSubConfig>()
            .ToList();

    public bool HasSubscription(TwitchEventSubConfig config)
        => _data!.Call("has_subscription", config.ToGodotObject()).AsBool();

    public void Unsubscribe(TwitchEventSubConfig config)
        => _data!.Call("unsubscribe", config.ToGodotObject());

    public List<TwitchEventSubConfig> GetSubscriptions()
        => _data!.Call("get_subscriptions")
            .AsGodotArray<GodotObject>()
            .Select(TwitchEventSubConfig.FromObject)
            .OfType<TwitchEventSubConfig>()
            .ToList();

    public static TwitchEventSub? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        Instance = new TwitchEventSub();
        Instance._data = data;
        return Instance;
    }

    public GodotObject ToGodotObject()
    {
        if (_data is not null) return _data;

        var script = GD.Load<GDScript>("res://addons/twitcher/eventsub/twitch_eventsub.gd");
        _data = script.New().AsGodotObject();
        return _data;
    }

    public void FreeInstance()
    {
        if (_data is not null && !_data.IsQueuedForDeletion()) _data.RemoveMeta(nameof(TwitchEventSub));
        Instance = null;
    }

    public override void _Notification(int what)
    {
        if (what == NotificationPredelete) FreeInstance();
    }
}