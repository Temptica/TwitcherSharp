using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.ChannelPoints;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetCustomRewardResponse : Resource, ITwitcherSharp<TwitchGetCustomRewardResponse>
{
    private GodotObject _data;
	public TwitchCustomReward[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetCustomRewardResponse object.
    /// </summary> 
    public static TwitchGetCustomRewardResponse FromObject(GodotObject data)
    {
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetCustomRewardResponse
		{
			Data = dataArray.Select(TwitchCustomReward.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_reward.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
