using Godot;
using TwitcherSharp.Api.Generated.Users;
using TwitcherSharp.Interfaces;

// ReSharper disable ClassNeverInstantiated.Global
namespace TwitcherSharp.Reward;

public partial class TwitchRedemption : RefCounted, ITwitcherSharp<TwitchRedemption>
{
    private TwitchRedemption()
    {
    }

    private GodotObject _data;

    public enum Status
    {
        Unknown = 0,    
        Unfulfilled = 1,
        Fulfilled = 2,
        Canceled = 3
    }

    // Signals
    [Signal]
    public delegate void FulfilledEventHandler();

    [Signal]
    public delegate void CancelledEventHandler();

    // Fields/Properties
    public string Id { get; set; }
    public TwitchReward Reward { get; set; }
    public TwitchUser Broadcaster { get; set; }
    public TwitchUser User { get; set; }
    public string UserInput { get; set; } = string.Empty;
    public Status CurrentStatus { get; set; } = Status.Unfulfilled;
    public string RedeemedAt { get; set; }

    /// <summary>
    /// Fullfill the redemption and remove the channel points
    /// </summary>
    public void Fullfill()
    {
        _data.Call("fullfill");
    }

    /// <summary>
    /// When the redeem got fullfilled
    /// </summary>
    public void NotifyFullfilled()
    {
        EmitSignalFulfilled();
    }

    /// <summary>
    /// Cancel the redemption
    /// </summary>
    public void Cancel()
    {
        _data.Call("cancel");
    }

    /// <summary>
    /// When the redeem got cancelled
    /// </summary>
    private void NotifyCancelled()
    {
        EmitSignalFulfilled();
    }

    private void ConnectToSignals()
    {
        _data.Connect("fullfilled", Callable.From(NotifyFullfilled));
        _data.Connect("cancelled", Callable.From(NotifyCancelled));
    }

    public static TwitchRedemption FromObject(GodotObject data)
    {
        var redemption = new TwitchRedemption
        {
            _data = data,
            Id = data.Get("id").AsString(),
            Reward = TwitchReward.FromObject(data.Get("reward").AsGodotObject()),
            Broadcaster = TwitchUser.FromObject(data.Get("broadcaster").AsGodotObject()),
            User = TwitchUser.FromObject(data.Get("user").AsGodotObject()),
            UserInput = data.Get("user_input").AsString(),
            CurrentStatus = data.Get("current_status").As<Status>(),
            RedeemedAt = data.Get("redeemed_at").AsString(),
        };
        redemption.ConnectToSignals();
        return redemption;
    }

    public GodotObject ToGodotObject()
    {
        throw new NotImplementedException();
    }
}