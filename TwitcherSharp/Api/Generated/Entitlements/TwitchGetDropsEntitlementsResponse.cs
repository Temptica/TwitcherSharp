using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Entitlements;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchGetDropsEntitlementsResponse : Resource, ITwitcherSharp<TwitchGetDropsEntitlementsResponse>
{
    private GodotObject _data;
	public TwitchDropsEntitlement[] Data { get; set; }
	public TwitchPagination Pagination { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchGetDropsEntitlementsResponse object.
    /// </summary> 
    public static TwitchGetDropsEntitlementsResponse FromObject(GodotObject data)
    {
        if(data == null) return null;
		var dataArray = data.Get("data").AsGodotArray<GodotObject>();
		return new TwitchGetDropsEntitlementsResponse
		{
			Data = dataArray.Select(TwitchDropsEntitlement.FromObject).ToArray(),
			Pagination = data.Get("pagination").As<TwitchPagination>(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_drops_entitlements.gd");
		var responseClass = script.Get("Response").AsGodotObject();
		var request = responseClass.Call("new").AsGodotObject();
		request.Set("data", Data);
		if(Pagination != null) request.Set("pagination", Pagination);
		return request;
	}
}
