using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.ChannelPoints;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateRedemptionStatusResponse : Resource, ITwitcherSharp<UpdateRedemptionStatusResponse>
{
    private GodotObject _data;
	public CustomRewardRedemption[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateRedemptionStatusResponse object.
    /// </summary> 
    public static UpdateRedemptionStatusResponse FromObject(GodotObject data)
    {
        return new UpdateRedemptionStatusResponse
        {

			Data = data.Get("data").As<CustomRewardRedemption[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_redemption_status_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
