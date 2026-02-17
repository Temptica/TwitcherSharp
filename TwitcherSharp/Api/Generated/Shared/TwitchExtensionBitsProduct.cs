using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Shared;

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
        if(data == null) return null;
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
	
	/// <summary> 
	/// An object that contains the product's cost information. 
	/// </summary>
	public partial class TwitchCost : Resource, ITwitcherSharp<TwitchCost>
	{
	    private GodotObject _data;
		public int Amount { get; set; }
		public string Type { get; set; }
	
	    /// <summary> 
	    /// Transforms the godot data into a TwitchCost object.
	    /// </summary> 
	    public static TwitchCost FromObject(GodotObject data)
	    {
	        if(data == null) return null;
			return new TwitchCost
			{
				Amount = data.Get("amount").AsInt32(),
				Type = data.Get("type").AsString(),
			};
		}
	
		public GodotObject ToGodotObject()
		{
			var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_cost.gd");
			var request = script.Call("new").AsGodotObject();
			request.Set("amount", Amount);
			request.Set("type", Type);
			return request;
		}
	
	}

}
