using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.ChannelPoints;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetCustomRewardRedemption 
/// </summary>
public partial class GetCustomRewardRedemptionOpt : Resource, ITwitcherSharp<GetCustomRewardRedemptionOpt>
{
    private GodotObject _data;
	public string Status { get; set; }
	public string[] Id { get; set; }
	public string Sort { get; set; }
	public string After { get; set; }
	public int First { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetCustomRewardRedemptionOpt object.
    /// </summary> 
    public static GetCustomRewardRedemptionOpt FromObject(GodotObject data)
    {
        return new GetCustomRewardRedemptionOpt
        {

			Status = data.Get("status").AsString(),
			Id = data.Get("id").AsStringArray(),
			Sort = data.Get("sort").AsString(),
			After = data.Get("after").AsString(),
			First = data.Get("first").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_custom_reward_redemption_opt.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("status", Status);
		request.Set("id", Id);
		request.Set("sort", Sort);
		request.Set("after", After);
		request.Set("first", First);
		return request;
	}
}
