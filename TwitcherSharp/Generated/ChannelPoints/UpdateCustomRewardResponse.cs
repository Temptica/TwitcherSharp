using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.ChannelPoints;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateCustomRewardResponse : Resource, ITwitcherSharp<UpdateCustomRewardResponse>
{
    private GodotObject _data;
	public CustomReward[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateCustomRewardResponse object.
    /// </summary> 
    public static UpdateCustomRewardResponse FromObject(GodotObject data)
    {
        return new UpdateCustomRewardResponse
        {

			Data = data.Get("data").As<CustomReward[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_custom_reward_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
