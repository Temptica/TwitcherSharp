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
    
    public static TwitchEventSub Required => ITwitcherSharpSingleton<TwitchEventSub>.Required;

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
    public async Task DoSetup() => await _data!.InvokeAsync("do_setup");

    /// <summary>
    /// Propergated call from twitch service
    /// </summary>
    public async Task DoUnSetup() => await _data!.InvokeAsync("do_unsetup");

    public async Task WaitSetup() => await _data!.InvokeAsync("wait_setup");

    /// <summary>
    /// Waits until the eventsub is fully established
    /// </summary>
    public async Task WaitForSessionEstablished() => await _data!.InvokeAsync("wait_for_session_established");

    public void OpenConnection() => _data!.Invoke("open_connection");

    public void CloseConnection() => _data!.Invoke("close_connection");

    /// <summary>
    /// Add a new subscription
    /// </summary>
    /// <param name="config"></param>
    public void Subscribe(TwitchEventSubConfig config)
    {
        using var configArg = GodotObjectExtension.ToVariant(config);
        _data!.Invoke("subscribe", configArg);
    }

    public List<TwitchEventSubConfig> GetSubscriptionsByType(TwitchEventSubDefinitionType type)
    {
        // twitcher numbers its types in another order than TwitchEventSubDefinitionType.
        var twitcherType = TwitchEventSubDefinition.All.First(definition => definition.Type == type).TwitcherType;
        return _data!.CallList<TwitchEventSubConfig>("get_subscription_by_type", twitcherType);
    }

    public bool HasSubscription(TwitchEventSubConfig config)
    {
        using var configArg = GodotObjectExtension.ToVariant(config);
        return _data!.Invoke("has_subscription", static v => v.AsBool(), configArg);
    }

    public void Unsubscribe(TwitchEventSubConfig config)
    {
        using var configArg = GodotObjectExtension.ToVariant(config);
        _data!.Invoke("unsubscribe", configArg);
    }

    public List<TwitchEventSubConfig> GetSubscriptions() => _data!.CallList<TwitchEventSubConfig>("get_subscriptions");

    public static TwitchEventSub? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var eventSub = new TwitchEventSub { _data = data };
        Instance = eventSub;
        return eventSub;
    }

    public GodotObject ToGodotObject()
    {
        if (_data is not null) return _data;

        _data = InteropExtension.NewObject("res://addons/twitcher/eventsub/twitch_eventsub.gd");
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