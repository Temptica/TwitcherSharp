using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Ads;
 
/// <summary> 
///  
/// </summary>
public partial class StartCommercialBody : Resource, ITwitcherSharp<StartCommercialBody>
{
    private GodotObject _data;
	public string BroadcasterId { get; set; }
	public int Length { get; set; }
    /// <summary> 
    /// Transforms the godot data into a StartCommercialBody object.
    /// </summary> 
    public static StartCommercialBody FromObject(GodotObject data)
    {
        return new StartCommercialBody
        {

			BroadcasterId = data.Get("broadcaster_id").AsString(),
			Length = data.Get("length").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_start_commercial_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("broadcaster_id", BroadcasterId);
		request.Set("length", Length);
		return request;
	}
}
