using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.ChannelPoints;
 
/// <summary> 
///  
/// </summary>
public partial class GetCustomRewardRedemptionResponse : Resource, ITwitcherSharp<GetCustomRewardRedemptionResponse>
{
    private GodotObject _data;
	public CustomRewardRedemption[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetCustomRewardRedemptionResponse object.
    /// </summary> 
    public static GetCustomRewardRedemptionResponse FromObject(GodotObject data)
    {
        return new GetCustomRewardRedemptionResponse
        {

			Data = data.Get("data").As<CustomRewardRedemption[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_reward_redemption_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
