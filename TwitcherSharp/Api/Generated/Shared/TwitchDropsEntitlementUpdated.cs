using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchDropsEntitlementUpdated : Resource, ITwitcherSharp<TwitchDropsEntitlementUpdated>
{
    private GodotObject _data;
	public string Status { get; set; }
	public string[] Ids { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchDropsEntitlementUpdated object.
    /// </summary> 
    public static TwitchDropsEntitlementUpdated FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchDropsEntitlementUpdated
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
