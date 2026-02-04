using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
/// Contains details about the digital product. 
/// </summary>
public partial class TwitchProductData : Resource, ITwitcherSharp<TwitchProductData>
{
    private GodotObject _data;
	public string Sku { get; set; }
	public string Domain { get; set; }
	public TwitchCost Cost { get; set; }
	public bool InDevelopment { get; set; }
	public string DisplayName { get; set; }
	public string Expiration { get; set; }
	public bool Broadcast { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchProductData object.
    /// </summary> 
    public static TwitchProductData FromObject(GodotObject data)
    {
		return new TwitchProductData
		{
			Sku = data.Get("sku").AsString(),
			Domain = data.Get("domain").AsString(),
			Cost = data.Get("cost").As<TwitchCost>(),
			InDevelopment = data.Get("in_development").AsBool(),
			DisplayName = data.Get("display_name").AsString(),
			Expiration = data.Get("expiration").AsString(),
			Broadcast = data.Get("broadcast").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_product_data.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("sku", Sku);
		request.Set("domain", Domain);
		request.Set("cost", Cost);
		request.Set("in_development", InDevelopment);
		request.Set("display_name", DisplayName);
		request.Set("expiration", Expiration);
		request.Set("broadcast", Broadcast);
		return request;
	}
}
