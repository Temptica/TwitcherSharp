using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.ChannelPoints;
 
/// <summary> 
///  
/// </summary>
public partial class CreateCustomRewardsResponse : Resource, ITwitcherSharp<CreateCustomRewardsResponse>
{
    private GodotObject _data;
	public CustomReward[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a CreateCustomRewardsResponse object.
    /// </summary> 
    public static CreateCustomRewardsResponse FromObject(GodotObject data)
    {
        return new CreateCustomRewardsResponse
        {

			Data = data.Get("data").As<CustomReward[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_custom_rewards_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
