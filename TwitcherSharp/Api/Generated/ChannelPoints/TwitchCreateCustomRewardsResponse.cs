using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.ChannelPoints;

/// <summary> 
///  
/// </summary>
public partial class TwitchCreateCustomRewardsResponse : Resource, ITwitcherSharp<TwitchCreateCustomRewardsResponse>
{
    private GodotObject _data;
	public TwitchCustomReward[] Data { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchCreateCustomRewardsResponse object.
    /// </summary> 
    public static TwitchCreateCustomRewardsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchCreateCustomRewardsResponse
		{
			Data = dataArray.Select(TwitchCustomReward.FromObject).ToArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_create_custom_rewards.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}

}
