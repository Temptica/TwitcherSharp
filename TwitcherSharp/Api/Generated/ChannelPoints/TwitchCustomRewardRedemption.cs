using TwitcherSharp.Interfaces;
using TwitcherSharp.Extensions;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

public partial class TwitchCustomRewardRedemption : RefCounted, ITwitcherSharp<TwitchCustomRewardRedemption>
{
    private GodotObject _data;
    public string BroadcasterId { get; set; }
    public string BroadcasterLogin { get; set; }
    public string BroadcasterName { get; set; }
    public string Id { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string UserLogin { get; set; }
    public TwitchReward Reward { get; set; }
    public string UserInput { get; set; }
    public string Status { get; set; }
    public string RedeemedAt { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCustomRewardRedemption object.
    /// </summary> 
    public static TwitchCustomRewardRedemption FromObject(GodotObject data)
    {
        if(data == null) return null;
        return new TwitchCustomRewardRedemption
        {
            BroadcasterId = data.Get("broadcaster_id").AsString(),
            BroadcasterLogin = data.Get("broadcaster_login").AsString(),
            BroadcasterName = data.Get("broadcaster_name").AsString(),
            Id = data.Get("id").AsString(),
            UserId = data.Get("user_id").AsString(),
            UserName = data.Get("user_name").AsString(),
            UserLogin = data.Get("user_login").AsString(),
            Reward = data.Get("reward").As<TwitchReward>(),
            UserInput = data.Get("user_input").AsString(),
            Status = data.Get("status").AsString(),
            RedeemedAt = data.Get("redeemed_at").AsString(),
        };
    }

    public GodotObject ToGodotObject()
    {
        var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_custom_reward_redemption.gd");
        var request = script.Call("new").AsGodotObject();
        request.Set("broadcaster_id", BroadcasterId);
        request.Set("broadcaster_login", BroadcasterLogin);
        request.Set("broadcaster_name", BroadcasterName);
        request.Set("id", Id);
        request.Set("user_id", UserId);
        request.Set("user_name", UserName);
        request.Set("user_login", UserLogin);
        request.Set("reward", Reward?.ToGodotObject());
        request.Set("user_input", UserInput);
        request.Set("status", Status);
        request.Set("redeemed_at", RedeemedAt);
        return request;
    }
    
    /// <summary> 
    /// An object that describes the reward that the user redeemed. 
    /// </summary>
    public partial class TwitchReward : RefCounted, ITwitcherSharp<TwitchReward>
    {
        private GodotObject _data;
        public string Id { get; set; }
        public string Title { get; set; }
        public string Prompt { get; set; }
        public int Cost { get; set; }
    
        /// <summary> 
        /// Transforms the godot data into a TwitchReward object.
        /// </summary> 
        public static TwitchReward FromObject(GodotObject data)
        {
            if(data == null) return null;
            return new TwitchReward
            {
                Id = data.Get("id").AsString(),
                Title = data.Get("title").AsString(),
                Prompt = data.Get("prompt").AsString(),
                Cost = data.Get("cost").AsInt32(),
            };
        }
    
        public GodotObject ToGodotObject()
        {
            var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_custom_reward_redemption.gd");
            var twitchRewardClass = script.Get("Reward").AsGodotObject();
            var request = twitchRewardClass.Call("new").AsGodotObject();
            request.Set("id", Id);
            request.Set("title", Title);
            request.Set("prompt", Prompt);
            request.Set("cost", Cost);
            return request;
        }
    
    }

}
