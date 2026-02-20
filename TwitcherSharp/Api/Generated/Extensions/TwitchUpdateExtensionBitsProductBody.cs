using TwitcherSharp.Interfaces;
using TwitcherSharp.Api.Generated.Shared;
using Godot;
   
namespace TwitcherSharp.Api.Generated.Extensions;

public partial class TwitchUpdateExtensionBitsProductBody : Resource, ITwitcherSharp<TwitchUpdateExtensionBitsProductBody>
{
    private GodotObject _data;
	public string Sku { get; set; }
	public TwitchCost Cost { get; set; }
	public string DisplayName { get; set; }
	public bool? InDevelopment { get; set; }
	public string Expiration { get; set; }
	public bool? IsBroadcast { get; set; }

    /// <summary> 
    /// Transforms the godot data into a TwitchUpdateExtensionBitsProductBody object.
    /// </summary> 
    public static TwitchUpdateExtensionBitsProductBody FromObject(GodotObject data)
    {
        if(data == null) return null;
		return new TwitchUpdateExtensionBitsProductBody
		{
			Sku = data.Get("sku").AsString(),
			Cost = data.Get("cost").As<TwitchCost>(),
			DisplayName = data.Get("display_name").AsString(),
			InDevelopment = data.Get("in_development").AsBool(),
			Expiration = data.Get("expiration").AsString(),
			IsBroadcast = data.Get("is_broadcast").AsBool(),
		};
	}

	public GodotObject ToGodotObject()
	{
		var script = GD.Load<GDScript>("res://addons/twitcher/generated/twitch_update_extension_bits_product.gd");
		var bodyClass = script.Get("Body").AsGodotObject();
		var request = bodyClass.Call("new").AsGodotObject();
		request.Set("sku", Sku);
		request.Set("cost", Cost);
		request.Set("display_name", DisplayName);
		if(InDevelopment.HasValue) request.Set("in_development", InDevelopment.Value);
		if(Expiration != null) request.Set("expiration", Expiration);
		if(IsBroadcast.HasValue) request.Set("is_broadcast", IsBroadcast.Value);
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
