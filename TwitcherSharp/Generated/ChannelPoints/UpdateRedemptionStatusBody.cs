using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.ChannelPoints;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateRedemptionStatusBody : Resource, ITwitcherSharp<UpdateRedemptionStatusBody>
{
    private GodotObject _data;
	public string Status { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateRedemptionStatusBody object.
    /// </summary> 
    public static UpdateRedemptionStatusBody FromObject(GodotObject data)
    {
        return new UpdateRedemptionStatusBody
        {

			Status = data.Get("status").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_redemption_status_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("status", Status);
		return request;
	}
}
