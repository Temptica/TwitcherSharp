using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class CustomRewardRedemption : Resource, ITwitcherSharp<CustomRewardRedemption>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public string BroadcasterLogin { get; set; }
	public string BroadcasterName { get; set; }
	public string Id { get; set; }
	public string UserId { get; set; }
	public string UserName { get; set; }
	public string UserLogin { get; set; }
	public Reward Reward { get; set; }
	public string UserInput { get; set; }
	public string Status { get; set; }
	public string RedeemedAt { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CustomRewardRedemption object.
    /// </summary> 
    public static CustomRewardRedemption FromObject(GodotObject data)
    {
        return new CustomRewardRedemption
        {

			BroadcasterId = data.Get("broadcaster_id").AsString(),
			BroadcasterLogin = data.Get("broadcaster_login").AsString(),
			BroadcasterName = data.Get("broadcaster_name").AsString(),
			Id = data.Get("id").AsString(),
			UserId = data.Get("user_id").AsString(),
			UserName = data.Get("user_name").AsString(),
			UserLogin = data.Get("user_login").AsString(),
			Reward = data.Get("reward").As<Reward>(),
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
		request.Set("reward", Reward);
		request.Set("user_input", UserInput);
		request.Set("status", Status);
		request.Set("redeemed_at", RedeemedAt);
		return request;
	}
}
