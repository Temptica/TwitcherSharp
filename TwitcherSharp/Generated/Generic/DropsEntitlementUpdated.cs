using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class DropsEntitlementUpdated : Resource, ITwitcherSharp<DropsEntitlementUpdated>
{
    private GodotObject _data;
	public string Status { get; set; }
	public string[] Ids { get; set; }
    /// <summary> 
    /// Transforms the godot data into a DropsEntitlementUpdated object.
    /// </summary> 
    public static DropsEntitlementUpdated FromObject(GodotObject data)
    {
        return new DropsEntitlementUpdated
        {

			Status = data.Get("status").AsString(),
			Ids = data.Get("ids").AsStringArray(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_drops_entitlement_updated.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("status", Status);
		request.Set("ids", Ids);
		return request;
	}
}
