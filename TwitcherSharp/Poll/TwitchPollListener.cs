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
    private GodotObject? _data;

    /// <summary>
    /// The <see cref="TwitchEventSub"/> for subscribing. If left empty, the Node attempts to fetch the <see cref="TwitchEventSub"/> itself.
    /// </summary>
    public TwitchEventSub? TwitchEventSub
    {
        get;
        set
        {
            _data?.SetObject("eventsub", value);
            field = value;
        }
    }

    /// <summary>
    /// The <see cref="TwitchApi"/> for API calls. If left empty, the Node attempts to fetch the <see cref="TwitchApi"/> itself.
    /// </summary>
    public TwitchApi? TwitchApi
    {
        get;
        set
        {
            _data?.SetObject("api", value);
            field = value;
        }
    }

    /// <summary>
    /// Should the node automatically subscribe to the necessary eventsubs in the ready function? 
    /// </summary>
    public bool EnsureSubscriptionsOnReady
    {
        get => _data?.Read("ensure_subscriptions_on_ready", static v => v.AsBool()) ?? field;
        set
        {
            _data?.SetValue("ensure_subscriptions_on_ready", value);
            field = value;
        }
    } = true;

    /// <summary>
    /// The broadcaster user. If left empty, the Node attempts to fetch it from the <see cref="TwitchApi"/>.
    /// </summary>
    /// <summary>
    /// The broadcaster whose polls to listen to. twitcher uses the current user when it is not set.
    /// </summary>
    public TwitchUser? Broadcaster
    {
        get
        {
            return _data is null ? field : _data.Get<TwitchUser>("broadcaster");
        }
        set
        {
            _data?.SetObject("broadcaster", value);
            field = value;
        }
    }

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
        _data!.Invoke("ensure_subscriptions");
    }

    public void ConnectSignals()
    {
        _data!.Connect("poll_json", Callable.From<Dictionary>(EmitSignalPollJson));
        _data.Connect("poll_begin", Callable.FromTwitcherSharp<TwitchPoll>(EmitSignalPollBegin));
        _data.Connect("poll_progress", Callable.FromTwitcherSharp<TwitchPoll>(EmitSignalPollProgress));
        _data.Connect("poll_completed", Callable.FromTwitcherSharp<TwitchPoll>(EmitSignalPollCompleted));
        _data.Connect("poll_terminated", Callable.FromTwitcherSharp<TwitchPoll>(EmitSignalPollTerminated));
        _data.Connect("poll_archived", Callable.FromTwitcherSharp<TwitchPoll>(EmitSignalPollArchived));
    }

    public static TwitchPollListener? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var pollListener = new TwitchPollListener
        {
            // Set before linking, so nothing is written back to the node.
            TwitchEventSub = data.GetNode<TwitchEventSub>("eventsub"),
            TwitchApi = data.GetNode<TwitchApi>("api"),
            _data = data,
        };

        pollListener.ConnectSignals();

        return pollListener;
    }

    public GodotObject ToGodotObject()
    {
        var obj = InteropExtension.NewObject("res://addons/twitcher/poll/twitch_poll_listener.gd");
        obj.SetValue("ensure_subscriptions_on_ready", EnsureSubscriptionsOnReady);
        obj.SetObject("eventsub", TwitchEventSub);
        obj.SetObject("api", TwitchApi);
        obj.SetObject("broadcaster", Broadcaster);
        return obj;
    }
}