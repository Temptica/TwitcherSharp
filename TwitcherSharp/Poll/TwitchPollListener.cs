using Godot;
using Godot.Collections;
using TwitcherSharp.Api.Generated;
using TwitcherSharp.Api.Generated.Polls;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.EventSub;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Poll;

/// <summary>
/// Helps listen for polls running on Twitch streams.
/// <para>This Listener exposes multiple <see cref="Signal"/>s to connect to. Each <see cref="Signal"/> has a purpose in the life cycle of a Poll.</para>
/// <list type="bullet">
/// <item>PollBegin: A poll was successfully started/created on stream.</item>
/// <item>PollProgress: A vote was cast on the poll.</item>
/// <item>PollCompleted: A poll has ended normally. Poll is still shown on stream.</item>
/// <item>PollTerminated: A poll has ended early (before the duration has run out). Poll is still shown on stream.</item>
/// <item>PollArchived: A poll was either (terminated or completed) and is not shown on stream anymore.</item>
/// </list>
/// </summary>
public partial class TwitchPollListener : RefCounted, ITwitcherSharp<TwitchPollListener>
{
    private GodotObject _data;

    /// <summary>
    /// The <see cref="TwitchEventSub"/> for subscribing. If left empty, the Node attempts to fetch the <see cref="TwitchEventSub"/> itself.
    /// If it doesn't exist, it will create a new one and add it to the root of the SceneTree.
    /// </summary>
    public TwitchEventSub TwitchEventSub { get; set; }

    /// <summary>
    /// The <see cref="TwitchApi"/> for API calls. If left empty, the Node attempts to fetch the <see cref="TwitchApi"/> itself.
    /// If it doesn't exist, it will create a new one and add it to the root of the SceneTree.'
    /// </summary>
    public TwitchApi TwitchApi { get; set; }

    /// <summary>
    /// Should the node automatically subscribe to the necessary eventsubs in the ready function? 
    /// </summary>
    public bool EnsureSubscriptionsOnReady { get; set; } = true;

    /// <summary>
    /// The broadcaster user. If left empty, the Node attempts to fetch it from the <see cref="TwitchApi"/>.
    /// </summary>
    public TwitchUser Broadcaster { get; set; }

    /// <summary>
    /// Emit the raw JSON response from the <see cref="TwitchEventSubDefinitionType.ChannelPollBegin"/>, <see cref="TwitchEventSubDefinitionType.ChannelPollProgress"/> and <see cref="TwitchEventSubDefinitionType.ChannelPollEnd"/>.
    /// </summary>
    [Signal]
    public delegate void PollJsonEventHandler(Dictionary pollJson);

    /// <summary>
    /// Emits a <see cref="TwitchPoll"/> object when a poll is created/begins.
    /// </summary>
    [Signal]
    public delegate void PollBeginEventHandler(TwitchPoll poll);

    /// <summary>
    /// Emits a <see cref="TwitchPoll"/> object when a poll has progressed.
    /// </summary>
    [Signal]
    public delegate void PollProgressEventHandler(TwitchPoll poll);

    /// <summary>
    /// Emits a <see cref="TwitchPoll"/> object when a poll is completed.
    /// </summary>
    [Signal]
    public delegate void PollCompletedEventHandler(TwitchPoll poll);

    /// <summary>
    /// Emits a <see cref="TwitchPoll"/> object when a poll is terminated.
    /// </summary>
    [Signal]
    public delegate void PollTerminatedEventHandler(TwitchPoll poll);

    /// <summary>
    /// Emits a <see cref="TwitchPoll"/> object when a poll is archived.
    /// </summary>
    [Signal]
    public delegate void PollArchivedEventHandler(TwitchPoll poll);

    public void EnsureSubscriptions()
    {
        _data.Call("ensure_subscriptions");
    }

    public void ConnectSignals()
    {
        _data.Connect("poll_json", Callable.From<Dictionary>(EmitSignalPollJson));
        _data.Connect("poll_begin", Callable.FromTwitcherSharp<TwitchPoll>(EmitSignalPollBegin));
        _data.Connect("poll_progress", Callable.FromTwitcherSharp<TwitchPoll>(EmitSignalPollProgress));
        _data.Connect("poll_completed", Callable.FromTwitcherSharp<TwitchPoll>(EmitSignalPollCompleted));
        _data.Connect("poll_terminated", Callable.FromTwitcherSharp<TwitchPoll>(EmitSignalPollTerminated));
        _data.Connect("poll_archived", Callable.FromTwitcherSharp<TwitchPoll>(EmitSignalPollArchived));
    }

    public static TwitchPollListener FromObject(GodotObject data)
    {
        var pollListener = new TwitchPollListener()
        {
            _data = data,
            EnsureSubscriptionsOnReady = data.Get("ensure_subscriptions_on_ready").AsBool(),
            Broadcaster = TwitchUser.FromObject(data.Get("broadcaster").As<GodotObject>()),
        };
        
        pollListener.TwitchEventSub ??= TwitchEventSub.Instance ?? TwitchEventSub.CreateInstance();
        pollListener.TwitchApi ??= TwitchApi.Instance;
        pollListener.Broadcaster ??= TwitchApi.Instance.GetUsers().GetAwaiter().GetResult().Data[0];
        
        pollListener.ConnectSignals();
        
        return pollListener;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/poll/twitch_poll_listener.gd");
        var obj = script.New().AsGodotObject();
        obj.Set("ensure_subscriptions_on_ready", EnsureSubscriptionsOnReady);
        obj.Set("broadcaster", Broadcaster?.ToGodotObject() ?? new Variant());
        return obj;
    }
}