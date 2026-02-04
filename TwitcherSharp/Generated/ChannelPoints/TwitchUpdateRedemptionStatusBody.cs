using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.ChannelPoints;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchUpdateRedemptionStatusBody : Resource, ITwitcherSharp<TwitchUpdateRedemptionStatusBody>
{
    private GodotObject _data;
	public string Status { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateRedemptionStatusBody object.
    /// </summary> 
    public static TwitchUpdateRedemptionStatusBody FromObject(GodotObject data)
    {
		return new TwitchUpdateRedemptionStatusBody
		{
			Status = data.Get("status").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_redemption_status.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("status", Status);
		return request;
	}
}
