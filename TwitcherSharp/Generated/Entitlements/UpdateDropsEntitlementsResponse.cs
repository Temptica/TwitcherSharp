using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Entitlements;
 
/// <summary> 
///  
/// </summary>
public partial class UpdateDropsEntitlementsResponse : Resource, ITwitcherSharp<UpdateDropsEntitlementsResponse>
{
    private GodotObject _data;
	public DropsEntitlementUpdated[] Data { get; set; }
    /// <summary> 
    /// Transforms the godot data into a UpdateDropsEntitlementsResponse object.
    /// </summary> 
    public static UpdateDropsEntitlementsResponse FromObject(GodotObject data)
    {
        return new UpdateDropsEntitlementsResponse
        {

			Data = data.Get("data").As<DropsEntitlementUpdated[]>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_drops_entitlements_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		return request;
	}
}
