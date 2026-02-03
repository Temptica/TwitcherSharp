using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.ChannelPoints;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetCustomReward 
/// </summary>
public partial class GetCustomRewardOpt : Resource, ITwitcherSharp<GetCustomRewardOpt>
{
    private GodotObject _data;
	public string[] Id { get; set; }
	public bool OnlyManageableRewards { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetCustomRewardOpt object.
    /// </summary> 
    public static GetCustomRewardOpt FromObject(GodotObject data)
    {
        return new GetCustomRewardOpt
        {

			Id = data.Get("id").AsStringArray(),
			OnlyManageableRewards = data.Get("only_manageable_rewards").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_reward_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("only_manageable_rewards", OnlyManageableRewards);
		return request;
	}
}
