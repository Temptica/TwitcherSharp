using TwitcherSharp.Interfaces;
using TwitcherSharp.Generated.Generic;
using Godot;
   
namespace TwitcherSharp.Generated.Generic;
 
/// <summary> 
///  
/// </summary>
public partial class TwitchExtensionBitsProduct : Resource, ITwitcherSharp<TwitchExtensionBitsProduct>
{
    private GodotObject _data;
	public string Sku { get; set; }
	public TwitchCost Cost { get; set; }
	public bool InDevelopment { get; set; }
	public string DisplayName { get; set; }
	public string Expiration { get; set; }
	public bool IsBroadcast { get; set; }
    /// <summary> 
    /// Transforms the godot data into a TwitchExtensionBitsProduct object.
    /// </summary> 
    public static TwitchExtensionBitsProduct FromObject(GodotObject data)
    {
		return new TwitchExtensionBitsProduct
		{
			Sku = data.Get("sku").AsString(),
			Cost = data.Get("cost").As<TwitchCost>(),
			InDevelopment = data.Get("in_development").AsBool(),
			DisplayName = data.Get("display_name").AsString(),
			Expiration = data.Get("expiration").AsString(),
			IsBroadcast = data.Get("is_broadcast").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_extension_bits_product.gd");
		var request = script.Call("new").AsGodotObject();
		request.Set("sku", Sku);
		request.Set("cost", Cost);
		request.Set("in_development", InDevelopment);
		request.Set("display_name", DisplayName);
		request.Set("expiration", Expiration);
		request.Set("is_broadcast", IsBroadcast);
		return request;
	}
}
