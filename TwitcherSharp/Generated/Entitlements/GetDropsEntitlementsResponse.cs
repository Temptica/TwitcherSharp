using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Entitlements;
 
/// <summary> 
///  
/// </summary>
public partial class GetDropsEntitlementsResponse : Resource, ITwitcherSharp<GetDropsEntitlementsResponse>
{
    private GodotObject _data;
	public DropsEntitlement[] Data { get; set; }
	public Pagination Pagination { get; set; }
    /// <summary> 
    /// Transforms the godot data into a GetDropsEntitlementsResponse object.
    /// </summary> 
    public static GetDropsEntitlementsResponse FromObject(GodotObject data)
    {
        return new GetDropsEntitlementsResponse
        {

			Data = data.Get("data").As<DropsEntitlement[]>(),
			Pagination = data.Get("pagination").As<Pagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_drops_entitlements_response.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("data", Data);
		request.Set("pagination", Pagination);
		return request;
	}
}
