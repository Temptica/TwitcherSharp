using System.Xml;
using Godot;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

// ReSharper disable ClassNeverInstantiated.Global
namespace TwitcherSharp.Reward;

public partial class TwitchRedemption(
    string redemptionId,
    TwitchReward twitchReward,
    TwitchUser broadcaster,
    TwitchUser user) : RefCounted, ITwitcherSharp<TwitchRedemption>
{
    private GodotObject? _data;

    public enum Status
    {
        Unknown = 0,
        Unfulfilled = 1,
        Fulfilled = 2,
        Canceled = 3
    }


    /// <summary>
    /// The unique redemption id
    /// </summary>
    public string Id { get; set; } = redemptionId;

    public TwitchReward Reward { get; set; } = twitchReward;
    public TwitchUser Broadcaster { get; set; } = broadcaster;
    public TwitchUser User { get; set; } = user;
    public string UserInput { get; set; } = "";

    /// <summary>
    /// Defaults to "unfulfilled". Possible values are "unknown", "unfulfilled", "fulfilled", and "canceled".
    /// </summary>
    public Status CurrentStatus { get; set; } = Status.Unfulfilled;

    public DateTime RedeemedAt { get; set; }

    /// <summary>
    /// Send when the redemption was fullfilled either within the app or externally
    /// </summary>
    [Signal]
    public delegate void FulfilledEventHandler();

    /// <summary>
    /// Send when the redemption was canceled either within the app or externally
    /// </summary>
    [Signal]
    public delegate void CancelledEventHandler();

    /// <summary>
    /// Fullfill the redemption and remove the channel points
    /// </summary>
    public async Task Fullfill()
    {
        await _data!.CallAsync("fullfill");
    }

    /// <summary>
    /// When the redeem got fullfilled
    /// </summary>
    private void NotifyFullfilled()
    {
        EmitSignalFulfilled();
    }

    /// <summary>
    /// Cancel the redemption
    /// </summary>
    public async Task Cancel()
    {
        await _data!.CallAsync("cancel");
    }

    /// <summary>
    /// When the redeem got cancelled
    /// </summary>
    private void NotifyCancelled()
    {
        EmitSignalCancelled();
    }

    private void ConnectToSignals()
    {
        _data!.Connect("fullfilled", Callable.From(NotifyFullfilled));
        _data!.Connect("cancelled", Callable.From(NotifyCancelled));
    }

    public static TwitchRedemption? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var redemption = new TwitchRedemption(
            data.Get("id").AsString(),
            TwitchReward.FromObject(data.Get("reward").AsGodotObject())!,
            TwitchUser.FromObject(data.Get("broadcaster").AsGodotObject())!,
            TwitchUser.FromObject(data.Get("user").AsGodotObject())!)
        {
            _data = data,
            UserInput = data.Get("user_input").AsString(),
            CurrentStatus = data.Get("current_status").As<Status>(),
            RedeemedAt = DateTime.Parse(data.Get("redeemed_at").AsString()),
        };

        redemption.ConnectToSignals();
        return redemption;
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/reward/twitch_redemption.gd");
        var instance = script.New().AsGodotObject();
        instance.Set("id", Id);
        instance.Set("reward", Reward.ToGodotObject());
        instance.Set("broadcaster", Broadcaster.ToGodotObject());
        instance.Set("user", User.ToGodotObject());
        instance.Set("user_input", UserInput);
        instance.Set("current_status", (int)CurrentStatus);
        instance.Set("redeemed_at", XmlConvert.ToString(RedeemedAt, XmlDateTimeSerializationMode.Utc));
        return instance;
    }
}