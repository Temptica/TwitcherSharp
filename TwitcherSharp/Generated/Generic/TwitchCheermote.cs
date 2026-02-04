using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchCheermote : Resource, ITwitcherSharp<TwitchCheermote>
{
    private GodotObject _data;
	public string Prefix { get; set; }
	public TwitchTiers[] Tiers { get; set; }
	public string Type { get; set; }
	public int Order { get; set; }
	public string LastUpdated { get; set; }
	public bool IsCharitable { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchCheermote object.
    /// </summary> 
    public static TwitchCheermote FromObject(GodotObject data)
    {
		var tiersArray = data.Get("tiers").AsGodotArray<GodotObject>();
		return new TwitchCheermote
		{
			Prefix = data.Get("prefix").AsString(),
			Tiers = tiersArray.Select(TwitchTiers.FromObject).ToArray(),
			Type = data.Get("type").AsString(),
			Order = data.Get("order").AsInt32(),
			LastUpdated = data.Get("last_updated").AsString(),
			IsCharitable = data.Get("is_charitable").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cheermote.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("prefix", Prefix);
		request.Set("tiers", Tiers);
		request.Set("type", Type);
		request.Set("order", Order);
		request.Set("last_updated", LastUpdated);
		request.Set("is_charitable", IsCharitable);
		return request;
	}
}
