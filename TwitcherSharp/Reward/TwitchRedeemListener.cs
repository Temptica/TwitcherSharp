using Godot;
using Godot.Collections;
using TwitcherSharp.Extensions;
using TwitcherSharp.Interfaces;

namespace TwitcherSharp.Reward;

public partial class TwitchRedeemListener : RefCounted, ITwitcherSharp<TwitchRedeemListener>
{
    private GodotObject _data;
    
    /// <summary>
    /// List of all rewards to listen for. Use AddReward to add more rewards. RemoveReward to remove rewards.
    /// </summary>
    public Array<TwitchReward> RewardsToListen { get; private set; } = [];

    /// <summary>
    /// Called when one of the rewards that this node is listening is getting redeemed
    /// </summary>
    [Signal]
    public delegate void RedeemedEventHandler(TwitchRedemption redemption);
    public void EnsureSubscription()
    {
        _data.Call("ensure_subscription");        
    }

    public void AddReward(TwitchReward reward)
    {
        RewardsToListen.Add(reward);
        _data.Set("rewards_to_listen", RewardsToListen);
    }
    
    public void RemoveReward(TwitchReward reward)
    {
        RewardsToListen.Remove(reward);
        _data.Set("rewards_to_listen", RewardsToListen);
    }

    public async Task FullFillRedemption(string redemptionId, TwitchReward reward, string broadcasterId)
    {
        /* 
                  
                  var request = optClass.Call("new").AsGodotObject();
                  var ids = new Godot.Collections.Array<string> { id };
                  request.Set("id", ids);
                  var responseTask = TwitchApi.Call("get_users", request);
                      
                  // Await the signal if the return value is something awaitable in Godot
                  // Note: If 'get_users' is defined as 'func get_users(...):', 
                  // Godot 4 handles the Coroutine/Signal return automatically via AsGodotObject()
                  var responseObj = await ToSignal(responseTask.AsGodotObject(), "completed");
                      
                  // In Godot 4, result of await is usually the first argument of the signal
                  var response = responseObj[0].AsGodotObject();
                  
                  var users = response.Get("data").AsGodotArray();*/
        var responseTask = _data.Call("fulfill_redemption", redemptionId, reward.ToGodotObject(), broadcasterId);
    }
    
    /*func fulfill_redemption(redemption_id: String, reward: TwitchReward, broadcaster_id: String) -> TwitchCustomRewardRedemption:
       	return await _update_redemption(true, redemption_id, reward, broadcaster_id)
       
       
       ## Tries to cancel the redemption in error case it will return null.
       func cancel_redemption(redemption_id: String, reward: TwitchReward, broadcaster_id: String) -> TwitchCustomRewardRedemption:
       	return await _update_redemption(false, redemption_id, reward, broadcaster_id)*/
    
    
    private void ConnectSignals()
    {
        _data.ConnectRedeemed(EmitSignalRedeemed);
    }

    public static TwitchRedeemListener FromObject(GodotObject data)
    {
        var listener = new TwitchRedeemListener
        {
            RewardsToListen = data.Get("rewards_to_listen").As<Array<TwitchReward>>(),
            _data = data,
        };

        listener.ConnectSignals();
        
        return listener;
    }

    public GodotObject ToGodotObject()
    {
        throw new NotImplementedException();
    }
}