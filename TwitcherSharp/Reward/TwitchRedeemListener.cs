using Godot;
using Godot.Collections;
using TwitcherSharp.Api.Generated;
using TwitcherSharp.Api.Generated.ChannelPoints;
using TwitcherSharp.EventSub;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Reward;

public partial class TwitchRedeemListener : RefCounted, ITwitcherSharp<TwitchRedeemListener>
{
    private GodotObject? _data;

    /// <summary>
    /// List of all rewards to listen for. Use AddReward to add more rewards. RemoveReward to remove rewards.
    /// </summary>
    public Array<TwitchReward> RewardsToListen { get; private set; } = [];

    /// <summary>
    /// Eventsub to listen for the redemption's. Will try to look for it in the scene tree if not set. Else it will create one to the scene root.
    /// </summary>
    public TwitchEventSub? TwitchEventSub { get; set; }

    /// <summary>
    /// Api to use for the redemption's. Will try to look for it in the scene tree if not set. Else it will create one to the scene root.'
    /// </summary>
    public TwitchApi? TwitchApi { get; set; }

    /// <summary>
    /// Should the node automatically subscribe to the necessary eventsubs in the ready function?
    /// </summary>
    public bool EnsureSubscriptionsOnReady { get; set; } = true;

    /// <summary>
    /// Called when one of the rewards that this node is listening is getting redeemed
    /// </summary>
    [Signal]
    public delegate void RedeemedEventHandler(TwitchRedemption redemption);

    public async Task EnsureSubscriptions()
    {
        await _data!.CallAsync("ensure_subscriptions");
    }

    public void AddReward(TwitchReward reward)
    {
        RewardsToListen.Add(reward);
        var rewards = _data!.Get("rewards_to_listen").AsGodotArray();
        rewards.Add(reward.ToGodotObject());
        _data.Set("rewards_to_listen", rewards);
    }

    public void RemoveReward(TwitchReward reward)
    {
        RewardsToListen.Remove(reward);
        var rewards = _data!.Get("rewards_to_listen").AsGodotArray();
        for (var i = rewards.Count - 1; i >= 0; i--)
        {
            if (rewards[i].AsGodotObject()?.Get("id").AsString() == reward.Id) rewards.RemoveAt(i);
        }
        _data.Set("rewards_to_listen", rewards);
    }

    public async Task FullFillRedemption(string redemptionId, TwitchReward reward, string broadcasterId)
        => await _data!.CallAsync("fulfill_redemption", redemptionId, reward.ToGodotObject(), broadcasterId);

    /// <summary>
    /// Cancels existing redemption for a specified reward and broadcaster.
    /// </summary>
    /// <param name="redemptionId">The unique identifier of the redemption to cancel.</param>
    /// <param name="reward">The reward associated with the redemption to be canceled.</param>
    /// <param name="broadcasterId">The unique identifier of the broadcaster linked to the redemption.</param>
    /// <returns>Returns the details of the canceled redemption as a <see cref="TwitchCustomRewardRedemption"/> object. Returns null on error</returns>
    public async Task<TwitchCustomRewardRedemption> CancelRedemption(string redemptionId, TwitchReward reward,
        string broadcasterId)
        => await _data!.CallAsync<TwitchCustomRewardRedemption>("cancel_redemption", redemptionId,
            reward.ToGodotObject(), broadcasterId);

    private void ConnectSignals()
    {
        _data!.Connect("redeemed", Callable.FromTwitcherSharp<TwitchRedemption>(EmitSignalRedeemed));
    }

    public static TwitchRedeemListener? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var rewards = data.Get("rewards_to_listen").AsGodotArray<Resource>().ToList().Select(TwitchReward.FromObject).ToList();
        var listener = new TwitchRedeemListener
        {
            RewardsToListen =  new Array<TwitchReward>(rewards!),
            TwitchEventSub = data.Get("twitch_event_sub").As<TwitchEventSub>(),
            TwitchApi = data.Get("twitch_api").As<TwitchApi>(),
            EnsureSubscriptionsOnReady = data.Get("ensure_subscriptions_on_ready").AsBool(),
            _data = data,
        };
        listener.TwitchEventSub ??= TwitchEventSub.Instance;
        listener.TwitchApi ??= TwitchApi.Instance;

        listener.ConnectSignals();

        return listener;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/reward/twitch_redeem_listener.gd");
        var instance = script.New().AsGodotObject();
        instance.Set("rewards_to_listen", RewardsToListen.ToGodotArray());
        instance.Set("twitch_event_sub", TwitchEventSub?.ToGodotObject() ?? new Variant());
        instance.Set("twitch_api", TwitchApi?.ToGodotObject() ?? new Variant());
        instance.Set("ensure_subscriptions_on_ready", EnsureSubscriptionsOnReady);
        return instance;
    }
}