using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// All optional parameters for TwitchAPI.GetDropsEntitlements 
/// </summary>
public partial class TwitchGetDropsEntitlementsOpt : Resource, ITwitcherSharp<TwitchGetDropsEntitlementsOpt>
{
    private GodotObject _data;
	public string[] Id { get; set; }
	public string UserId { get; set; }
	public string GameId { get; set; }
	public string FulfillmentStatus { get; set; }
	public string After { get; set; }
	public int First { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchGetDropsEntitlementsOpt object.
    /// </summary> 
    public static TwitchGetDropsEntitlementsOpt FromObject(GodotObject data)
    {
		return new TwitchGetDropsEntitlementsOpt
		{
			Id = data.Get("id").AsStringArray(),
			UserId = data.Get("user_id").AsString(),
			GameId = data.Get("game_id").AsString(),
			FulfillmentStatus = data.Get("fulfillment_status").AsString(),
			After = data.Get("after").AsString(),
			First = data.Get("first").AsInt32(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_get_drops_entitlements.gd");
		var optClass = script.Get("Opt").AsGodotObject();
		var request = optClass.Call("new").AsGodotObject();
		request.Set("id", Id);
		request.Set("user_id", UserId);
		request.Set("game_id", GameId);
		request.Set("fulfillment_status", FulfillmentStatus);
		request.Set("after", After);
		request.Set("first", First);
		return request;
	}
}
