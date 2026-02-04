using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetCustomReward 
/// </summary>
public partial class TwitchGetCustomRewardOpt : Resource, ITwitcherSharp<TwitchGetCustomRewardOpt>
{
    private GodotObject _data;
	public string[] Id { get; set; }
	public bool OnlyManageableRewards { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetCustomRewardOpt object.
    /// </summary> 
    public static TwitchGetCustomRewardOpt FromObject(GodotObject data)
    {
		return new TwitchGetCustomRewardOpt
		{
			Id = data.Get("id").AsStringArray(),
			OnlyManageableRewards = data.Get("only_manageable_rewards").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_reward.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("only_manageable_rewards", OnlyManageableRewards);
		return request;
	}
}
