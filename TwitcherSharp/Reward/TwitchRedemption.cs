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
    private Variant _data;

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
        using var _ = await _data.CallAsync("fullfill");
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
        using var _ = await _data.CallAsync("cancel");
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
        _data.With(data =>
        {
            data.Connect("fullfilled", Callable.From(NotifyFullfilled));
            return data.Connect("cancelled", Callable.From(NotifyCancelled));
        });
    }

    public static TwitchRedemption? FromObject(GodotObject? data)
    {
        if (data == null) return null;
        var redemption = new TwitchRedemption(
            data.Read("id", static v => v.AsString()),
            data.Get<TwitchReward>("reward")!,
            data.Get<TwitchUser>("broadcaster")!,
            data.Get<TwitchUser>("user")!)
        {
            _data = Variant.CreateFrom(data),
            UserInput = data.Read("user_input", static v => v.AsString()),
            CurrentStatus = data.Read("current_status", static v => v.As<Status>()),
            RedeemedAt = DateTime.Parse(data.Read("redeemed_at", static v => v.AsString())),
        };

        redemption.ConnectToSignals();
        return redemption;
    }

    public GodotObject ToGodotObject()
    {
        var instance = InteropExtension.NewObject("res://addons/twitcher/reward/twitch_redemption.gd");
        instance.SetValue("id", Id);
        instance.SetObject("reward", Reward);
        instance.SetObject("broadcaster", Broadcaster);
        instance.SetObject("user", User);
        instance.SetValue("user_input", UserInput);
        instance.SetValue("current_status", (int)CurrentStatus);
        instance.SetValue("redeemed_at", XmlConvert.ToString(RedeemedAt, XmlDateTimeSerializationMode.Utc));
        return instance;
    }

    /// <summary> Releases the twitcher object this instance was mapped from. </summary>
    protected override void Dispose(bool disposing)
    {
        // Only when disposed explicitly: when finalized, the Variant is finalized on its own.
        if (disposing) _data.Dispose();
        base.Dispose(disposing);
    }
}