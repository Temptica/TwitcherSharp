using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Entitlements;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateDropsEntitlementsBody : Resource, ITwitcherSharp<UpdateDropsEntitlementsBody>
{
    private GodotObject _data;
	public string[] EntitlementIds { get; set; }
	public string FulfillmentStatus { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateDropsEntitlementsBody object.
    /// </summary> 
    public static UpdateDropsEntitlementsBody FromObject(GodotObject data)
    {
        return new UpdateDropsEntitlementsBody
        {

			EntitlementIds = data.Get("entitlement_ids").AsStringArray(),
			FulfillmentStatus = data.Get("fulfillment_status").AsString(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_drops_entitlements_body.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("entitlement_ids", EntitlementIds);
		request.Set("fulfillment_status", FulfillmentStatus);
		return request;
	}
}
