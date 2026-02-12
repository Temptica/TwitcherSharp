using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUpdateCustomRewardResponse : Resource, ITwitcherSharp<TwitchUpdateCustomRewardResponse>
{
    private GodotObject _data;
	public TwitchCustomReward[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateCustomRewardResponse object.
    /// </summary> 
    public static TwitchUpdateCustomRewardResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchUpdateCustomRewardResponse
		{
			Data = dataArray.Select(TwitchCustomReward.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_custom_reward.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
