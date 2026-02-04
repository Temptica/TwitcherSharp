using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.ChannelPoints;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetCustomRewardRedemptionResponse : Resource, ITwitcherSharp<TwitchGetCustomRewardRedemptionResponse>
{
    private GodotObject _data;
	public TwitchCustomRewardRedemption[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetCustomRewardRedemptionResponse object.
    /// </summary> 
    public static TwitchGetCustomRewardRedemptionResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetCustomRewardRedemptionResponse
		{
			Data = dataArray.Select(TwitchCustomRewardRedemption.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_reward_redemption.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
