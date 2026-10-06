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
    /// Api to use for the redemption's. Will try to look for it in the scene tree if not set. Else it will create one to the scene root.'
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
    /// Called when one of the rewards that this node is listening is getting redeemed
    /// </summary>
    [Signal]
    public delegate void RedeemedEventHandler(TwitchRedemption redemption);

    public async Task EnsureSubscription()
    {
        using var _ = await _data!.CallAsync("ensure_subscription");
    }

    public void AddReward(TwitchReward reward)
    {
        RewardsToListen.Add(reward);
        // Mutate the array Godot already owns: it is typed as Array[TwitchReward] on the
        // GDScript side and rejects a freshly built Array[Object] without reporting an error.
        using var rewards = _data!.Read("rewards_to_listen", static v => v.AsGodotArray());
        using var rewardArg = GodotObjectExtension.ToVariant(reward);
        rewards.Add(rewardArg);
    }

    public void RemoveReward(TwitchReward reward)
    {
        RewardsToListen.Remove(reward);
        using var rewards = _data!.Read("rewards_to_listen", static v => v.AsGodotArray());
        for (var i = rewards.Count - 1; i >= 0; i--)
        {
            using var item = rewards[i];
            if (item.Read("id", static v => v.AsString()) == reward.Id) rewards.RemoveAt(i);
        }
    }

    public async Task FullFillRedemption(string redemptionId, TwitchReward reward, string broadcasterId)
    {
        using var rewardArg = GodotObjectExtension.ToVariant(reward);
        using var _ = await _data!.CallAsync("fulfill_redemption", redemptionId, rewardArg, broadcasterId);
    }

    /// <summary>
    /// Cancels existing redemption for a specified reward and broadcaster.
    /// </summary>
    /// <param name="redemptionId">The unique identifier of the redemption to cancel.</param>
    /// <param name="reward">The reward associated with the redemption to be canceled.</param>
    /// <param name="broadcasterId">The unique identifier of the broadcaster linked to the redemption.</param>
    /// <returns>Returns the details of the canceled redemption as a <see cref="TwitchCustomRewardRedemption"/> object. Returns null on error</returns>
    public async Task<TwitchCustomRewardRedemption> CancelRedemption(string redemptionId, TwitchReward reward,
        string broadcasterId)
    {
        using var rewardArg = GodotObjectExtension.ToVariant(reward);
        return (await _data!.CallAsync<TwitchCustomRewardRedemption>("cancel_redemption", redemptionId, rewardArg,
            broadcasterId))!;
    }

    private void ConnectSignals()
    {
        _data!.Connect("redeemed", Callable.FromTwitcherSharp<TwitchRedemption>(EmitSignalRedeemed));
    }

    public static TwitchRedeemListener? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var listener = new TwitchRedeemListener
        {
            RewardsToListen = new Array<TwitchReward>(data.GetArray<TwitchReward>("rewards_to_listen")),
            // Set before linking, so nothing is written back to the node.
            TwitchEventSub = data.GetNode<TwitchEventSub>("eventsub"),
            TwitchApi = data.GetNode<TwitchApi>("api"),
            _data = data,
        };

        listener.ConnectSignals();

        return listener;
    }

    public GodotObject ToGodotObject()
    {
        var instance = InteropExtension.NewObject("res://addons/twitcher/reward/twitch_redeem_listener.gd");
        instance.SetArray("rewards_to_listen", RewardsToListen);
        instance.SetObject("eventsub", TwitchEventSub);
        instance.SetObject("api", TwitchApi);
        instance.SetValue("ensure_subscriptions_on_ready", EnsureSubscriptionsOnReady);
        return instance;
    }
}